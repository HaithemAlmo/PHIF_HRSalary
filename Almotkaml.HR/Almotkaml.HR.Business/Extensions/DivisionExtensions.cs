using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DivisionExtensions
    {
        public static IEnumerable<DivisionListItem> ToList(this IEnumerable<Division> divisions)
            => divisions.Select(d => new DivisionListItem()
            {
                Name = d.Name,
                DivisionId = d.DivisionId
            });

        public static IEnumerable<DivisionGridRow> ToGrid(this IEnumerable<Division> divisions)
            => divisions.Select(d => new DivisionGridRow()
            {
                DivisionId = d.DivisionId,
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Department?.Name,
                Name = d.Name,
                CenterName = d.Department?.Center?.Name
            });
    }
}
