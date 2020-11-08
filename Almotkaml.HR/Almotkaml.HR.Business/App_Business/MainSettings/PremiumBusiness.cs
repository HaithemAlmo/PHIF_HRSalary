using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class PremiumBusiness : Business, IPremiumBusiness
    {
        public PremiumBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Premium && permission;


        public PremiumModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Premium_Create))
                return Null<PremiumModel>(RequestState.NoPermission);

            return new PremiumModel()
            {
                CanCreate = ApplicationUser.Permissions.Premium_Create,
                CanEdit = ApplicationUser.Permissions.Premium_Edit,
                CanDelete = ApplicationUser.Permissions.Premium_Delete,
                PremiumGrid = UnitOfWork.Premiums.GetAll().ToGrid()
            };
        }

        public void Refresh(PremiumModel model)
        {

        }

        public bool Select(PremiumModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Premium_Edit))
                return Fail(RequestState.NoPermission);
            if (model.PremiumId <= 0)
                return Fail(RequestState.BadRequest);

            var premium = UnitOfWork.Premiums.Find(model.PremiumId);

            if (premium == null)
                return Fail(RequestState.NotFound);

            model.Name = premium.Name;
            model.DiscountOrBoun = premium.DiscountOrBoun;
            model.ISAdvancePremmium = premium.ISAdvancePremmium;
            model.IsSubject = premium.IsSubject;
            model.IsTemporary = premium.IsTemporary;
            model.IsFrozen = premium.IsFrozen;

            return true;
        }

         public bool Create(PremiumModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Premium_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Premiums.NameIsExisted(model.Name))
                return NameExisted();

            var premium = Premium.New(model.DiscountOrBoun,model.Name, model.IsTemporary, model.IsSubject,model.ISAdvancePremmium,model.IsFrozen);
            UnitOfWork.Premiums.Add(premium);

            UnitOfWork.Complete(n => n.Premium_Create);

            return SuccessCreate();
        }

        public bool Edit(PremiumModel model)
        {
            if (model.PremiumId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Premium_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var premium = UnitOfWork.Premiums.Find(model.PremiumId);

            if (premium == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Premiums.NameIsExisted(model.Name, model.PremiumId))
                return NameExisted();

            premium.Modify(model.DiscountOrBoun, model.Name, model.IsTemporary, model.IsSubject, model.ISAdvancePremmium,model.IsFrozen);

            UnitOfWork.Complete(n => n.Premium_Edit);

            return SuccessEdit();
        }

        public bool Delete(PremiumModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Premium_Delete))
                return Fail(RequestState.NoPermission);

            if (model.PremiumId <= 0)
                return Fail(RequestState.BadRequest);

            var premium = UnitOfWork.Premiums.Find(model.PremiumId);

            if (premium == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Premiums.Remove(premium);
            if (!UnitOfWork.TryComplete(n => n.Premium_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}