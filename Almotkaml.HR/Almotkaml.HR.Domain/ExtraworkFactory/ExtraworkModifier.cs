using System;

namespace Almotkaml.HR.Domain.ExtraworkFactory
{
    public class ExtraworkModifier
    {
        internal ExtraworkModifier(Extrawork extrawork)
        {
            Extrawork = extrawork;
        }
        private Extrawork Extrawork { get; }

        public ExtraworkModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Extrawork.EmployeeId = employeeId;
            return this;
        }

        public ExtraworkModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Extrawork.Employee = employee;
            Extrawork.EmployeeId = employee.EmployeeId;

            return this;
        }

        public ExtraworkModifier TimeCoun(decimal timeCoun)
        {
            Check.NotNull(timeCoun, nameof(timeCoun));
            Extrawork.TimeCount = timeCoun;
            return this;

        }

        public ExtraworkModifier DecisionNumber(string decisionNumber)
        {
            Check.NotNull(decisionNumber, nameof(decisionNumber));
            Extrawork.DecisionNumber = decisionNumber;
            return this;
        }

        public ExtraworkModifier Date(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            Extrawork.Date = date;
            return this;
        }

        public ExtraworkModifier DateFrom(DateTime dateFrom)
        {
            Check.NotNull(dateFrom, nameof(dateFrom));
            Extrawork.DateFrom = dateFrom;
            return this;
        }

        public ExtraworkModifier DateTo(DateTime dateTo)
        {
            Check.NotNull(dateTo, nameof(dateTo));
            Extrawork.DateTo = dateTo;
            return this;
        }

        public Extrawork Confirm()
        {
            return Extrawork;
        }
    }


}