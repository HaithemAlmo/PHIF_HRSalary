using Almotkaml.Erp.Accounting.Domain;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CenterExtensions
    {
        public static IEnumerable<CenterGridRow> ToGrid(this IEnumerable<Center> centers, IList<ICostCenter> costCenters)
           => centers.Select(d => new CenterGridRow()
           {
               Name = d.Name,
               CenterId = d.CenterId,
               CostCenterName = costCenters.FirstOrDefault(c => c.CostCenterId == d.CostCenterId)?.Name,
               
           });
        public static IEnumerable<CenterGridRow> ToGrid(this IEnumerable<Center> centers)
           => centers.Select(d => new CenterGridRow()
           {
               Name = d.Name,
               CenterId = d.CenterId,
           });

        public static IEnumerable<CenterListItem> ToList(this IEnumerable<Center> centers)
           => centers.Select(d => new CenterListItem()
           {
               Name = d.Name,
               CenterId = d.CenterId,
           });
    }
}
