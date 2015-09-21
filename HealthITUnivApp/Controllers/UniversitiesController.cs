using System;
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
    public partial class UniversitiesController : Controller
    {
        private HISYS001Entities db = new HISYS001Entities();

        // GET: Universities
        
        public ActionResult Index()
        {
            return View(db.Universities.ToList());
        }

        // GET: Universities/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: Universities/Create
        
        public ActionResult Create()
        {
            List<EducationSystem> systems = db.EducationSystems.ToList<EducationSystem>();            
            List<SelectListItem> listItems = new List<SelectListItem>();
                     
            foreach(var x in systems)
            {
                listItems.Add(new SelectListItem() { Text=x.SystemName, Value=x.SystemName});
            }
            if (listItems.Count > 0)
            {
                ViewData["Systems"] = listItems;
                // ViewBag.Systems = systemNames;
            }

            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "UniversityId,UniversityName,UniversityAbbreviation,UniversityURL,UniversityStreet,UniversityCity,UniversityState,UniversityCountry,UniversityZipCode,UniversityPhoneNo,UniversityHead,SystemName")] University university)
        {
            List<EducationSystem> systems = db.EducationSystems.ToList<EducationSystem>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in systems)
            {
                listItems.Add(new SelectListItem() { Text = x.SystemName, Value = x.SystemName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Systems"] = listItems;
                // ViewBag.Systems = systemNames;
            }

            if (ModelState.IsValid)
            {
                var count = db.Universities.Select(a => a.UniversityName.ToLower().Equals(university.UniversityName.ToLower())).Count();

                if (count == 0)
                {
                    db.Universities.Add(university);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("UniversityName", "University Name already exists in DB.");
                    return View(university);
                }
              
            }
           

            return View(university);
        }

        
        // GET: Universities/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            List<EducationSystem> systems = db.EducationSystems.ToList<EducationSystem>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in systems)
            {
                listItems.Add(new SelectListItem() { Text = x.SystemName, Value = x.SystemName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Systems"] = listItems;
                // ViewBag.Systems = systemNames;
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniversityId,UniversityName,UniversityAbbreviation,UniversityURL,UniversityStreet,UniversityCity,UniversityState,UniversityCountry,UniversityZipCode,UniversityPhoneNo,UniversityHead,SystemName")] University university)
        {
            List<EducationSystem> systems = db.EducationSystems.ToList<EducationSystem>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in systems)
            {
                listItems.Add(new SelectListItem() { Text = x.SystemName, Value = x.SystemName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Systems"] = listItems;
                // ViewBag.Systems = systemNames;
            }
            if (ModelState.IsValid)
            {
                var count = db.Universities.Select(a => a.UniversityName.ToLower().Equals(university.UniversityName.ToLower())).Count();

                if (count == 0)
                {
                    db.Entry(university).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("UniversityName", "University Name already exists in DB.");
                    return View(university);
                }

            }
           
            return View(university);
        }

        
        // GET: Universities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        
        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            University university = db.Universities.Find(id);
            db.Universities.Remove(university);
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
