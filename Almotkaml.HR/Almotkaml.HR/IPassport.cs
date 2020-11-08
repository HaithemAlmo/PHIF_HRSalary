namespace Almotkaml.HR
{
    public interface IPassport<out TDate>
    {
        string Number { get; }
        string AutoNumber { get; }
        TDate IssueDate { get; }
        string IssuePlace { get; }

    }
}