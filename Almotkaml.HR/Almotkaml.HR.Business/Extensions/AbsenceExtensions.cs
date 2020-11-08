using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class AbsenceExtensions
    {

        public static IEnumerable<AbsenceGridRow> ToGrid(this IEnumerable<Absence> absences)
           => absences.Select(s => new AbsenceGridRow()
           {
               AbsenceDay=s.AbsenceDay,
               AbsenceId = s.AbsenceId,
               Date = s.Date.FormatToString(),
               Note = s.Note,
               AbsenceType = s.AbsenceType,
           });
    }
}
