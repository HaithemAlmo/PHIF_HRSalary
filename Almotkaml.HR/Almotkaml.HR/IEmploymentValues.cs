namespace Almotkaml.HR
{
    public interface IEmploymentValues<out TDate>
    {
        string DesignationResolutionNumber { get; }
        TDate DesignationResolutionDate { get; }
        string DesignationIssue { get; }
        TDate ContractDate { get; }
        string ContractDuration { get; }
    }
}