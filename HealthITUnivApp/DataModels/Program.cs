using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthITUnivApp
{
	public partial class Program
	{
        public Program()
        {
            ProgramList = new List<SelectListItem>()
            {
               new SelectListItem { Value = "Bachelor", Text = "Bachelor" },
               new SelectListItem { Value = "Associate", Text = "Associate" },
               new SelectListItem { Value = "Masters", Text = "Masters" },
               new SelectListItem { Value = "PhD", Text = "PhD" },
               new SelectListItem { Value = "Certification", Text = "Certification" },
               new SelectListItem { Value = "Doctorate", Text = "Doctorate" },
               new SelectListItem { Value = "CE", Text = "CE" },
               new SelectListItem { Value = "OTHER", Text = "OTHER" }

            };
        }

        public List<System.Web.Mvc.SelectListItem> ProgramList { get; set; }       
        

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