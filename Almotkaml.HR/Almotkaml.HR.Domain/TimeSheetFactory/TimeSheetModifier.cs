using System;

namespace Almotkaml.HR.Domain.TimeSheetFactory
{
    public class TimeSheetModifier
    {
        internal TimeSheetModifier(TimeSheet timeSheet)
        {
            TimeSheet = timeSheet;
        }
        private TimeSheet TimeSheet { get; }

        public TimeSheetModifier WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            TimeSheet.EmployeeId = employeeId;
            return this;
        }

        public TimeSheetModifier WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            TimeSheet.Employee = employee;
            TimeSheet.EmployeeId = employee.EmployeeId;

            return this;
        }

        public TimeSheetModifier WithHourAccess(string hourAccess)
        {
            Check.NotNull(hourAccess, nameof(hourAccess));
            TimeSheet.HourAccess = hourAccess;
            return this;

        }

        public TimeSheetModifier WithHourleave(string hourleave)
        {
            Check.NotNull(hourleave, nameof(hourleave));
            TimeSheet.Hourleave = hourleave;
            return this;
        }

        public TimeSheetModifier WithDate(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            TimeSheet.Date = date;
            return this;
        }

        public TimeSheet Confirm()
        {
            return TimeSheet;
        }
    }


}