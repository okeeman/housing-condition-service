using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
// ASP.NET development server.
//using HouseConditionClient.ServiceReference1;
// Azure emulator.
using HouseConditionClient.ServiceReference2;
// Required to bring WebGet and WebChannelFactory into scope.
using System.ServiceModel.Web;

namespace HouseConditionClient
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
                using (HouseConditionServiceClient c = new HouseConditionServiceClient())
                {
                    Console.WriteLine("Total repair costs (SOAP): {0:C}", c.GetTotalCosts());
                }

                //WebChannelFactory<IHouseConditionService> cf = new WebChannelFactory<IHouseConditionService>(new Uri("http://localhost:52109/HouseConditionService.svc/pox"));
                // Note: change routes in global.asax so don't have to append .svc
                WebChannelFactory<IHouseConditionService> cf = new WebChannelFactory<IHouseConditionService>(new Uri("http://127.0.0.1:81/houseconditionservice.svc/pox"));
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
