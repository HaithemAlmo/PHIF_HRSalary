using System;

namespace Almotkaml.HR.Domain.SituationResolveJobFactory
{
    public interface IEmployeeIdHolder
    {
        IDecisionNumberHolder WithEmployeeId(int employeeId);
        IDecisionNumberHolder WithEmployee(Employee employee);
    }
    public interface IDecisionNumberHolder
    {
        IDecisionDateHolder WithDecisionNumber(string decisionNumber);
    }
    public interface IDecisionDateHolder
    {
        IDegreeHolder WithDecisionDate(DateTime

            decisionDate);
    }
    public interface IDegreeHolder
    {
        IBounHolder WithDegree(int degree);
    }

    public interface IBounHolder
    {
        IDegreeNowHolder WithBoun(int boun);
    }

    public interface IDegreeNowHolder
    {
        IDateDegreeLastHolder WithDegreeNow(int degreeNow);
    }
    public interface IDateDegreeLastHolder
    {
        IBounNowHolder WithDateDegreeLast(DateTime dateDegreeLast);
    }

    public interface IBounNowHolder
    {
        IBuild WithBounNow(int bounNow);
    }

    public interface IBuild
    {
        SituationResolveJob Biuld();
    }
}
