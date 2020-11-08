using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class RewardType
    {
        public static RewardType New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var rewardType = new RewardType()
            {
                Name = name,
            };


            return rewardType;
        }
        private RewardType()
        {

        }
        public int RewardTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Reward> Rewards { get; } = new HashSet<Reward>();
        //public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }

    }
}