using Almotkaml.HR.Domain.DelegationFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Delegation
    {
        internal Delegation() { }
        public static INameHolder New() => new DelegationBuilder();

        public int DelegationId { get; internal set; }
        public string Name { get; internal set; }
        public string JobNumber { get; internal set; } // الرقم الوظيفي 
        public JobTypeTransfer JobTypeTransfer { get; internal set; }
        public DateTime DateFrom { get; internal set; }
        public DateTime DateTo { get; internal set; }
        public string SideName { get; internal set; }
        public int? QualificationTypeId { get; internal set; }
        public QualificationType QualificationType { get; internal set; }
        public string DelegationNumber { get; internal set; }
        public DateTime? DecisionDate { get; internal set; }
        public DelegationModifier Modify() => new DelegationModifier(this);
    }
}
