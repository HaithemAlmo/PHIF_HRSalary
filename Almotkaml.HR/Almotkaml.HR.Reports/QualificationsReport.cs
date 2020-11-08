using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Reports
{
    public class QualificationsReport
    {
        public string JobNumber { get; set; }
        public string NationalityNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Qualification { get; set; }//
        public string Specialty { get; set; }  //التخصص الأساسي
        public string SubSpecialty { get; set; }  //التخصص الفرعي
        public string ExactSpecialty { get; set; }  //التخصص الدقيق
        public string AquiredSpecialty { get; set; }  //التخصص المكتسب
    }
}
