using Almotkaml.HR.Domain.EvaluationFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Evaluation
    {
        internal Evaluation() { }

        public static IEmployeeIdHolder New()
        {
            return new EvaluationBuilder();
        }
        public int EvaluationId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public Grade Grade { get; internal set; }
        public double? Ratio { get; internal set; }
        public int? Year { get; internal set; }
        public DateTime? Date { get; internal set; }
        public string Note { get; internal set; }
        public EvaluationModifier Modify()
        {
            return new EvaluationModifier(this);
        }

    }
}
