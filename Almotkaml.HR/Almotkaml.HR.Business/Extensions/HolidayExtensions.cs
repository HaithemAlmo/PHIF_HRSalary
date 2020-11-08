using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class HolidayExtensions
    {
        public static IEnumerable<HolidayGridRow> ToGrid(this IEnumerable<Holiday> Holidays)
           => Holidays.Select(d => new HolidayGridRow()
           {
               HolidayId = d.HolidayId,
               Name = d.Name,
               DayFrom = d.DayFrom,
               DayTo = d.DayTo,
               MonthFrom = d.MonthFrom,
               MonthTo = d.MonthTo
           });
    }
}