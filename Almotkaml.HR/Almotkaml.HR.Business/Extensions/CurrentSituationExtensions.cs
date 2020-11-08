using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CurrentSituationExtensions
    {
        public static IEnumerable<CurrentSituationListItem> ToList(this IEnumerable<CurrentSituation> currentSituations)
            => currentSituations.Select(d => new CurrentSituationListItem()
            {
                Name = d.Name,
                CurrentSituationId = d.CurrentSituationId
            });
        public static IList<CurrentSituationListItem> ToList2(this IEnumerable<CurrentSituation> currentSituations)
        => currentSituations.Select(d => new CurrentSituationListItem()
        {
            Name = d.Name,
            CurrentSituationId = d.CurrentSituationId,
            IsSelected = false
        }).ToList();
    }
}