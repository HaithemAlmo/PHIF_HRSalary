using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CoachExtensions
    {
        public static IEnumerable<CoachGridRow> ToGrid(this IEnumerable<Coach> coachs)
            => coachs.Select(d => new CoachGridRow()
            {
                CoachId = d.CoachId,
                Name = d.CoachType == CoachType.Inside ? d.Employee?.GetFullName()
                : d.Name,
                Phone = d.CoachType == CoachType.Inside ? d.Employee?.Phone
                : d.Phone
            });
        public static IEnumerable<CoachListItem> ToList(this IEnumerable<Coach> coachs)
            => coachs.Select(d => new CoachListItem()
            {
                Name = d.Name,
                CoachId = d.CoachId
            });
    }
}