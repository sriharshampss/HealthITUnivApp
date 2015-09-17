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
    public class DepartmentsController : Controller
    {
        private HISYS001Entities11 db = new HISYS001Entities11();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;
              
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,DepartmentName,DepartmentAbbreviation,DepartmentURL,DepartmentStreet,DepartmentCity,DepartmentState,DepartmentCountry,DepartmentZipCode,DepartmentPhoneNo,DepartmentHead,CollegeName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;

            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,DepartmentName,DepartmentAbbreviation,DepartmentURL,DepartmentStreet,DepartmentCity,DepartmentState,DepartmentCountry,DepartmentZipCode,DepartmentPhoneNo,DepartmentHead,CollegeName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;

            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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
