using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class ExtraWorkExtensions
    {
        public static IEnumerable<ExtraWorkGridRow> ToGrid(this IEnumerable<Extrawork> extraworks)
          => extraworks.Select(a => new ExtraWorkGridRow()
          {
              ExtraworkId = a.ExtraworkId,
              EmployeeName = a.Employee?.GetFullName(),
              TimeCount = a.TimeCount,
              DecisionNumber = a.DecisionNumber,
              Date = a.Date,
              DateFrom = a.DateFrom,
              DateTo = a.DateTo
          });
    }
}
