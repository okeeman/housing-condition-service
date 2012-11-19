using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Added reference via solution explorer.
using System.ServiceModel.Web;
// Required to bring the ASP.NET attribute into scope.
using System.ServiceModel.Activation;
// Required to bring HttpResponseHeader into scope. non-generic only, what is needed for generics?
using System.Net;

namespace HousingConditionWebApp
{ 
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HouseConditionService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HouseConditionService : IHouseConditionService
    {
        // Had to make the return type nullable.
        public decimal? GetTotalCosts()
        {
            decimal? totalCost = 0;

            using (var db = new HouseConditionEntities())
            {
                totalCost = db.Houses.Sum(row => row.Cost);
            }

            //var result = new HttpResponseHeader<House>();

            return totalCost;
        }
    }
}
