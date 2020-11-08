using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class AbsenceBusiness : Business, IAbsenceBusiness
    {
        public AbsenceBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Absence && permission;

        public AbsenceModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Absence_Create))
                return Null<AbsenceModel>(RequestState.NoPermission);

            return new AbsenceModel()
            {
                CanCreate = ApplicationUser.Permissions.Absence_Create,
                CanEdit = ApplicationUser.Permissions.Absence_Edit,
                CanDelete = ApplicationUser.Permissions.Absence_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                AbsenceGrid = UnitOfWork.Absences.GetAbsenceByEmployeeId(0).ToGrid(),
            };
        }

        public void Refresh(AbsenceModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);

            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
            model.AbsenceGrid = UnitOfWork.Absences.GetAbsenceByEmployeeId(model.EmployeeId).ToGrid();
        }

        public bool Select(AbsenceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Absence_Edit))
                return Fail(RequestState.NoPermission);
            if (model.AbsenceId <= 0)
                return Fail(RequestState.BadRequest);

            var absence = UnitOfWork.Absences.Find(model.AbsenceId);

            if (absence == null)
                return Fail(RequestState.NotFound);
            model.AbsenceId = absence.AbsenceId;
            model.EmployeeId = absence.EmployeeId;
            model.Note = absence.Note;
            model.AbsenceType = absence.AbsenceType;
            model.Date = absence.Date.ToString();
            model.DeductionMonth = absence.DeductionMonth;
            model.DeductionYear = absence.DeductionYear;
            model.AbsenceDay = absence.AbsenceDay;
            return true;
        }

        public bool Create(AbsenceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Absence_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Absences.CheckAbsenceBy(model.EmployeeId, model.Date.ToDateTime()))
                return false;

            var absence = Absence.New()
                .WithAbsenceType(model.AbsenceType)
                .WithDate(model.Date.ToDateTime())
                .WithDeductionMonth(model .DeductionMonth)
                .WithDeductionYear (model.DeductionYear)
                .WithNote(model.Note)
                .WithDay(model.AbsenceDay)
                .WithEmployeeId(model.EmployeeId)
                .Biuld();

            UnitOfWork.Absences.Add(absence);

            UnitOfWork.Complete(n => n.Absence_Create);
            model.AbsenceGrid = UnitOfWork.Absences.GetAbsenceByEmployeeId(model.EmployeeId).ToGrid();
            Clear(model);
            return SuccessCreate();
        }

        public bool Edit(AbsenceModel model)
        {
            if (model.AbsenceId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Absence_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Absences.CheckAbsenceBy(model.EmployeeId, model.Date.ToDateTime()))
                return false;

            var absence = UnitOfWork.Absences.Find(model.AbsenceId);

            if (absence == null)
                return Fail(RequestState.NotFound);

            absence.Modify()
              .AbsenceType(model.AbsenceType)
                .Date(model.Date.ToDateTime())
                .DeductionMonth (model .DeductionMonth)
                .DeductionYear (model .DeductionYear)
                .Note(model.Note)
                .Days(model.AbsenceDay)
                .Confirm();

            UnitOfWork.Complete(n => n.Absence_Edit);

            Clear(model);
            model.AbsenceGrid = UnitOfWork.Absences.GetAbsenceByEmployeeId(model.EmployeeId).ToGrid();
            return SuccessEdit();
        }

        public bool Delete(AbsenceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Absence_Delete))
                return Fail(RequestState.NoPermission);

            if (model.AbsenceId <= 0)
                return Fail(RequestState.BadRequest);

            var absence = UnitOfWork.Absences.Find(model.AbsenceId);

            if (absence == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Absences.Remove(absence);

            if (!UnitOfWork.TryComplete(n => n.Absence_Delete))
                return Fail(UnitOfWork.Message);

            model.AbsenceGrid = UnitOfWork.Absences.GetAbsenceByEmployeeId(model.EmployeeId).ToGrid();
            return SuccessDelete();
        }

        private void Clear(AbsenceModel model)
        {
            model.AbsenceId = 0;
            model.Date = "";
            model.Note = "";
            model.AbsenceType = 0;
            model.DeductionMonth = 0;
            model.DeductionYear = 0;
        }

    }
}