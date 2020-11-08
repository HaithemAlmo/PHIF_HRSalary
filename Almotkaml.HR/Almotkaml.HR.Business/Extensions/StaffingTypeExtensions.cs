using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class StaffingTypeExtensions
    {
        public static IEnumerable<StaffingTypeListItem> ToList(this IEnumerable<StaffingType> staffingTypes)
            => staffingTypes.Select(d => new StaffingTypeListItem()
            {
                Name = d.Name,
                StaffingTypeId = d.StaffingTypeId
            });
    }
}