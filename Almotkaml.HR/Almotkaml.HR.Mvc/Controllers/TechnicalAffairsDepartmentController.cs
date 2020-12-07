using Almotkaml.HR.Models;
using System;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class TechnicalAffairsDepartmentController : BaseController
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
            LoadModel(model, form["savedModel"]);

            HumanResource.TechnicalAffairsDepartment.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

     
        public ActionResult edit()
        {
            var model0 = HumanResource.TechnicalAffairsDepartment.Prepare();

            if (model0 == null)
                return HumanResourceState();

            SaveModel(model0);
            return View(model0);

           // return View("edit", model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit(TechnicalAffairsDepartmentModel model, FormCollection form)
        {

            LoadModel(model, form["savedModel"]);

            HumanResource.TechnicalAffairsDepartment.Refresh(model);
            //if (!Request.IsAjaxRequest())
            //    return AjaxNotWorking();

            return View("edit", model);
        }



        private PartialViewResult AjaxIndex(TechnicalAffairsDepartmentModel model, FormCollection form)
        {
            var editTechnicalAffairsDepartmentId = IntValue(form["editTechnicalAffairsDepartmentd"]);
            var deleteTechnicalAffairsDepartmentId = IntValue(form["deleteTechnicalAffairsDepartmentId"]);
            var createchnicalAffairsDepartmentId = IntValue(form["createTechnicalAffairsDepartmentd"]);
            //var editEntrantsAndReviewersId = IntValue(form["editEntrantsAndReviewersId"]);
            // Select
            //if (editEntrantsAndReviewersId > 0)

            // if( HumanResource.TechnicalAffairsDepartment.SelectEntries(model,editEntrantsAndReviewersId))
            //        return AjaxHumanResourceState("_Form", model);


            if (editTechnicalAffairsDepartmentId > 0)
                return Select(model, editTechnicalAffairsDepartmentId);
            //return Select(model, editEntrantsAndReviewersId );
            //Delete
            //if (deleteTechnicalAffairsDepartmentId > 0)
       // Insert
            //if (!ModelState.IsValid)
            //    return PartialView("_Form", model);
            //    return Create(model, CreatechnicalAffairsDepartmentId);

     
            if (createchnicalAffairsDepartmentId== 0)
            {
                if (!HumanResource.TechnicalAffairsDepartment .Create(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            if (model.TechnicalAffairsDepartmentId > 0)
            {
                if (!HumanResource.TechnicalAffairsDepartment.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }


        private PartialViewResult Select(TechnicalAffairsDepartmentModel model, int editTechnicalAffairsDepartmentId)
        {
            ModelState.Clear();
        model.TechnicalAffairsDepartmentId = editTechnicalAffairsDepartmentId;
             model.EntrantsAndReviewersId= editTechnicalAffairsDepartmentId;
            if (!HumanResource.TechnicalAffairsDepartment .Select(model))
                return AjaxHumanResourceState("_Form", model);

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