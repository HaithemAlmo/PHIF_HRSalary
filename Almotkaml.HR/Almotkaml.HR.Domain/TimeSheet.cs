using Almotkaml.HR.Domain.TimeSheetFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class TimeSheet
    {
        internal TimeSheet()
        {

        }
        public static IEmployeeIdHolder New()
        {
            return new TimeSheetBuilder();
        }

        public long TimeSheetId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public string HourAccess { get; internal set; }
        public string Hourleave { get; internal set; }
        public DateTime Date { get; internal set; }

        public TimeSheetModifier Modify()
        {
            return new TimeSheetModifier(this);
        }




    }
}
