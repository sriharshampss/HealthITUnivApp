﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class College
	{
		public int CollegeID { get; set; }

		[Required(ErrorMessage = "Please enter College Name")]
		public string CollegeName { get; set; }

		[Required(ErrorMessage = "Please enter College Abbreviation")]
		public string CollegeAbbrevation { get; set; }
		public string CollegeURL { get; set; }
		public string CollegeStreet { get; set; }
		public string CollegeCity { get; set; }
		public string CollegeState { get; set; }
		public string CollegeCountry { get; set; }
		public string CollegeZipCode { get; set; }
		public string CollegePhoneNo { get; set; }
		public string CollegeHead { get; set; }
		public string UniversityName { get; set; }
	}
}