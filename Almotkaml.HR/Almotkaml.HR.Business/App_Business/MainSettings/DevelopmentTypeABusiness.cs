using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DevelopmentTypeABusiness : Business, IDevelopmentTypeABusiness
    {
        public DevelopmentTypeABusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DevelopmentTypeA && permission;

        public DevelopmentTypeAModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeA_Create))
                return Null<DevelopmentTypeAModel>(RequestState.NoPermission);

            return new DevelopmentTypeAModel()
            {
                CanCreate = ApplicationUser.Permissions.DevelopmentTypeA_Create,
                CanEdit = ApplicationUser.Permissions.DevelopmentTypeA_Edit,
                CanDelete = ApplicationUser.Permissions.DevelopmentTypeA_Delete,
                Grid = UnitOfWork.DevelopmentTypeAs.GetAll().ToGrid()
            };
        }

        public void Refresh(DevelopmentTypeAModel model)
        {

        }

        public bool Select(DevelopmentTypeAModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeA_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DevelopmentTypeAId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeA = UnitOfWork.DevelopmentTypeAs.Find(model.DevelopmentTypeAId);

            if (developmentTypeA == null)
                return Fail(RequestState.NotFound);

            model.Name = developmentTypeA.Name;
            return true;
        }

        public bool Create(DevelopmentTypeAModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeA_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DevelopmentTypeAs.NameIsExisted(model.Name))
                return NameExisted();
            var developmentTypeA = DevelopmentTypeA.New(model.TrainingType, model.Name);
            UnitOfWork.DevelopmentTypeAs.Add(developmentTypeA);

            UnitOfWork.Complete(n => n.DevelopmentTypeA_Create);

            return SuccessCreate();
        }

        public bool Edit(DevelopmentTypeAModel model)
        {
            if (model.DevelopmentTypeAId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeA_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var developmentTypeA = UnitOfWork.DevelopmentTypeAs.Find(model.DevelopmentTypeAId);

            if (developmentTypeA == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.DevelopmentTypeAs.NameIsExisted(model.Name, model.DevelopmentTypeAId))
                return NameExisted();
            developmentTypeA.Modify(model.TrainingType, model.Name);

            UnitOfWork.Complete(n => n.DevelopmentTypeA_Edit);

            return SuccessEdit();
        }

        public bool Delete(DevelopmentTypeAModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeA_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DevelopmentTypeAId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeA = UnitOfWork.DevelopmentTypeAs.Find(model.DevelopmentTypeAId);

            if (developmentTypeA == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DevelopmentTypeAs.Remove(developmentTypeA);
            if (!UnitOfWork.TryComplete(n => n.DevelopmentTypeA_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}