using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class BankBranchRepository : Repository<BankBranch>, IBankBranchRepository
    {
        private HrDbContext Context { get; }

        internal BankBranchRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<BankBranch> GetBankBranchWithBank(int bankId)
        {
            return Context.BankBranches
                .Include(d => d.Bank)
                .Where(d => d.BankId == bankId);
        }

        public IEnumerable<BankBranch> GetBankBranchWithBank()
        {
            return Context.BankBranches
                .Include(d => d.Bank);
        }

        public bool BankBranchExisted(string name, int bankId) => Context.BankBranches
            .Any(e => e.Name == name && e.BankId == bankId);

        public bool BankBranchExisted(string name, int bankId, int idToExcept) => Context.BankBranches
            .Any(e => e.Name == name && e.BankBranchId != idToExcept && e.BankId == bankId);


    }
}