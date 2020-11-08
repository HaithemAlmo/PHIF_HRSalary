namespace Almotkaml.HR.Domain
{
    public interface IYearlyVacationRule
    {
        int GetYearlyVacationBalance(Employee employee);
    }
}