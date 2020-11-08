using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IBankBranchRepository : IRepository<BankBranch>
    {
        IEnumerable<BankBranch> GetBankBranchWithBank(int bankId);
        IEnumerable<BankBranch> GetBankBranchWithBank();
        bool BankBranchExisted(string name, int bankId);
        bool BankBranchExisted(string name, int bankId, int idToExcept);
    }
}