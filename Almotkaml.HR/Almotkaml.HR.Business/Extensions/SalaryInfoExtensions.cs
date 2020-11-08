using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SalaryInfoExtensions
    {

        public static IEnumerable<SalaryInfoGridRow> ToGridEmployee(this IEnumerable<Employee> employee)
            => employee.Select(s => new SalaryInfoGridRow()
            {
                Active=s.IsActive,
                BasicSalary = s.SalaryInfo?.BasicSalary ?? 0,
                EmployeeId = s.EmployeeId,
                
                EmployeeName = s.GetFullName(),
                Edit = s.SalaryInfo?.BasicSalary == null || s.SalaryInfo?.BasicSalary == 0
            });
    }
}