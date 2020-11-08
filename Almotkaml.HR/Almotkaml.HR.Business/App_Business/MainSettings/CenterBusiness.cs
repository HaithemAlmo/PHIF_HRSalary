using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CenterBusiness : Business, ICenterBusiness
    {
        public CenterBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Center && permission;


        public CenterModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Center_Create))
                return Null<CenterModel>(RequestState.NoPermission);

            var costCenters = ErpUnitOfWork.CostCenters.GetAll();

            return new CenterModel()
            {
                //CostCenterList = 
                CanCreate = ApplicationUser.Permissions.Center_Create,
                CanEdit = ApplicationUser.Permissions.Center_Edit,
                CanDelete = ApplicationUser.Permissions.Center_Delete,
                CenterGrid = UnitOfWork.Centers.GetAll().ToGrid(),
                CostCenterList = ErpUnitOfWork.CostCenters.GetAll().ToList()
            };
        }

        public void Refresh(CenterModel model)
        {

        }

        public bool Select(CenterModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Center_Edit))
                return Fail(RequestState.NoPermission);
            if (model.CenterId <= 0)
                return Fail(RequestState.BadRequest);

            var center = UnitOfWork.Centers.Find(model.CenterId);

            if (center == null)
                return Fail(RequestState.NotFound);

            model.Name = center.Name;
            model.CostCenterId = center.CostCenterId;
            return true;

        }

        public bool Create(CenterModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Center_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Centers.NameIsExisted(model.Name))
                return NameExisted();
            var center = Center.New(model.Name, model.CostCenterId);
            UnitOfWork.Centers.Add(center);

            UnitOfWork.Complete(n => n.Center_Create);

            return SuccessCreate();
        }

        public bool Edit(CenterModel model)
        {
            if (model.CenterId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Center_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var center = UnitOfWork.Centers.Find(model.CenterId);

            if (center == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Centers.NameIsExisted(model.Name, model.CenterId))
                return NameExisted();

            center.Modify(model.Name, model.CostCenterId);

            UnitOfWork.Complete(n => n.Center_Edit);

            return SuccessEdit();
        }

        public bool Delete(CenterModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Center_Delete))
                return Fail(RequestState.NoPermission);

            if (model.CenterId <= 0)
                return Fail(RequestState.BadRequest);

            var center = UnitOfWork.Centers.Find(model.CenterId);

            if (center == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Centers.Remove(center);

            if (!UnitOfWork.TryComplete(n => n.Center_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

    }
}