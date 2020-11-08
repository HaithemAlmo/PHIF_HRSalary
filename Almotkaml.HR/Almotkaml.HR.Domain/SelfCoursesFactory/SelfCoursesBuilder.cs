using System;

namespace Almotkaml.HR.Domain.SelfCoursesFactory
{
    public class SelfCoursesBuilder : IEmployeeIdHolder, ICourseNameHolder, IPlaceHolder, ISubSpecialtyIdHolder
        , IDateHolder, IResultHolder, IDurationHolder, ITrainingCenterHolder, IBuild
    {

        internal SelfCoursesBuilder() { }
        private SelfCourses SelfCourses { get; } = new SelfCourses();
        public ICourseNameHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            SelfCourses.EmployeeId = employeeId;
            return this;
        }

        public ICourseNameHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            SelfCourses.Employee = employee;
            return this;
        }

        public IPlaceHolder WithCourseName(string courseName)
        {
            Check.NotNull(courseName, nameof(courseName));
            SelfCourses.CourseName = courseName;
            return this;
        }

        public ISubSpecialtyIdHolder WithPlace(PlaceCourse place)
        {
            Check.NotNull(place, nameof(place));
            SelfCourses.Place = place;
            return this;
        }

        public IDateHolder WithSubSpecialtyId(int subSpecialtyId)
        {
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));
            SelfCourses.SubSpecialtyId = subSpecialtyId;
            return this;
        }

        public IResultHolder WithDate(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            SelfCourses.Date = date;
            return this;
        }

        public IDurationHolder WithResult(string result)
        {
            Check.NotNull(result, nameof(result));
            SelfCourses.Result = result;
            return this;
        }

        public ITrainingCenterHolder WithDuration(string duration)
        {
            Check.NotNull(duration, nameof(duration));
            SelfCourses.Duration = duration;
            return this;
        }

        public IBuild WithTrainingCenter(string trainingCenter)
        {
            Check.NotNull(trainingCenter, nameof(trainingCenter));
            SelfCourses.TrainingCenter = trainingCenter;
            return this;
        }

        public SelfCourses Biuld()
        {
            return SelfCourses;
        }

    }
}
