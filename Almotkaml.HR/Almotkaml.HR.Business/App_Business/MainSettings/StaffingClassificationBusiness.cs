using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class StaffingClassificationBusiness : Business, IStaffingClassificationBusiness
    {
        public StaffingClassificationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Staffing && permission;

        public StaffingClassificationModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Staffing_Create))
                return Null<StaffingClassificationModel>(RequestState.NoPermission);
            
            return new StaffingClassificationModel()
            {
                CanCreate = ApplicationUser.Permissions.Staffing_Create,
                CanEdit = ApplicationUser.Permissions.Staffing_Edit,
                CanDelete = ApplicationUser.Permissions.Staffing_Delete,
                StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList(),
                StaffingClassificationGrid = UnitOfWork.StaffingClassification.GetWithStaffings().ToGrid()

            };
        }

        public void Refresh(StaffingClassificationModel model)
        {
            model.StaffingTypeList = UnitOfWork.StaffingTypes.GetAll().ToList();

            model.StaffingList = model.StaffingTypeId > 0
                ? UnitOfWork.Staffings.GetStaffingWithStaffingType(model.StaffingTypeId ?? 0).ToList()
                : new HashSet<StaffingListItem>();

            model.StaffingClassificationGrid = model.StaffingId > 0
                ? UnitOfWork.StaffingClassification.GetWithStaffings(model.StaffingId>0  ? model.StaffingId :  0).ToGrid()
                : model.StaffingClassificationGrid;
        }

        public bool Select(StaffingClassificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingClassification_Edit))
                return Fail(RequestState.NoPermission);
            if (model.StaffingClassificationId <= 0)
                return Fail(RequestState.BadRequest);

            var staffing = UnitOfWork.StaffingClassification.Find(model.StaffingClassificationId);

            if (staffing == null)
                return Fail(RequestState.NotFound);

            model.StaffingTypeId = staffing.Staffing?.StaffingTypeId;
            model.StaffingId = staffing.StaffingId;
            model.StaffingClassificationId = staffing.StaffingClassificationId;
            model.Name = staffing.Name;
            return true;
        }

        public bool Create(StaffingClassificationModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.StaffingClassification_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.StaffingClassification.StaffingClassificationExisted(model.Name, model.StaffingId))
                return NameExisted();
            var staffingClassification = StaffingClassification.New(model.Name, model.StaffingId);
            UnitOfWork.StaffingClassification.Add(staffingClassification);

            UnitOfWork.Complete(n => n.StaffingClassification_Create);

            return SuccessCreate();
        }

        public bool Edit(StaffingClassificationModel model)
        {
            if (model.StaffingClassificationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.StaffingClassification_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var staffingClassification = UnitOfWork.StaffingClassification.Find(model.StaffingClassificationId);

            if (staffingClassification == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.StaffingClassification.StaffingClassificationExisted(model.Name, model.StaffingId))
                return NameExisted();
            staffingClassification.Modify(model.Name, model.StaffingId);

            UnitOfWork.Complete(n => n.StaffingClassification_Edit);

            return SuccessEdit();
        }

        public bool Delete(StaffingClassificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.StaffingClassification_Delete))
                return Fail(RequestState.NoPermission);

            if (model.StaffingClassificationId <= 0)
                return Fail(RequestState.BadRequest);

            var staffingClassification = UnitOfWork.StaffingClassification.Find(model.StaffingClassificationId);

            if (staffingClassification == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.StaffingClassification.Remove(staffingClassification);

            if (!UnitOfWork.TryComplete(n => n.StaffingClassification_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}