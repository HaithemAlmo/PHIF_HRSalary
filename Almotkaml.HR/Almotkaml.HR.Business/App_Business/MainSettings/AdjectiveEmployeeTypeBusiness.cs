using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class AdjectiveEmployeeTypeBusiness : Business, IAdjectiveEmployeeTypeBusiness
    {
        public AdjectiveEmployeeTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.AdjectiveEmployeeType && permission;



        public AdjectiveEmployeeTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployeeType_Create))
                return Null<AdjectiveEmployeeTypeModel>(RequestState.NoPermission);

            return new AdjectiveEmployeeTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.AdjectiveEmployeeType_Create,
                CanEdit = ApplicationUser.Permissions.AdjectiveEmployeeType_Edit,
                CanDelete = ApplicationUser.Permissions.AdjectiveEmployeeType_Delete,
                AdjectiveEmployeeTypeGrid = UnitOfWork.AdjectiveEmployeeTypes
                    .GetAll()
                    .Select(a => new AdjectiveEmployeeTypeGridRow()
                    {
                        AdjectiveEmployeeTypeId = a.AdjectiveEmployeeTypeId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(AdjectiveEmployeeTypeModel model)
        {

        }

        public bool Select(AdjectiveEmployeeTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployeeType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.AdjectiveEmployeeTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var adjectiveEmployeeId = UnitOfWork.AdjectiveEmployeeTypes.Find(model.AdjectiveEmployeeTypeId);

            if (adjectiveEmployeeId == null)
                return Fail(RequestState.NotFound);

            model.Name = adjectiveEmployeeId.Name;
            return true;
        }

        public bool Create(AdjectiveEmployeeTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployeeType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.AdjectiveEmployeeTypes.NameIsExisted(model.Name))
                return NameExisted();
            var adjectiveEmployeeId = AdjectiveEmployeeType.New(model.Name);
            UnitOfWork.AdjectiveEmployeeTypes.Add(adjectiveEmployeeId);

            UnitOfWork.Complete(n => n.AdjectiveEmployeeType_Create);

            return SuccessCreate();
        }

        public bool Edit(AdjectiveEmployeeTypeModel model)
        {
            if (model.AdjectiveEmployeeTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployeeType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var adjectiveEmployeeId = UnitOfWork.AdjectiveEmployeeTypes.Find(model.AdjectiveEmployeeTypeId);

            if (adjectiveEmployeeId == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.AdjectiveEmployeeTypes.NameIsExisted(model.Name, model.AdjectiveEmployeeTypeId))
                return NameExisted();
            adjectiveEmployeeId.Modify(model.Name);

            UnitOfWork.Complete(n => n.AdjectiveEmployeeType_Edit);

            return SuccessEdit();
        }

        public bool Delete(AdjectiveEmployeeTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployeeType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.AdjectiveEmployeeTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var adjectiveEmployeeId = UnitOfWork.AdjectiveEmployeeTypes.Find(model.AdjectiveEmployeeTypeId);

            if (adjectiveEmployeeId == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.AdjectiveEmployeeTypes.Remove(adjectiveEmployeeId);

            if (!UnitOfWork.TryComplete(n => n.AdjectiveEmployeeType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}