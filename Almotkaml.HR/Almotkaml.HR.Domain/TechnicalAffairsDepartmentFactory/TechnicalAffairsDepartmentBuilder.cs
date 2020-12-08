
using System;

namespace Almotkaml.HR.Domain.TechnicalAffairsDepartmentFactory
{
    public class TechnicalAffairsDepartmentBuilder : IEntrantsAndReviewersIdHolder, IMonthWorkHolder, IYearWorkHolder
        , IDataEntryCountHolder, IDataEntryBalanceHolder, IFirstReviewCountHolder, IFirstReviewBalanceHolder, IAccommodationReviewCountHolder
        , IAccommodationReviewBalanceHolder, IClincReviewCountHolder, IClincReviewBalanceHolder, ITotalBalanceHolder, INoteHolder
        , IIsPaidHolder, IBuild
        
    {

        internal TechnicalAffairsDepartmentBuilder() { }
        private TechnicalAffairsDepartment TechnicalAffairsDepartment { get; } = new TechnicalAffairsDepartment();


        public IMonthWorkHolder WithEntrantsAndReviewersId(int entrantsAndReviewersId)
        {
            TechnicalAffairsDepartment .EntrantsAndReviewersId = entrantsAndReviewersId;
            return this;
        }


        public IYearWorkHolder WithMonthWork(int monthWork)
        {
            TechnicalAffairsDepartment.MonthWork  = monthWork;
            return this;
        }

        public IDataEntryCountHolder WithYearWork(int yearWork)
        {
            TechnicalAffairsDepartment.YearWork = yearWork;
            return this;
        }


        public IDataEntryBalanceHolder  WithDataEntryCount(int dataEntryCount)
        {
            TechnicalAffairsDepartment.DataEntryCount = dataEntryCount;
            return this;
        }

        public IFirstReviewCountHolder  WithDataEntryBalance(decimal  dataEntryBalance)
        {
            TechnicalAffairsDepartment.DataEntryBalance = dataEntryBalance;
            return this;
        }
        public IFirstReviewBalanceHolder  WithFirstReviewCount(int firstReviewCount)
        {
            TechnicalAffairsDepartment.FirstReviewCount = firstReviewCount;
            return this;
        }

        public IAccommodationReviewCountHolder  WithFirstReviewBalance(decimal firstReviewBalance)
        {
            TechnicalAffairsDepartment.FirstReviewBalance = firstReviewBalance;
            return this;
        }
        public IAccommodationReviewBalanceHolder  WithAccommodationReviewCount(int accommodationReviewCount)
        {
            TechnicalAffairsDepartment.AccommodationReviewCount = accommodationReviewCount;
            return this;
        }

        public IClincReviewCountHolder  WithAccommodationReviewBalance(decimal accommodationReviewBalance)
        {
            TechnicalAffairsDepartment.AccommodationReviewBalance = accommodationReviewBalance;
            return this;
        }
        public IClincReviewBalanceHolder  WithClincReviewCount(int clincReviewCount)
        {
            TechnicalAffairsDepartment.ClincReviewCount = clincReviewCount;
            return this;
        }

        public ITotalBalanceHolder  WithClincReviewBalance(decimal clincReviewBalance)
        {
            TechnicalAffairsDepartment.ClincReviewBalance = clincReviewBalance;
            return this;
        }
        public INoteHolder  WithTotalBalance(decimal  totalBalance)
        {
            TechnicalAffairsDepartment.TotalBalance = totalBalance;
            return this;
        }

        public IIsPaidHolder  WithNote(string  note)
        {
            TechnicalAffairsDepartment.Note = note;
            return this;
        }
        public IBuild  WithIsPaid(bool IsPaid)
        {
            TechnicalAffairsDepartment.IsPaid = IsPaid;
            return this;
        }

   

        //public IBuild WithEmployeeId(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    TechnicalAffairsDepartment.EmployeeId = employeeId;
        //    return this;
        //}

        //public IBuild WithEmployee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    TechnicalAffairsDepartment.EmployeeId = employee.EmployeeId;
        //    TechnicalAffairsDepartment.Employee = employee;
        //    return this;
        //}

        public TechnicalAffairsDepartment Biuld()
        {
            return TechnicalAffairsDepartment;
        }

   
    }

}