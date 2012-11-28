using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Added to bring HouseCondition into scope.
using WCFServiceWebRole1;

namespace ServiceTests
{
    [TestClass]
    public class ServiceIntegrationTest
    {
        
        [TestMethod]
        public void TestGetTotalCosts()
        {
            // Hard-coding result is not ideal. Tests should be automated.
            // There is no logic to test in any case. This is only testing the framework and the connection to the database.
            decimal? actual = 261505M;
            HouseCondition s = new HouseCondition();
            Assert.AreEqual(actual, s.GetTotalCosts());
        }
        
    }
}
