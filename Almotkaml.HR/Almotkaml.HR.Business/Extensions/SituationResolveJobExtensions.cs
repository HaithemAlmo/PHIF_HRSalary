using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SituationResolveJobExtensions
    {
        public static IEnumerable<SituationResolveJobGrid> ToGrid(this IEnumerable<SituationResolveJob> rewards)
          => rewards.Select(s => new SituationResolveJobGrid()
          {
              SituationResolveJobId = s.SituationResolveJobId,
              DegreeNow = s.DegreeNow,
              EmployeeName = s.Employee?.GetFullName(),
              Degree = s.Degree ?? 0,
              Boun = s.Boun ?? 0,
              BounNow = s.BounNow,
              DecisionNumber = s.DecisionNumber,
              DecisionDate = s.DecisionDate.FormatToString(),
              DateDegreeLast = s.DateDegreeLast.FormatToString(),
              DateBounLast = s.DateBounLast.FormatToString(),
              JobNowName = s.JobNow?.Name
          });
    }
}
