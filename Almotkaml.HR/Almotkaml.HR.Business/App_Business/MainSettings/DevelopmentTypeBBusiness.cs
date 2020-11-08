using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DevelopmentTypeBBusiness : Business, IDevelopmentTypeBBusiness
    {
        public DevelopmentTypeBBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DevelopmentTypeB && permission;

        public DevelopmentTypeBModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeB_Create))
                return Null<DevelopmentTypeBModel>(RequestState.NoPermission);

            return new DevelopmentTypeBModel()
            {
                CanCreate = ApplicationUser.Permissions.DevelopmentTypeB_Create,
                CanEdit = ApplicationUser.Permissions.DevelopmentTypeB_Edit,
                CanDelete = ApplicationUser.Permissions.DevelopmentTypeB_Delete,
                DevelopmentTypeAList = UnitOfWork.DevelopmentTypeAs
                            .DevelopmentTypeAWithTrainingType(TrainingType.Training).ToList(),
                Grid = UnitOfWork.DevelopmentTypeBs
                    .GetDevelopmentTypeBWithDevelopmentTypeA().ToGrid()
            };
        }

        public void Refresh(DevelopmentTypeBModel model)
        {
            model.DevelopmentTypeAList = model.TrainingType >= 0
                ? UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(model.TrainingType).ToList()
                : new HashSet<DevelopmentTypeAListItem>();
        }

        public bool Select(DevelopmentTypeBModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeB_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DevelopmentTypeBId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeB = UnitOfWork.DevelopmentTypeBs.Find(model.DevelopmentTypeBId);

            if (developmentTypeB == null)
                return Fail(RequestState.NotFound);
            model.DevelopmentTypeAId = developmentTypeB.DevelopmentTypeAId;
            model.Name = developmentTypeB.Name;
            model.TrainingType = developmentTypeB.DevelopmentTypeA?.TrainingType ?? 0;
            return true;
        }

        public bool Create(DevelopmentTypeBModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeB_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DevelopmentTypeBs.DevelopmentTypeBExisted(model.Name, model.DevelopmentTypeAId, model.DevelopmentTypeBId))
                return NameExisted();

            var developmentTypeB = DevelopmentTypeB.New(model.Name, model.DevelopmentTypeAId);
            UnitOfWork.DevelopmentTypeBs.Add(developmentTypeB);

            UnitOfWork.Complete(n => n.DevelopmentTypeB_Create);

            return SuccessCreate();
        }

        public bool Edit(DevelopmentTypeBModel model)
        {
            if (model.DevelopmentTypeBId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeB_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var developmentTypeB = UnitOfWork.DevelopmentTypeBs.Find(model.DevelopmentTypeBId);

            if (developmentTypeB == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.DevelopmentTypeBs.DevelopmentTypeBExisted(model.Name, model.DevelopmentTypeAId, model.DevelopmentTypeBId))
                return NameExisted();
            developmentTypeB.Modify(model.Name, model.DevelopmentTypeAId);

            UnitOfWork.Complete(n => n.DevelopmentTypeB_Edit);

            return SuccessEdit();
        }

        public bool Delete(DevelopmentTypeBModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeB_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DevelopmentTypeBId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeB = UnitOfWork.DevelopmentTypeBs.Find(model.DevelopmentTypeBId);

            if (developmentTypeB == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DevelopmentTypeBs.Remove(developmentTypeB);

            if (!UnitOfWork.TryComplete(n => n.DevelopmentTypeB_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}