using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DevelopmentTypeAExtensions
    {
        public static IEnumerable<DevelopmentTypeAGridRow> ToGrid(this IEnumerable<DevelopmentTypeA> developmentTypeAs)
           => developmentTypeAs.Select(d => new DevelopmentTypeAGridRow()
           {
               DevelopmentTypeAId = d.DevelopmentTypeAId,
               Name = d.Name,
               TrainingType = d.TrainingType

           });
        public static IEnumerable<DevelopmentTypeAListItem> ToList(this IEnumerable<DevelopmentTypeA> developmentTypeAs)
            => developmentTypeAs.Select(d => new DevelopmentTypeAListItem()
            {
                Name = d.Name,
                DevelopmentTypeAId = d.DevelopmentTypeAId
            });
    }
}