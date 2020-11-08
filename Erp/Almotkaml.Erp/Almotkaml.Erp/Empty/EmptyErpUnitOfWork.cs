using Almotkaml.Erp.Accounting.Repository;

namespace Almotkaml.Erp.Empty
{
    public class EmptyErpUnitOfWork : IErpUnitOfWork
    {
        public void Dispose() { }
        public void Complete() { }

        public bool TryComplete() => true;

        public bool BackUp(string path) => true;

        public bool Restore(string path) => true;

        public string Message => null;
        public IAccountingManualRepository AccountingManuals { get; } = new EmptyAccountingManualRepository();
        public ICostCenterRepository CostCenters { get; } = new EmptyCostCenterRepository();
    }
}