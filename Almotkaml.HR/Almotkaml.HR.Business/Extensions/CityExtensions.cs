using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CityExtensions
    {
        public static IEnumerable<CityListItem> ToList(this IEnumerable<City> cities)
            => cities.Select(d => new CityListItem()
            {
                Name = d.Name,
                CityId = d.CityId
            });

        public static IEnumerable<CityGridRow> ToGrid(this IEnumerable<City> cities)
            => cities.Select(d => new CityGridRow()
            {
                CityId = d.CityId,
                CountryId = d.CountryId,
                CountryName = d.Country?.Name,
                Name = d.Name
            });
    }
}