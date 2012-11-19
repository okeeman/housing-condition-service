using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Added to bring HouseConditionController into scope.
using HousingConditionWebApp.Controllers;
// Added to bring ViewResult into scope.
using System.Web.Mvc;

namespace HousingConditionWebApp.Tests.Controllers
{
    // These tests are actually Integration tests rather than Unit tests as they do not isolate the database from the tests.
    [TestClass]
    public class HouseConditionControllerTest
    {
        House h1, h2, h3, h4, h5;
        HouseConditionController controller = new HouseConditionController();
        // Instantiating the HouseConditionController opens up a database connection but it is private field so it cannot be accessed in the test class.
        HouseConditionEntities db = new HouseConditionEntities();

        [TestMethod]
        public void TestIndexView()
        {
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsReturnCorrectData()
        {
            var result = controller.Details(2) as ViewResult;
            House test = (House)result.Model;
            Assert.AreEqual("112 Beacon Street", test.Address);
        }

        [TestMethod]
        public void TestCreateView()
        {
            var result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateRedirectIfModelValid()
        {
            h3 = new House();
            h3.Address = "987 YourStreet";
            h3.Repairs = true;
            h3.Cost = 10000M;

            // Inserts House h3 into the database.
            var result = controller.Create(h3) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Cleanup database after test by deleting the House placed in it during the Create Action test.
            // Trying to delete House h3 using db.Houses.Delete(h3) will not work as h3 is 
            // not in the data-set which has been loaded from the database when db was instantiated.
            // A new query is required to get an up-to-date view of the database.
            using (db)
            {
                House toDelete = db.Houses.Single(h => h.Address == "987 YourStreet"); 
                db.Houses.DeleteObject(toDelete);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestCreateRedisplayCreateViewIfModelInvalid()
        {
            h4 = new House();
            h4.Address = "Will Not Enter Database";
            h4.Repairs = true;
            h4.Cost = 15000M;

            // The Create Action will attempt to put this house into the database but it will fail as a Model Error has been added.
            controller.ModelState.AddModelError("An error", "Error message");
            var result = controller.Create(h4) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateActionHouseNotAddedToDatabaseIfModelInvalid()
        {
            h4 = new House();
            h4.Address = "Will Not Enter Database";
            h4.Repairs = true;
            h4.Cost = 15000M;

            // The Create Action will attempt to put this house into the database but it will fail as a Model Error has been added.
            controller.ModelState.AddModelError("An error", "Error message");
            var result = controller.Create(h4) as ViewResult;

            int count = db.Houses.Count(row => row.Address == "Will Not Enter Database");
            Assert.AreEqual(0, count);
        }


        [TestMethod]
        public void TestEditView()
        {
            // Retrieves details of the House with ID = 2.
            var result = controller.Edit(2) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void TestEditRedirectIfModelValid()
        {
            // Put a test House in the database, retrieve it and edit it, then save it back to the database.
            // When the test has finished remove the House from the database.
            h5 = new House();
            h5.Address = "Test Edit redirect";
            h5.Repairs = true;
            h5.Cost = 10000M;

            House toFind;

            using (db)
            {
                db.Houses.AddObject(h5);
                db.SaveChanges();

                toFind = db.Houses.Single(h => h.Address == "Test Edit redirect");
                toFind.Address = "Test Edit redirect Address changed";
                // The entity must be detached from the db context in this class so that it may be attached to the context 
                // in the controller class when the Edit Action is called.
                db.Detach(toFind);
            
                var result = controller.Edit(toFind) as RedirectToRouteResult;
                // Redirects to the Index Action following a successful edit, i.e. Model has changed and is valid.
                Assert.AreEqual("Index", result.RouteValues["action"]);

                // Reattach the entity to the db context in the test class.
                toFind = db.Houses.Single(h => h.Address == "Test Edit redirect Address changed");
                db.Houses.DeleteObject(toFind);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestEditRedisplayEditViewIfModelInvalid()
        {
            controller.ModelState.AddModelError("An error", "Error message");
            var result = controller.Edit(h1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            // Doesn't actually delete House, only returns Delete View as expected.
            var result = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestDeleteConfirmedRedirectsToIndexAction()
        {
            h1 = new House();
            h1.Address = "123 AnyStreet";
            h1.Repairs = true;
            h1.Cost = 50000M;

            House toDelete;

            using (db)
            {
                // Save test House to database.
                db.Houses.AddObject(h1);
                db.SaveChanges();
                // Retrieve test House to test the DeleteConfirmed Action.
                toDelete = db.Houses.Single(h => h.Address == "123 AnyStreet"); 
            }
            
            // Test redirect to Index Action after successful removal of House h1 from database.
            var result = controller.DeleteConfirmed(toDelete.ID) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestDeleteConfirmedRemovesHouseFromDatabase()
        {
            h2 = new House();
            h2.Address = "22 TestStreet";
            h2.Repairs = false;
            h2.Cost = 0M;

            House toDelete;

            using (db)
            {
                // Add House h2 to the database in order to test the DeleteConfirmed Action.
                db.Houses.AddObject(h2);
                db.SaveChanges();
                toDelete = db.Houses.Single(h => h.Address == "22 TestStreet");
                var result = controller.DeleteConfirmed(toDelete.ID) as RedirectToRouteResult;
                int count = db.Houses.Count(row => row.Address == "22 TestStreet");
                // Check that House h2 has been deleted from the database.
                Assert.AreEqual(0, count);
            }
        }

        //[ExpectedException ]
    }
}
