using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DevelopmentTypeDBusiness : Business, IDevelopmentTypeDBusiness
    {
        public DevelopmentTypeDBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DevelopmentTypeD && permission;

        public DevelopmentTypeDModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeD_Create))
                return Null<DevelopmentTypeDModel>(RequestState.NoPermission);

            return new DevelopmentTypeDModel()
            {
                CanCreate = ApplicationUser.Permissions.DevelopmentTypeD_Create,
                CanEdit = ApplicationUser.Permissions.DevelopmentTypeD_Edit,
                CanDelete = ApplicationUser.Permissions.DevelopmentTypeD_Delete,
                DevelopmentTypeAList =
                    UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(TrainingType.Training).ToList(),
                Grid = UnitOfWork.DevelopmentTypeDs.GetDevelopmentTypeDWithDevelopmentTypeC().ToGrid()
            };
        }

        public void Refresh(DevelopmentTypeDModel model)
        {
            if (model == null)
                return;

            model.DevelopmentTypeAList = model.TrainingType >= 0
                ? UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(model.TrainingType).ToList()
                : new HashSet<DevelopmentTypeAListItem>();


            model.DevelopmentTypeBList = model.DevelopmentTypeAId > 0
                ? UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(model.DevelopmentTypeAId)
                    .ToList()
                : new HashSet<DevelopmentTypeBListItem>();

            model.DevelopmentTypeCList = model.DevelopmentTypeBId > 0
                ? UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(model.DevelopmentTypeBId)
                    .ToList()
                : new HashSet<DevelopmentTypeCListItem>();

        }

        public bool Select(DevelopmentTypeDModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeD_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DevelopmentTypeDId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeD = UnitOfWork.DevelopmentTypeDs.Find(model.DevelopmentTypeDId);

            if (developmentTypeD == null)
                return Fail(RequestState.NotFound);

            var developmentTypeAId = developmentTypeD.DevelopmentTypeC?.DevelopmentTypeB?.DevelopmentTypeAId ?? 0;
            var developmentTypeBId = developmentTypeD.DevelopmentTypeC?.DevelopmentTypeBId ?? 0;
            model.DevelopmentTypeAId = developmentTypeAId;
            model.DevelopmentTypeBId = developmentTypeBId;
            model.DevelopmentTypeCId = developmentTypeD.DevelopmentTypeCId;
            model.DevelopmentTypeCList = UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(developmentTypeBId).ToList();
            model.DevelopmentTypeBList = UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(developmentTypeAId).ToList();
            model.Name = developmentTypeD.Name;
            model.TrainingType = developmentTypeD.DevelopmentTypeC?.DevelopmentTypeB?.DevelopmentTypeA?.TrainingType ?? 0;
            return true;
        }

        public bool Create(DevelopmentTypeDModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeD_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DevelopmentTypeDs.DevelopmentTypeDExisted(model.Name, model.DevelopmentTypeCId))
                return NameExisted();

            var developmentTypeD = DevelopmentTypeD.New(model.Name, model.DevelopmentTypeCId);

            UnitOfWork.DevelopmentTypeDs.Add(developmentTypeD);

            UnitOfWork.Complete(n => n.DevelopmentTypeD_Create);

            return SuccessCreate();
        }

        public bool Edit(DevelopmentTypeDModel model)
        {
            if (model.DevelopmentTypeDId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeD_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var developmentTypeD = UnitOfWork.DevelopmentTypeDs.Find(model.DevelopmentTypeDId);

            if (developmentTypeD == null)
                return Fail(RequestState.NotFound);
            if (UnitOfWork.DevelopmentTypeDs.DevelopmentTypeDExisted(model.Name, model.DevelopmentTypeCId, model.DevelopmentTypeDId))
                return NameExisted();

            developmentTypeD.Modify(model.Name, model.DevelopmentTypeCId);

            UnitOfWork.Complete(n => n.DevelopmentTypeD_Edit);

            return SuccessEdit();
        }

        public bool Delete(DevelopmentTypeDModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DevelopmentTypeD_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DevelopmentTypeDId <= 0)
                return Fail(RequestState.BadRequest);

            var developmentTypeD = UnitOfWork.DevelopmentTypeDs.Find(model.DevelopmentTypeDId);

            if (developmentTypeD == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DevelopmentTypeDs.Remove(developmentTypeD);

            if (!UnitOfWork.TryComplete(n => n.DevelopmentTypeD_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }



    }
}