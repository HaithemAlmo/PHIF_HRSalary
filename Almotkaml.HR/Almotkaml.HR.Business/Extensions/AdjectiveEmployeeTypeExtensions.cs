using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class AdjectiveEmployeeTypeExtensions
    {
        public static IEnumerable<AdjectiveEmployeeTypeListItem> ToList(this IEnumerable<AdjectiveEmployeeType> adjectiveEmployeeTypes)
            => adjectiveEmployeeTypes.Select(d => new AdjectiveEmployeeTypeListItem()
            {
                Name = d.Name,
                AdjectiveEmployeeTypeId = d.AdjectiveEmployeeTypeId
            });

        public static IEnumerable<AdjectiveEmployeeTypeGridRow> ToGrid(this IEnumerable<AdjectiveEmployeeType> adjectiveEmployeeTypes)
            => adjectiveEmployeeTypes.Select(d => new AdjectiveEmployeeTypeGridRow()
            {
                AdjectiveEmployeeTypeId = d.AdjectiveEmployeeTypeId,
                Name = d.Name,
            });
    }
}