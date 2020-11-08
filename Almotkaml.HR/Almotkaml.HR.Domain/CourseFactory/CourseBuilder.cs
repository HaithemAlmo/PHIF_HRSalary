namespace Almotkaml.HR.Domain.CourseFactory
{
    public class CourseBuilder : ITrainingTypeHolder, INameHolder, ICoursePlaceHolder, ICityHolder, INameFoundationHolder, IBuild
    {

        internal CourseBuilder() { }
        private Course Course { get; } = new Course();

        public INameHolder WithTrainingType(TrainingType trainingType)
        {
            Course.TrainingType = trainingType;
            return this;
        }

        public ICoursePlaceHolder WithName(string name)
        {
            Course.Name = name;
            return this;
        }

        public ICityHolder WithCoursePlace(CoursePlace coursePlace)
        {
            Course.CoursePlace = coursePlace;
            return this;
        }

        public INameFoundationHolder WithCity(City city)
        {
            Course.City = city;
            Course.CityId = city.CityId;
            return this;
        }

        public INameFoundationHolder WithCity(int cityId)
        {
            Course.CityId = cityId;
            return this;
        }

        public IBuild WithFoundationName(string foundationName)
        {
            Course.FoundationName = foundationName;
            return this;
        }
        public Course Biuld()
        {
            return Course;
        }
    }
}