using Almotkaml.HR.Domain.RewardFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Reward
    {
        public static IDateHolder New()
        {
            return new RewardBuilder();
        }

        internal Reward()
        {

        }
        public int RewardId { get; internal set; }
        public DateTime Date { get; internal set; }
        public string EfficiencyEstimate { get; internal set; }
        public string Value { get; internal set; }
        public int RewardTypeId { get; internal set; }
        public RewardType RewardType { get; internal set; }
        public string Note { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public RewardModifier Modify()
        {
            return new RewardModifier(this);
        }


    }
}