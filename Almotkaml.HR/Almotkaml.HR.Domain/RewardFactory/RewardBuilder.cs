using System;

namespace Almotkaml.HR.Domain.RewardFactory
{
    public class RewardBuilder : IDateHolder, IEfficiencyEstimateHolder, IValueHolder, IRewardTypeIdHolder
        , INoteHolder, IEmployeeIdHolder, IBuild
    {

        internal RewardBuilder() { }
        private Reward Reward { get; } = new Reward();

        public IEfficiencyEstimateHolder WithDate(DateTime date)
        {
            Reward.Date = date;
            return this;
        }

        public IValueHolder WithEfficiencyEstimate(string efficiencyEstimate)
        {
            Reward.EfficiencyEstimate = efficiencyEstimate;
            return this;
        }

        public IRewardTypeIdHolder WithValue(string value)
        {
            Reward.Value = value;
            return this;
        }

        public INoteHolder WithRewardTypeId(int rewardTypeId)

        {

            Reward.RewardTypeId = rewardTypeId;
            return this;
        }

        public INoteHolder WithRewardType(RewardType rewardType)
        {
            Reward.RewardTypeId = rewardType.RewardTypeId;
            Reward.RewardType = rewardType;
            return this;
        }

        public IEmployeeIdHolder WithNote(string note)
        {
            Reward.Note = note;
            return this;
        }

        public IBuild WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Reward.EmployeeId = employeeId;
            return this;
        }

        public IBuild WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Reward.EmployeeId = employee.EmployeeId;
            Reward.Employee = employee;
            return this;
        }
        public Reward Biuld()
        {
            return Reward;
        }

    }

}