using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class BounsModel
    {
        public int EmployeeId { get; set; }
        public IEnumerable<BounsGridRow> BounsGrid { get; set; } = new HashSet<BounsGridRow>();
        public bool CanSubmit { get; set; }
    }

    public class BounsGridRow
    {
        public int EmployeeId { get; set; }
        public string JobNumber { get; set; }
        public string ArabicFullName { get; set; }
        public string NationalNumber { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public int Boun { get; set; } // العلاوات
        public int Bounhr { get; set; }
        public int MeritBoun { get; set; } // العلاوة المستحقة
        public string DateMeritBoun { get; set; } // تاريخ استحقاق العلاوة
        public string DateMeritBounhr { get; set; }
    }
}