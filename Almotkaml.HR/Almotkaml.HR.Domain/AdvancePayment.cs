using System;

namespace Almotkaml.HR.Domain
{
    public class AdvancePayment
    {
        public static AdvancePayment New( int employeeId, decimal value, decimal installmentValue
            , DateTime deductionDate, bool isInside, DateTime date,int id)
        {
            var advancePayment = new AdvancePayment()
            {
                PremiumId = id,

                EmployeeId = employeeId,
                Value = value,
                InstallmentValue = installmentValue,
                DeductionDate = deductionDate,
                IsInside = isInside,
                Date = date

            };

            return advancePayment;
        }
        public static AdvancePayment New(int employeeId, Employee employee, decimal value, decimal installmentValue, DateTime deductionDate
                            , bool isInside, DateTime date,int id )
        {
            var advancePayment = new AdvancePayment()
            {
                AllValue = value,
                PremiumId = id,
                EmployeeId = employeeId,
                Value = value,
                InstallmentValue = installmentValue,
                DeductionDate = deductionDate,
                IsInside = isInside,
                Date = date
            };

            return advancePayment;
        }
        public int AdvancePaymentId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PremiumId { get; set; }

        public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }

        public decimal InstallmentValue { get; set; }
        public bool IsInside { get; set; }
        public DateTime DeductionDate { get; set; } // تاريخ بدء الخصم
        public DateTime Date { get; set; } // تاريخ بدء الخصم
        public void Modify(decimal value, decimal installmentValue, DateTime deductionDate,
                    bool isInside, DateTime date,int id)
        {
            PremiumId = id;
            
            Value = value;
            InstallmentValue = installmentValue;
            DeductionDate = deductionDate;
            IsInside = isInside;
            Date = date;
        }

    }
}