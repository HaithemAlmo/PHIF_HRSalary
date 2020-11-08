using System;

namespace Almotkaml.HR.Domain.EvaluationFactory
{
    public class EvaluationBuilder : IEmployeeIdHolder, IGradeHolder, IRatioHolder,INoteHolder, IYearHolder, IDateHolder, IBuild
    {

        internal EvaluationBuilder() { }
        private Evaluation Evaluation { get; } = new Evaluation();

        public IGradeHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Evaluation.EmployeeId = employeeId;
            return this;
        }

        public IGradeHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Evaluation.Employee = employee;
            return this;
        }

        public IRatioHolder WithGrade(Grade grade)
        {
            Check.NotNull(grade, nameof(grade));
            Evaluation.Grade = grade;
            return this;
        }

        public IYearHolder WithRatio(double? ratio)
        {

            if (!((ratio >= 0 && ratio <= 100) || ratio == null))
                throw new ArgumentOutOfRangeException(nameof(ratio));

            Evaluation.Ratio = ratio;
            return this;

        }

        public IDateHolder WithYear(int? year)
        {
            Evaluation.Year = year;
            return this;
        }

        //public IBuild WithDate(DateTime? date)
        //{
        //    Evaluation.Date = date;
        //    return this;
        //}
        public Evaluation Biuld()
        {
            return Evaluation;
        }

        public IBuild WithNote(string note)
        {
            Evaluation.Note = note;
          return this;
        }

        public INoteHolder WithDate(DateTime? date)
        {
            Evaluation.Date = date;
             return this;
            //    return this;

        }

      

    }

}