using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HousingConditionWebApp;

namespace HousingConditionWebApp.Controllers
{ 
    public class HouseConditionController : Controller
    {
        private HouseConditionEntities db = new HouseConditionEntities();

        public ViewResult Index()
        {
            using (db)
            {
                // View names which are not declared explicitly, (i.e. View name is inferred from Action name), cannot be tested easily
                // so View names are explicitly declared in the return statements.
                return View("Index", db.Houses.ToList());
            }
        }

        public ViewResult Details(int id)
        {
            using (db)
            {
                House house = db.Houses.Single(h => h.ID == id);
                return View("Details", house);
            }
        }

        public ActionResult Create()
        {
            return View("Create");
        } 

        [HttpPost]
        public ActionResult Create(House house)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.Houses.AddObject(house);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("Create", house);
        }
        
        public ActionResult Edit(int id)
        {
            using (db)
            {
                House house = db.Houses.Single(h => h.ID == id);
                return View("Edit", house);
            }
        }

        [HttpPost]
        public ActionResult Edit(House house)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.Houses.Attach(house);
                    db.ObjectStateManager.ChangeObjectState(house, EntityState.Modified);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", house);
        }

        public ActionResult Delete(int id)
        {
            using (db)
            {
                House house = db.Houses.Single(h => h.ID == id);
                return View("Delete", house);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (db)
            {
                House house = db.Houses.Single(h => h.ID == id);
                db.Houses.DeleteObject(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}