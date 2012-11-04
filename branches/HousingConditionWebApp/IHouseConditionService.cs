using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Required to bring WebGet into scope.
using System.ServiceModel.Web;

namespace HousingConditionWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHouseConditionService" in both code and config file together.
    [ServiceContract]
    public interface IHouseConditionService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/")]
        decimal? GetTotalCosts();
    }
}
