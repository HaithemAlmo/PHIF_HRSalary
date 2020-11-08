using System;

namespace Almotkaml.HR.Domain.AbsenceFactory
{
    public interface IAbsenceTypeHolder
    {
        IDateHolder WithAbsenceType(AbsenceType absenceType);
    }
    public interface IDateHolder
    {
        IDeductionMonthHolder WithDate(DateTime date);
    }
    public interface IDeductionMonthHolder
    {
        IDeductionYearHolder WithDeductionMonth(int deductionMonth);
    }
    public interface IDeductionYearHolder
    {
        INoteHolder WithDeductionYear(int deductionYear);
    }
    public interface INoteHolder
    {
        IDayHolder WithNote(string note);
    }
    public interface IDayHolder
    {
        IEmployeeIdHolder WithDay(int Day);
    }
    public interface IEmployeeIdHolder
    {
        IBuild WithEmployeeId(int employeeId);
        IBuild WithEmployee(Employee employee);
    }
    public interface IBuild
    {
        Absence Biuld();
    }
}