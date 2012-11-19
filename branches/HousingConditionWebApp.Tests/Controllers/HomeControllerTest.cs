using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HousingConditionWebApp;
using HousingConditionWebApp.Controllers;

namespace HousingConditionWebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeIndexNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            // Redirects to HomeConditionController, Index Action so View Result of Home/Index is null.
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestHomeIndexRedirect()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as RedirectToRouteResult;

            // Assert
            // Redirects to HomeConditionController, Index Action.
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void TestAboutView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("About", result.ViewName);
        }
    }
}
