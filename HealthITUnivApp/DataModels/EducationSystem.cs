using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HealthITUnivApp;

namespace HealthITUnivApp
{
	public partial class EducationSystem
	{
		public int SystemID { get; set; }

		[Required(ErrorMessage = "Please enter Education System Name")]
		public string SystemName { get; set; }

		[Required(ErrorMessage = "Please enter Education System Abbreviation")]
		public string SystemAbbreviation { get; set; }
		public string SystemURL { get; set; }
		public string SystemStreet { get; set; }
		public string SystemCity { get; set; }
		public string SystemState { get; set; }
		public string SystemCountry { get; set; }
		public string SystemZipCode { get; set; }
		public string SystemPhoneNo { get; set; }
		public string SystemHeadPerson { get; set; }
	}
}