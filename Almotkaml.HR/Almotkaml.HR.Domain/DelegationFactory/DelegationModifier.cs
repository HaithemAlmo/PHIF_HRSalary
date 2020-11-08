using System;

namespace Almotkaml.HR.Domain.DelegationFactory
{
    public class DelegationModifier
    {
        internal DelegationModifier(Delegation delegation)
        {
            Delegation = delegation;
        }

        private Delegation Delegation { get; }

        public DelegationModifier Name(string name)
        {
            Delegation.Name = name;
            return this;
        }

        public DelegationModifier JobNumber(string jobNumber)
        {
            Delegation.JobNumber = jobNumber;
            return this;
        }

        public DelegationModifier JobTypeTransfer(JobTypeTransfer jobTypeTransfer)
        {
            Delegation.JobTypeTransfer = jobTypeTransfer;
            return this;
        }

        public DelegationModifier DateFrom(DateTime dateFrom)
        {
            Delegation.DateFrom = dateFrom;
            return this;
        }

        public DelegationModifier DateTo(DateTime dateTo)
        {
            Delegation.DateTo = dateTo;
            return this;
        }

        public DelegationModifier SideName(string sideName)
        {
            Delegation.SideName = sideName;
            return this;
        }

        public DelegationModifier QualificationType(int? qualificationTypeId)
        {
            if (Delegation.QualificationTypeId == qualificationTypeId)
                return this;

            Delegation.QualificationType = null;
            Delegation.QualificationTypeId = qualificationTypeId;
            return this;
        }

        public DelegationModifier QualificationType(QualificationType qualificationType)
        {
            Delegation.QualificationTypeId = qualificationType?.QualificationTypeId;
            Delegation.QualificationType = qualificationType;
            return this;
        }

        public DelegationModifier DelegationNumber(string delegationNumber)
        {
            Delegation.DelegationNumber = delegationNumber;
            return this;
        }

        public DelegationModifier DecisionDate(DateTime? decisionDate)
        {
            if (decisionDate != null)
                Check.IsValidDate(decisionDate.Value, nameof(decisionDate));

            Delegation.DecisionDate = decisionDate;
            return this;
        }

        public Delegation Confirm()
        {
            return Delegation;
        }
    }
}
