﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthITUnivApp;

namespace HealthITUnivApp.Controllers
{
    public class EducationSystemsController : Controller
    {
        private HISYS001Entities db = new HISYS001Entities();

        
        // GET: EducationSystems
        public ActionResult Index()
        {
            return View(db.EducationSystems.ToList());
        }

        
        // GET: EducationSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSystem educationSystem = db.EducationSystems.Find(id);
            if (educationSystem == null)
            {
                return HttpNotFound();
            }
            return View(educationSystem);
        }

        
        // GET: EducationSystems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create( EducationSystem educationSystem)
        {
            if (ModelState.IsValid)
            {
                var count = db.EducationSystems.Select(a => a.SystemName.ToLower().Equals(educationSystem.SystemName.ToLower())
                                                        & a.SystemId != educationSystem.SystemId).Count();

                if(count == 0)
                {
                    db.EducationSystems.Add(educationSystem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("SystemName", "System Name already exists in DB.");                    
                    return View(educationSystem);
                }     
            }
            return View(educationSystem);
        }

        
        // GET: EducationSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSystem educationSystem = db.EducationSystems.Find(id);
            if (educationSystem == null)
            {
               return HttpNotFound();
            }
            return View(educationSystem);
        }

        
        // POST: EducationSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EducationSystem educationSystem)
        {
            if (ModelState.IsValid)
            {
                var count = db.EducationSystems.Where<EducationSystem>(a => (a.SystemName.ToLower().Equals(educationSystem.SystemName.ToLower())
                                                             & a.SystemId != educationSystem.SystemId)).Count();

                if(count == 0)
                {
                    db.Entry(educationSystem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("SystemName", "System Name already exists in DB.");
                    return View(educationSystem);
                }

            }
            return View(educationSystem);
        }

        
        // GET: EducationSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationSystem educationSystem = db.EducationSystems.Find(id);
            if (educationSystem == null)
            {
                return HttpNotFound();
            }
            return View(educationSystem);
        }

        
        // POST: EducationSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationSystem educationSystem = db.EducationSystems.Find(id);
            db.EducationSystems.Remove(educationSystem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
