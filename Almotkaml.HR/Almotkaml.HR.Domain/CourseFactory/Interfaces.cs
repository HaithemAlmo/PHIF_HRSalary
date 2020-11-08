namespace Almotkaml.HR.Domain.CourseFactory
{
    public interface ITrainingTypeHolder
    {
        INameHolder WithTrainingType(TrainingType trainingType);
    }
    public interface INameHolder
    {
        ICoursePlaceHolder WithName(string name);
    }
    public interface ICoursePlaceHolder
    {
        ICityHolder WithCoursePlace(CoursePlace coursePlace);
    }
    public interface ICityHolder
    {
        INameFoundationHolder WithCity(City city);
        INameFoundationHolder WithCity(int cityId);
    }
    public interface INameFoundationHolder
    {
        IBuild WithFoundationName(string foundationName);
    }

    public interface IBuild
    {
        Course Biuld();
    }
}