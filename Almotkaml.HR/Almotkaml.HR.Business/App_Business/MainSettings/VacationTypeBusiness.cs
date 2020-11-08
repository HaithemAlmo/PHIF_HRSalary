using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class VacationTypeBusiness : Business, IVacationTypeBusiness
    {
        public VacationTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.VacationType && permission;

        public VacationTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.VacationType_Create))
                return Null<VacationTypeModel>(RequestState.NoPermission);

            return new VacationTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.VacationType_Create,
                CanEdit = ApplicationUser.Permissions.VacationType_Edit,
                CanDelete = ApplicationUser.Permissions.VacationType_Delete,
                Grid = UnitOfWork.VacationTypes.GetAll().ToGrid()
            };
        }

        public void Refresh(VacationTypeModel model)
        {
        }

        public bool Select(VacationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.VacationType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.VacationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var vacationType = UnitOfWork.VacationTypes.Find(model.VacationTypeId);

            if (vacationType == null)
                return Fail(RequestState.NotFound);

            if (vacationType.VacationEssential != VacationEssential.UnKounw)
                return false;

            model.Name = vacationType.Name;
            //model.Days = vacationType.Days;
            //model.DiscountPercentage = vacationType.DiscountPercentage;

            return true;
        }

        public bool Create(VacationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.VacationType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.VacationTypes.NameIsExisted(model.Name))
                return NameExisted();

            var vacationType = VacationType.New(model.Name);

            UnitOfWork.VacationTypes.Add(vacationType);

            UnitOfWork.Complete(n => n.VacationType_Create);

            return SuccessCreate();
        }

        public bool Edit(VacationTypeModel model)
        {
            if (model.VacationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.VacationType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var vacationType = UnitOfWork.VacationTypes.Find(model.VacationTypeId);

            if (vacationType == null)
                return Fail(RequestState.NotFound);

            if (vacationType.VacationEssential != VacationEssential.UnKounw)
                return false;

            if (UnitOfWork.VacationTypes.NameIsExisted(model.Name, model.VacationTypeId))
                return NameExisted();

            vacationType.Modify(model.Name);

            UnitOfWork.Complete(n => n.VacationType_Edit);

            return SuccessEdit();
        }

        public bool Delete(VacationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.VacationType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.VacationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var vacationType = UnitOfWork.VacationTypes.Find(model.VacationTypeId);

            if (vacationType == null)
                return Fail(RequestState.NotFound);

            if (vacationType.VacationEssential != VacationEssential.UnKounw)
                return false;

            UnitOfWork.VacationTypes.Remove(vacationType);
            if (!UnitOfWork.TryComplete(n => n.VacationType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}