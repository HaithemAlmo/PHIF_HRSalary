using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class UnitBusiness : Business, IUnitBusiness
    {
        public UnitBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Unit && permission;

        public UnitModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Unit_Create))
                return Null<UnitModel>(RequestState.NoPermission);

            return new UnitModel()
            {
                CanCreate = ApplicationUser.Permissions.Unit_Create,
                CanEdit = ApplicationUser.Permissions.Unit_Edit,
                CanDelete = ApplicationUser.Permissions.Unit_Delete,
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                UnitGrid = UnitOfWork.Units.GetUnitWithDivision().ToGrid()
            };
        }

        public void Refresh(UnitModel model)
        {
            if (model == null)
                return;

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId).ToList()
                : new HashSet<DepartmentListItem>();

            model.DivisionList = model.DepartmentId > 0
                ? UnitOfWork.Divisions.GetDivisionWithDepartment(model.DepartmentId).ToList()
                : new HashSet<DivisionListItem>();

        }

        public bool Select(UnitModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Unit_Edit))
                return Fail(RequestState.NoPermission);
            if (model.UnitId <= 0)
                return Fail(RequestState.BadRequest);

            var unit = UnitOfWork.Units.Find(model.UnitId);

            if (unit == null)
                return Fail(RequestState.NotFound);

            var centerId = unit.Division?.Department?.CenterId ?? 0;
            var departmentId = unit.Division?.DepartmentId ?? 0;
            model.CenterId = centerId;
            model.DepartmentId = departmentId;
            model.DivisionId = unit.DivisionId;
            model.DivisionList = UnitOfWork.Divisions.GetDivisionWithDepartment(departmentId).ToList();
            model.DepartmentList = UnitOfWork.Departments.GetDepartmentWithCenter(centerId).ToList();
            model.Name = unit.Name;
            return true;
        }

        public bool Create(UnitModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Unit_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Units.UnitExisted(model.Name, model.DivisionId))
                return NameExisted();

            var unit = Unit.New(model.Name, model.DivisionId);

            UnitOfWork.Units.Add(unit);

            UnitOfWork.Complete(n => n.Unit_Create);

            return SuccessCreate();
        }

        public bool Edit(UnitModel model)
        {
            if (model.UnitId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Unit_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var unit = UnitOfWork.Units.Find(model.UnitId);

            if (unit == null)
                return Fail(RequestState.NotFound);
            if (UnitOfWork.Units.UnitExisted(model.Name, model.DivisionId, model.UnitId))
                return NameExisted();

            unit.Modify(model.Name, model.DivisionId);

            UnitOfWork.Complete(n => n.Unit_Edit);

            return SuccessEdit();
        }

        public bool Delete(UnitModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Unit_Delete))
                return Fail(RequestState.NoPermission);

            if (model.UnitId <= 0)
                return Fail(RequestState.BadRequest);

            var unit = UnitOfWork.Units.Find(model.UnitId);

            if (unit == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Units.Remove(unit);

            if (!UnitOfWork.TryComplete(n => n.Unit_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }



    }
}