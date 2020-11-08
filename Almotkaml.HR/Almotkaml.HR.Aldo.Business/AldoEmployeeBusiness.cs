using Almotkaml.Extensions;
using Almotkaml.HR.Aldo.Models;
using Almotkaml.HR.Business;
using Almotkaml.HR.Business.App_Business.MainSettings;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Aldo.Business
{
    public class AldoEmployeeBusiness : EmployeeBusiness
    {
        public AldoEmployeeBusiness(HumanResource humanResource) : base(humanResource)
        {

        }

        public override EmployeeFormModel Find(int id)
        {
            var model = base.Find(id);

            model.JobInfoModel = model.JobInfoModel.As<AldoJobInfoModel>();

            return model;
        }

        public override bool Edit(int id, JobInfoModel model) => Edit(id, model.As<AldoJobInfoModel>());

        private bool Edit(int id, AldoJobInfoModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Employee_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(id);

            if (employee.JobInfo == null)
                return false;

            var modifier = employee.JobInfo.Modify()
                .EmploymentValues(model.EmploymentValues.ToDomain())
                .DirectlyDate(model.DirectlyDate.ToDateTime())
                .Degree(model.Degree, model.ClampDegree, model.SalayClassification)
                .Job(model.JobId)
                .JobNumberApproved(model.JobNumberApproved)
                .CurrentSituation(model.CurrentSituationId)
                .Unit(model.UnitId)
                .DegreeNow(model.DegreeNow, model.ClampDegreeNow, model.SalayClassification)
                .DateDegreeNow(model.DateDegreeNow.ToDateTime())
                .DateMeritDegreeNow(model.DateMeritDegreeNow.ToDateTime())
                .Bouns(model.Bouns)
                .DateBouns(model.DateBouns.ToDateTime())
                .DateMeritBouns(model.DateMeritBouns.ToDateTime())
                .AdjectiveEmployee(model.AdjectiveEmployeeId)
                .Staffing(model.StaffingId)
                .JobType(model.JobType)
                .VacationBalance(model.VacationBalance)
                .Notes(model.Notes)
                .ClassificationOnSearching(model.ClassificationOnSearchingId)
                .ClassificationOnWork(model.ClassificationOnWorkId)
                .SalayClassification(model.SalayClassification)
                //.WithJobClass(model.JobClass)
                .Redirection(model.Redirection, model.RedirectionNote);

            if (employee.JobInfo.JobNumber == 0)
                modifier.JobNumber(UnitOfWork.Employees.GetJobNumber());

            modifier.Confirm();

            UnitOfWork.Complete(n => n.Employee_Edit);

            return SuccessEdit();
        }
    }
}