using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class RewardBusiness : Business, IRewardBusiness
    {
        public RewardBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Reward && permission;

        public RewardModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Reward_Create))
                return Null<RewardModel>(RequestState.NoPermission);

            return new RewardModel()
            {
                CanCreate = ApplicationUser.Permissions.Reward_Create,
                CanEdit = ApplicationUser.Permissions.Reward_Edit,
                CanDelete = ApplicationUser.Permissions.Reward_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                RewardGrid = UnitOfWork.Rewards.GetRewardByEmployeeId(0).ToGrid(),
                RewardTypeList = UnitOfWork.RewardTypes.GetAll().ToList()


            };
        }

        public void Refresh(RewardModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
            model.RewardGrid = UnitOfWork.Rewards.GetRewardByEmployeeId(model.EmployeeId).ToGrid();
        }

        public bool Select(RewardModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Reward_Edit))
                return Fail(RequestState.NoPermission);
            if (model.RewardId <= 0)
                return Fail(RequestState.BadRequest);

            var reward = UnitOfWork.Rewards.Find(model.RewardId);

            if (reward == null)
                return Fail(RequestState.NotFound);
            model.RewardId = reward.RewardId;
            model.EmployeeId = reward.EmployeeId;
            model.EfficiencyEstimate = reward.EfficiencyEstimate;
            model.RewardTypeId = reward.RewardTypeId;
            model.Date = reward.Date.ToString();
            model.Note = reward.Note;
            model.Value = reward.Value;

            return true;
        }

        public bool Create(RewardModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Reward_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var reward = Reward.New()
                .WithDate(model.Date.ToDateTime())
                .WithEfficiencyEstimate(model.EfficiencyEstimate)
                .WithValue(model.Value)
                .WithRewardTypeId(model.RewardTypeId)
                .WithNote(model.Note)
                .WithEmployeeId(model.EmployeeId)
                .Biuld();
            UnitOfWork.Rewards.Add(reward);

            UnitOfWork.Complete(n => n.Reward_Create);
            Clear(model);
            return SuccessCreate();
        }

        public bool Edit(RewardModel model)
        {
            if (model.RewardId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Reward_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var reward = UnitOfWork.Rewards.Find(model.RewardId);

            if (reward == null)
                return Fail(RequestState.NotFound);

            reward.Modify()
               .Date(model.Date.ToDateTime())
                .EfficiencyEstimate(model.EfficiencyEstimate)
                .Value(model.Value)
                .RewardType(model.RewardTypeId)
                .Note(model.Note)
                .Employee(model.EmployeeId)
                .Confirm();

            UnitOfWork.Complete(n => n.Reward_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(RewardModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Reward_Delete))
                return Fail(RequestState.NoPermission);

            if (model.RewardId <= 0)
                return Fail(RequestState.BadRequest);

            var reward = UnitOfWork.Rewards.Find(model.RewardId);

            if (reward == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Rewards.Remove(reward);

            if (!UnitOfWork.TryComplete(n => n.Reward_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(RewardModel model)
        {
            model.RewardId = 0;
            model.Date = "";
            model.EfficiencyEstimate = "";
            model.RewardTypeId = 0;
            model.Note = "";
            model.Value = "";



        }
    }
}