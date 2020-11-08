using System;

namespace Almotkaml.HR.Domain.SanctionFactory
{
    public class SanctionModifier
    {
        internal SanctionModifier(Sanction sanction)
        {
            Sanction = sanction;
        }
        private Sanction Sanction { get; }
        public SanctionModifier SanctionType(int sanctionTypeId)
        {
            Check.MoreThanZero(sanctionTypeId, nameof(sanctionTypeId));
            Sanction.SanctionTypeId = sanctionTypeId;
            return this;
        }

        public SanctionModifier SanctionType(SanctionType sanctionType)
        {
            Check.NotNull(sanctionType, nameof(sanctionType));
            Sanction.SanctionType = sanctionType;
            return this;
        }

        public SanctionModifier Date(DateTime date)
        {
            Sanction.Date = date;
            return this;
        }

        public SanctionModifier Cause(string cause)
        {
            Sanction.Cause = cause;
            return this;
        }

        public SanctionModifier SanctionsDay(int sanctionsDay)
        {
            Sanction.SanctionDay = sanctionsDay;
            return this;
        }
        public SanctionModifier DeductionMonth(int deductionMonth)
        {
            Sanction.DeductionMonth = deductionMonth;
            return this;
        }
        public SanctionModifier DeductionYear(int deductionYear)
        {
            Sanction.DeductionYear = deductionYear;
            return this;
        }
        public SanctionModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Sanction.EmployeeId = employeeId;
            return this;
        }

        public SanctionModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Sanction.EmployeeId = employee.EmployeeId;
            Sanction.Employee = employee;
            return this;
        }
        public Sanction Confirm()
        {
            return Sanction;
        }
    }


}