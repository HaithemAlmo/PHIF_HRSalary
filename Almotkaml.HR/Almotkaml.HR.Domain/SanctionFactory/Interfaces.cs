using System;

namespace Almotkaml.HR.Domain.SanctionFactory
{
    public interface ISanctionTypeIdHolder
    {
        IDateHolder WithSanctionTypeId(int sanctionTypeId);
        IDateHolder WithSanctionType(SanctionType sanctionType);
    }
    public interface IDateHolder
    {
        ICauseHolder WithDate(DateTime date);
    }
    public interface ICauseHolder
    {
        ISanctionDayHolder WithCause(string cause);
    }
    public interface ISanctionDayHolder
    {
        IDeductionMonthHolder WithSanctionDay(int sanctionDay);
    }
    public interface IDeductionMonthHolder
    {
        IDeductionYearHolder WithDeductionMonth(int deductionMonth);
    }
    public interface IDeductionYearHolder
    {
        IEmployeeIdHolder WithDeductionYear(int deductionYear);
    }
    public interface IEmployeeIdHolder
    {
        IBuild WithEmployeeId(int employeeId);
        IBuild WithEmployee(Employee employee);
    }
    public interface IBuild
    {
        Sanction Biuld();
    }
}