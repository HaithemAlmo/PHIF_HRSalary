using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class EndServiceExtensions
    {
        public static IEnumerable<EndServicesGridRow> ToGrid(this IEnumerable<EndServices> endServiceses)
          => endServiceses.Select(d => new EndServicesGridRow()
          {

              EndServicesId = d.EndServicesId,
              EmployeeName = d.Employee?.GetFullName(),
              CauseOfEndService = d.CauseOfEndService,
              DecisionDate = d.DecisionDate.ToString(),
              Cause = d.Cause,
              DecisionNumber = d.DecisionNumber
          });
    }
}
