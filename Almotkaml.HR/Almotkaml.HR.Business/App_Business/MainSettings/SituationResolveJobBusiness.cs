using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SituationResolveJobBusiness : Business, ISituationResolveJobBusiness
    {
        public SituationResolveJobBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
         => ApplicationUser.Permissions.SituationResolveJob && permission;

        public SituationResolveJobModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Create))
                return Null<SituationResolveJobModel>(RequestState.NoPermission);

            return new SituationResolveJobModel()
            {
                CanCreate = ApplicationUser.Permissions.SituationResolveJob_Create,
                CanEdit = ApplicationUser.Permissions.SituationResolveJob_Edit,
                CanDelete = ApplicationUser.Permissions.SituationResolveJob_Delete,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                JobNowList = UnitOfWork.Jobs.GetAll().ToList()

            };
        }

        public bool Delete(SituationResolveJobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SituationResolveJobId <= 0)
                return Fail(RequestState.BadRequest);

            var situationResolveJob = UnitOfWork.SituationResolveJobs.Find(model.SituationResolveJobId);

            if (situationResolveJob == null)
                return Fail(RequestState.NotFound);

            if (!UnitOfWork.SituationResolveJobs.IsLastRecode(situationResolveJob.EmployeeId, model.SituationResolveJobId))
                return Fail(RequestState.NotFound);

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);
            if (employee == null)
                return Fail(RequestState.NotFound);

            employee.RemoveSituationResolveJob(situationResolveJob);
            //UnitOfWork.SituationResolveJobs.Remove(situationResolveJob);

            if (!UnitOfWork.TryComplete(n => n.SituationResolveJob_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Edit(SituationResolveJobModel model)
        {
            if (model.SituationResolveJobId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var situationResolveJob = UnitOfWork.SituationResolveJobs.Find(model.SituationResolveJobId);

            if (situationResolveJob == null)
                return Fail(RequestState.NotFound);

            if (!UnitOfWork.SituationResolveJobs.IsLastRecode(situationResolveJob.EmployeeId, model.SituationResolveJobId))
                return Fail(RequestState.NotFound);

            situationResolveJob.Modify(model.DegreeNow, model.BounNow, model.DecisionNumber, model.DecisionDate.ToDateTime(), model.JobNowId);

            UnitOfWork.Complete(n => n.SituationResolveJob_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Create(SituationResolveJobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return false;

            employee.AddSituationResolveJob(model.DegreeNow/*, model.BounNow*/, model.DecisionNumber, model.DecisionDate.ToDateTime(), model.JobNowId, model.Note);

            UnitOfWork.Complete(n => n.SituationResolveJob_Create);
            Clear(model);
            return SuccessCreate();
        }
        public bool Create(SituationResolveJobModel model, int type)
        {
            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Create))
                return Fail(RequestState.NoPermission);



            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return false;

            employee.AddSituationResolveJob(model.DegreeNow/*, model.BounNow*/, model.DecisionNumber, model.DecisionDate.ToDateTime(), model.JobNowId, model.Note);

            UnitOfWork.Complete(n => n.SituationResolveJob_Create);

            return SuccessCreate();
        }

        public bool Select(SituationResolveJobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SituationResolveJob_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SituationResolveJobId <= 0)
                return Fail(RequestState.BadRequest);

            var situationResolveJob = UnitOfWork.SituationResolveJobs.Find(model.SituationResolveJobId);

            if (situationResolveJob == null)
                return Fail(RequestState.NotFound);
            model.SituationResolveJobId = situationResolveJob.SituationResolveJobId;
            model.EmployeeId = situationResolveJob.EmployeeId;
            model.DecisionDate = situationResolveJob.DecisionDate.FormatToString();
            model.Degree = situationResolveJob.Degree ?? 0;
            model.Boun = situationResolveJob.Boun ?? 0;
            model.DegreeNow = situationResolveJob.DegreeNow;
            model.BounNow = situationResolveJob.BounNow;
            model.DecisionNumber = situationResolveJob.DecisionNumber;
            model.DateDegreeLast = situationResolveJob.DateDegreeLast.FormatToString();
            model.DateBounLast = situationResolveJob.DateBounLast.FormatToString();
            model.JobNowId = situationResolveJob.JobNowId ?? 0;
            model.JobLastId = situationResolveJob.JobLastId ?? 0;
            model.JobNowList = UnitOfWork.Jobs.GetAll().ToList();
            model.JobLastList = UnitOfWork.Jobs.GetAll().ToList();
            model.Note = situationResolveJob.Note;
            return true;
        }
        public void Refresh(SituationResolveJobModel model)
        {
            var situationResolveJob = UnitOfWork.SituationResolveJobs.Find(model.SituationResolveJobId);
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee?.JobInfo == null)
            {
                ModelState.AddError("هذا الموظف لاتوجد لديه بيانات وظيفية");
                return;
            }
            model.EmployeeName = employee.GetFullName();
            model.JobNowList = UnitOfWork.Jobs.GetAll().ToList();
            model.Boun = employee.JobInfo?.Bouns ?? 0;
            model.Degree = employee.JobInfo?.DegreeNow ?? 0;
            model.DateDegreeLast = employee.JobInfo?.DateDegreeNow.FormatToString();
            if (situationResolveJob?.SituationResolveJobId != null)
            {
                model.Boun = situationResolveJob.Boun ?? 0;
                model.Degree = situationResolveJob?.DegreeNow ?? 0;
                model.DateDegreeLast = situationResolveJob.DateDegreeLast.FormatToString();
                
                //model.JobNowId = situationResolveJob?.JobNowId ?? 0;
                model.SituationResolveJobGrid = UnitOfWork.SituationResolveJobs.GetSituationResolveJobByEmployeeId(situationResolveJob.EmployeeId).ToGrid();
            }
            else
            {
                model.SituationResolveJobGrid = UnitOfWork.SituationResolveJobs.GetSituationResolveJobByEmployeeId(model.EmployeeId).ToGrid();
                
                model.JobNowId = employee.JobInfo?.JobId ?? 0;
            }
           

            //model.Note = situationResolveJob.Note ??"";
        }

        private void Clear(SituationResolveJobModel model)
        {
            model.SituationResolveJobId = 0;
            model.DecisionDate = "";
            //model.Boun = 0;
            //model.Degree = 0;
            model.BounNow = 0;
            model.DegreeNow = 0;
            model.DecisionNumber = "";
            model.DecisionDate = "";
            //model.DateDegreeLast = "";
            //model.DateBounLast = "";
            model.JobNowId = 0;
            model.JobLastId = 0;
            model.Note = "";
            //model.JobLastList = new HashSet<JobListItem>();
            model.JobNowList = new HashSet<JobListItem>();

        }
    }
}
