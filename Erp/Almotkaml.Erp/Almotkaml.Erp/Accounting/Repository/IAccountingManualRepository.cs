using Almotkaml.Erp.Accounting.Domain;
using System.Collections.Generic;

namespace Almotkaml.Erp.Accounting.Repository
{
    public interface IAccountingManualRepository
    {
        IEnumerable<IAccountingManual> GetBanks();
    }
}