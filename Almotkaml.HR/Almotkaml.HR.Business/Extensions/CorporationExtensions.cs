using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CorporationExtensions
    {
        public static IEnumerable<CorporationGridRow> ToGrid(this IEnumerable<Corporation> corporations)
          => corporations.Select(d => new CorporationGridRow()
          {
              CorporationId = d.CorporationId,
              Name = d.Name,
              Address = d.Address,
              CityName = d.City?.Name,
              CountryName = d.City?.Country?.Name,
              Email = d.Email,
              Phone = d.Phone,
              Note = d.Note
          });
    }
}
