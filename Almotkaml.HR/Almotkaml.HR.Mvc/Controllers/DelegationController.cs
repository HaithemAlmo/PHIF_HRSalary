using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DelegationController : BaseController
    {
        // GET: Delegation
        public ActionResult Index()
        {
            var model = HumanResource.Delegation.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: Delegation/Create
        public ActionResult Create()
        {
            var model = HumanResource.Delegation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Delegation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DelegationFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(DelegationFormModel model, string save)
        {
            HumanResource.Delegation.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Delegation.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Delegation/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Delegation.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Delegation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DelegationFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, DelegationFormModel model, string save)
        {
            HumanResource.Delegation.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Delegation.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Delegation/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Delegation.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Delegation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Delegation.Find(id);
            if (!HumanResource.Delegation.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(DelegationFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DelegationFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.QualificationTypeList = loadedModel.QualificationTypeList;
        }
    }
}