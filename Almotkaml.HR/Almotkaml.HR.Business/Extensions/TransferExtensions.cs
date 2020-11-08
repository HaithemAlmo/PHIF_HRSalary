using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class TransferExtensions
    {

        public static IEnumerable<TransferGridRow> ToGrid(this IEnumerable<Transfer> transfers)
            => transfers.Select(s => new TransferGridRow()
            {
                TransferId = s.TransferId,
                EmployeeId = s.EmployeeId,
                EmployeeName = s.Employee.GetFullName(),
                JobTypeTransfer = s.JobTypeTransfer,
                SideName = s.SideName,
                DateTo = s.DateTo.FormatToString(),
                DateFrom = s.DateFrom.FormatToString()
            });
    }
}