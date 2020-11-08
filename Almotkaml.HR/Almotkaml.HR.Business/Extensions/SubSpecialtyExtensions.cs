using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SubSpecialtyExtensions
    {

        public static IEnumerable<SubSpecialtyListItem> ToList(this IEnumerable<SubSpecialty> subSpecialtys)
            => subSpecialtys.Select(d => new SubSpecialtyListItem()
            {
                Name = d.Name,
                SubSpecialtyId = d.SubSpecialtyId
            });

        public static IEnumerable<SubSpecialtyGridRow> ToGrid(this IEnumerable<SubSpecialty> subSpecialtys)
            => subSpecialtys.Select(d => new SubSpecialtyGridRow()
            {
                SubSpecialtyId = d.SubSpecialtyId,
                SpecialtyId = d.SpecialtyId,
                SpecialtyName = d.Specialty?.Name,
                Name = d.Name
            });
    }
}