using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class VacationExtensions
    {
        public static IEnumerable<VacationGridRow> ToGrid(this IEnumerable<Vacation> vacations)
            => vacations.Select(v => new VacationGridRow()
            {
                VacationId = v.VacationId,
                DateFrom = v.DateFrom.FormatToString(),
                DateTo = v.DateTo.FormatToString(),
                VacationTypeName = v.VacationType.Name,
                Days = v.GetDays(v.DateFrom, v.DateTo, v.VacationTypeId), //(int)(v.DateTo - v.DateFrom).TotalDays,
                DecisionNumber = v.DecisionNumber,
                DecisionDate = v.DecisionDate.FormatToString(),
                Place = v.Place ? "داخلية" : "خارجية"
            });

        public static IEnumerable<VacationGridRow> ToGrid2(this IEnumerable<Vacation> vacations)
          => vacations.Select(v => new VacationGridRow()
          {
              VacationId = v.VacationId,
              DateFrom = v.DateFrom.FormatToString(),
              DateTo = v.DateTo.FormatToString(),
              VacationTypeName = v.VacationType.Name,
              Days = v.GetDays2(v.DateFrom, v.DateTo), //(int)(v.DateTo - v.DateFrom).TotalDays,
                DecisionNumber = v.DecisionNumber,
              DecisionDate = v.DecisionDate.FormatToString(),
              Place = v.Place ? "داخلية" : "خارجية"
          });
    }
}