using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DevelopmentStateBusiness : Business, IDevelopmentStateBusiness
    {
        public DevelopmentStateBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DevelopmentState && permission;


        public DevelopmentStateModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentState_Create))
                return Null<DevelopmentStateModel>(RequestState.NoPermission);

            return new DevelopmentStateModel()
            {
                CanCreate = ApplicationUser.Permissions.DevelopmentState_Create,
                CanEdit = ApplicationUser.Permissions.DevelopmentState_Edit,
                CanDelete = ApplicationUser.Permissions.DevelopmentState_Delete,
                Grid = UnitOfWork.DevelopmentStates.GetAll().ToGrid()
            };
        }

        public void Refresh(DevelopmentStateModel model)
        {

        }

        public bool Select(DevelopmentStateModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentState_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DevelopmentStateId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentState = UnitOfWork.DevelopmentStates.Find(model.DevelopmentStateId);

            if (developmentState == null)
                return Fail(RequestState.NotFound);

            model.Name = developmentState.Name;
            return true;
        }

        public bool Create(DevelopmentStateModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentState_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DevelopmentStates.NameIsExisted(model.Name))
                return NameExisted();
            var developmentState = DevelopmentState.New(model.Name);
            UnitOfWork.DevelopmentStates.Add(developmentState);

            UnitOfWork.Complete(n => n.DevelopmentState_Create);

            return SuccessCreate();
        }

        public bool Edit(DevelopmentStateModel model)
        {
            if (model.DevelopmentStateId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentState_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var developmentState = UnitOfWork.DevelopmentStates.Find(model.DevelopmentStateId);

            if (developmentState == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.DevelopmentStates.NameIsExisted(model.Name, model.DevelopmentStateId))
                return NameExisted();
            developmentState.Modify(model.Name);

            UnitOfWork.Complete(n => n.DevelopmentState_Edit);

            return SuccessEdit();
        }

        public bool Delete(DevelopmentStateModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentState_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DevelopmentStateId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentState = UnitOfWork.DevelopmentStates.Find(model.DevelopmentStateId);

            if (developmentState == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DevelopmentStates.Remove(developmentState);
            if (!UnitOfWork.TryComplete(n => n.DevelopmentState_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}