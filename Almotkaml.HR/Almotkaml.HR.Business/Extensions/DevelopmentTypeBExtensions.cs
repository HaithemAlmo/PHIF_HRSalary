using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DevelopmentTypeBExtensions
    {
        public static IEnumerable<DevelopmentTypeBGridRow> ToGrid(this IEnumerable<DevelopmentTypeB> developmentTypeBs)
           => developmentTypeBs.Select(d => new DevelopmentTypeBGridRow()
           {
               DevelopmentTypeBId = d.DevelopmentTypeBId,
               Name = d.Name,
               DevelopmentTypeAName = d.DevelopmentTypeA?.Name,
               TrainingType = d.DevelopmentTypeA?.TrainingType ?? 0
           });
        public static IEnumerable<DevelopmentTypeBListItem> ToList(this IEnumerable<DevelopmentTypeB> DevelopmentTypeBs)
            => DevelopmentTypeBs.Select(d => new DevelopmentTypeBListItem()
            {
                Name = d.Name,
                DevelopmentTypeBId = d.DevelopmentTypeBId
            });
    }
}