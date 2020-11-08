using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SanctionBusiness : Business, ISanctionBusiness
    {
        public SanctionBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Sanction && permission;

        public SanctionModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Sanction_Create))
                return Null<SanctionModel>(RequestState.NoPermission);

            return new SanctionModel()
            {
                CanCreate = ApplicationUser.Permissions.Sanction_Create,
                CanEdit = ApplicationUser.Permissions.Sanction_Edit,
                CanDelete = ApplicationUser.Permissions.Sanction_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                SanctionGrid = UnitOfWork.Sanctions.GetSanctionByEmployeeId(0).ToGrid(),
                SanctionTypeList = UnitOfWork.SanctionTypes.GetAll().ToList()



            };
        }

        public void Refresh(SanctionModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);

            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
            model.SanctionGrid = UnitOfWork.Sanctions.GetSanctionByEmployeeId(model.EmployeeId).ToGrid();
            model.SanctionTypeList = UnitOfWork.SanctionTypes.GetAll().ToList();
        }

        public bool Select(SanctionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Sanction_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SanctionId <= 0)
                return Fail(RequestState.BadRequest);

            var sanction = UnitOfWork.Sanctions.Find(model.SanctionId);

            if (sanction == null)
                return Fail(RequestState.NotFound);
            model.SanctionId = sanction.SanctionId;
            model.EmployeeId = sanction.EmployeeId;
            model.Cause = sanction.Cause;
            model.SanctionTypeId = sanction.SanctionTypeId;
            model.Date = sanction.Date.ToString();
            model.SanctionsDay = sanction.SanctionDay;
            //model.DeductionMonth = sanction.DeductionMonth;
            return true;
        }

        public bool Create(SanctionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Sanction_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var sanction = Sanction.New()
                .WithSanctionTypeId(model.SanctionTypeId)
                .WithDate(model.Date.ToDateTime())
                .WithCause(model.Cause)
                .WithSanctionDay(model.SanctionsDay)
                .WithDeductionMonth(model.DeductionMonth)
                .WithDeductionYear(model.DeductionYear)
                .WithEmployeeId(model.EmployeeId)
                .Biuld();
            UnitOfWork.Sanctions.Add(sanction);

            UnitOfWork.Complete(n => n.Sanction_Create);
            Clear(model);
            return SuccessCreate();
        }

        public bool Edit(SanctionModel model)
        {
            if (model.SanctionId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Sanction_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var sanction = UnitOfWork.Sanctions.Find(model.SanctionId);

            if (sanction == null)
                return Fail(RequestState.NotFound);

            sanction.Modify()
                .SanctionType(model.SanctionTypeId)
                .Date(model.Date.ToDateTime())
                .Cause(model.Cause)
                .SanctionsDay(model .SanctionsDay)
                .DeductionMonth(model .DeductionMonth)
                .DeductionYear (model .DeductionYear)
                .Employee(model.EmployeeId)
                .Confirm();

            UnitOfWork.Complete(n => n.Sanction_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(SanctionModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Sanction_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SanctionId <= 0)
                return Fail(RequestState.BadRequest);

            var sanction = UnitOfWork.Sanctions.Find(model.SanctionId);

            if (sanction == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Sanctions.Remove(sanction);

            if (!UnitOfWork.TryComplete(n => n.Sanction_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(SanctionModel model)
        {
            model.SanctionId = 0;
            model.Date = "";
            model.Cause = "";
            model.SanctionTypeId = 0;
            model.SanctionsDay = 0;
            model.DeductionMonth = 0;
            model.DeductionYear = 0;
        }

    }
}