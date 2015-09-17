<<<<<<< HEAD
﻿using System;
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

        
        [Display(Name = "System Name")]
		[Required(ErrorMessage = "Please enter Education System Name")]
		public string SystemName { get; set; }

        [Display(Name = "System Abbreviation")]
        [Required(ErrorMessage = "Please enter Education System Abbreviation")]
		public string SystemAbbreviation { get; set; }

        [Display(Name = "System URL")]
        public string SystemURL { get; set; }

        [Display(Name = "System Street")]
        public string SystemStreet { get; set; }

        [Display(Name = "System City")]
        public string SystemCity { get; set; }

        [Display(Name = "System State")]
        public string SystemState { get; set; }

        [Display(Name = "System Country")]
        public string SystemCountry { get; set; }

        [Display(Name = "System Zip Code")]
        public string SystemZipCode { get; set; }

        [Display(Name = "System Phone No")]
        public string SystemPhoneNo { get; set; }

        [Display(Name = "System Head Person")]
        public string SystemHeadPerson { get; set; }
	}
=======
﻿using System;
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
>>>>>>> 79fc1229683e1d85d5bf629778b96aa1c25e9e70
}