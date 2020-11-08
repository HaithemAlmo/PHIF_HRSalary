using System;

namespace Almotkaml.HR.Domain.DelegationFactory
{
    public interface INameHolder
    {
        IJobNumberHolder WithName(string name);
    }
    public interface IJobNumberHolder
    {
        IJobTypeTransferHolder WithJobNumber(string jobNumber);
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
        IQualificationTypeHolder WithSideName(string sideName);
    }
    public interface IQualificationTypeHolder
    {
        IDelegationNumberHolder WithQualificationTypeId(int? qualificationTypeId);
        IDelegationNumberHolder WithQualificationType(QualificationType qualificationType);
    }
    public interface IDelegationNumberHolder
    {
        IDecisionDateHolder WithDelegationNumber(string delegationNumber);
    }
    public interface IDecisionDateHolder
    {
        IBuild WithDecisionDate(DateTime? decisionDate);
    }
    public interface IBuild
    {
        Delegation Biuld();
    }
}