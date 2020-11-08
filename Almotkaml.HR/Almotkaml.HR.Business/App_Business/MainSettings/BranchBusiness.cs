using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class BranchBusiness : Business, IBranchBusiness
    {
        public BranchBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Branch && permission;


        public BranchModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Branch_Create))
                return Null<BranchModel>(RequestState.NoPermission);

            return new BranchModel()
            {
                CanCreate = ApplicationUser.Permissions.Branch_Create,
                CanEdit = ApplicationUser.Permissions.Branch_Edit,
                CanDelete = ApplicationUser.Permissions.Branch_Delete,
                BranchGrid = UnitOfWork.Branches
                    .GetAll()
                    .Select(a => new BranchGridRow()
                    {
                        BranchId = a.BranchId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(BranchModel model)
        {

        }

        public bool Select(BranchModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Branch_Edit))
                return Fail(RequestState.NoPermission);
            if (model.BranchId <= 0)
                return Fail(RequestState.BadRequest);

            var branch = UnitOfWork.Branches.Find(model.BranchId);

            if (branch == null)
                return Fail(RequestState.NotFound);

            model.Name = branch.Name;
            return true;
        }

        public bool Create(BranchModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Branch_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Branches.NameIsExisted(model.Name))
                return NameExisted();
            var branch = Branch.New(model.Name);
            UnitOfWork.Branches.Add(branch);

            UnitOfWork.Complete(n => n.Branch_Create);

            return SuccessCreate();
        }

        public bool Edit(BranchModel model)
        {
            if (model.BranchId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Branch_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var branch = UnitOfWork.Branches.Find(model.BranchId);

            if (branch == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Branches.NameIsExisted(model.Name, model.BranchId))
                return NameExisted();
            branch.Modify(model.Name);

            UnitOfWork.Complete(n => n.Branch_Edit);

            return SuccessEdit();
        }

        public bool Delete(BranchModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Branch_Delete))
                return Fail(RequestState.NoPermission);

            if (model.BranchId <= 0)
                return Fail(RequestState.BadRequest);

            var branch = UnitOfWork.Branches.Find(model.BranchId);

            if (branch == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Branches.Remove(branch);
            if (!UnitOfWork.TryComplete(n => n.Branch_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}