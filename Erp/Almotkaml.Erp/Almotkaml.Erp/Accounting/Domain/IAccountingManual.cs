namespace Almotkaml.Erp.Accounting.Domain
{
    public interface IAccountingManual
    {
        int AccountingManualId { get; }
        string Name { get; }
        string Number { get; }
        short AccountingLevelId { get; }
        string LevelName { get; }
    }
}