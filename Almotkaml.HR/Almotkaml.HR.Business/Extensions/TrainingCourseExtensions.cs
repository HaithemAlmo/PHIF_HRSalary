using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class TrainingCourseExtensions
    {
        public static IEnumerable<TrainingCourseGridRow> ToGrid(this IEnumerable<TrainingCourse> trainingCourses)
          => trainingCourses.Select(d => new TrainingCourseGridRow()
          {
              Name = d.Name,
              Date = d.Date.ToString(),
              SpecialtyName = d.SubSpecialty.Name,
              ExecutingAgency = d.ExecutingAgency,
              PlaceCourse = d.PlaceCourse,
              Result = d.Result,
              TrainingCourseId = d.TrainingCourseId
          });
    }
}
