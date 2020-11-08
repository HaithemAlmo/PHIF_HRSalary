using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class EvaluationExtensions
    {


        public static IEnumerable<EvaluationGrirgRow> ToGrid(this IEnumerable<Evaluation> evaluations)
          => evaluations.Select(a => new EvaluationGrirgRow()
          {
              EvaluationId = a.EvaluationId,
              EmployeeName = a.Employee.GetFullName(),
              Grade = a.Grade,
              Ratio = a.Ratio.GetValueOrDefault(),
              Year = a.Year.GetValueOrDefault(),
              Date = a.Date.FormatToString()
          });
    }
}
