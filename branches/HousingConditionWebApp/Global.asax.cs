using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
// Required to bring WebServiceHostFactory into scope. Added reference via solution explorer.
using System.ServiceModel.Activation;

namespace HousingConditionWebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            // Added so REST call can be made without appending .svc
            // This is currently causing a problem so leaving commented out for now.
            // Works for REST client calls but messes up the HouseCondition controller. May have to separate projects.
            //WebServiceHostFactory factory = new WebServiceHostFactory();
            //RouteTable.Routes.Add(new ServiceRoute("HouseConditionService", factory, typeof(HouseConditionService)));
           
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}