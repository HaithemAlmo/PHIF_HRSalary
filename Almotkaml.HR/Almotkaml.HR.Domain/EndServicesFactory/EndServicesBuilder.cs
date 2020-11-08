using System;

namespace Almotkaml.HR.Domain.EndServicesFactory
{
    public class EndServicesBuilder : IEmployeeId, ICauseOfEndService, ICause, IDate, IDecisionNumber
        , IBuild
    {
        internal EndServicesBuilder()
        { }

        private EndServices EndServices { get; } = new EndServices();
        public ICauseOfEndService WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            EndServices.EmployeeId = employeeId;
            return this;
        }

        public ICauseOfEndService WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            EndServices.EmployeeId = employee.EmployeeId;
            EndServices.Employee = employee;
            return this;
        }

        public ICause WithCauseOfEndService(CauseOfEndService causeOfEndService)
        {
            EndServices.CauseOfEndService = causeOfEndService;
            return this;
        }

        public IDate WithCause(string cause)
        {
            EndServices.Cause = cause;
            return this;
        }

        public IDecisionNumber WithDate(DateTime decisionDate)
        {
            EndServices.DecisionDate = decisionDate;
            return this;
        }
        public IBuild WithDecisionNumber(string decisionNumber)
        {
            EndServices.DecisionNumber = decisionNumber;
            return this;
        }

        public EndServices Biuld()
        {
            return EndServices;
        }

    }

}