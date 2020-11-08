using System;

namespace Almotkaml.HR.Domain.TransferFactory
{
    public interface IEmployeeHolder
    {
        IJobTypeTransferHolder WithEmployeeId(int employeeId);
        IJobTypeTransferHolder WithEmployee(Employee employee);
    }
    public interface IJobTypeTransferHolder
    {
        IDateFromHolder WithJobTypeTransfer(JobTypeTransfer jobTypeTransfer);
    }
    public interface IDateFromHolder
    {
        IDateToHolder WithDateFrom(DateTime dateFrom);
    }
    public interface IDateToHolder
    {
        ISideNameHolder WithDateTo(DateTime dateTo);
    }
    public interface ISideNameHolder
    {
        IBuild WithSideName(string sideName);
    }
    public interface IBuild
    {
        Transfer Biuld();
    }
}