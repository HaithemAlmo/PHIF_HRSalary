using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class StaffingClassificationExtensions
    {
        public static IEnumerable<StaffingClassificationListItem> ToList(this IEnumerable<StaffingClassification> staffings)
            => staffings.Select(d => new StaffingClassificationListItem()
            {
                Name = d.Name,
                StaffingClassificationId = d.StaffingClassificationId

            });

        public static IEnumerable<StaffingClassificationGridRow> ToGrid(this IEnumerable<StaffingClassification> staffings)
            => staffings.Select(d => new StaffingClassificationGridRow()
            {
                StaffingId = d.StaffingId,
                StaffingClassificationId = d.StaffingClassificationId,
                StaffingName = d.Staffing?.Name,
                Name = d.Name
            });
    }
}