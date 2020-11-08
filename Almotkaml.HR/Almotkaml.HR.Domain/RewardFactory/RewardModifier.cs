using System;

namespace Almotkaml.HR.Domain.RewardFactory
{
    public class RewardModifier
    {
        internal RewardModifier(Reward reward)
        {
            Reward = reward;
        }
        private Reward Reward { get; }
        public RewardModifier Date(DateTime date)
        {
            Reward.Date = date;
            return this;
        }

        public RewardModifier EfficiencyEstimate(string efficiencyEstimate)
        {
            Reward.EfficiencyEstimate = efficiencyEstimate;
            return this;
        }

        public RewardModifier Value(string value)
        {
            Reward.Value = value;
            return this;
        }

        public RewardModifier RewardType(int rewardTypeId)
        {
            Reward.RewardTypeId = rewardTypeId;
            return this;
        }

        public RewardModifier RewardType(RewardType rewardType)
        {
            Reward.RewardTypeId = rewardType.RewardTypeId;
            Reward.RewardType = rewardType;
            return this;
        }

        public RewardModifier Note(string note)
        {
            Reward.Note = note;
            return this;
        }

        public RewardModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Reward.EmployeeId = employeeId;
            return this;
        }

        public RewardModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Reward.EmployeeId = employee.EmployeeId;
            Reward.Employee = employee;
            return this;
        }
        public Reward Confirm()
        {
            return Reward;
        }
    }
}