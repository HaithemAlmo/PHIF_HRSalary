using Almotkaml.Repository;

namespace Almotkaml.Erp.Accounting.Repository
{
    public interface IErpUnitOfWork : IDefaultUnitOfWork
    {
        IAccountingManualRepository AccountingManuals { get; }
        ICostCenterRepository CostCenters { get; }
    }
}
