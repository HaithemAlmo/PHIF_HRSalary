using System;

namespace Almotkaml.HR.Domain.DelegationFactory
{
    public class DelegationBuilder : INameHolder, IJobNumberHolder, IJobTypeTransferHolder, IDateFromHolder
        , IDateToHolder, ISideNameHolder, IQualificationTypeHolder, IDelegationNumberHolder, IDecisionDateHolder
        , IBuild
    {
        internal DelegationBuilder()
        { }

        private Delegation Delegation { get; } = new Delegation();

        public IJobNumberHolder WithName(string name)
        {
            Delegation.Name = name;
            return this;
        }

        public IJobTypeTransferHolder WithJobNumber(string jobNumber)
        {
            Delegation.JobNumber = jobNumber;
            return this;
        }

        public IDateFromHolder WithJobTypeTransfer(JobTypeTransfer jobTypeTransfer)
        {
            Delegation.JobTypeTransfer = jobTypeTransfer;
            return this;
        }

        public IDateToHolder WithDateFrom(DateTime dateFrom)
        {
            Delegation.DateFrom = dateFrom;
            return this;
        }

        public ISideNameHolder WithDateTo(DateTime dateTo)
        {
            Delegation.DateTo = dateTo;
            return this;
        }

        public IQualificationTypeHolder WithSideName(string sideName)
        {
            Delegation.SideName = sideName;
            return this;
        }

        public IDelegationNumberHolder WithQualificationTypeId(int? qualificationTypeId)
        {
            if (qualificationTypeId == 0)
                qualificationTypeId = null;

            Delegation.QualificationTypeId = qualificationTypeId;
            return this;
        }

        public IDelegationNumberHolder WithQualificationType(QualificationType qualificationType)
        {
            Delegation.QualificationTypeId = qualificationType?.QualificationTypeId;
            Delegation.QualificationType = qualificationType;
            return this;
        }

        public IDecisionDateHolder WithDelegationNumber(string delegationNumber)
        {
            Delegation.DelegationNumber = delegationNumber;
            return this;
        }

        public IBuild WithDecisionDate(DateTime? decisionDate)
        {
            if (decisionDate != null)
                Check.IsValidDate(decisionDate.Value, nameof(decisionDate));

            Delegation.DecisionDate = decisionDate;
            return this;
        }

        public Delegation Biuld()
        {
            return Delegation;
        }
    }
}