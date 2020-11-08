using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class JobBusiness : Business, IJobBusiness
    {
        public JobBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Job && permission;


        public JobModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Job_Create))
                return Null<JobModel>(RequestState.NoPermission);

            return new JobModel()
            {
                CanCreate = ApplicationUser.Permissions.Job_Create,
                CanEdit = ApplicationUser.Permissions.Job_Edit,
                CanDelete = ApplicationUser.Permissions.Job_Delete,
                JobGrid = UnitOfWork.Jobs
                    .GetAll()
                    .Select(a => new JobGridRow()
                    {
                        JobId = a.JobId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(JobModel model)
        {

        }

        public bool Select(JobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Job_Edit))
                return Fail(RequestState.NoPermission);
            if (model.JobId <= 0)
                return Fail(RequestState.BadRequest);

            var job = UnitOfWork.Jobs.Find(model.JobId);

            if (job == null)
                return Fail(RequestState.NotFound);

            model.Name = job.Name;
            return true;
        }

        public bool Create(JobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Job_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Jobs.NameIsExisted(model.Name))
                return NameExisted();
            var job = Job.New(model.Name);
            UnitOfWork.Jobs.Add(job);

            UnitOfWork.Complete(n => n.Job_Create);

            return SuccessCreate();
        }

        public bool Edit(JobModel model)
        {
            if (model.JobId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Job_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var job = UnitOfWork.Jobs.Find(model.JobId);

            if (job == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Jobs.NameIsExisted(model.Name, model.JobId))
                return NameExisted();
            job.Modify(model.Name);

            UnitOfWork.Complete(n => n.Job_Edit);

            return SuccessEdit();
        }

        public bool Delete(JobModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Job_Delete))
                return Fail(RequestState.NoPermission);

            if (model.JobId <= 0)
                return Fail(RequestState.BadRequest);

            var job = UnitOfWork.Jobs.Find(model.JobId);

            if (job == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Jobs.Remove(job);

            if (!UnitOfWork.TryComplete(n => n.Job_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}