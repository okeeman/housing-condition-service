using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Added to bring HouseCondition into scope.
using WCFServiceWebRole1;

namespace WebServiceTests
{
    [TestClass]
    public class WebServiceIntegrationTest
    {
        [TestMethod]
        public void TestGetTotalCosts()
        {
            // Hard-coding result is not ideal. Tests should be automated. There is no logic to test in the method anyway.
            // It is only testing the framework; which is unnecessary.
            decimal? actual = 430743M;
            HouseCondition s = new HouseCondition();
            Assert.AreEqual(actual, s.GetTotalCosts());
        }
    }
}
