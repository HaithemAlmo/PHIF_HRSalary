using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SelfCoursesBusiness : Business, ISelfCoursesBusiness
    {
        public SelfCoursesBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
        => ApplicationUser.Permissions.SelfCourse && permission;


        public SelfCoursesModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SelfCourse_Create))
                return Null<SelfCoursesModel>(RequestState.NoPermission);

            return new SelfCoursesModel()
            {
                CanCreate = ApplicationUser.Permissions.SelfCourse_Create,
                CanEdit = ApplicationUser.Permissions.SelfCourse_Edit,
                CanDelete = ApplicationUser.Permissions.SelfCourse_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                SelfCoursesGrid = UnitOfWork.SelfCourses.GetSelfCourseByEmployeeId(0).ToGrid(),
                SpecialtyListItems = UnitOfWork.Specialties.GetAll().ToList()


            };
        }

        public void Refresh(SelfCoursesModel model)
        {

            model.SelfCoursesGrid = UnitOfWork.SelfCourses.GetSelfCourseByEmployeeId(model.EmployeeId).ToGrid();
            model.SubSpecialtyListItems = model.SpecialtyId > 0
                ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
                : new HashSet<SubSpecialtyListItem>();


            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();

        }

        public bool Select(SelfCoursesModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SelfCourse_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SelfCourseId <= 0)
                return Fail(RequestState.BadRequest);

            var selfCourse = UnitOfWork.SelfCourses.Find(model.SelfCourseId);

            if (selfCourse == null)
                return Fail(RequestState.NotFound);
            var specialtyId = selfCourse.SubSpecialty?.Specialty?.SpecialtyId ?? 0;

            model.SelfCourseId = selfCourse.SelfCoursesId;

            model.EmployeeId = selfCourse.EmployeeId;
            model.EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid();
            model.EmployeeName = selfCourse.Employee.GetFullName();
            model.CourseName = selfCourse.CourseName;
            model.Place = selfCourse.Place;
            model.Date = selfCourse.Date.ToString();
            model.SubSpecialtyId = selfCourse.SubSpecialtyId;
            model.Result = selfCourse.Result;
            model.Duration = selfCourse.Duration;
            model.TrainingCenter = selfCourse.TrainingCenter;

            model.SpecialtyListItems = UnitOfWork.Specialties.GetAll().ToList();
            model.SubSpecialtyListItems = UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(specialtyId).ToList();
            model.SpecialtyId = specialtyId;

            return true;
        }

        public bool Create(SelfCoursesModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SelfCourse_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var selfCourse = SelfCourses.New()
                .WithEmployeeId(model.EmployeeId)
                .WithCourseName(model.CourseName)
                .WithPlace(model.Place)
                .WithSubSpecialtyId(model.SubSpecialtyId)
                .WithDate(model.Date.ToDateTime())
                .WithResult(model.Result)
                .WithDuration(model.Duration)
                .WithTrainingCenter(model.TrainingCenter)
                .Biuld();
            UnitOfWork.SelfCourses.Add(selfCourse);

            UnitOfWork.Complete(n => n.SelfCourse_Create);
            Clear(model);

            return SuccessCreate();
        }

        public bool Edit(SelfCoursesModel model)
        {
            if (model.SelfCourseId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.SelfCourse_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var selfCourse = UnitOfWork.SelfCourses.Find(model.SelfCourseId);

            if (selfCourse == null)
                return Fail(RequestState.NotFound);

            selfCourse.Modify()
                 .Employee(model.EmployeeId)
                .CourseName(model.CourseName)
                .Place(model.Place)
                .SubSpecialtyId(model.SubSpecialtyId)
                .Date(model.Date.ToDateTime())
                .Result(model.Result)
                .Duration(model.Duration)
                .TrainingCenter(model.TrainingCenter)
                .Confirm();

            UnitOfWork.Complete(n => n.SelfCourse_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(SelfCoursesModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SelfCourse_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SelfCourseId <= 0)
                return Fail(RequestState.BadRequest);

            var selfCourse = UnitOfWork.SelfCourses.Find(model.SelfCourseId);

            if (selfCourse == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.SelfCourses.Remove(selfCourse);

            if (!UnitOfWork.TryComplete(n => n.SelfCourse_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(SelfCoursesModel model)
        {
            model.SelfCourseId = 0;
            model.Date = "";
            model.CourseName = "";
            model.Duration = "";
            model.Place = 0;
            model.Result = "";
            model.SpecialtyId = 0;
            model.SubSpecialtyId = 0;
            model.TrainingCenter = "";
        }
    }
}
