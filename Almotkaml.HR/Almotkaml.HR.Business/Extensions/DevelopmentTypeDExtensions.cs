using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DevelopmentTypeDExtensions
    {
        public static IEnumerable<DevelopmentTypeDGridRow> ToGrid(this IEnumerable<DevelopmentTypeD> developmentTypeDs)
           => developmentTypeDs.Select(d => new DevelopmentTypeDGridRow()
           {
               DevelopmentTypeDId = d.DevelopmentTypeDId,
               Name = d.Name,
               DevelopmentTypeAName = d.DevelopmentTypeC?.DevelopmentTypeB?.DevelopmentTypeA?.Name,
               DevelopmentTypeBName = d.DevelopmentTypeC?.DevelopmentTypeB?.Name,
               DevelopmentTypeCName = d.DevelopmentTypeC?.Name,
               TrainingType = d.DevelopmentTypeC?.DevelopmentTypeB?.DevelopmentTypeA?.TrainingType ?? 0,
           });
        public static IEnumerable<DevelopmentTypeDListItem> ToList(this IEnumerable<DevelopmentTypeD> developmentTypeDs)
            => developmentTypeDs.Select(d => new DevelopmentTypeDListItem()
            {
                Name = d.Name,
                DevelopmentTypeDId = d.DevelopmentTypeDId
            });
    }
}