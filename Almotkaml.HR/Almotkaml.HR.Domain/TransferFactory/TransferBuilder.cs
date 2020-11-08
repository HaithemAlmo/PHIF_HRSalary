using System;

namespace Almotkaml.HR.Domain.TransferFactory
{
    public class TransferBuilder : IEmployeeHolder, IJobTypeTransferHolder, IDateFromHolder
        , IDateToHolder, ISideNameHolder, IBuild
    {
        internal TransferBuilder()
        { }

        private Transfer Transfer { get; } = new Transfer();
        public IJobTypeTransferHolder WithEmployeeId(int employeeId)
        {
            Transfer.EmployeeId = employeeId;
            return this;
        }

        public IJobTypeTransferHolder WithEmployee(Employee employee)
        {
            Transfer.EmployeeId = employee.EmployeeId;
            Transfer.Employee = employee;
            return this;
        }

        public IDateFromHolder WithJobTypeTransfer(JobTypeTransfer jobTypeTransfer)
        {
            Transfer.JobTypeTransfer = jobTypeTransfer;
            return this;
        }

        public IDateToHolder WithDateFrom(DateTime dateFrom)
        {
            Transfer.DateFrom = dateFrom;
            return this;
        }

        public ISideNameHolder WithDateTo(DateTime dateTo)
        {
            Transfer.DateTo = dateTo;
            return this;
        }

        public IBuild WithSideName(string sideName)
        {
            Transfer.SideName = sideName;
            return this;
        }

        public Transfer Biuld()
        {
            return Transfer;
        }

    }

}