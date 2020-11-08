using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class TrainingCourse
    {
        public static TrainingCourse New(string name, string executingAgency, int subSpecialtyId, DateTime date, string result)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));

            var trainingCourse = new TrainingCourse()
            {
                Name = name,
                ExecutingAgency = executingAgency,
                SubSpecialtyId = subSpecialtyId,
                Date = date,
                Result = result
            };


            return trainingCourse;
        }
        public static TrainingCourse New(string name, string executingAgency, SubSpecialty subSpecialty, DateTime date, string result)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(subSpecialty, nameof(subSpecialty));

            var trainingCourse = new TrainingCourse()
            {
                Name = name,
                ExecutingAgency = executingAgency,
                SubSpecialty = subSpecialty,
                Date = date,
                Result = result
            };


            return trainingCourse;
        }
        private TrainingCourse()
        {

        }
        public int TrainingCourseId { get; private set; }
        public string Name { get; private set; }
        public string ExecutingAgency { get; private set; }
        public PlaceCourse PlaceCourse { get; private set; }
        public int SubSpecialtyId { get; private set; }
        public SubSpecialty SubSpecialty { get; private set; }
        public DateTime Date { get; private set; }
        public string Result { get; private set; }
        public ICollection<Employee> Employees { get; } = new HashSet<Employee>();
        public void Modify(string name, string executingAgency, int subSpecialtyId, DateTime date, string result)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(subSpecialtyId, nameof(subSpecialtyId));

            Name = name;
            ExecutingAgency = executingAgency;
            SubSpecialtyId = subSpecialtyId;
            SubSpecialty = null;
            Date = date;
            Result = result;

        }
        public void Modify(string name, string executingAgency, SubSpecialty subSpecialty, DateTime date, string result)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(subSpecialty, nameof(subSpecialty));

            Name = name;
            ExecutingAgency = executingAgency;
            SubSpecialty = subSpecialty;
            Date = date;
            Result = result;

        }

    }

}