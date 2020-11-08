using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class BankBranchBusiness : Business, IBankBranchBusiness
    {
        public BankBranchBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.BankBranch && permission;

        public BankBranchModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.BankBranch_Create))
                return Null<BankBranchModel>(RequestState.NoPermission);

            //var accountingManuals = ErpUnitOfWork.AccountingManuals.GetBanks();

            return new BankBranchModel()
            {
                CanCreate = ApplicationUser.Permissions.BankBranch_Create,
                CanEdit = ApplicationUser.Permissions.BankBranch_Edit,
                CanDelete = ApplicationUser.Permissions.BankBranch_Delete,
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                BankBranchGrid = UnitOfWork.BankBranches
                    .GetBankBranchWithBank().ToGrid(),//accountingManuals.AsIList()),
                AccountingManualList = ErpUnitOfWork.AccountingManuals.GetBanks().ToList()
            };
        }

        public void Refresh(BankBranchModel model)
        {

        }

        public bool Select(BankBranchModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.BankBranch_Edit))
                return Fail(RequestState.NoPermission);
            if (model.BankBranchId <= 0)
                return Fail(RequestState.BadRequest);

            var bankBranch = UnitOfWork.BankBranches.Find(model.BankBranchId);

            if (bankBranch == null)
                return Fail(RequestState.NotFound);
            model.BankId = bankBranch.BankId;
            model.Name = bankBranch.Name;
            model.AccountingManualId = bankBranch.AccountingManualId;
            return true;
        }

        public bool Create(BankBranchModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.BankBranch_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.BankBranches.BankBranchExisted(model.Name, model.BankId, model.BankBranchId))
                return NameExisted();

            var bankBranch = BankBranch.New(model.Name, model.BankId, model.AccountingManualId);
            UnitOfWork.BankBranches.Add(bankBranch);

            UnitOfWork.Complete(n => n.BankBranch_Create);

            return SuccessCreate();
        }

        public bool Edit(BankBranchModel model)
        {
            if (model.BankBranchId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.BankBranch_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var bankBranch = UnitOfWork.BankBranches.Find(model.BankBranchId);

            if (bankBranch == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.BankBranches.BankBranchExisted(model.Name, model.BankId, model.BankBranchId))
                return NameExisted();
            bankBranch.Modify(model.Name, model.BankId, model.AccountingManualId);

            UnitOfWork.Complete(n => n.BankBranch_Edit);

            return SuccessEdit();
        }

        public bool Delete(BankBranchModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.BankBranch_Delete))
                return Fail(RequestState.NoPermission);

            if (model.BankBranchId <= 0)
                return Fail(RequestState.BadRequest);

            var bankBranch = UnitOfWork.BankBranches.Find(model.BankBranchId);

            if (bankBranch == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.BankBranches.Remove(bankBranch);

            if (!UnitOfWork.TryComplete(n => n.BankBranch_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}