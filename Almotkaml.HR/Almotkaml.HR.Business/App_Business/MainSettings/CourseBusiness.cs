using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CourseBusiness : Business, ICourseBusiness
    {
        public CourseBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Course && permission;

        public CourseIndexModel Index()
        {
            if (!HavePermission())
                return Null<CourseIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Courses.GetAll().ToGrid();

            return new CourseIndexModel()
            {
                CourseGrid = grid,
                CanCreate = ApplicationUser.Permissions.Course_Create,
                CanEdit = ApplicationUser.Permissions.Course_Edit,
                CanDelete = ApplicationUser.Permissions.Course_Delete,
            };
        }

        public void Refresh(CourseFormModel model)
        {
            if (model == null)
                return;

            model.CityList = model.CountryId > 0
                ? UnitOfWork.Cities.GetCityWithCountry(model.CountryId).ToList()
                : new HashSet<CityListItem>();

        }

        public CourseFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Course_Create))
                return Null<CourseFormModel>(RequestState.NoPermission);

            return new CourseFormModel()
            {
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                CanSubmit = ApplicationUser.Permissions.Course_Create
            };
        }

        public bool Create(CourseFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Course_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var course = Course.New()
                .WithTrainingType(model.TrainingType)
                .WithName(model.Name)
                .WithCoursePlace(model.CoursePlace)
                .WithCity(model.CityId)
                .WithFoundationName(model.FoundationName)
                .Biuld();

            UnitOfWork.Courses.Add(course);

            UnitOfWork.Complete(n => n.Course_Create);

            return SuccessCreate();
        }

        public CourseFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Course_Edit))
                return Null<CourseFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<CourseFormModel>(RequestState.BadRequest);

            var course = UnitOfWork.Courses.Find(id);

            if (course == null)
                return Null<CourseFormModel>(RequestState.NotFound);

            return new CourseFormModel()
            {
                CourseId = id,
                Name = course.Name,
                FoundationName = course.FoundationName,
                CoursePlace = course.CoursePlace,
                TrainingType = course.TrainingType,
                CountryId = course.City.CountryId,
                CityId = course.CityId,
                CityList = UnitOfWork.Cities.GetCityWithCountry(course.City.CountryId).ToList(),
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                CanSubmit = ApplicationUser.Permissions.Course_Edit,
            };
        }

        public bool Edit(int id, CourseFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Course_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var course = UnitOfWork.Courses.Find(id);

            if (course == null)
                return Fail(RequestState.NotFound);

            course.Modify()
                .TrainingType(model.TrainingType)
                .City(model.CityId)
                .CoursePlace(model.CoursePlace)
                .FoundationName(model.FoundationName)
                .Name(model.Name)
                .Confirm();

            UnitOfWork.Complete(n => n.Course_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, CourseFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Course_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var course = UnitOfWork.Courses.Find(id);

            if (course == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Courses.Remove(course);

            if (!UnitOfWork.TryComplete(n => n.Course_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}