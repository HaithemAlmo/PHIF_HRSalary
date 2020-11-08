using System;

namespace Almotkaml.HR.Domain.SelfCoursesFactory
{
    public interface IEmployeeIdHolder
    {
        ICourseNameHolder WithEmployeeId(int employeeId);
        ICourseNameHolder WithEmployee(Employee employee);
    }
    public interface ICourseNameHolder
    {
        IPlaceHolder WithCourseName(string courseName);
    }
    public interface IPlaceHolder
    {
        ISubSpecialtyIdHolder WithPlace(PlaceCourse	 place);
    }
    public interface ISubSpecialtyIdHolder
    {
        IDateHolder WithSubSpecialtyId(int subSpecialtyId);
    }
    public interface IDateHolder
    {
        IResultHolder WithDate(DateTime date);

    }
    public interface IResultHolder
    {
        IDurationHolder WithResult(string result);
    }

    public interface IDurationHolder
    {
        ITrainingCenterHolder WithDuration(string duration);
    }
    public interface ITrainingCenterHolder
    {
        IBuild WithTrainingCenter(string trainingCenter);
    }

    public interface IBuild
    {
        SelfCourses Biuld();
    }

}