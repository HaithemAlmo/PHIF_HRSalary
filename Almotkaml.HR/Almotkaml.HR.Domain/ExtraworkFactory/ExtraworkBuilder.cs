using System;

namespace Almotkaml.HR.Domain.ExtraworkFactory
{
    public class ExtraworkBuilder : IEmployeeIdHolder, ITimeCountHolder, IDecisionNumberHolder, IDateHolder, IDateFromHolder, IDateToHolder, IBuild
    {

        internal ExtraworkBuilder() { }
        private Extrawork Extrawork { get; } = new Extrawork();


        public ITimeCountHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Extrawork.EmployeeId = employeeId;
            return this;
        }

        public ITimeCountHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Extrawork.Employee = employee;
            Extrawork.EmployeeId = employee.EmployeeId;

            return this;
        }

        public IDecisionNumberHolder WithTimeCount(decimal timeCount)
        {
            Check.NotNull(timeCount, nameof(timeCount));
            Extrawork.TimeCount = timeCount;
            return this;
        }

        public IDateHolder WithDecisionNumber(string decisionNumber)
        {
            Check.NotNull(decisionNumber, nameof(decisionNumber));
            Extrawork.DecisionNumber = decisionNumber;
            return this;
        }

        public IDateFromHolder WithDate(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            Extrawork.Date = date;
            return this;

        }

        public IDateToHolder WithIDateFrom(DateTime datefrom)
        {
            Check.NotNull(datefrom, nameof(datefrom));
            Extrawork.DateFrom = datefrom;
            return this;
        }

        public IBuild WithDateTo(DateTime dateto)
        {
            Extrawork.DateTo = dateto;
            return this;
        }

        public Extrawork Biuld()
        {
            return Extrawork;
        }
    }

}