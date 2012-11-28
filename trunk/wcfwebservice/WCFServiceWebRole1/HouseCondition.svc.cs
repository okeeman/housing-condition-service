using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
// Required to bring the ASP.NET attribute into scope.
using System.ServiceModel.Activation;
// Required to bring HouseConditionEntities into scope.
using WCFServiceWebRole1.Model;

namespace WCFServiceWebRole1
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HouseCondition : IHouseCondition
    {
        public decimal? GetTotalCosts()
        {
            decimal? totalCost = 0;

            using (var db = new HouseConditionEntities())
            {
                totalCost = db.Houses.Sum(row => row.Cost);
            }

            return totalCost;
        }
    }
}
