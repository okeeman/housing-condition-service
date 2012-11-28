using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseRepairMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Redirects to the HouseConditionController, Index Action.
            return RedirectToAction("Index", "HouseCondition");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
