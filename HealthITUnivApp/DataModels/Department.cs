using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class Department
	{

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter Department Name")]
		public string DepartmentName { get; set; }

		[Required(ErrorMessage = "Please enter Department Abbreviation")]
		public string DepartmentAbbreviation { get; set; }
		public string DepartmentURL { get; set; }
		public string DepartmentStreet { get; set; }
		public string DepartmentCity { get; set; }
		public string DepartmentState { get; set; }
		public string DepartmentCounty { get; set; }
		public string DepartmentZipCode { get; set; }
		public string DepartmentPhoneNo { get; set; }
		public string DepartmentHead { get; set; }

        [Required(ErrorMessage = "Please enter College Name")]
        public string CollegeName { get; set; }

        public string UniversityName { get; set; }
    }
}