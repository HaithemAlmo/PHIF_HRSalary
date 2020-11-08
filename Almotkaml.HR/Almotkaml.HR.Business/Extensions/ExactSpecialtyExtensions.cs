using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class ExactSpecialtyExtensions
    {
        public static IEnumerable<ExactSpecialtyListItem> ToList(this IEnumerable<ExactSpecialty> exactSpecialties)
            => exactSpecialties.Select(d => new ExactSpecialtyListItem()
            {
                Name = d.Name,
                ExactSpecialtyId = d.ExactSpecialtyId
            });

        public static IEnumerable<ExactSpecialtyGridRow> ToGrid(this IEnumerable<ExactSpecialty> exactSpecialties)
            => exactSpecialties.Select(d => new ExactSpecialtyGridRow()
            {
                ExactSpecialtyId = d.ExactSpecialtyId,
                SubSpecialtyName = d.SubSpecialty?.Name,
                Name = d.Name,
                SpecialtyName = d.SubSpecialty?.Specialty?.Name,
                SubSpecialtyId = d.SubSpecialtyId
            });
    }
}