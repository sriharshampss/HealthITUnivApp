using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class Course
	{
		public int CourseID { get; set; }
		public string CourseNumber { get; set; }
		public string CourseName { get; set; }
		public string CourseType { get; set; }
		public string ProgramName { get; set; }
		public string DepartmentName { get; set; }
		public string URL { get; set; }
	}
}