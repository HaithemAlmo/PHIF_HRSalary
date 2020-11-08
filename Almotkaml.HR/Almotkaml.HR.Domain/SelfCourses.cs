using Almotkaml.HR.Domain.SelfCoursesFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class SelfCourses
    {

        public static IEmployeeIdHolder New()
        {
            return new SelfCoursesBuilder();
        }
        internal SelfCourses() { }

        public int SelfCoursesId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public string CourseName { get; internal set; }
        public PlaceCourse Place { get; internal set; }
        public int SubSpecialtyId { get; internal set; }
        public SubSpecialty SubSpecialty { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Result { get; internal set; }
        public string Duration { get; internal set; }
        public string TrainingCenter { get; internal set; }

        public SelfCoursesModifier Modify()
        {
            return new SelfCoursesModifier(this);
        }







    }

}
