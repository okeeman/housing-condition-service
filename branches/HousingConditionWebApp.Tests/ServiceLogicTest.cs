using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HousingConditionWebApp.Tests
{
    [TestClass]
    public class ServiceLogicTest
    {
        [TestMethod]
        public void TestGetTotalCosts()
        {
            //var db = new HouseConditionEntities();
            //// Hard-coding result is not ideal. Tests should be automated.
            //// The result of this test depends on the order of execution of the Controller tests as those tests
            //// insert and delete Houses into the database. Best to run this on its own at present. Could create
            //// an ordered test run in the test project.
            //decimal? actual = 388000M;
            //Assert.AreEqual(actual, db.Houses.Sum(row => row.Cost));
        }
    }
}
