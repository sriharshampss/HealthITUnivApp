using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthITUnivApp
{
	public partial class Course
	{
        public Course()
        {
            CourseList = new List<SelectListItem>()
            {
               new SelectListItem { Value = "Core", Text = "Core" },
               new SelectListItem { Value = "Elective", Text = "Elective" },
               new SelectListItem { Value = "Optional", Text = "Optional" },
               new SelectListItem { Value = "Prereq", Text = "Prereq" },
               new SelectListItem { Value = "Other", Text = "Other" }
            };
        }

        public List<SelectListItem> CourseList { get; set; }

        [Key]
		public int CourseId { get; set; }
		public string CourseNumber { get; set; }
		public string CourseName { get; set; }
		public string CourseType { get; set; }
		public string ProgramName { get; set; }
		public string DepartmentName { get; set; }
		public string URL { get; set; }
        public string CourseDescription { get; set; }
    }
}