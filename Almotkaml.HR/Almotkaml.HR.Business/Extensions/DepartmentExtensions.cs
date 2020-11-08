using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DepartmentExtensions
    {
        public static IEnumerable<DepartmentGridRow> ToGrid(this IEnumerable<Department> departments)
           => departments.Select(d => new DepartmentGridRow()
           {
               Name = d.Name,
               DepartmentId = d.DepartmentId,
               CenterName = d.Center?.Name,
               CenterId = d.CenterId,

           });
        public static IEnumerable<DepartmentListItem> ToList(this IEnumerable<Department> departments)
           => departments.Select(d => new DepartmentListItem()
           {
               Name = d.Name,
               DepartmentId = d.DepartmentId,
           });
    }
}
