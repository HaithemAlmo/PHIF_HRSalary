using Almotkaml.HR.Models;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SalaryInfoController : BaseController
    {
        // GET: SalaryInfo
        public ActionResult Index()
        {
            var model = HumanResource.SalaryInfo.Index();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        // GET: SalaryInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HumanResource.SalaryInfo.Find(id);

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: SalaryInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SalaryInfoFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxEdit(id, model, save);
        }

        private PartialViewResult AjaxEdit(int id, SalaryInfoFormModel model, string save)
        {
            HumanResource.SalaryInfo.Refresh(model);

            if (save == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);
            foreach (var row in model.TemporaryList)
            {
                foreach (var row2 in model.TemporaryPremiumListItem.Where(s => s.PremiumId == row.PremiumId))
                {
                    row2.ISAdvancePremmium = row.ISAdvancePremmium;
                    row2.IsTemporary = row.IsTemporary;
                     
                    //row2.Value = row.Value;


                }
            }
            if (!ModelState.IsValid)
                return PartialView("_Form", model);
            foreach (var row in model.AdvancPremiumList)
            {
                foreach (var row2 in model.AdvancPremiumList.Where(s => s.PremiumId == row.PremiumId ))
                {
                    row2.Value = row.Value;
                    row2.PremiumId = row.PremiumId;

                }
            }
                if (!HumanResource.SalaryInfo.Save(id, model))
                    return AjaxHumanResourceState("_Form", model);

                CallRedirect();

                return PartialView("_Form", model);
           
        }
        public ActionResult EndedSalary()
        {
            var model = HumanResource.SalaryInfo.EndedSalary();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        private void LoadModel(SalaryInfoFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalaryInfoFormModel>(savedModel);
            if (loadedModel == null)
                return;

            // model.TemporaryPremiumListItem = loadedModel.TemporaryPremiumListItem;
            //model.EmployeePremiumList = loadedModel.EmployeePremiumList;
            model.TemporaryList = loadedModel.TemporaryList;
            model.BankList = loadedModel.BankList;
            model.CanSubmit = loadedModel.CanSubmit;
            model.EmployeeId = loadedModel.EmployeeId;
            model.IsDesignation = loadedModel.IsDesignation;
        }
    }
}