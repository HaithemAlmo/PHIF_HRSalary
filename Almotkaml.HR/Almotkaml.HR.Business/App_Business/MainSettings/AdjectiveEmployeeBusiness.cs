using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class AdjectiveEmployeeBusiness : Business, IAdjectiveEmployeeBusiness
    {
        public AdjectiveEmployeeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.AdjectiveEmployee && permission;


        public AdjectiveEmployeeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployee_Create))
                return Null<AdjectiveEmployeeModel>(RequestState.NoPermission);

            return new AdjectiveEmployeeModel()
            {
                CanCreate = ApplicationUser.Permissions.AdjectiveEmployee_Create,
                CanEdit = ApplicationUser.Permissions.AdjectiveEmployee_Edit,
                CanDelete = ApplicationUser.Permissions.AdjectiveEmployee_Delete,
                AdjectiveEmployeeGrid = UnitOfWork.AdjectiveEmployees
                    .GetAdjectiveEmployeeWithType().ToGrid(),

                AdjectiveEmployeeTypeList = UnitOfWork.AdjectiveEmployeeTypes.GetAll().ToList()
            };
        }

        public void Refresh(AdjectiveEmployeeModel model)
        {

        }

        public bool Select(AdjectiveEmployeeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployee_Edit))
                return Fail(RequestState.NoPermission);
            if (model.AdjectiveEmployeeId <= 0)
                return Fail(RequestState.BadRequest);

            var adjectiveEmployee = UnitOfWork.AdjectiveEmployees.Find(model.AdjectiveEmployeeId);

            if (adjectiveEmployee == null)
                return Fail(RequestState.NotFound);

            model.Name = adjectiveEmployee.Name;
            model.AdjectiveEmployeeTypeId = adjectiveEmployee.AdjectiveEmployeeTypeId;
            //model.AdjectiveEmployeeTypeList = UnitOfWork.AdjectiveEmployeeTypes.GetAdjectiveEmployeeType().ToList();
            return true;
        }

        public bool Create(AdjectiveEmployeeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployee_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.AdjectiveEmployees.AdjectiveEmployeeExisted(model.Name, model.AdjectiveEmployeeTypeId, model.AdjectiveEmployeeId))
                return NameExisted();

            var adjectiveEmployeeId = AdjectiveEmployee.New(model.Name, model.AdjectiveEmployeeTypeId);
            UnitOfWork.AdjectiveEmployees.Add(adjectiveEmployeeId);

            UnitOfWork.Complete(n => n.AdjectiveEmployee_Create);

            return SuccessCreate();
        }

        public bool Edit(AdjectiveEmployeeModel model)
        {
            if (model.AdjectiveEmployeeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployee_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var adjectiveEmployeeId = UnitOfWork.AdjectiveEmployees.Find(model.AdjectiveEmployeeId);

            if (adjectiveEmployeeId == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.AdjectiveEmployees.AdjectiveEmployeeExisted(model.Name, model.AdjectiveEmployeeTypeId, model.AdjectiveEmployeeId))
                return NameExisted();

            adjectiveEmployeeId.Modify(model.Name, model.AdjectiveEmployeeTypeId);

            UnitOfWork.Complete(n => n.AdjectiveEmployee_Edit);

            return SuccessEdit();
        }

        public bool Delete(AdjectiveEmployeeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdjectiveEmployee_Delete))
                return Fail(RequestState.NoPermission);

            if (model.AdjectiveEmployeeId <= 0)
                return Fail(RequestState.BadRequest);

            var adjectiveEmployeeId = UnitOfWork.AdjectiveEmployees.Find(model.AdjectiveEmployeeId);

            if (adjectiveEmployeeId == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.AdjectiveEmployees.Remove(adjectiveEmployeeId);

            if (!UnitOfWork.TryComplete(n => n.AdjectiveEmployee_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}