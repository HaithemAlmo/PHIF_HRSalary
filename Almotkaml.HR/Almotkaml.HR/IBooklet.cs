namespace Almotkaml.HR
{
    public interface IBooklet<out TDate>
    {
        string Number { get; }
        string FamilyNumber { get; }
        string RegistrationNumber { get; }
        TDate IssueDate { get; }
        string IssuePlace { get; }
        string CivilRegistry { get; }
    }
}