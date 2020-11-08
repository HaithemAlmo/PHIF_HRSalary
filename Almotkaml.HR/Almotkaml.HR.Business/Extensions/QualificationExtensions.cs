using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class QualificationExtensions
    {
        public static IEnumerable<QualificationGridRow> ToGrid(this IEnumerable<Qualification> qualifications)
          => qualifications.Select(q => new QualificationGridRow()
          {
              QualificationId = q.QualificationId,
              Date = q.Date.FormatToString(),
              GraduationCountry = q.GraduationCountry,
              EmployeeId = q.EmployeeId,
              EmployeeName = q.Employee?.GetFullName(),
              NameDonorFoundation = q.NameDonorFoundation,
              QualificationTypeId = q.QualificationTypeId,
              QualificationTypeName = q.QualificationType?.Name,
              ExactSpecialtyId = q.ExactSpecialtyId ?? 0,
              ExactSpecialtyName = q.ExactSpecialty?.Name,
              SubSpecialtyId = q.ExactSpecialty?.SubSpecialtyId ?? 0,
              SubSpecialtyName = q.SubSpecialty?.Name ?? q.ExactSpecialty?.SubSpecialty?.Name,
              SpecialtyId = q.ExactSpecialty?.SubSpecialty?.Specialty?.SpecialtyId ?? 0,
              SpecialtyName = q.Specialty?.Name ?? q.SubSpecialty?.Specialty?.Name ?? q.ExactSpecialty?.SubSpecialty?.Specialty?.Name,
              AquiredSpecialty = q.AquiredSpecialty
          });
    }
}
