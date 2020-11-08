namespace Almotkaml.HR.Domain.CourseFactory
{
    public class CourseModifier
    {
        internal CourseModifier(Course course)
        {
            Course = course;
        }
        private Course Course { get; }
        public CourseModifier TrainingType(TrainingType trainingType)
        {
            Course.TrainingType = trainingType;
            return this;
        }

        public CourseModifier Name(string name)
        {
            Course.Name = name;
            return this;
        }

        public CourseModifier CoursePlace(CoursePlace coursePlace)
        {
            Course.CoursePlace = coursePlace;
            return this;
        }

        public CourseModifier City(City city)
        {
            Course.City = city;
            Course.CityId = city.CityId;
            return this;
        }

        public CourseModifier City(int cityId)
        {
            Course.CityId = cityId;
            return this;
        }

        public CourseModifier FoundationName(string foundationName)
        {
            Course.FoundationName = foundationName;
            return this;
        }

        public Course Confirm()
        {
            return Course;
        }
    }
}