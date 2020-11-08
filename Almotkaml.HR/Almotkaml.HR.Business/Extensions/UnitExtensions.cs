using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class UnitExtensions
    {
        public static IEnumerable<UnitListItem> ToList(this IEnumerable<Unit> units)
            => units.Select(d => new UnitListItem()
            {
                Name = d.Name,
                UnitId = d.UnitId
            });

        public static IEnumerable<UnitGridRow> ToGrid(this IEnumerable<Unit> units)
            => units.Select(d => new UnitGridRow()
            {
                UnitId = d.UnitId,
                DivisionName = d.Division?.Name,
                Name = d.Name,
                DepartmentName = d.Division?.Department?.Name,
                CenterName = d.Division?.Department?.Center?.Name,
                DivisionId = d.DivisionId
            });
    }
}