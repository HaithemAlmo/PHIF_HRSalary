using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DevelopmentStateExtensions
    {
        public static IEnumerable<DevelopmentStateGridRow> ToGrid(this IEnumerable<DevelopmentState> developmentStates)
           => developmentStates.Select(d => new DevelopmentStateGridRow()
           {
               DevelopmentStateId = d.DevelopmentStateId,
               Name = d.Name
           });
        public static IEnumerable<DevelopmentStateListItem> ToList(this IEnumerable<DevelopmentState> developmentStates)
            => developmentStates.Select(d => new DevelopmentStateListItem()
            {
                Name = d.Name,
                DevelopmentStateId = d.DevelopmentStateId
            });
    }
}