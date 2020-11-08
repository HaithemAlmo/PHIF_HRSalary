using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TransferBusiness : Business, ITransferBusiness
    {
        public TransferBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Transfer && permission;

        public TransferModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Transfer_Create))
                return Null<TransferModel>(RequestState.NoPermission);

            return new TransferModel()
            {
                CanCreate = ApplicationUser.Permissions.Transfer_Create,
                CanEdit = ApplicationUser.Permissions.Transfer_Edit,
                CanDelete = ApplicationUser.Permissions.Transfer_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                TransferGrid = UnitOfWork.Transfers.GetTransferByEmployeeId(0).ToGrid(),
            };
        }

        public void Refresh(TransferModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);

            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
            model.TransferGrid = UnitOfWork.Transfers.GetTransferByEmployeeId(model.EmployeeId).ToGrid();
        }

        public bool Select(TransferModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Transfer_Edit))
                return Fail(RequestState.NoPermission);
            if (model.TransferId <= 0)
                return Fail(RequestState.BadRequest);

            var transfer = UnitOfWork.Transfers.Find(model.TransferId);

            if (transfer == null)
                return Fail(RequestState.NotFound);
            model.TransferId = transfer.TransferId;
            model.EmployeeId = transfer.EmployeeId;
            model.DateFrom = transfer.DateFrom.FormatToString();
            model.DateTo = transfer.DateTo.FormatToString();
            model.JobTypeTransfer = transfer.JobTypeTransfer;
            model.SideName = transfer.SideName;

            return true;
        }

        public bool Create(TransferModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Transfer_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;
            //if(model.JobTypeTransfer==JobTypeTransfer.EmptiedFull)
            //{
            //    model.JobTypeTransfer=="تفرغجز"
            //}
            var transfer = Transfer.New()
                .WithEmployeeId(model.EmployeeId)
                .WithJobTypeTransfer(model.JobTypeTransfer)
                .WithDateFrom(model.DateFrom.ToDateTime())
                .WithDateTo(model.DateTo.ToDateTime())
                .WithSideName(model.SideName)
                .Biuld();

            UnitOfWork.Transfers.Add(transfer);

            UnitOfWork.Complete(n => n.Transfer_Create);
            Clear(model);
            return SuccessCreate();
        }

        public bool Edit(TransferModel model)
        {
            if (model.TransferId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Transfer_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var transfer = UnitOfWork.Transfers.Find(model.TransferId);

            if (transfer == null)
                return Fail(RequestState.NotFound);

            transfer.Modify()
                .JobTypeTransfer(model.JobTypeTransfer)
                .DateFrom(model.DateFrom.ToDateTime())
                .DateTo(model.DateTo.ToDateTime())
                .SideName(model.SideName)
                .Confirm();

            UnitOfWork.Complete(n => n.Transfer_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(TransferModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Transfer_Delete))
                return Fail(RequestState.NoPermission);

            if (model.TransferId <= 0)
                return Fail(RequestState.BadRequest);

            var transfer = UnitOfWork.Transfers.Find(model.TransferId);

            if (transfer == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Transfers.Remove(transfer);

            if (!UnitOfWork.TryComplete(n => n.Transfer_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(TransferModel model)
        {
            model.TransferId = 0;
            model.DateFrom = "";
            model.DateTo = "";
            model.JobTypeTransfer = 0;
            model.SideName = "";

        }

    }
}