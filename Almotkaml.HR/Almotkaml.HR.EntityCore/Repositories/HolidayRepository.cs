using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        private HrDbContext Context { get; }

        internal HolidayRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Holidays
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Holidays
            .Any(e => e.Name == name && e.HolidayId != idToExcept);

        public int HolidayCount(DateTime dateFrom, DateTime dateTo)
        {
            var count = 0;
            var holidays = Context.Holidays;
            foreach (var holiday in holidays)
            {
                var holidayStart = new DateTime(DateTime.Now.Year, holiday.MonthFrom, holiday.DayFrom);
                var holidayEnd = new DateTime(DateTime.Now.Year, holiday.MonthTo, holiday.DayTo);

                for (var i = dateFrom; i <= dateTo;)
                {
                    if (holidayStart <= holidayEnd && holidayStart == i && !(i.DayOfWeek == DayOfWeek.Friday
                        || i.DayOfWeek == DayOfWeek.Saturday))
                    {
                        holidayStart = holidayStart.AddDays(1);
                        count += 1;
                    }
                    i = i.AddDays(1);
                }
            }
            return count;
        }
    }
}