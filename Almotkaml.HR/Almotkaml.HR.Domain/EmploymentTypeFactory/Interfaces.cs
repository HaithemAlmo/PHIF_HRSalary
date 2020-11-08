namespace Almotkaml.HR.Domain.EmploymentTypeFactory
{
    public interface INameHolder
    {
        IDesignationResolutionNumberHolder WithName(string name);
    }
    public interface IDesignationResolutionNumberHolder
    {
        IDesignationResolutionDateHolder WithDesignationResolutionNumber(bool designationResolutionNumber);
    }
    public interface IDesignationResolutionDateHolder
    {
        IDesignationIssueHolder WithDesignationResolutionDate(bool designationResolutionDate);
    }
    public interface IDesignationIssueHolder
    {
        IContractDateHolder WithDesignationIssue(bool designationIssue);
    }
    public interface IContractDateHolder
    {
        IContractDurationHolder WithContractDate(bool contractDate);
    }
    public interface IContractDurationHolder
    {
        IBuild WithContractDuration(bool contractDuration);
    }
    public interface IBuild
    {
        EmploymentType Biuld();
    }
}