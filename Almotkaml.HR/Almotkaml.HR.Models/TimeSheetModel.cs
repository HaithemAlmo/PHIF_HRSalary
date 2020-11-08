using System;
using System.Collections.Generic;
using Almotkaml.Attributes;
using Almotkaml.Extensions;

namespace Almotkaml.HR.Models
{
    public class TimeSheetIndexModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public string Message { get; set; }
        [TrueDate]
        public string Date { get; set; }
        public DateTime GetDate() => Date.ToDateTime();
        public IEnumerable<TimeSheetGridRow> TimeSheetGridRows { get; set; } = new HashSet<TimeSheetGridRow>();
    }

    public class TimeSheetGridRow
    {
        public long TimeSheetId { get; set; }
        public string EmployeeName { get; set; }
        public string HourAccess { get; set; }
        public string Hourleave { get; set; }
        public DateTime Date { get; set; }
    }

    public class TimeSheetFormModel : IValidatable
    {
        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        public string HourAccess { get; set; }
        public string Hourleave { get; set; }
        [TrueDate]
        public string Date { get; set; }
        public DateTime GetDate() => Date.ToDateTime();
        public bool IsValid() => true;
        public string ValidationMessage { get; set; }
        public bool CanSubmit { get; set; }
    }

}


