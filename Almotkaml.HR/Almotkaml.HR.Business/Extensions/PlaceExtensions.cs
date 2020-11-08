using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class PlaceExtensions
    {

        public static IEnumerable<PlaceGridRow> ToGrid(this IEnumerable<Place> places)
         => places.Select(p => new PlaceGridRow()
         {
             PlaceId = p.PlaceId,
             Name = p.Name,
             BranchId = p.BranchId,
             BranchName = p.Branch.Name
         });
        public static IEnumerable<PlaceListItem> ToList(this IEnumerable<Place> places)
         => places.Select(p => new PlaceListItem()
         {
             PlaceId = p.PlaceId,
             Name = p.Name,
         });
    }
}
