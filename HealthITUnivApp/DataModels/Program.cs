using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class Program
	{
        public int ProgramId { get; set; }

        [Required(ErrorMessage = "Please enter Program Name")]
        public string ProgramName { get; set; }
        [Required(ErrorMessage = "Please enter Program Type")]
        public string ProgramType { get; set; }
		public string ProgramAbbrevation { get; set; }
		public string ProgramURL { get; set; }
        [Display(Name = "Assosciated departments")]
		public string DepartmentName { get; set; }
        [Display(Name ="Program Main Department")]
        [Required(ErrorMessage = "Please enter Program Main Department")]
        public string ProgramLeadDepartment { get; set; }
		public string ProgramHead { get; set; }
		public string Accredited { get; set; }
		public string Accredited_Type { get; set; }
		public Nullable<System.DateTime> Accredited_StartDate { get; set; }
		public Nullable<System.DateTime> Accredited_EndDate { get; set; }
       
        public Nullable<System.DateTime> Program_StartDate { get; set; }
        public Nullable<System.DateTime> Program_EndDate { get; set; }
       
        [Required(ErrorMessage ="Please enter college name")]
        public string CollegeName { get; set; }
    }

}