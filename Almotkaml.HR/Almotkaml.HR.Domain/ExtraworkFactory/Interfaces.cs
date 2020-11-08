using System;

namespace Almotkaml.HR.Domain.ExtraworkFactory
{
    public interface IEmployeeIdHolder
    {
        ITimeCountHolder WithEmployeeId(int employeeId);
        ITimeCountHolder WithEmployee(Employee employee);
    }
    public interface ITimeCountHolder
    {
        IDecisionNumberHolder WithTimeCount(decimal timeCount);
    }
    public interface IDecisionNumberHolder
    {
        IDateHolder WithDecisionNumber(string decisionNumber);
    }
    public interface IDateHolder
    {
        IDateFromHolder WithDate(DateTime date);
    }


    public interface IDateFromHolder
    {
        IDateToHolder WithIDateFrom(DateTime datefrom);
    }


    public interface IDateToHolder
    {
        IBuild WithDateTo(DateTime dateto);
    }
    public interface IBuild
    {
        Extrawork Biuld();
    }
}