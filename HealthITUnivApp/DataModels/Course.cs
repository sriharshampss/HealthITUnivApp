using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class Course
	{
        [Key]
		public int CourseId { get; set; }
		public string CourseNumber { get; set; }
		public string CourseName { get; set; }
		public string CourseType { get; set; }
		public string ProgramName { get; set; }
		public string DepartmentName { get; set; }
		public string URL { get; set; }
	}
}