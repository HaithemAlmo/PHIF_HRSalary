using System;

namespace Almotkaml.HR.Domain.SanctionFactory
{
    public class SanctionBuilder : ISanctionTypeIdHolder, IDateHolder
        , ICauseHolder, ISanctionDayHolder, IDeductionMonthHolder, IDeductionYearHolder, IEmployeeIdHolder, IBuild
    {

        internal SanctionBuilder() { }
        private Sanction Sanction { get; } = new Sanction();

        public IDateHolder WithSanctionTypeId(int sanctionTypeId)
        {
            Check.MoreThanZero(sanctionTypeId, nameof(sanctionTypeId));
            Sanction.SanctionTypeId = sanctionTypeId;
            return this;
        }

        public IDateHolder WithSanctionType(SanctionType sanctionType)
        {
            Check.NotNull(sanctionType, nameof(sanctionType));
            Sanction.SanctionType = sanctionType;
            Sanction.SanctionTypeId = sanctionType.SanctionTypeId;
            return this;
        }

        public ICauseHolder WithDate(DateTime date)
        {
            Sanction.Date = date;
            return this;
        }

        public ISanctionDayHolder WithCause(string cause)
        {
            Sanction.Cause = cause;
            return this;
        }
        public IDeductionMonthHolder WithSanctionDay(int sanctionDay)
        {
            Sanction.SanctionDay = sanctionDay;
            return this;
          
        }
        public IDeductionYearHolder   WithDeductionMonth(int deductionMonth)
        {
            Sanction.DeductionMonth = deductionMonth;
            return this;
          
        }
        public IEmployeeIdHolder WithDeductionYear(int deductionYear)
        {
            Sanction.DeductionYear = deductionYear;
            return this;
        }
        public IBuild WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Sanction.EmployeeId = employeeId;
            return this;
        }

        public IBuild WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Sanction.EmployeeId = employee.EmployeeId;
            Sanction.Employee = employee;
            return this;
        }
        public Sanction Biuld()
        {
            return Sanction;
        }


    }

}