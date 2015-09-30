
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class University
	{

        public int UniversityId { get; set; }

        [Required(ErrorMessage = "Please enter UniversityName")]
		public string UniversityName { get; set; }

		[Required(ErrorMessage = "Please enter University Abbreviation")]
		public string UniversityAbbreviation { get; set; }
		public string UniversityURL { get; set; }
		public string UniversityStreet { get; set; }
		public string UniversityCity { get; set; }
		public string UniversityState { get; set; }
		public string UniversityCounty { get; set; }
		public string UniversityZipCode { get; set; }
		public string UniversityPhoneNo { get; set; }
		public string UniversityHead { get; set; }
		public string SystemName { get; set; }
	}

}