using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Web Service.
using HouseConditionConsoleClient.HouseCondition;
// Required to bring WebGet and WebChannelFactory into scope. Must change from default .NET Client Framework 4 to .NET Framework 4 and add reference to System.ServiceModel.Web.
using System.ServiceModel.Web;
// Required to bring ServiceContract and OperationContract into scope.
using System.ServiceModel;

namespace HouseConditionConsoleClient
{
    [ServiceContract]
    public interface IHouseConditionService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/")]
        decimal? GetTotalCosts();
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (HouseConditionClient c = new HouseConditionClient())
                {
                    Console.WriteLine("Total repair costs (SOAP): {0:C}", c.GetTotalCosts());
                }

                // Don't have to append .svc extension.
                WebChannelFactory<IHouseConditionService> cf = new WebChannelFactory<IHouseConditionService>(new Uri("http://housingcondition.cloudapp.net/HouseCondition/pox"));
                IHouseConditionService channel = cf.CreateChannel();
                Console.WriteLine("Total repair costs (REST): {0:C}", channel.GetTotalCosts());
            }
            catch (TimeoutException te)
            {
                Console.WriteLine(te.Message);
            }
            catch (FaultException fEx)
            {
                Console.WriteLine("This is a FaultException:\n" + fEx.Message);
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
