using System;

namespace Almotkaml.HR.Domain.EvaluationFactory
{
    public class EvaluationModifier
    {
        internal EvaluationModifier(Evaluation evaluation)
        {
            Evaluation = evaluation;
        }
        private Evaluation Evaluation { get; }

        public EvaluationModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            Evaluation.EmployeeId = employeeId;
            return this;
        }
        public EvaluationModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            Evaluation.Employee = employee;
            Evaluation.EmployeeId = employee.EmployeeId;

            return this;
        }
        public EvaluationModifier Grade(Grade grade)
        {
            Check.NotNull(grade, nameof(grade));
            Evaluation.Grade = grade;
            return this;
        }
        public EvaluationModifier Ratio(double? ratio)
        {
            Evaluation.Ratio = ratio;
            return this;
        }

        public EvaluationModifier Year(int? year)
        {
            Evaluation.Year = year;
            return this;
        }

        public EvaluationModifier Date(DateTime? date)
        {
            Evaluation.Date = date;
            return this;
        }
        public EvaluationModifier Note(string note)
        {
            Evaluation.Note  = note;
            return this;
        }
        public Evaluation Confirm()
        {
            return Evaluation;
        }
    }


}