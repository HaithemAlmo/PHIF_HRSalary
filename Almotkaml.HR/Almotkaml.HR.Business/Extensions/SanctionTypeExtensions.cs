using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SanctionTypeExtensions
    {
        public static IEnumerable<SanctionTypeListItem> ToList(this IEnumerable<SanctionType> sanctionTypes)
            => sanctionTypes.Select(d => new SanctionTypeListItem()
            {
                Name = d.Name,
                SanctionTypeId = d.SanctionTypeId
            });
    }
}