using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DelegationExtensions
    {
        public static IEnumerable<DelegationGridRow> ToGrid(this IEnumerable<Delegation> delegationes)
            => delegationes.Select(d => new DelegationGridRow()
            {

                DelegationId = d.DelegationId,
                SideName = d.SideName,
                JobTypeTransfer = d.JobTypeTransfer,
                DateTo = d.DateTo.FormatToString(),
                DateFrom = d.DateFrom.FormatToString(),
                JobNumber = d.JobNumber,
                Name = d.Name
            });
    }
}