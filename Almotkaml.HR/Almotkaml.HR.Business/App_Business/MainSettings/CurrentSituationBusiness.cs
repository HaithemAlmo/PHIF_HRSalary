using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CurrentSituationBusiness : Business, ICurrentSituationBusiness
    {
        public CurrentSituationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.CurrentSituation && permission;

        public CurrentSituationModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.CurrentSituation_Create))
                return Null<CurrentSituationModel>(RequestState.NoPermission);

            return new CurrentSituationModel()
            {
                CanCreate = ApplicationUser.Permissions.CurrentSituation_Create,
                CanEdit = ApplicationUser.Permissions.CurrentSituation_Edit,
                CanDelete = ApplicationUser.Permissions.CurrentSituation_Delete,
                CurrentSituationGrid = UnitOfWork.CurrentSituations
                    .GetAll()
                    .Select(a => new CurrentSituationGridRow()
                    {
                        CurrentSituationId = a.CurrentSituationId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(CurrentSituationModel model)
        {

        }

        public bool Select(CurrentSituationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.CurrentSituation_Edit))
                return Fail(RequestState.NoPermission);
            if (model.CurrentSituationId <= 0)
                return Fail(RequestState.BadRequest);

            var currentSituation = UnitOfWork.CurrentSituations.Find(model.CurrentSituationId);

            if (currentSituation == null)
                return Fail(RequestState.NotFound);

            model.Name = currentSituation.Name;
            return true;

        }

        public bool Create(CurrentSituationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.CurrentSituation_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.CurrentSituations.NameIsExisted(model.Name))
                return NameExisted();
            var currentSituation = CurrentSituation.New(model.Name);
            UnitOfWork.CurrentSituations.Add(currentSituation);

            UnitOfWork.Complete(n => n.CurrentSituation_Create);

            return SuccessCreate();


        }

        public bool Edit(CurrentSituationModel model)
        {
            if (model.CurrentSituationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.CurrentSituation_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var currentSituation = UnitOfWork.CurrentSituations.Find(model.CurrentSituationId);

            if (currentSituation == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.CurrentSituations.NameIsExisted(model.Name, model.CurrentSituationId))
                return NameExisted();
            currentSituation.Modify(model.Name);

            UnitOfWork.Complete(n => n.CurrentSituation_Edit);

            return SuccessEdit();
        }

        public bool Delete(CurrentSituationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.CurrentSituation_Delete))
                return Fail(RequestState.NoPermission);

            if (model.CurrentSituationId <= 0)
                return Fail(RequestState.BadRequest);

            var currentSituation = UnitOfWork.CurrentSituations.Find(model.CurrentSituationId);

            if (currentSituation == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.CurrentSituations.Remove(currentSituation);

            if (!UnitOfWork.TryComplete(n => n.CurrentSituation_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}