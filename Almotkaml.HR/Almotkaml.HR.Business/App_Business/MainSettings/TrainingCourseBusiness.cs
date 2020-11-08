using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TrainingCourseBusiness : Business, ITrainingCourseBusiness
    {
        public TrainingCourseBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
        => ApplicationUser.Permissions.TrainingCourse && permission;

        public TrainingCourseIndexModel Index()
        {
            if (!HavePermission())
                return Null<TrainingCourseIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.TrainingCourses
                .GetAll().ToGrid();


            return new TrainingCourseIndexModel()
            {
                TrainingCourseGrid = grid,
                CanCreate = ApplicationUser.Permissions.TrainingCourse_Create,
                CanEdit = ApplicationUser.Permissions.TrainingCourse_Edit,
                CanDelete = ApplicationUser.Permissions.TrainingCourse_Delete,
            };
        }

        public void Refresh(TrainingCourseFormModel model)
        {
            throw new System.NotImplementedException();
        }

        public TrainingCourseFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.TrainingCourse_Create))
                return Null<TrainingCourseFormModel>(RequestState.NoPermission);


            var employeeGrid = UnitOfWork.Employees
                .GetAll();

            return new TrainingCourseFormModel()
            {
                //TrainingCourseTypeList = TrainingCourseTypeList,
                //EmployeeGrid = employeeGrid.ToGrid()
            };
        }

        public bool Create(TrainingCourseFormModel model)
        {
            throw new System.NotImplementedException();
        }

        public TrainingCourseFormModel Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(int id, TrainingCourseFormModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id, TrainingCourseFormModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
