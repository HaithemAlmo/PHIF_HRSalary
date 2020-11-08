using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class RewardTypeBusiness : Business, IRewardTypeBusiness
    {
        public RewardTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.RewardType && permission;

        public RewardTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.RewardType_Create))
                return Null<RewardTypeModel>(RequestState.NoPermission);

            return new RewardTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.RewardType_Create,
                CanEdit = ApplicationUser.Permissions.RewardType_Edit,
                CanDelete = ApplicationUser.Permissions.RewardType_Delete,
                RewardTypeGrid = UnitOfWork.RewardTypes
                    .GetAll()
                    .Select(a => new RewardTypeGridRow()
                    {
                        RewardTypeId = a.RewardTypeId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(RewardTypeModel model)
        {

        }

        public bool Select(RewardTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RewardType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.RewardTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var rewardType = UnitOfWork.RewardTypes.Find(model.RewardTypeId);

            if (rewardType == null)
                return Fail(RequestState.NotFound);

            model.Name = rewardType.Name;
            return true;

        }

        public bool Create(RewardTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RewardType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.RewardTypes.NameIsExisted(model.Name))
                return NameExisted();
            var rewardType = RewardType.New(model.Name);
            UnitOfWork.RewardTypes.Add(rewardType);

            UnitOfWork.Complete(n => n.RewardType_Create);

            return SuccessCreate();


        }

        public bool Edit(RewardTypeModel model)
        {
            if (model.RewardTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.RewardType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var rewardType = UnitOfWork.RewardTypes.Find(model.RewardTypeId);

            if (rewardType == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.RewardTypes.NameIsExisted(model.Name, model.RewardTypeId))
                return NameExisted();
            rewardType.Modify(model.Name);

            UnitOfWork.Complete(n => n.RewardType_Edit);

            return SuccessEdit();
        }

        public bool Delete(RewardTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RewardType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.RewardTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var rewardType = UnitOfWork.RewardTypes.Find(model.RewardTypeId);

            if (rewardType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.RewardTypes.Remove(rewardType);

            if (!UnitOfWork.TryComplete(n => n.RewardType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}