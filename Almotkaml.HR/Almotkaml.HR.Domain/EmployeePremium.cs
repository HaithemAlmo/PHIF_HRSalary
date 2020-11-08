namespace Almotkaml.HR.Domain
{
    public class EmployeePremium
    {
        public static EmployeePremium New( Employee employee, Premium premium, decimal value,  int isadvance, ISAdvancePremmium isAdvancePremmium, IsTemporary IsTemporary, AdvancePayment advancePayment)
        {
            var employeePremium = new EmployeePremium()
            {AdvancePayment= advancePayment,
                Employee = employee,
                Premium = premium,
                Value = value,
                IsAdvansePremmium=isadvance,
                IsTemporary = IsTemporary,
                ISAdvancePremmium = isAdvancePremmium
                
            };

            return employeePremium;
        }
        public static EmployeePremium New( int employeeId, int premiumId, decimal value, int isadvance, IsTemporary IsTemporary, ISAdvancePremmium isAdvancePremmium)
        {
            var employeePremium = new EmployeePremium()
            {
                EmployeeId = employeeId,
                PremiumId = premiumId,
                IsAdvansePremmium = isadvance,
                Value = value,
            ISAdvancePremmium = isAdvancePremmium,
                IsTemporary = IsTemporary,
            };

            return employeePremium;
        }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PremiumId { get; set; }
        public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public int IsAdvansePremmium { get; set; }
        public AdvancePayment AdvancePayment { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        // public int SalaryId { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public Salary  Salary { get; set; }
        public void Modify(decimal value,int isadvance, ISAdvancePremmium isAdvancePremmium)
        {
            Value = value;
            IsAdvansePremmium = isadvance;
            ISAdvancePremmium = isAdvancePremmium;
        }
    }
}