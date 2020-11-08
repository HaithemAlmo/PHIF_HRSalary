using Almotkaml.HR.Domain.CourseFactory;

namespace Almotkaml.HR.Domain
{
    public class Course
    {
        internal Course()
        {

        }
        public static ITrainingTypeHolder New() => new CourseBuilder();

        public int CourseId { get; set; }
        public TrainingType TrainingType { get; set; }
        public string Name { get; set; }
        public CoursePlace CoursePlace { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string FoundationName { get; set; }
        public CourseModifier Modify() => new CourseModifier(this);

    }


}