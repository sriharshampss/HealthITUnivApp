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
    public class CoursesController : Controller
    {
        private HISYS001Entities db = new HISYS001Entities();

        // GET: Courses
        
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpGet]
        
        public JsonResult getUnivs()
        {
            List<University> univs = db.Universities.ToList<University>();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.UniversityName, Value = x.UniversityName });
            }
            return Json(listItems, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        
        public JsonResult getColleges(string univName)
        {
            if (String.IsNullOrEmpty(univName))
                return Json(db.Colleges.ToList<College>(), JsonRequestBehavior.AllowGet);

            List<College> colgs = db.Colleges.Where<College>(x => x.UniversityName.ToLower().Equals(univName.ToLower())).ToList<College>();
            return Json(colgs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        
        public JsonResult getDepartments(string collegeName)
        {
            if (String.IsNullOrEmpty(collegeName))
                return Json(db.Departments.ToList<Department>(), JsonRequestBehavior.AllowGet);

            List<Department> depts = db.Departments.Where<Department>(x => x.CollegeName.ToLower().Equals(collegeName.ToLower())).ToList<Department>();
            return Json(depts, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        
        public JsonResult getPrograms(string departmentName)
        {
            if (String.IsNullOrEmpty(departmentName))
                return Json(db.Programs.ToList<Program>(), JsonRequestBehavior.AllowGet);

            List<Program> depts = db.Programs.Where<Program>(x => x.ProgramLeadDepartment.ToLower().Equals(departmentName.ToLower())).ToList<Program>();
            return Json(depts, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        
        public JsonResult getCollegeAndUniv(int CourseId)
        {
            if (CourseId == 0)
            {
                return null;
            }
            Course course = db.Courses.Find(CourseId);
            var result = (from c in db.Colleges
                          join d in db.Departments
                          on c.CollegeName equals d.CollegeName
                          from cs in db.Colleges
                          join p in db.Programs
                          on cs.CollegeName equals p.CollegeName
                          from p1 in db.Programs
                          join crs in db.Courses
                          on p1.ProgramName equals crs.ProgramName
                          where crs.CourseId == CourseId
                          select new { UniversityName = c.UniversityName, CollegeName = c.CollegeName, ProgramName = p.ProgramName,
                              ProgramLeadDepartment = p.ProgramLeadDepartment,
                              CourseName = crs.CourseName}).ToList();


            return Json(result, JsonRequestBehavior.AllowGet);

        }


        // GET: Courses/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            

            if (ModelState.IsValid)
            {
                var result = (from c in db.Colleges
                             join d in db.Departments
                             on c.CollegeName equals d.CollegeName
                             from cs in db.Colleges
                             join p in db.Programs
                             on cs.CollegeName equals p.CollegeName
                             from ps in db.Programs
                             join cr in db.Courses
                             on ps.ProgramName equals cr.ProgramName
                             where cr.CourseNumber == course.CourseNumber
                              select new { CourseName = course.CourseName}).ToList().Count();

                if (result == 0)
                {
                    course.DepartmentName = course.DepartmentName.Replace("string:", "").Trim();
                    course.ProgramName = course.ProgramName.Replace("string:", "").Trim();
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("CourseNumber", "Course Number already exists in DB.");
                    return View(course);
                }
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseNumber,CourseName,CourseType,ProgramName,DepartmentName,URL")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
