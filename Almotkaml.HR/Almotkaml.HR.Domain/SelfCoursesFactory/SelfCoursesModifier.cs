using System;

namespace Almotkaml.HR.Domain.SelfCoursesFactory
{
    public class SelfCoursesModifier
    {
        internal SelfCoursesModifier(SelfCourses selfCourses)
        {
            SelfCourses = selfCourses;
        }
        private SelfCourses SelfCourses { get; }

        public SelfCoursesModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            SelfCourses.EmployeeId = employeeId;
            return this;
        }

        public SelfCoursesModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            SelfCourses.Employee = employee;
            return this;
        }

        public SelfCoursesModifier CourseName(string courseName)
        {
            Check.NotNull(courseName, nameof(courseName));
            SelfCourses.CourseName = courseName;
            return this;
        }

        public SelfCoursesModifier Place(PlaceCourse place)
        {
            Check.NotNull(place, nameof(place));
            SelfCourses.Place = place;
            return this;
        }

        public SelfCoursesModifier SubSpecialtyId(int subSpecialtyId)
        {
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));
            SelfCourses.SubSpecialtyId = subSpecialtyId;
            return this;
        }

        public SelfCoursesModifier Date(DateTime date)
        {
            Check.NotNull(date, nameof(date));
            SelfCourses.Date = date;
            return this;
        }

        public SelfCoursesModifier Result(string result)
        {
            Check.NotNull(result, nameof(result));
            SelfCourses.Result = result;
            return this;
        }

        public SelfCoursesModifier Duration(string duration)
        {
            Check.NotNull(duration, nameof(duration));
            SelfCourses.Duration = duration;
            return this;
        }

        public SelfCoursesModifier TrainingCenter(string trainingCenter)
        {
            Check.NotNull(trainingCenter, nameof(trainingCenter));
            SelfCourses.TrainingCenter = trainingCenter;
            return this;
        }
        public SelfCourses Confirm()
        {
            return SelfCourses;
        }
    }


}