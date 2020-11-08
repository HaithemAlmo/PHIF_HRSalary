using Almotkaml.Erp.Accounting.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class AccountingExtensions
    {
        public static IEnumerable<AccountingManualListItem> ToList(this IEnumerable<IAccountingManual> accountingManuals)
            => accountingManuals.Select(a => new AccountingManualListItem()
            {
                Number = a.Number,
                AccountingLevelId = a.AccountingLevelId,
                AccountingManualId = a.AccountingManualId,
                LevelName = a.LevelName,
                ManualName = a.Name
            });

        public static IEnumerable<CostCenterListItem> ToList(this IEnumerable<ICostCenter> costCenters)
            => costCenters.Select(c => new CostCenterListItem()
            {
                Name = c.Name,
                CostCenterId = c.CostCenterId
            });
    }
}