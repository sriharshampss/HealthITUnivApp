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
    public class ProgramsController : Controller
    {
        private HISYS001Entities db = new HISYS001Entities();

        // GET: Programs
        
        public ActionResult Index()
        {
            return View(db.Programs.ToList());
        }

        // GET: Programs/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        
        public ActionResult Create()
        {
           
            return View(new Program());
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
        public JsonResult getCourses()
        {
            List<Course> univs = db.Courses.ToList<Course>();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var x in univs)
            {
                listItems.Add(new SelectListItem() { Text = x.CourseNumber+"--"+x.CourseName, Value = x.CourseName });
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
        
        public JsonResult getCollegeAndUniv(int ProgramId)
        {
            if (ProgramId == 0)
            {
                return null;
            }
            Program program = db.Programs.Find(ProgramId);
            var result = (from c in db.Colleges
                          join d in db.Departments
                          on c.CollegeName equals d.CollegeName
                          from cs in db.Colleges
                          join p in db.Programs
                          on cs.CollegeName equals p.CollegeName
                          where p.ProgramId == ProgramId
                          select new { UniversityName = c.UniversityName, CollegeName = c.CollegeName, ProgramName = p.ProgramName, ProgramLeadDepartment = p.ProgramLeadDepartment }).ToList();
                          

            return Json(result, JsonRequestBehavior.AllowGet);

        }


        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create(Program program)
        {
            if (ModelState.IsValid)
            {
                var result = (from c in db.Colleges
                              join d in db.Departments
                              on c.CollegeName equals d.CollegeName
                              from cs in db.Colleges
                              join p in db.Programs
                              on cs.CollegeName equals p.CollegeName
                              where p.ProgramName == program.ProgramName
                              & p.ProgramId != program.ProgramId
                              select new { ProgramName = program.ProgramName }).ToList().Count();

                if (result == 0)
                {
                    program.ProgramLeadDepartment = program.ProgramLeadDepartment.Replace("string:", "").Trim();
                    program.CollegeName = program.CollegeName.Replace("string:", "").Trim();
                    string[] coursesData = program.Courses.Split(';');
                    for(int i =0;i<coursesData.Length;i=i+4)
                    {
                        if((i+1)< coursesData.Length && (i+3) < coursesData.Length)
                        {
                            ProgramCourse pc = new ProgramCourse()
                            {
                                CollegeName = program.CollegeName,
                                CourseName = coursesData[i + 1],
                                CourseType = coursesData[i + 3],
                                ProgramName = program.ProgramName
                            };
                            db.ProgramCourses.Add(pc);
                        }                        
                    }

                    db.Programs.Add(program);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ProgramName", "Program Name already exists in DB.");
                    return View(program);
                }
            }
          
            return View(program);
        }

        // GET: Programs/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            List<ProgramCourse> pcList = db.ProgramCourses.Where<ProgramCourse>(x => x.ProgramName.Equals(program.ProgramName)).ToList<ProgramCourse>();
            string courseData = "";
            int i = 0;
            foreach (ProgramCourse p in pcList)
            {
                courseData += "cId" + i.ToString()+ ";" + p.PCId +";"+ "cName" + i.ToString() + ";" + p.CourseName + ";" + "courseType" + i.ToString() + ";" + p.CourseType + ";";
                i++;
            }
            program.Courses = courseData;
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Program program)
        {
            if (ModelState.IsValid)
            {
                program.ProgramLeadDepartment = program.ProgramLeadDepartment.Replace("string:", "").Trim();
                program.CollegeName = program.CollegeName.Replace("string:", "").Trim();
                string[] coursesData = program.Courses.Split(';');
                
                for (int i = 0; i < coursesData.Length; i = i + 6)
                {
                    if ((i + 3) < coursesData.Length && (i + 5) < coursesData.Length)
                    {
                        int cId;
                        var isNull = Int32.TryParse(coursesData[i + 1],out cId);
                        var cName = coursesData[i + 3];
                        var cType = coursesData[i + 5];

                        if(!isNull)
                        {
                            ProgramCourse pc = new ProgramCourse()
                            {
                                CollegeName = program.CollegeName,
                                CourseName = cName,
                                CourseType = cType,
                                ProgramName = program.ProgramName
                            };
                            db.ProgramCourses.Add(pc);

                        }
                        else
                        {
                            ProgramCourse pCourse = db.ProgramCourses.Where<ProgramCourse>(x => x.PCId.Equals(cId)).FirstOrDefault<ProgramCourse>();
                            pCourse.CourseName = cName;
                            pCourse.CourseType = cType;
                        }            
                                             
                    }
                }
                db.Entry(program).State = EntityState.Modified;                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        // GET: Programs/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.Programs.Find(id);
            db.Programs.Remove(program);
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
