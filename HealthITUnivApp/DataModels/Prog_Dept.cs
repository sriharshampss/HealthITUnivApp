using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthITUnivApp.DataModels
{
    public partial class Prog_Dept
    {
        public string DepartmentName { get; set; }
        public string ProgramName { get; set; }
        public string ProgramType { get; set; }
        public Nullable<System.DateTime> Program_StartDate { get; set; }
        public Nullable<System.DateTime> Program_EndDate { get; set; }
        public string Accredited { get; set; }
        public string Accredited_Type { get; set; }
        public Nullable<System.DateTime> Accredited_StartDate { get; set; }
        public Nullable<System.DateTime> Accredited_EndDate { get; set; }
    }
}
