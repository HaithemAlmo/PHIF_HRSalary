using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class AdjectiveEmployeeExtensions
    {
        public static IEnumerable<AdjectiveEmployeeListItem> ToList(this IEnumerable<AdjectiveEmployee> adjectiveEmployees)
            => adjectiveEmployees.Select(d => new AdjectiveEmployeeListItem()
            {
                Name = d.Name,
                AdjectiveEmployeeId = d.AdjectiveEmployeeId
            });

        public static IEnumerable<AdjectiveEmployeeGridRow> ToGrid(this IEnumerable<AdjectiveEmployee> adjectiveEmployees)
            => adjectiveEmployees.Select(d => new AdjectiveEmployeeGridRow()
            {
                AdjectiveEmployeeId = d.AdjectiveEmployeeId,
                AdjectiveEmployeeTypeId = d.AdjectiveEmployeeTypeId,
                AdjectiveEmployeeTypeName = d.AdjectiveEmployeeType?.Name,
                Name = d.Name
            });
    }
}