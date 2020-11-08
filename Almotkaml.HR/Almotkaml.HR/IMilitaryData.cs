namespace Almotkaml.HR
{
    public interface IMilitaryData<out TDate>
    {
        AdjectiveMilitary AdjectiveMilitary { get; }
        string MilitaryNumber { get; }
        string Subunit { get; }
        string Rank { get; }
        TDate GranduationDate { get; }
        string MotherUnit { get; }
        string College { get; }

    }
}