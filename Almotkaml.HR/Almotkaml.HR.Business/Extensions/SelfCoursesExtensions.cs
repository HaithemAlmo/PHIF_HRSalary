using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SelfCoursesExtensions
    {
        public static IEnumerable<SelfCoursesGridRows> ToGrid(this IEnumerable<SelfCourses> selfCourseses)
         => selfCourseses.Select(a => new SelfCoursesGridRows()
         {

             SelfCourseId = a.SelfCoursesId,
             EmployeeName = a.Employee?.GetFullName(),
             CourseName = a.CourseName,
             Place = a.Place,
             Date = a.Date,
             SpecialtyName = a.SubSpecialty.Specialty.Name,
             SubSpecialtyName = a.SubSpecialty.Name,
             Result = a.Result,
             Duration = a.Duration,
             TrainingCenter = a.TrainingCenter
         });
    }
}
