using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class BankBusiness : Business, IBankBusiness
    {
        public BankBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Bank && permission;


        public BankModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Bank_Create))
                return Null<BankModel>(RequestState.NoPermission);

            return new BankModel()
            {
                CanCreate = ApplicationUser.Permissions.Bank_Create,
                CanEdit = ApplicationUser.Permissions.Bank_Edit,
                CanDelete = ApplicationUser.Permissions.Bank_Delete,
                BankGrid = UnitOfWork.Banks.GetAll().ToGrid()
            };
        }

        public void Refresh(BankModel model)
        {

        }

        public bool Select(BankModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Bank_Edit))
                return Fail(RequestState.NoPermission);
            if (model.BankId <= 0)
                return Fail(RequestState.BadRequest);

            var bank = UnitOfWork.Banks.Find(model.BankId);

            if (bank == null)
                return Fail(RequestState.NotFound);

            model.Name = bank.Name;
            return true;
        }

        public bool Create(BankModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Bank_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Banks.NameIsExisted(model.Name))
                return NameExisted();
            var bank = Bank.New(model.Name);
            UnitOfWork.Banks.Add(bank);

            UnitOfWork.Complete(n => n.Bank_Create);

            return SuccessCreate();
        }

        public bool Edit(BankModel model)
        {
            if (model.BankId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Bank_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var bank = UnitOfWork.Banks.Find(model.BankId);

            if (bank == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Banks.NameIsExisted(model.Name, model.BankId))
                return NameExisted();
            bank.Modify(model.Name);

            UnitOfWork.Complete(n => n.Bank_Edit);

            return SuccessEdit();
        }

        public bool Delete(BankModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Bank_Delete))
                return Fail(RequestState.NoPermission);

            if (model.BankId <= 0)
                return Fail(RequestState.BadRequest);

            var bank = UnitOfWork.Banks.Find(model.BankId);

            if (bank == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Banks.Remove(bank);
            if (!UnitOfWork.TryComplete(n => n.Bank_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}