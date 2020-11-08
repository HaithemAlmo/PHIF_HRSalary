using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EvaluationBusiness : Business, IEvaluationBusiness
    {
        public EvaluationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
       => ApplicationUser.Permissions.Evaluation && permission;


        public EvaluationModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Create))
                return Null<EvaluationModel>(RequestState.NoPermission);

            return new EvaluationModel()
            {
                CanCreate = ApplicationUser.Permissions.Evaluation_Create,
                CanEdit = ApplicationUser.Permissions.Evaluation_Edit,
                CanDelete = ApplicationUser.Permissions.Evaluation_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                EvaluationGrird = UnitOfWork.Evaluations.GetEvaluationByEmployeeId(0).ToGrid()


            };
        }

        public void Refresh(EvaluationModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            var Evaluation= UnitOfWork.Evaluations.GetEvaluationByEmployeeId(model.EmployeeId);

            if (employee == null)
                return;

            model.EmployeeName = employee.GetFullName();
            model.DegreeNow = employee.JobInfo?.DegreeNow ?? 0;
            model.DateDegree = employee.JobInfo?.DateDegreeNow.FormatToString();
            //model.Note = Evaluation?.Select(s => s.Note).Last()?? "";
      
            model.EvaluationGrird = UnitOfWork.Evaluations.GetEvaluationByEmployeeId(model.EmployeeId).ToGrid();
        }

        public bool Select(EvaluationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Edit))
                return Fail(RequestState.NoPermission);
            if (model.EvaluationId <= 0)
                return Fail(RequestState.BadRequest);
            var evaluation = UnitOfWork.Evaluations.Find(model.EvaluationId);
            
            if (evaluation == null)
                return Fail(RequestState.NotFound);
            model.EvaluationId = evaluation.EvaluationId;
            model.EmployeeId = evaluation.EmployeeId;
            model.Grade = evaluation.Grade;
            model.Ratio = evaluation.Ratio.GetValueOrDefault();
            model.Date = evaluation.Date.ToString();
            model.Year = evaluation.Year.GetValueOrDefault();
            model.Note = evaluation.Note;

            return true;
        }

        public bool Create(EvaluationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var evaluation = Evaluation.New()
                .WithEmployeeId(model.EmployeeId)
                .WithGrade(model.Grade)
                .WithRatio(model.Ratio)
                .WithYear(model.Year)
                .WithDate(model.Date.ToDateTime())     
                .WithNote(model.Note)        
                .Biuld();

            UnitOfWork.Evaluations.Add(evaluation);

            UnitOfWork.Complete(n => n.Evaluation_Create);
            Clear(model);

            return SuccessCreate();
        }

        public bool Edit(EvaluationModel model)
        {
            if (model.EvaluationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var evaluation = UnitOfWork.Evaluations.Find(model.EvaluationId);

            if (evaluation == null)
                return Fail(RequestState.NotFound);

            evaluation.Modify()
                   .Employee(model.EmployeeId)
                   .Grade(model.Grade)
                   .Ratio(model.Ratio)
                   .Year(model.Year)
                   .Date(model.Date.ToDateTime())
                   .Note(model.Note)
                   .Confirm();

            UnitOfWork.Complete(n => n.Evaluation_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(EvaluationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Evaluation_Delete))
                return Fail(RequestState.NoPermission);

            if (model.EvaluationId <= 0)
                return Fail(RequestState.BadRequest);

            var evaluation = UnitOfWork.Evaluations.Find(model.EvaluationId);

            if (evaluation == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Evaluations.Remove(evaluation);

            if (!UnitOfWork.TryComplete(n => n.Evaluation_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(EvaluationModel model)
        {
            model.Date = "";
            model.Grade = 0;
            model.Ratio = 0;
            model.Year = 0;
            model.EvaluationId = 0;
            model.Note="";
        }



    }
}
