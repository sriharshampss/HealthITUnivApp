using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class Program
	{
		public int ProgramID { get; set; }
		public string ProgramName { get; set; }
		public string ProgramType { get; set; }
		public string ProgramAbbrevation { get; set; }
		public string ProgramURL { get; set; }
		public string DepartmentName { get; set; }
		public string ProgramLeadDepartment { get; set; }
		public string ProgramHead { get; set; }
		public string Accredited { get; set; }
		public string Accredited_Type { get; set; }
		public Nullable<System.DateTime> Accredited_StartDate { get; set; }
		public Nullable<System.DateTime> Accredited_EndDate { get; set; }
	}
}