using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class BankBranch
    {
        public static BankBranch New(string name, int bankId, int? accountingManualId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(bankId, nameof(bankId));
            if (accountingManualId == 0)
                accountingManualId = null;


            var bankBranch = new BankBranch()
            {
                Name = name,
                BankId = bankId,
                AccountingManualId = accountingManualId
            };


            return bankBranch;
        }
        public static BankBranch New(string name, Bank bank, int? accountingManualId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(bank, nameof(bank));
            if (accountingManualId == 0)
                accountingManualId = null;


            var bankBranch = new BankBranch()
            {
                Name = name,
                Bank = bank,
                AccountingManualId = accountingManualId
            };


            return bankBranch;
        }
        private BankBranch()
        {

        }
        public int BankBranchId { get; private set; }
        public string Name { get; private set; }
        public Bank Bank { get; private set; }
        public int BankId { get; private set; }
        public int? AccountingManualId { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, int bankId, int? accountingManualId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(bankId, nameof(bankId));
            if (accountingManualId == 0)
                accountingManualId = null;

            Name = name;
            BankId = bankId;
            Bank = null;
            AccountingManualId = accountingManualId;

        }

        public void Modify(string name, Bank bank, int? accountingManualId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(bank, nameof(bank));
            if (accountingManualId == 0)
                accountingManualId = null;
            Name = name;
            Bank = bank;
            AccountingManualId = accountingManualId;

        }
    }
}
