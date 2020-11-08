using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class CourseExtensions
    {
        public static IEnumerable<CourseGridRow> ToGrid(this IEnumerable<Course> courses)
            => courses.Select(d => new CourseGridRow()
            {
                CourseId = d.CourseId,
                Name = d.Name,
                CoursePlace = d.CoursePlace,
                CityName = d.City?.Name,
                CountryName = d.City?.Country?.Name,
                NameFoundation = d.FoundationName,
                TrainingType = d.TrainingType
            });
        public static IEnumerable<CourseListItem> ToList(this IEnumerable<Course> courses)
            => courses.Select(d => new CourseListItem()
            {
                CourseId = d.CourseId,
                Name = d.Name,
            });
    }
}