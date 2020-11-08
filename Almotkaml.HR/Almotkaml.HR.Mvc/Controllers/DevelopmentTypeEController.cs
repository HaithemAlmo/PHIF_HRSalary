namespace Almotkaml.HR.Mvc.Controllers
{
    //public class DevelopmentTypeEController : BaseController
    //{
    //    public ActionResult Index()
    //    {
    //        var model = HumanResource.DevelopmentTypeE.Prepare();

    //        if (model == null)
    //            return HumanResourceState();

    //        SaveModel(model);
    //        return View(model);
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Index(DevelopmentTypeEModel model, FormCollection form)
    //    {
    //        LoadModel(model, form["savedModel"]);

    //        HumanResource.DevelopmentTypeE.Refresh(model);

    //        if (!Request.IsAjaxRequest())
    //            return AjaxNotWorking();

    //        return AjaxIndex(model, form);
    //    }

    //    private PartialViewResult AjaxIndex(DevelopmentTypeEModel model, FormCollection form)
    //    {
    //        var editDevelopmentTypeEId = IntValue(form["editDevelopmentTypeEId"]);
    //        var deleteDevelopmentTypeEId = IntValue(form["deleteDevelopmentTypeEId"]);

    //        // Select
    //        if (editDevelopmentTypeEId > 0)
    //            return Select(model, editDevelopmentTypeEId);

    //        // Delete
    //        if (deleteDevelopmentTypeEId > 0)
    //            return Delete(model, deleteDevelopmentTypeEId);

    //        if (form["save"] == null)
    //        {
    //            ModelState.Clear();
    //            return PartialView("_Form", model);
    //        }

    //        // Insert
    //        if (!ModelState.IsValid)
    //            return PartialView("_Form", model);

    //        if (model.DevelopmentTypeEId == 0)
    //        {
    //            if (!HumanResource.DevelopmentTypeE.Create(model))
    //                return AjaxHumanResourceState("_Form", model);
    //        }

    //        if (model.DevelopmentTypeEId > 0)
    //        {
    //            if (!HumanResource.DevelopmentTypeE.Edit(model))
    //                return AjaxHumanResourceState("_Form", model);
    //        }

    //        CallRedirect();
    //        return PartialView("_Form", model);
    //    }
    //    private PartialViewResult Select(DevelopmentTypeEModel model, int editDevelopmentTypeEId)
    //    {
    //        ModelState.Clear();
    //        model.DevelopmentTypeEId = editDevelopmentTypeEId;

    //        if (!HumanResource.DevelopmentTypeE.Select(model))
    //            return AjaxHumanResourceState("_Form", model);

    //        return PartialView("_Form", model);
    //    }
    //    private PartialViewResult Delete(DevelopmentTypeEModel model, int deleteDevelopmentTypeEId)
    //    {
    //        ModelState.Clear();
    //        model.DevelopmentTypeEId = deleteDevelopmentTypeEId;

    //        if (!HumanResource.DevelopmentTypeE.Delete(model))
    //            return AjaxHumanResourceState("_Form", model);
    //        CallRedirect();
    //        return PartialView("_Form", model);
    //    }

    //    private void LoadModel(DevelopmentTypeEModel model, string savedModel)
    //    {
    //        var loadedModel = LoadSavedModel<DevelopmentTypeEModel>(savedModel);

    //        if (loadedModel == null)
    //            return;

    //        model.CanCreate = loadedModel.CanCreate;
    //        model.CanEdit = loadedModel.CanEdit;
    //        model.CanDelete = loadedModel.CanDelete;
    //        model.Grid = loadedModel.Grid;
    //        model.DevelopmentTypeAList = loadedModel.DevelopmentTypeAList;
    //        model.DevelopmentTypeBList = loadedModel.DevelopmentTypeBList;
    //        model.DevelopmentTypeCList = loadedModel.DevelopmentTypeCList;
    //        model.DevelopmentTypeDList = loadedModel.DevelopmentTypeDList;
    //    }
    //}
}


