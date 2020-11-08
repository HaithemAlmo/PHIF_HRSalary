using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class StaffingExtensions
    {
        public static IEnumerable<StaffingListItem> ToList(this IEnumerable<Staffing> staffings)
            => staffings.Select(d => new StaffingListItem()
            {
                Name = d.Name,
                StaffingId = d.StaffingId
            });

        public static IEnumerable<StaffingGridRow> ToGrid(this IEnumerable<Staffing> staffings)
            => staffings.Select(d => new StaffingGridRow()
            {
                StaffingId = d.StaffingId,
                StaffingTypeId = d.StaffingTypeId,
                StaffingTypeName = d.StaffingType?.Name,
                Name = d.Name
            });
    }
}