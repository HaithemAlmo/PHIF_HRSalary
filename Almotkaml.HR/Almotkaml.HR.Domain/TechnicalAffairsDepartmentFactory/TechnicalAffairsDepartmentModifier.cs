using System;

namespace Almotkaml.HR.Domain.TechnicalAffairsDepartmentFactory
{
    public class TechnicalAffairsDepartmentModifier
    {
        internal TechnicalAffairsDepartmentModifier(TechnicalAffairsDepartment technicalAffairsDepartment)
        {
            TechnicalAffairsDepartment = technicalAffairsDepartment;
        }
        private TechnicalAffairsDepartment TechnicalAffairsDepartment { get; }

        public TechnicalAffairsDepartmentModifier EntrantsAndReviewersId(int entrantsAndReviewersId)
        {
            TechnicalAffairsDepartment.EntrantsAndReviewersId  = entrantsAndReviewersId;
            return this;
        }

        public TechnicalAffairsDepartmentModifier MonthWork(int monthWork)
        {
            TechnicalAffairsDepartment.MonthWork  = monthWork;
            return this;
        }

        public TechnicalAffairsDepartmentModifier YearWork(int yearWork)
        {
            TechnicalAffairsDepartment.YearWork  = yearWork;
            return this;
        }

        public TechnicalAffairsDepartmentModifier DataEntryCount(int dataEntryCount)
        {
            TechnicalAffairsDepartment.DataEntryCount  = dataEntryCount;
            return this;
        }

        public TechnicalAffairsDepartmentModifier DataEntryBalance(decimal  dataEntryBalance)
        {
            TechnicalAffairsDepartment.DataEntryBalance  = dataEntryBalance;
            return this;
        }

        public TechnicalAffairsDepartmentModifier FirstReviewCount(int firstReviewCount)
        {
            TechnicalAffairsDepartment.FirstReviewCount  = firstReviewCount;
            return this;
        }

        public TechnicalAffairsDepartmentModifier FirstReviewBalance(decimal firstReviewBalance)
        {
            TechnicalAffairsDepartment.FirstReviewBalance  = firstReviewBalance;
            return this;
        }

        public TechnicalAffairsDepartmentModifier AccommodationReviewCount(int accommodationReviewCount)
        {
            TechnicalAffairsDepartment.AccommodationReviewCount  = accommodationReviewCount;
            return this;
        }

        public TechnicalAffairsDepartmentModifier AccommodationReviewBalance(decimal accommodationReviewBalance)
        {
            TechnicalAffairsDepartment.AccommodationReviewBalance  = accommodationReviewBalance;
            return this;
        }

        public TechnicalAffairsDepartmentModifier ClincReviewCount(int clincReviewCount)
        {
            TechnicalAffairsDepartment.ClincReviewCount  = clincReviewCount;
            return this;
        }

        public TechnicalAffairsDepartmentModifier ClincReviewBalance(decimal clincReviewBalance)
        {
            TechnicalAffairsDepartment.ClincReviewBalance  = clincReviewBalance;
            return this;
        }

        public TechnicalAffairsDepartmentModifier TotalBalance(decimal totalBalance)
        {
            TechnicalAffairsDepartment.TotalBalance  = totalBalance;
            return this;
        }

        public TechnicalAffairsDepartmentModifier Note(string note)
        {
            TechnicalAffairsDepartment.Note = note;
            return this;
        }
        public TechnicalAffairsDepartmentModifier IsPaid(bool  IsPaid)
        {
            TechnicalAffairsDepartment.IsPaid  = IsPaid;
            return this;
        }
        //public AbsenceModifier EmployeeId(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    Absence.EmployeeId = employeeId;
        //    return this;
        //}

        //public AbsenceModifier Employee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    Absence.EmployeeId = employee.EmployeeId;
        //    Absence.Employee = employee;
        //    return this;
        //}
        public TechnicalAffairsDepartment Confirm()
        {
            return TechnicalAffairsDepartment;
        }
    }


}