using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DepartmentBusiness : Business, IDepartmentBusiness
    {
        public DepartmentBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Department && permission;


        public DepartmentModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Create))
                return Null<DepartmentModel>(RequestState.NoPermission);

            return new DepartmentModel()
            {
                CanCreate = ApplicationUser.Permissions.Department_Create,
                CanEdit = ApplicationUser.Permissions.Department_Edit,
                CanDelete = ApplicationUser.Permissions.Department_Delete,
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                DepartmentGrid = UnitOfWork.Departments.GetAll().ToGrid()
            };
        }

        public void Refresh(DepartmentModel model)
        {

        }

        public bool Select(DepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            var department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (department == null)
                return Fail(RequestState.NotFound);

            model.Name = department.Name;
            model.CenterId = department.CenterId;
            return true;

        }

        public bool Create(DepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Departments.DepartmentExisted(model.Name, model.CenterId))
                return NameExisted();
            var department = Department.New(model.Name, model.CenterId);
            UnitOfWork.Departments.Add(department);

            UnitOfWork.Complete(n => n.Department_Create);

            return SuccessCreate();


        }

        public bool Edit(DepartmentModel model)
        {
            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Department_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (department == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Departments.DepartmentExisted(model.Name, model.CenterId, model.DepartmentId))
                return NameExisted();
            department.Modify(model.Name, model.CenterId);

            UnitOfWork.Complete(n => n.Department_Edit);

            return SuccessEdit();
        }

        public bool Delete(DepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            var department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (department == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Departments.Remove(department);

            if (!UnitOfWork.TryComplete(n => n.Department_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

    }
}