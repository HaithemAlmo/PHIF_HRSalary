using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CountryExtensions
    {
        public static IEnumerable<CountryListItem> ToList(this IEnumerable<Country> countries)
           => countries.Select(d => new CountryListItem()
           {
               Name = d.Name,
               CountryId = d.CountryId
           });
    }
}
