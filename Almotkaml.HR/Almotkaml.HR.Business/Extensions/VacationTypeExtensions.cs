using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class VacationTypeExtensions
    {
        public static IEnumerable<VacationTypeListItem> ToList(this IEnumerable<VacationType> vacationTypes)
            => vacationTypes.Select(d => new VacationTypeListItem()
            {
                Name = d.Name,
                VacationTypeId = d.VacationTypeId
            });

        public static IEnumerable<VacationTypeGridRow> ToGrid(this IEnumerable<VacationType> vacationTypes)
            => vacationTypes.Select(d => new VacationTypeGridRow()
            {
                VacationTypeId = d.VacationTypeId,
                Name = d.Name,
                CanEditAndDelete = d.VacationEssential == VacationEssential.UnKounw
                //Days = d.Days,
                //DiscountPercentage = d.DiscountPercentage,
            });
    }
}