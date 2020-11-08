using Almotkaml.Attributes;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class TimeSheetIndexModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


        [Date]
        public string Date { get; set; }
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

    public class TimeSheetFormModel
    {

        public int EmployeeId { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        public string HourAccess { get; set; }
        public string Hourleave { get; set; }
        [Date]
        public string Date { get; set; }
        public bool CanSubmit { get; set; }
    }


}


