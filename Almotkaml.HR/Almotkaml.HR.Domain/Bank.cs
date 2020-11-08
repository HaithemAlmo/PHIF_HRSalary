using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Bank
    {
        public static Bank New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var bank = new Bank()
            {
                Name = name,
            };


            return bank;
        }

        private Bank()
        {

        }
        public int BankId { get; private set; }
        public string Name { get; private set; }
        public ICollection<BankBranch> BankBranchs { get; } = new HashSet<BankBranch>();
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}
