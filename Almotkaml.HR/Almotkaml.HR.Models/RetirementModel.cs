using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class RetirementModel
    {
        public int EmployeeId { get; set; }
        public IEnumerable<RetirementGridRow> RetirementGrid { get; set; } = new HashSet<RetirementGridRow>();
        public bool CanSubmit { get; set; }
    }

    public class RetirementGridRow
    {
        public int EmployeeId { get; set; }
        public string ArabicFullName { get; set; }
        public string JobNumber { get; set; }
        public string NationalNumber { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string CenterName { get; set; }
    }
}