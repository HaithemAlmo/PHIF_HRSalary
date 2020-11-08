using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class BounsExtensions
    {
        public static IEnumerable<BounsGridRow> ToBounsGrid(this IEnumerable<Employee> employees)
        {
            return employees.Select(d => new BounsGridRow()
            {
                EmployeeId = d.EmployeeId,
                ArabicFullName = d.GetFullName(),
                DepartmentName = d.JobInfo?.Unit?.Division?.Department?.Name,
                JobNumber = d.JobInfo?.GetJobNumber(),
                NationalNumber = d.NationalNumber,
                Boun = d.JobInfo?.Bouns ?? 0,
                DateMeritBoun =

              d.JobInfo?.DateBouns.FormatToString(),
                DivisionName = d.JobInfo?.Unit?.Division?.Name,
                MeritBoun = d.JobInfo?.Bouns + 1 ?? 0
            });
        }
    
    public static IEnumerable<BounsGridRow> ToBounsGridhr(this IEnumerable<Employee> employees)
    {
        return employees.Select(d => new BounsGridRow()
        {
            EmployeeId = d.EmployeeId,
            ArabicFullName = d.GetFullName(),
            DepartmentName = d.JobInfo?.Unit?.Division?.Department?.Name,
            JobNumber = d.JobInfo?.GetJobNumber(),
            NationalNumber = d.NationalNumber,
            Bounhr = d.JobInfo?.Bounshr ?? 0,
            DateMeritBounhr =
              d.JobInfo?.DateBounshr.FormatToString(),
 
            DivisionName = d.JobInfo?.Unit?.Division?.Name,
            MeritBoun = d.JobInfo?.Bounshr + 1 ?? 0
        });
    }
}
}