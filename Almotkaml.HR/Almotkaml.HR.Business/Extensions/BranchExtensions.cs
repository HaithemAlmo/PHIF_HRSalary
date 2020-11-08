using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class BranchExtensions
    {
        public static IEnumerable<BranchListItem> ToList(this IEnumerable<Branch> branches)
         => branches.Select(d => new BranchListItem()
         {
             Name = d.Name,
             BranchId = d.BranchId
         });
    }
}
