using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;


namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class StaffingBusiness : Business, IStaffingBusiness
    {
        public StaffingBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Staffing && permission;

        public StaffingModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Staffing_Create))
                return Null<StaffingModel>(RequestState.NoPermission);

            return new StaffingModel()
            {
                CanCreate = ApplicationUser.Permissions.Staffing_Create,
                CanEdit = ApplicationUser.Permissions.Staffing_Edit,
                CanDelete = ApplicationUser.Permissions.Staffing_Delete,
                StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList(),
                StaffingGrid = UnitOfWork.Staffings
                    .GetStaffingWithStaffingType().ToGrid()

            };
        }

        public void Refresh(StaffingModel model)
        {

        }

        public bool Select(StaffingModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Staffing_Edit))
                return Fail(RequestState.NoPermission);
            if (model.StaffingId <= 0)
                return Fail(RequestState.BadRequest);

            var staffing = UnitOfWork.Staffings.Find(model.StaffingId);

            if (staffing == null)
                return Fail(RequestState.NotFound);
            model.StaffingTypeId = staffing.StaffingTypeId;
            model.Name = staffing.Name;
            return true;
        }

        public bool Create(StaffingModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Staffing_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Staffings.StaffingExisted(model.Name, model.StaffingTypeId, model.StaffingId))
                return NameExisted();
            var staffing = Staffing.New(model.Name, model.StaffingTypeId);
            UnitOfWork.Staffings.Add(staffing);

            UnitOfWork.Complete(n => n.Staffing_Create);

            return SuccessCreate();
        }

        public bool Edit(StaffingModel model)
        {
            if (model.StaffingId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Staffing_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var staffing = UnitOfWork.Staffings.Find(model.StaffingId);

            if (staffing == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Staffings.StaffingExisted(model.Name, model.StaffingTypeId, model.StaffingId))
                return NameExisted();
            staffing.Modify(model.Name, model.StaffingTypeId);

            UnitOfWork.Complete(n => n.Staffing_Edit);

            return SuccessEdit();
        }

        public bool Delete(StaffingModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Staffing_Delete))
                return Fail(RequestState.NoPermission);

            if (model.StaffingId <= 0)
                return Fail(RequestState.BadRequest);

            var staffing = UnitOfWork.Staffings.Find(model.StaffingId);

            if (staffing == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Staffings.Remove(staffing);

            if (!UnitOfWork.TryComplete(n => n.Staffing_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}