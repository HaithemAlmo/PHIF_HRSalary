using System;

namespace Almotkaml.HR.Domain
{
    public class SalaryPremium
    {
        public static SalaryPremium New(Salary salary, Premium premium, DateTime MonthDate, decimal value, int isadvance, ISAdvancePremmium isAdvancePremmium, AdvancePayment advancePayment,IsTemporary IsTemporary,IsSubject IsSubject)
        {
            var employeePremium = new SalaryPremium()
            {
                MonthDate = MonthDate,
                Salary =salary,
                Premium = premium,
                Value = value,
               IsTemporary=IsTemporary,
               IsSubject=IsSubject,
                IsAdvansePremmium=isAdvancePremmium,
                advancePayment=advancePayment
            };

            return employeePremium;
        }
        public static SalaryPremium New(long salaryId,  DateTime MonthDate,int premiumId, decimal value, int isadvance, AdvancePayment AdvancePayment)
        {
            var employeePremium = new SalaryPremium()
            {
            
                MonthDate = MonthDate,
                SalaryId = salaryId,
                PremiumId = premiumId,
               
                Value = value,
                advancePayment = AdvancePayment

            };

            return employeePremium;
        }
        public DateTime MonthDate { get; set; }
        public long SalaryId { get; set; }
        public Salary Salary { get; set; }
       // public int EmployeeId { get; set; }
       //public Employee Employee { get; set; }
        public int PremiumId { get; set; }
        public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public AdvancePayment advancePayment { get; set; }
        public ISAdvancePremmium IsAdvansePremmium { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsSubject IsSubject { get; set; }
        public void Modify(decimal value)
        {
            Value = value;
        }

        
    }
}