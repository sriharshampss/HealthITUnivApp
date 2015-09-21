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
        private HISYS001Entities db = new HISYS001Entities();

        
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

        
        [HttpGet]
        public JsonResult getColleges(string univName)
        {
            if(String.IsNullOrEmpty(univName))
                return Json(db.Colleges.ToList<College>(), JsonRequestBehavior.AllowGet);

            List<College> colgs = db.Colleges.Where<College>(x => x.UniversityName.ToLower().Equals(univName.ToLower())).ToList<College>();
            return Json(colgs, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult getUnivs()
        {
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text=x.UniversityName,Value=x.UniversityName});
            }
            return Json(listItems, JsonRequestBehavior.AllowGet);
        }

        
        // GET: Departments/Create
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

        
        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,DepartmentAbbreviation,DepartmentURL,DepartmentStreet,DepartmentCity,DepartmentState,DepartmentCountry,DepartmentZipCode,DepartmentPhoneNo,DepartmentHead,CollegeName,UniversityName")] Department department)
        {
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;
            if (ModelState.IsValid)
            {

                var result  = (from c in db.Colleges
                              join d in db.Departments on
                              c.CollegeName equals d.CollegeName
                              where d.DepartmentName.Equals(department.DepartmentName)
                              select new {CollegeName = c.CollegeName }).ToList().Count();

                             
                if (result == 0)
                {
                    department.CollegeName = department.CollegeName.Replace("string:", "").Trim();
                    db.Departments.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("DepartmentName", "Department Name already exists in DB.");
                    return View(department);
                }
            }

           
            

            return View(department);
        }
        [HttpGet]
        
        public JsonResult getCollegeAndUniv(int? id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return null;
            }
            var result = (from c in db.Colleges
                          join d in db.Departments on
                          c.CollegeName equals d.CollegeName
                          where d.DepartmentName.Equals(department.DepartmentName)
                          select new { UniversityName = c.UniversityName,CollegeName = c.CollegeName }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
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
            department.CollegeName = department.CollegeName.Replace("string:", "").Trim();
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName,DepartmentAbbreviation,DepartmentURL,DepartmentStreet,DepartmentCity,DepartmentState,DepartmentCountry,DepartmentZipCode,DepartmentPhoneNo,DepartmentHead,CollegeName")] Department department)
        {
            List<College> colgs = db.Colleges.ToList<College>();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in colgs)
            {
                listItems.Add(new SelectListItem() { Text = x.CollegeName, Value = x.CollegeName });
            }

            ViewData["Colleges"] = listItems;

            if (ModelState.IsValid)
            {
                var result = (from c in db.Colleges
                              join d in db.Departments on
                              c.CollegeName equals d.CollegeName
                              where d.DepartmentName.Equals(department.DepartmentName)
                              select new { CollegeName = c.CollegeName }).ToList().Count();

                if (result == 0)
                {
                    department.CollegeName = department.CollegeName.Replace("string:", "").Trim();
                    db.Entry(department).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("DepartmentName", "Department Name already exists in DB.");
                    return View(department);
                }
            }
           
           
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
