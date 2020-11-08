using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SpecialtyExtensions
    {
        public static IEnumerable<SpecialtyListItem> ToList(this IEnumerable<Specialty> specialtys)
            => specialtys.Select(d => new SpecialtyListItem()
            {
                Name = d.Name,
                SpecialtyId = d.SpecialtyId
            });
    }
}