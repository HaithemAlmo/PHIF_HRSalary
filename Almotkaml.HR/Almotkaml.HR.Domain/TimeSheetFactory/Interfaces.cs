using System;

namespace Almotkaml.HR.Domain.TimeSheetFactory
{
    public interface IEmployeeIdHolder
    {
        IHourAccessHolder WithEmployeeId(int employeeId);
        IHourAccessHolder WithEmployee(Employee employee);
    }
    public interface IHourAccessHolder
    {
        IHourleaveHolder WithHourAccess(string hourAccess);
    }
    public interface IHourleaveHolder
    {
        IDateHolder WithHourleave(string hourleave);
    }
    public interface IDateHolder
    {
        IBuild WithDate(DateTime date);
    }

    public interface IBuild
    {
        TimeSheet Biuld();
    }
}