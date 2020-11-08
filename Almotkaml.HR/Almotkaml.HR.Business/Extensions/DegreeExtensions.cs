using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DegreeExtensions
    {
        public static IList<DegreeGridRow> ToDegreeGrid(this IEnumerable<Employee> employees)
        {
            var grid = new List<DegreeGridRow>();
            foreach (var employee in employees)
            {
                var date = employee.JobInfo?.DateDegreeNow;
                int Mon = employee.JobInfo.DateDegreeNow.Value.Month;
                int Day = employee.JobInfo.DateDegreeNow.Value.Day;
                var firstHalfYear = new DateTime(date.GetValueOrDefault().Year,Mon,Day);
                var secondHalfYear = new DateTime(date.GetValueOrDefault().Year, Mon, Day);

                grid.Add(new DegreeGridRow()
                {
                    EmployeeId = employee.EmployeeId,
                    ArabicFullName = employee.GetFullName(),
                    DepartmentName = employee.JobInfo?.Unit?.Division?.Department?.Name,
                    DivisionName = employee.JobInfo?.Unit?.Division?.Name,
                    JobNumber = employee.JobInfo?.GetJobNumber(),
                    NationalNumber = employee.NationalNumber,
                    Boun = employee.JobInfo?.Bouns ?? 0,
                    Degree = employee.JobInfo?.Degree ?? 0,
                    DegreeNow = employee.JobInfo?.DegreeNow ?? 0,
                    DateDegreeNow = employee.JobInfo?.DateDegreeNow.FormatToString(),
                    MeritDegreeNow = employee.JobInfo?.DegreeNow + 1 ?? 0,
                    //MeritBoun = (employee.JobInfo?.DegreeNow < 10 && employee.JobInfo.DegreeNow != null)
                    // ? employee.JobInfo?.Bouns - 4 ?? 0
                    // : (employee.JobInfo?.DegreeNow == 10 && employee.JobInfo.DegreeNow != null)
                    // ? employee.JobInfo?.Bouns - 5 ?? 0
                    // : employee.JobInfo?.Bouns - 1 ?? 0,
                    DateMeritDegreeNow =
                     date <= firstHalfYear && employee.JobInfo?.DegreeNow < 10 && date != null
                     ? firstHalfYear.AddYears(4).FormatToString()
                     : (employee.JobInfo?.DegreeNow == 10 || employee.JobInfo?.DegreeNow == 11 ) && date != null && date <= firstHalfYear
                     ? firstHalfYear.AddYears(5).FormatToString()
                     : employee.JobInfo?.DegreeNow > 11 && date != null && date <= firstHalfYear
                     ? firstHalfYear.AddYears(7).FormatToString()
                     : date >= firstHalfYear && date <= secondHalfYear && employee.JobInfo?.DegreeNow < 10 && date != null
                     ? secondHalfYear.AddYears(4).FormatToString()
                     : (employee.JobInfo?.DegreeNow == 10 || employee.JobInfo?.DegreeNow == 11) && date != null && date >= firstHalfYear && date <= secondHalfYear
                     ? secondHalfYear.AddYears(5).FormatToString()
                     : employee.JobInfo?.DegreeNow > 11 && date != null && date >= firstHalfYear && date <= secondHalfYear
                     ? secondHalfYear.AddYears(7).FormatToString()
                     : "",
                    JobId = employee.JobInfo?.JobId ?? 0,
                });
            }
            return grid;
            //return employees.Select(d => new DegreeGridRow()
            //{
            //    EmployeeId = d.EmployeeId,
            //    ArabicFullName = d.GetFullName(),
            //    DepartmentName = d.JobInfo?.Unit?.Division?.Department?.Name,
            //    DivisionName = d.JobInfo?.Unit?.Division?.Name,
            //    JobNumber = d.JobInfo?.JobNumber,
            //    NationalNumber = d.NationalNumber,
            //    Boun = d.JobInfo?.Bouns ?? 0,
            //    Degree = d.JobInfo?.Degree ?? 0,
            //    DegreeNow = d.JobInfo?.DegreeNow ?? 0,
            //    DateDegreeNow = d.JobInfo?.DateDegreeNow.FormatToString(),
            //    MeritDegreeNow = d.JobInfo?.DegreeNow + 1 ?? 0,
            //    MeritBoun = (d.JobInfo?.DegreeNow < 10 && d.JobInfo.DegreeNow != null)
            //        ? d.JobInfo?.Bouns - 4 ?? 0
            //        : (d.JobInfo?.DegreeNow == 10 && d.JobInfo.DegreeNow != null)
            //            ? d.JobInfo?.Bouns - 5 ?? 0
            //            : d.JobInfo?.Bouns - 1 ?? 0,
            //    DateMeritDegreeNow = d.JobInfo != null && d.JobInfo.DateDegreeNow.GetValueOrDefault() <=
            //    new DateTime(d.JobInfo.DateDegreeNow.GetValueOrDefault().Year, 6, 30) && d.JobInfo?.DegreeNow < 10
            //    && d.JobInfo.DegreeNow != null
            //        ? new DateTime(d.JobInfo.DateDegreeNow.GetValueOrDefault().AddYears(4).Year, 6, 30).FormatToString()
            //        : d.JobInfo?.DegreeNow == 10 && d.JobInfo.DegreeNow != null
            //            ? d.JobInfo?.DateDegreeNow?.AddYears(5).FormatToString()
            //            : d.JobInfo?.DateDegreeNow?.AddYears(1).FormatToString(),
            //    JobId = d.JobInfo?.JobId ?? 0,
            //}).ToList();
        }
    }
}