using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthITUnivApp
{
	public partial class University
	{
		public int UniversityID { get; set; }

        [Display(Name = "University Name")]
        [Required(ErrorMessage = "Please enter UniversityName")]
		public string UniversityName { get; set; }

        [Display(Name = "University Abbreviation")]
        [Required(ErrorMessage = "Please enter University Abbreviation")]
		public string UniversityAbbreviation { get; set; }

        [Display(Name = "University URL")]
        public string UniversityURL { get; set; }

        [Display(Name = "Street")]
        public string UniversityStreet { get; set; }

        [Display(Name = "City")]
        public string UniversityCity { get; set; }

        [Display(Name = "State")]
        public string UniversityState { get; set; }

        [Display(Name = "Country")]
        public string UniversityCountry { get; set; }

        [Display(Name = "Zip Code")]
        public string UniversityZipCode { get; set; }

        [Display(Name = "Phone No")]
        public string UniversityPhoneNo { get; set; }

        [Display(Name = "University Head")]
        public string UniversityHead { get; set; }

        [Display(Name = "University System Name")]
        public string SystemName { get; set; }
	}
}