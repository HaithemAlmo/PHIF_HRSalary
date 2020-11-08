using System;

namespace Almotkaml.HR.Domain
{
    public class Holiday
    {
        public static Holiday New(string name, short dayFrom, short dayTo, short monthFrom, short monthTo)
        {
            var holiday = new Holiday()
            {
                Name = name,
                DayFrom = dayFrom,
                DayTo = dayTo,
                MonthFrom = monthFrom,
                MonthTo = monthTo
            };

            return holiday;
        }

        private Holiday()
        {

        }
        public int HolidayId { get; set; }
        public string Name { get; set; }
        public short DayFrom { get; set; }
        public short DayTo { get; set; }
        public short MonthFrom { get; set; }
        public short MonthTo { get; set; }
        public DateTime DateFrom(int year) => new DateTime(year, MonthFrom, DayFrom);
        public DateTime DateTo(int year) => MonthTo < MonthFrom
            ? new DateTime(year + 1, MonthTo, DayTo)
            : new DateTime(year, MonthTo, DayTo);

        public void Modify(string name, short dayFrom, short dayTo, short monthFrom, short monthTo)
        {
            Name = name;
            DayFrom = dayFrom;
            DayTo = dayTo;
            MonthFrom = monthFrom;
            MonthTo = monthTo;
        }

    }
}