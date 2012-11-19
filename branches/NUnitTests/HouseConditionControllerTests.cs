using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Added to bring TestFixture into scope.
using NUnit.Framework;
// Added to bring HouseConditionController into scope.
using HousingConditionWebApp.Controllers;
// Added to bring HouseConditionController into scope.
using HousingConditionWebApp.Models;
// Added to bring House into scope.
using HousingConditionWebApp;

namespace NUnitTests
{
    [TestFixture]
    public class HouseConditionControllerIndexTests : IDbContext
    {
        IQueryable<House> Houses
        {
            get
            {
                House h1 = new House();
                h1.ID = 1000;
                h1.Address = "123 AnyStreet";
                h1.Repairs = true;
                h1.Cost = 50000M;

                House h2 = new House();
                h2.ID = 1000;
                h2.Address = "987 YourStreet";
                h2.Repairs = false;
                h2.Cost = 0M;

                List<House> list = new List<House>();
                list.Add(h1);
                list.Add(h2);
                var queryable = list.AsQueryable<House>();
                
                return queryable;
            }
        }

        [Test]
        public void Test1()
        {
            var controller = new HouseConditionController(Houses);
        }
    }
}
