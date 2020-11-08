using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SanctionExtensions
    {

        public static IEnumerable<SanctionGridRow> ToGrid(this IEnumerable<Sanction> sanctions)
           => sanctions.Select(s => new SanctionGridRow()
           {
               SanctionId = s.SanctionId,
               EmployeeId = s.EmployeeId,
               EmployeeName = s.Employee.GetFullName(),
               Date = s.Date.FormatToString(),
               Cause = s.Cause,
               SanctionTypeId = s.SanctionTypeId,
               SanctionTypeName = s.SanctionType.Name
           });
    }
}
