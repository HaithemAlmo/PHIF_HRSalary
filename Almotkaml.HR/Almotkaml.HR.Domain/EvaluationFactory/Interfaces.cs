using System;

namespace Almotkaml.HR.Domain.EvaluationFactory
{
    
    public interface IEmployeeIdHolder
    {
        IGradeHolder WithEmployeeId(int employeeId);
        IGradeHolder WithEmployee(Employee employee);
    }
    public interface IGradeHolder
    {
        IRatioHolder WithGrade(Grade grade);
    }
    public interface IRatioHolder
    {
        IYearHolder WithRatio(double? ratio);
    }
    public interface IYearHolder
    {
        IDateHolder WithYear(int? year);
    }
    
    public interface IDateHolder
    {
        INoteHolder WithDate(DateTime? date);
    }
    public interface INoteHolder
    {
        IBuild WithNote(string note);
    }

    public interface IBuild
    {
        Evaluation Biuld();
    }
}