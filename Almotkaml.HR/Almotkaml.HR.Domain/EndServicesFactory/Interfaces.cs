using System;

namespace Almotkaml.HR.Domain.EndServicesFactory
{
    public interface IEmployeeId
    {
        ICauseOfEndService WithEmployeeId(int employeeid);
        ICauseOfEndService WithEmployee(Employee employee);
    }
    public interface ICauseOfEndService
    {
        ICause WithCauseOfEndService(CauseOfEndService causeOfEndService);
    }
    public interface ICause
    {
        IDate WithCause(string cause);
    }
    public interface IDate
    {
        IDecisionNumber WithDate(DateTime decisionDate);

    }
    public interface IDecisionNumber
    {
        IBuild WithDecisionNumber(string decisionNumber);

    }

    public interface IBuild
    {
        EndServices Biuld();
    }
}