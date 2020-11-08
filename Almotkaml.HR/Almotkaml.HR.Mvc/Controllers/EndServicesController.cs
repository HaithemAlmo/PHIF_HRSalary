using Almotkaml.HR.Models;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class EndServicesController : BaseController
    {
        // GET: EndServices
        public ActionResult Index()
        {
            var model = HumanResource.EndServices.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: EndServices/Create
        public ActionResult Create()
        {
            var model = HumanResource.EndServices.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: EndServices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EndServicesFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxCreate(model, save);
        }

        public PartialViewResult AjaxCreate(EndServicesFormModel model, string save)
        {
            HumanResource.EndServices.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.EndServices.Create(model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: EndServices/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.EndServices.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: EndServices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EndServicesFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, EndServicesFormModel model, string save)
        {
            HumanResource.EndServices.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.EndServices.Edit(id, model))
                return AjaxHumanResourceState("_Form", model);

            CallRedirect();

            return PartialView("_Form", model);
        }

        // GET: EndServices/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HumanResource.EndServices.Find(id);

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // POST: EndServices/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HumanResource.EndServices.Find(id);
            if (!HumanResource.EndServices.Delete(id, model))
                return HumanResourceState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(EndServicesFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<EndServicesFormModel>(savedModel);
            if (loadedModel == null)
                return;

            model.CanSubmit = loadedModel.CanSubmit;
            model.EmployeeGrid = loadedModel.EmployeeGrid;


        }
    }
}