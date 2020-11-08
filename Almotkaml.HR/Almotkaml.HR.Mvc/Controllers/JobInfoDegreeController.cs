using Almotkaml.HR.Models;
using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class JobInfoDegreeController : BaseController
    {
        // GET: JobInfoDegree
        public virtual ActionResult Index()
        {
            var model = HumanResource.Employee.PrepareJobInfoDegree();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]

        public ActionResult Index( JobInfoDegreeModel model, string save, string savedModel, FormCollection form)
        {
           
            HumanResource.Employee.Refresh(model);

            if (model == null)
                return HumanResourceState();

            return PartialView(model);

        }

        public virtual ActionResult EditJobDegree(int id)
        {
            var model = new JobInfoDegreeModel();
             HumanResource.Employee.Refresh(id, model);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJobDegree(int id, JobInfoDegreeModel model, string savedModel, FormCollection form)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();
            return AjaxEdit(id, model,form);
        }



        private PartialViewResult AjaxEdit(int id, JobInfoDegreeModel model, FormCollection form)
        {

            HumanResource.Employee.Refresh(id, model);
            if (form["editJobInfoId"] != null)
            {
                //ModelState.Clear();
                model.EmployeeId = id;


                if (!HumanResource.Employee.Edit(id, model))
                    return PartialView("_FormEdit", model);

            }
            if (form["SettlementJobInfoId"] != null)
            {

                model.SituationResolveJob = new SituationResolveJobModel();
                model.SituationResolveJob.SituationResolveJobId = HumanResource.Employee.Find(id).SituationResolveJobModel.SituationResolveJobId;
                if (model.SituationResolveJob.SituationResolveJobId == 0)
                {
                    model.SituationResolveJob.EmployeeId = id;
                    model.SituationResolveJob.DegreeNow = model.DegreeNow ?? 0;
                    model.SituationResolveJob.BounNow = model.Bouns ?? 0;
                    model.SituationResolveJob.DecisionDate = model.DecisionDate;
                    model.SituationResolveJob.DecisionNumber = model.DecisionNumber.ToString();
                    model.SituationResolveJob.JobNowId = model.JobId ?? 0;
                    if (!HumanResource.SituationResolveJob.Create(model.SituationResolveJob, 1))
                        return PartialView("_FormEdit", model);
                }

                if (model.SituationResolveJob.SituationResolveJobId > 0)
                {
                    if (!HumanResource.SituationResolveJob.Edit(model.SituationResolveJob))
                        return PartialView("_FormEdit", model);
                }
            }
            if (form["PromotionJobInfoId"] != null)
            {
                //ModelState.Clear();
                model.EmployeeId = id;
              

                    if (!HumanResource.Degree.Submit(model, 2))
                    return PartialView("_FormEdit", model);

            }

         
            CallRedirect();

            return PartialView("_FormEdit", model);
        }

        private void LoadModel(JobInfoDegreeModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<JobInfoDegreeModel>(savedModel);

            if (loadedModel == null)
                return;

            model.JobList = loadedModel.JobList;
            //model.NewJobId = loadedModel.NewJobId;
            model.DegreeGrid = loadedModel.DegreeGrid;
            model.CanSubmit = loadedModel.CanSubmit;
            model.CanPromotion = loadedModel.CanPromotion;
            model.CanSettlement = loadedModel.CanSettlement;

        }
        //public enum PromotionType
        //{
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.PromotionEnt))]
        //    PromotionEnt =1,
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.PromotionReq))]
        //    PromotionReq =2

        //}
        
        //public enum PromotionSeason
        //{
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.All))]
        //    All = 0,
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstOfYear))]
        //    FirstOfYear = 1,
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.SecondOfYear))]
        //    SecondOfYear = 2

        //}



        //private PartialViewResult Submit(JobInfoDegreeModel model, int? editEmployeeId)
        //{
        //    ModelState.Clear();
        //    model.EmployeeId = editEmployeeId ?? 0;

        //    if (!HumanResource.Degree.Submit(model, 2))
        //        return AjaxHumanResourceState("_Form", model);

        //    model = HumanResource.Employee.PrepareJobInfoDegree();

        //    return PartialView("_Form", model);
        //}

        //private PartialViewResult AjaxEdit(int id, JobInfoDegreeModel model, string save, FormCollection form)
        //{
        //    //HumanResource.Employee.Refresh(id, model);

        //    if (form["editJobInfoId"] != null)
        //    {
        //        //ModelState.Clear();
        //        model.EmployeeId = id;


        //        if (!HumanResource.Employee.Edit(id, model))
        //            return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);

        //    }
        //    if (form["SettlementJobInfoId"] != null)
        //    {

        //        model.SituationResolveJob = new SituationResolveJobModel();
        //        model.SituationResolveJob.SituationResolveJobId = HumanResource.Employee.Find(id).SituationResolveJobModel.SituationResolveJobId;
        //        if (model.SituationResolveJob.SituationResolveJobId == 0)
        //        {
        //            //(model.DegreeNow, model.BounNow, model.DecisionNumber, model.DecisionDate.ToDateTime(), model.JobNowId,model.Note )
        //            model.SituationResolveJob.EmployeeId = id;
        //            model.SituationResolveJob.DegreeNow = model.DegreeNow ?? 0;
        //            model.SituationResolveJob.BounNow = model.Bouns ?? 0;
        //            model.SituationResolveJob.DecisionDate = model.DateDegreeNow;
        //            model.SituationResolveJob.DecisionNumber = model.DegreeLastResolutionNumber.ToString();
        //            model.SituationResolveJob.JobNowId = model.JobId ?? 0;
        //            if (!HumanResource.SituationResolveJob.Create(model.SituationResolveJob, 1))
        //                return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
        //        }

        //        if (model.SituationResolveJob.SituationResolveJobId > 0)
        //        {
        //            if (!HumanResource.SituationResolveJob.Edit(model.SituationResolveJob))
        //                return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);
        //        }
        //    }
        //    if (form["PromotionJobInfoId"] != null)
        //    {
        //        //ModelState.Clear();
        //        model.EmployeeId = id;


        //        if (!HumanResource.Degree.Submit(model, 2))
        //            return AjaxHumanResourceState("_JobInfoDegreeModelForm", model);

        //    }

        //    return PartialView("_JobInfoDegreeModelForm", model);



        //}
    }
}