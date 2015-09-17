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
    public class CollegesController : Controller
    {         
        private HISYS001Entities11 db = new HISYS001Entities11();

        // GET: Colleges
        public ActionResult Index()
        {
            return View(db.Colleges.ToList());
        }

        // GET: Colleges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: Colleges/Create
        public ActionResult Create()
        {
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.UniversityName, Value = x.UniversityName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Universities"] = listItems;
                // ViewBag.Systems = systemNames;
            }
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollegeID,CollegeName,CollegeAbbrevation,CollegeURL,CollegeStreet,CollegeCity,CollegeState,CollegeCountry,CollegeZipCode,CollegePhoneNo,CollegeHead,UniversityName")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Colleges.Add(college);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.UniversityName, Value = x.UniversityName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Universities"] = listItems;
                // ViewBag.Systems = systemNames;
            }

            return View(college);
        }

        // GET: Colleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.UniversityName, Value = x.UniversityName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Universities"] = listItems;
                // ViewBag.Systems = systemNames;
            }
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollegeID,CollegeName,CollegeAbbrevation,CollegeURL,CollegeStreet,CollegeCity,CollegeState,CollegeCountry,CollegeZipCode,CollegePhoneNo,CollegeHead,UniversityName")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.UniversityName, Value = x.UniversityName });
            }
            if (listItems.Count > 0)
            {
                ViewData["Universities"] = listItems;
                // ViewBag.Systems = systemNames;
            }
            return View(college);
        }

        // GET: Colleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            College college = db.Colleges.Find(id);
            db.Colleges.Remove(college);
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
