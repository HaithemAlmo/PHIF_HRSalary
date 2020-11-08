using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class DegreeModel
    {
        public int EmployeeId { get; set; }
        public IList<DegreeGridRow> DegreeGrid { get; set; } = new List<DegreeGridRow>();
        public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();
        public bool CanSubmit { get; set; }
      
    }

    public class DegreeGridRow
    {
        public int EmployeeId { get; set; }
        public string JobNumber { get; set; }
        public string ArabicFullName { get; set; }
        public string NationalNumber { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public int Boun { get; set; } // العلاوة
        public int Degree { get; set; } // درجة التوظيف
        public int DegreeNow { get; set; }
        public string DateDegreeNow { get; set; }
        public int MeritDegreeNow { get; set; }
        public string DateMeritDegreeNow { get; set; } // تاريخ استحقاق الدرجة
        public int MeritBoun { get; set; } // العلاوة المستحقة
        public int JobId { get; set; }
    }
}