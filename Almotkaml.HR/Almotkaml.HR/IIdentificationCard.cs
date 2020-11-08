namespace Almotkaml.HR
{
    public interface IIdentificationCard<out TDate>
    {
        string Number { get; }
        TDate IssueDate { get; }
        string IssuePlace { get; }

    }
}