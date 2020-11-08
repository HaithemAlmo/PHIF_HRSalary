using System;

namespace Almotkaml.HR.Domain.EndServicesFactory
{
    public class EndServicesModifier
    {
        internal EndServicesModifier(EndServices endServices)
        {
            EndServices = endServices;
        }

        private EndServices EndServices { get; }


        public EndServicesModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            EndServices.EmployeeId = employeeId;
            return this;
        }

        public EndServicesModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            EndServices.EmployeeId = employee.EmployeeId;
            EndServices.Employee = employee;
            return this;
        }

        public EndServicesModifier CauseOfEndService(CauseOfEndService causeOfEndService)
        {
            EndServices.CauseOfEndService = causeOfEndService;
            return this;
        }

        public EndServicesModifier Cause(string cause)
        {
            EndServices.Cause = cause;
            return this;
        }

        public EndServicesModifier Date(DateTime decisionDate)
        {
            EndServices.DecisionDate = decisionDate;
            return this;
        }
        public EndServicesModifier DecisionNumber(string decisionNumber)
        {
            EndServices.DecisionNumber = decisionNumber;
            return this;
        }

        public EndServices Confirm()
        {
            return EndServices;
        }
    }
}
