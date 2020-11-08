using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class StaffingTypeBusiness : Business, IStaffingTypeBusiness
    {
        public StaffingTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.StaffingType && permission;

        public StaffingTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingType_Create))
                return Null<StaffingTypeModel>(RequestState.NoPermission);

            return new StaffingTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.StaffingType_Create,
                CanEdit = ApplicationUser.Permissions.StaffingType_Edit,
                CanDelete = ApplicationUser.Permissions.StaffingType_Delete,
                StaffingTypeGrid = UnitOfWork.StaffingTypes
                    .GetAll()
                    .Select(a => new StaffingTypeGridRow()
                    {
                        StaffingTypeId = a.StaffingTypeId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(StaffingTypeModel model)
        {

        }

        public bool Select(StaffingTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.StaffingTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var staffingType = UnitOfWork.StaffingTypes.Find(model.StaffingTypeId);

            if (staffingType == null)
                return Fail(RequestState.NotFound);

            model.Name = staffingType.Name;
            return true;

        }

        public bool Create(StaffingTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.StaffingTypes.NameIsExisted(model.Name))
                return NameExisted();
            var staffingType = StaffingType.New(model.Name);
            UnitOfWork.StaffingTypes.Add(staffingType);

            UnitOfWork.Complete(n => n.StaffingType_Create);

            return SuccessCreate();


        }

        public bool Edit(StaffingTypeModel model)
        {
            if (model.StaffingTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.StaffingType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var staffingType = UnitOfWork.StaffingTypes.Find(model.StaffingTypeId);

            if (staffingType == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.StaffingTypes.NameIsExisted(model.Name, model.StaffingTypeId))
                return NameExisted();
            staffingType.Modify(model.Name);

            UnitOfWork.Complete(n => n.StaffingType_Edit);

            return SuccessEdit();
        }

        public bool Delete(StaffingTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.StaffingTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var staffingType = UnitOfWork.StaffingTypes.Find(model.StaffingTypeId);

            if (staffingType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.StaffingTypes.Remove(staffingType);

            if (!UnitOfWork.TryComplete(n => n.StaffingType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}