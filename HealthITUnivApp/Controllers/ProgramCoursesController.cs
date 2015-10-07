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
    public class ProgramCoursesController : Controller
    {
        private HISYS001Entities db = new HISYS001Entities();

        // GET: ProgramCourses
        public ActionResult Index()
        {
            return View(db.ProgramCourses.ToList());
        }

        // GET: ProgramCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramCourse programCourse = db.ProgramCourses.Find(id);
            if (programCourse == null)
            {
                return HttpNotFound();
            }
            return View(programCourse);
        }

        // GET: ProgramCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCId,ProgramName,CourseName,CourseType,CollegeName")] ProgramCourse programCourse)
        {
            if (ModelState.IsValid)
            {
                db.ProgramCourses.Add(programCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programCourse);
        }

        // GET: ProgramCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramCourse programCourse = db.ProgramCourses.Find(id);
            if (programCourse == null)
            {
                return HttpNotFound();
            }
            return View(programCourse);
        }

        // POST: ProgramCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCId,ProgramName,CourseName,CourseType,CollegeName")] ProgramCourse programCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programCourse);
        }

        // GET: ProgramCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramCourse programCourse = db.ProgramCourses.Find(id);
            if (programCourse == null)
            {
                return HttpNotFound();
            }
            return View(programCourse);
        }

        // POST: ProgramCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramCourse programCourse = db.ProgramCourses.Find(id);
            db.ProgramCourses.Remove(programCourse);
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
