using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class CorporationController : BaseController
    {
        // GET: Corporation
        public ActionResult Index()
        {
            var model = HumanResource.Corporation.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: Corporation/Create
        public ActionResult Create()
        {
            var model = HumanResource.Corporation.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Corporation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CorporationFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(CorporationFormModel model, string save)
        {
            HumanResource.Corporation.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Corporation.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Corporation/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.Corporation.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Corporation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CorporationFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, CorporationFormModel model, string save)
        {
            HumanResource.Corporation.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.Corporation.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: Corporation/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.Corporation.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: Corporation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.Corporation.Find(id);
            if (!HumanResource.Corporation.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(CorporationFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CorporationFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.CountryList = loadedModel.CountryList;

        }
    }
}