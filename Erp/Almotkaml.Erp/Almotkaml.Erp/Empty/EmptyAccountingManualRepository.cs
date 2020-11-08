using Almotkaml.Erp.Accounting.Domain;
using Almotkaml.Erp.Accounting.Repository;
using System.Collections.Generic;

namespace Almotkaml.Erp.Empty
{
    public class EmptyAccountingManualRepository : IAccountingManualRepository
    {
        public IEnumerable<IAccountingManual> GetBanks() => new HashSet<IAccountingManual>();
    }
}