using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class ExtraWorkBusiness : Business, IExtraWorkBusiness
    {

        public ExtraWorkBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
                  => ApplicationUser.Permissions.Extrawork && permission;


        public ExtraWorkModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Extrawork_Create))
                return Null<ExtraWorkModel>(RequestState.NoPermission);

            return new ExtraWorkModel()
            {
                CanCreate = ApplicationUser.Permissions.Extrawork_Create,
                CanEdit = ApplicationUser.Permissions.Extrawork_Edit,
                CanDelete = ApplicationUser.Permissions.Extrawork_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                ExtraWorkGridRows = UnitOfWork.ExtraWorks.GetExtraWorkByEmployeeId(0).ToGrid()

            };
        }

        public void Refresh(ExtraWorkModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
            model.ExtraWorkGridRows = UnitOfWork.ExtraWorks.GetExtraWorkByEmployeeId(model.EmployeeId).ToGrid();
        }

        public bool Select(ExtraWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Extrawork_Edit))
                return Fail(RequestState.NoPermission);
            if (model.ExtraWorkId <= 0)
                return Fail(RequestState.BadRequest);

            var extraWork = UnitOfWork.ExtraWorks.Find(model.ExtraWorkId);

            if (extraWork == null)
                return Fail(RequestState.NotFound);
            model.ExtraWorkId = extraWork.ExtraworkId;
            model.EmployeeId = extraWork.EmployeeId;
            model.Date = extraWork.Date.ToString();
            model.DateFrom = extraWork.DateFrom.ToString();
            model.DateTo = extraWork.DateTo.ToString();
            model.DecisionNumber = extraWork.DecisionNumber;
            model.TimeCount = extraWork.TimeCount;

            return true;
        }

        public bool Create(ExtraWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Extrawork_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var extraWork = Extrawork.New()
                 .WithEmployeeId(model.EmployeeId)
                        .WithTimeCount(model.TimeCount)
                        .WithDecisionNumber(model.DecisionNumber)
                        .WithDate(model.Date.ToDateTime())
                        .WithIDateFrom(model.DateFrom.ToDateTime())
                        .WithDateTo(model.DateTo.ToDateTime())
                        .Biuld();
            UnitOfWork.ExtraWorks.Add(extraWork);

            UnitOfWork.Complete(n => n.Extrawork_Create);
            Clear(model);

            return SuccessCreate();
        }

        public bool Edit(ExtraWorkModel model)
        {
            if (model.ExtraWorkId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Extrawork_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var extraWork = UnitOfWork.ExtraWorks.Find(model.ExtraWorkId);

            if (extraWork == null)
                return Fail(RequestState.NotFound);

            extraWork.Modify()
                    .Employee(model.EmployeeId)
                .TimeCoun(model.TimeCount)
                .DecisionNumber(model.DecisionNumber)
                .Date(model.Date.ToDateTime())
                .DateFrom(model.DateFrom.ToDateTime())
                .DateTo(model.DateTo.ToDateTime())
                .Confirm();

            UnitOfWork.Complete(n => n.Extrawork_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(ExtraWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Extrawork_Delete))
                return Fail(RequestState.NoPermission);

            if (model.ExtraWorkId <= 0)
                return Fail(RequestState.BadRequest);

            var extraWork = UnitOfWork.ExtraWorks.Find(model.ExtraWorkId);

            if (extraWork == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.ExtraWorks.Remove(extraWork);

            if (!UnitOfWork.TryComplete(n => n.Extrawork_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(ExtraWorkModel model)
        {
            model.Date = "";
            model.DateFrom = "";
            model.DateTo = "";
            model.DecisionNumber = "";
            model.ExtraWorkId = 0;
            model.TimeCount = 0;

        }


    }
}
