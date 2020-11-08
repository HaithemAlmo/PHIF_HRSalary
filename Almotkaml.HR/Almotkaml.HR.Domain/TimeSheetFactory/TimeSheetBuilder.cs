using System;

namespace Almotkaml.HR.Domain.TimeSheetFactory
{
    public class TimeSheetBuilder : IEmployeeIdHolder, IHourAccessHolder, IHourleaveHolder, IDateHolder, IBuild
    {

        internal TimeSheetBuilder() { }
        private TimeSheet TimeSheet { get; } = new TimeSheet();

        public IHourAccessHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            TimeSheet.EmployeeId = employeeId;
            return this;
        }

        public IHourAccessHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            TimeSheet.Employee = employee;
            TimeSheet.EmployeeId = employee.EmployeeId;

            return this;
        }

        public IHourleaveHolder WithHourAccess(string hourAccess)
        {
            Check.NotNull(hourAccess, nameof(hourAccess));
            TimeSheet.HourAccess = hourAccess;
            return this;

        }

        public IDateHolder WithHourleave(string hourleave)
        {
            Check.NotNull(hourleave, nameof(hourleave));
            TimeSheet.Hourleave = hourleave;
            return this;
        }

        public IBuild WithDate(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            TimeSheet.Date = date;
            return this;
        }

        public TimeSheet Biuld()
        {
            return TimeSheet;
        }

    }

}