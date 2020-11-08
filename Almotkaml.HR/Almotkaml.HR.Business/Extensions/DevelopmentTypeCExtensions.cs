using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DevelopmentTypeCExtensions
    {
        public static IEnumerable<DevelopmentTypeCGridRow> ToGrid(this IEnumerable<DevelopmentTypeC> developmentTypeCs)
           => developmentTypeCs.Select(d => new DevelopmentTypeCGridRow()
           {
               DevelopmentTypeCId = d.DevelopmentTypeCId,
               Name = d.Name,
               DevelopmentTypeAName = d.DevelopmentTypeB?.DevelopmentTypeA?.Name,
               DevelopmentTypeBName = d.DevelopmentTypeB?.Name,
               TrainingType = d.DevelopmentTypeB?.DevelopmentTypeA?.TrainingType ?? 0
           });
        public static IEnumerable<DevelopmentTypeCListItem> ToList(this IEnumerable<DevelopmentTypeC> developmentTypeCs)
            => developmentTypeCs.Select(d => new DevelopmentTypeCListItem()
            {
                Name = d.Name,
                DevelopmentTypeCId = d.DevelopmentTypeCId
            });
    }
}