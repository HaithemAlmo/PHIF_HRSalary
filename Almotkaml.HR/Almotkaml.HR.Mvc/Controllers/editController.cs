using Almotkaml.HR.Models;
using System;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class editController : BaseController
    {

        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HumanResource.TechnicalAffairsDepartment.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);
            return View(model);
        }
        public void Refresh(TechnicalAffairsDepartmentModel model)
        {
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
          // LoadModel(model, form["savedModel"]);

            HumanResource.TechnicalAffairsDepartment.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }
        public ActionResult Ajaxedit(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            //    LoadModel(model, form["savedModel"]);

            //    HumanResource.TechnicalAffairsDepartment.Refresh(model);

            //    if (!Request.IsAjaxRequest())
            //        return AjaxNotWorking();

            //    return AjaxIndex(model, form);

            return View("edit", model);
        }
        private PartialViewResult AjaxIndex(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            var editEntrantsAndReviewersId = IntValue(form["editEntrantsAndReviewersId"]);

            var search = (form["search"]);
            if (search == "search")
            {
                //var aa = model.EntrantsAndReviewersType;
                //if(model.EntrantsAndReviewersType != null) {
                //    HumanResource.TechnicalAffairsDepartment.Select(model);
                //}
                if(model.YearWork == 0 || model.MonthWork ==0)
                    return PartialView("_Form", model);

                HumanResource.TechnicalAffairsDepartment.Select0(model);
            }

            if (editEntrantsAndReviewersId > 0) {
                if (HumanResource.TechnicalAffairsDepartment.SelectEntries(model))
                    return PartialView("_Form", model);
            }
            return PartialView("_Form", model);
        }


        private PartialViewResult Select(TechnicalAffairsDepartmentModel model, int editTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
        model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;
             model.EntrantsAndReviewersId= editTechnicalAffairsDepartmentId;
            if (HumanResource.TechnicalAffairsDepartment.Select(model))
                HumanResource.TechnicalAffairsDepartment.Edit(model);
               // return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Create(TechnicalAffairsDepartmentModel model, int createTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
         //  model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;
            model.EntrantsAndReviewersId = model.TechnicalAffairsDepartmentId;
            if (!HumanResource.TechnicalAffairsDepartment.Create(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(TechnicalAffairsDepartmentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<TechnicalAffairsDepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.EntrantsAndReviewersGrid = loadedModel.EntrantsAndReviewersGrid;
        }

   
    }
}