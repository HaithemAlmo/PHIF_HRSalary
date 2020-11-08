using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DevelopmentTypeCBusiness : Business, IDevelopmentTypeCBusiness
    {
        public DevelopmentTypeCBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DevelopmentTypeC && permission;


        public DevelopmentTypeCModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeC_Create))
                return Null<DevelopmentTypeCModel>(RequestState.NoPermission);

            return new DevelopmentTypeCModel()
            {
                CanCreate = ApplicationUser.Permissions.DevelopmentTypeB_Create,
                CanEdit = ApplicationUser.Permissions.DevelopmentTypeB_Edit,
                CanDelete = ApplicationUser.Permissions.DevelopmentTypeB_Delete,
                DevelopmentTypeAList = UnitOfWork.DevelopmentTypeAs
                            .DevelopmentTypeAWithTrainingType(TrainingType.Training).ToList(),
                Grid = UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB().ToGrid()
            };
        }

        public void Refresh(DevelopmentTypeCModel model)
        {
            if (model == null)
                return;

            model.DevelopmentTypeAList = model.TrainingType >= 0
                ? UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(model.TrainingType).ToList()
                : new HashSet<DevelopmentTypeAListItem>();

            model.DevelopmentTypeBList = model.DevelopmentTypeAId > 0
                ? UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(model.DevelopmentTypeAId).ToList()
                : new HashSet<DevelopmentTypeBListItem>();
        }

        public bool Select(DevelopmentTypeCModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeC_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DevelopmentTypeCId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeC = UnitOfWork.DevelopmentTypeCs.Find(model.DevelopmentTypeCId);

            if (developmentTypeC == null)
                return Fail(RequestState.NotFound);

            var developmentTypeAId = developmentTypeC.DevelopmentTypeB?.DevelopmentTypeAId ?? 0;

            model.DevelopmentTypeBId = developmentTypeC.DevelopmentTypeBId;
            model.DevelopmentTypeAId = developmentTypeAId;
            model.Name = developmentTypeC.Name;
            model.DevelopmentTypeBList = UnitOfWork.DevelopmentTypeBs
                  .GetDevelopmentTypeBWithDevelopmentTypeA(developmentTypeAId).ToList();
            model.TrainingType = developmentTypeC.DevelopmentTypeB?.DevelopmentTypeA?.TrainingType ?? 0;
            return true;
        }

        public bool Create(DevelopmentTypeCModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeC_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DevelopmentTypeCs.DevelopmentTypeCExisted(model.Name, model.DevelopmentTypeBId))
                return NameExisted();

            var developmentTypeC = DevelopmentTypeC.New(model.Name, model.DevelopmentTypeBId);
            UnitOfWork.DevelopmentTypeCs.Add(developmentTypeC);

            UnitOfWork.Complete(n => n.DevelopmentTypeC_Create);

            return SuccessCreate();
        }

        public bool Edit(DevelopmentTypeCModel model)
        {
            if (model.DevelopmentTypeCId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeC_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var developmentTypeC = UnitOfWork.DevelopmentTypeCs.Find(model.DevelopmentTypeCId);

            if (developmentTypeC == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.DevelopmentTypeCs.DevelopmentTypeCExisted(model.Name, model.DevelopmentTypeBId, model.DevelopmentTypeCId))
                return NameExisted();
            developmentTypeC.Modify(model.Name, model.DevelopmentTypeBId);

            UnitOfWork.Complete(n => n.DevelopmentTypeC_Edit);

            return SuccessEdit();
        }

        public bool Delete(DevelopmentTypeCModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeC_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DevelopmentTypeCId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeC = UnitOfWork.DevelopmentTypeCs.Find(model.DevelopmentTypeCId);

            if (developmentTypeC == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DevelopmentTypeCs.Remove(developmentTypeC);

            if (!UnitOfWork.TryComplete(n => n.DevelopmentTypeC_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}