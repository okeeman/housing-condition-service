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

        //
        // GET: /HouseCondition/

        public ViewResult Index()
        {
            return View(db.Houses.ToList());
        }

        //
        // GET: /HouseCondition/Details/5

        public ViewResult Details(int id)
        {
            House house = db.Houses.Single(h => h.ID == id);
            return View(house);
        }

        //
        // GET: /HouseCondition/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /HouseCondition/Create

        [HttpPost]
        public ActionResult Create(House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.AddObject(house);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(house);
        }
        
        //
        // GET: /HouseCondition/Edit/5
 
        public ActionResult Edit(int id)
        {
            House house = db.Houses.Single(h => h.ID == id);
            return View(house);
        }

        //
        // POST: /HouseCondition/Edit/5

        [HttpPost]
        public ActionResult Edit(House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Attach(house);
                db.ObjectStateManager.ChangeObjectState(house, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house);
        }

        //
        // GET: /HouseCondition/Delete/5
 
        public ActionResult Delete(int id)
        {
            House house = db.Houses.Single(h => h.ID == id);
            return View(house);
        }

        //
        // POST: /HouseCondition/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            House house = db.Houses.Single(h => h.ID == id);
            db.Houses.DeleteObject(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}