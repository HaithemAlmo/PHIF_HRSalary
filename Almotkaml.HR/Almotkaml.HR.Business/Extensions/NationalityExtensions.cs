using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class NationalityExtensions
    {
        public static IEnumerable<NationalityGridRow> ToGrid(this IEnumerable<Nationality> nationalities)
          => nationalities.Select(d => new NationalityGridRow()
          {
              NationalityId = d.NationalityId,
              Name = d.Name
          });
        public static IEnumerable<NationalityListItem> ToList(this IEnumerable<Nationality> nationalities)
          => nationalities.Select(d => new NationalityListItem()
          {
              NationalityId = d.NationalityId,
              Name = d.Name
          });
    }
}
