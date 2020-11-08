using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class RetirementExtensions
    {
        public static IEnumerable<RetirementGridRow> ToRetirementGrid(this IEnumerable<Employee> employees)
            => employees.Select(d => new RetirementGridRow()
            {
                EmployeeId = d.EmployeeId,
                ArabicFullName = d.GetFullName(),
                DepartmentName = d.JobInfo?.Unit?.Division?.Department?.Name,
                JobNumber = d.JobInfo?.GetJobNumber(),
                NationalNumber = d.NationalNumber,
                DivisionName = d.JobInfo?.Unit?.Division?.Name,
                CenterName = d.JobInfo?.Unit?.Division?.Department?.Center?.Name,
            });
    }
}