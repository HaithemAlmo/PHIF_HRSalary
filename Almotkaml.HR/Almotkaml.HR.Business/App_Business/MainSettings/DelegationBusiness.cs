using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DelegationBusiness : Business, IDelegationBusiness
    {
        public DelegationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Delegation && permission;

        public DelegationIndexModel Index()
        {
            if (!HavePermission())
                return Null<DelegationIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Delegations.GetAll().ToGrid();

            return new DelegationIndexModel()
            {
                DelegationGrid = grid,
                CanCreate = ApplicationUser.Permissions.Delegation_Create,
                CanEdit = ApplicationUser.Permissions.Delegation_Edit,
                CanDelete = ApplicationUser.Permissions.Delegation_Delete,
            };
        }

        public DelegationFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Delegation_Create))
                return Null<DelegationFormModel>(RequestState.NoPermission);

            return new DelegationFormModel()
            {
                CanSubmit = true,
                QualificationTypeList = UnitOfWork.QualificationTypes.GetAll().ToList()
            };
        }

        public DelegationFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Delegation_Edit))
                return Null<DelegationFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<DelegationFormModel>(RequestState.BadRequest);

            var delegation = UnitOfWork.Delegations.Find(id);

            if (delegation == null)
                return Null<DelegationFormModel>(RequestState.NotFound);

            return new DelegationFormModel()
            {
                DelegationId = id,
                SideName = delegation.SideName,
                JobTypeTransfer = delegation.JobTypeTransfer,
                JobNumber = delegation.JobNumber,
                Name = delegation.Name,
                DateFrom = delegation.DateFrom.FormatToString(),
                DateTo = delegation.DateTo.FormatToString(),
                CanSubmit = ApplicationUser.Permissions.Delegation_Edit,
                DecisionDate = delegation.DecisionDate?.FormatToString(),
                DelegationNumber = delegation.DelegationNumber,
                QualificationTypeId = delegation.QualificationTypeId,
                QualificationTypeList = UnitOfWork.QualificationTypes.GetAll().ToList()
            };
        }

        public bool Delete(int id, DelegationFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Delegation_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var delegation = UnitOfWork.Delegations.Find(id);

            if (delegation == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Delegations.Remove(delegation);

            if (!UnitOfWork.TryComplete(n => n.Delegation_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Edit(int id, DelegationFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Delegation_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var delegation = UnitOfWork.Delegations.Find(id);

            if (delegation == null)
                return Fail(RequestState.NotFound);

            delegation.Modify()
                .Name(model.Name)
                .JobNumber(model.JobNumber)
                .JobTypeTransfer(model.JobTypeTransfer)
                .DateFrom(model.DateFrom.ToDateTime())
                .DateTo(model.DateTo.ToDateTime())
                .SideName(model.SideName)
                .DecisionDate(model.DecisionDate?.ToNullableDateTime())
                .DelegationNumber(model.DelegationNumber)
                .QualificationType(model.QualificationTypeId)
                .Confirm();

            UnitOfWork.Complete(n => n.Delegation_Edit);

            return SuccessEdit();
        }

        public bool Create(DelegationFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Delegation_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var delegation = Delegation.New()
                .WithName(model.Name)
                .WithJobNumber(model.JobNumber)
                .WithJobTypeTransfer(model.JobTypeTransfer)
                .WithDateFrom(model.DateFrom.ToDateTime())
                .WithDateTo(model.DateTo.ToDateTime())
                .WithSideName(model.SideName)
                .WithQualificationTypeId(model.QualificationTypeId)
                .WithDelegationNumber(model.DelegationNumber)
                .WithDecisionDate(model.DecisionDate?.ToNullableDateTime())
                .Biuld();

            UnitOfWork.Delegations.Add(delegation);

            UnitOfWork.Complete(n => n.Delegation_Create);

            return SuccessCreate();
        }

        public void Refresh(DelegationFormModel model)
        {
        }
    }
}