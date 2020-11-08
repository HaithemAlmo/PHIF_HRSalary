using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DivisionBusiness : Business, IDivisionBusiness
    {
        public DivisionBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Division && permission;


        public DivisionModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Division_Create))
                return Null<DivisionModel>(RequestState.NoPermission);

            return new DivisionModel()
            {
                CanCreate = ApplicationUser.Permissions.Department_Create,
                CanEdit = ApplicationUser.Permissions.Department_Edit,
                CanDelete = ApplicationUser.Permissions.Department_Delete,
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                DivisionGrid = UnitOfWork.Divisions.GetDivisionWithDepartment().ToGrid()

            };
        }

        public void Refresh(DivisionModel model)
        {
            if (model == null)
                return;

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId).ToList()
                : new HashSet<DepartmentListItem>();
        }

        public bool Select(DivisionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Division_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DivisionId <= 0)
                return Fail(RequestState.BadRequest);

            var division = UnitOfWork.Divisions.Find(model.DivisionId);

            if (division == null)
                return Fail(RequestState.NotFound);

            var centerId = division.Department?.CenterId ?? 0;

            model.DepartmentId = division.DepartmentId;
            model.CenterId = centerId;
            model.Name = division.Name;
            model.DepartmentList = UnitOfWork.Departments.GetDepartmentWithCenter(centerId).ToList();
            return true;
        }

        public bool Create(DivisionModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Division_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Divisions.DivisionExisted(model.Name, model.DepartmentId))
                return NameExisted();

            var division = Division.New(model.Name, model.DepartmentId);
            UnitOfWork.Divisions.Add(division);

            UnitOfWork.Complete(n => n.Division_Create);

            return SuccessCreate();
        }

        public bool Edit(DivisionModel model)
        {
            if (model.DivisionId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Division_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var division = UnitOfWork.Divisions.Find(model.DivisionId);

            if (division == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Divisions.DivisionExisted(model.Name, model.DepartmentId, model.DivisionId))
                return NameExisted();
            division.Modify(model.Name, model.DepartmentId);

            UnitOfWork.Complete(n => n.Division_Edit);

            return SuccessEdit();
        }

        public bool Delete(DivisionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Division_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DivisionId <= 0)
                return Fail(RequestState.BadRequest);

            var division = UnitOfWork.Divisions.Find(model.DivisionId);

            if (division == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Divisions.Remove(division);

            if (!UnitOfWork.TryComplete(n => n.Division_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}