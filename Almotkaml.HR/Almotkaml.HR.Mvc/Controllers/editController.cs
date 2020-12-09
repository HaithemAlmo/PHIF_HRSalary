using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
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

         //   var employee = UnitOfWork.te.GetEntrantsAndReviewersByEmployeeId(model.EntrantsAndReviewersId);

            //if (employee == null)
            //    return;

            //model.EmployeeName = employee.EmployeeName;
            //model.EntrantsAndReviewersType = employee.EntrantsAndReviewersType;
         //   model.TechnicalAffairsDepartmentGrid = UnitOfWork.TechnicalAffairsDepartments.GetTechnicalAffairsDepartmentByEmployeeId(model.EntrantsAndReviewersId).ToGrid();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TechnicalAffairsDepartmentModel model, FormCollection form, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.TechnicalAffairsDepartment.Refresh0(model);
            var print = (form["print"]);
            if (print == "print")
            {

                return Report(model, savedModel);
            }
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
           // LoadModel(model, savedModel);

            var editEntrantsAndReviewersId = IntValue(form["editEntrantsAndReviewersId"]);

            //var print = (form["print"]);
            //if (print == "print")
            //{
            //   // return Report(model, savedModel);
            //    //    //var aa = model.EntrantsAndReviewersType;
            //    //    //if(model.EntrantsAndReviewersType != null) {
            //    //    //    HumanResource.TechnicalAffairsDepartment.Select(model);
            //    //    //}
            //    //    if(model.YearWork == 0 || model.MonthWork ==0)
            //    //        return PartialView("_Form", model);

            //    //    HumanResource.TechnicalAffairsDepartment.Select0(model);
            //    //    if(model !=null)
            //    //        return PartialView("_Form", model);
            //}

            if (editEntrantsAndReviewersId > 0)
            {
                if (HumanResource.TechnicalAffairsDepartment.SelectEntries(model, editEntrantsAndReviewersId))
                    return PartialView("_Form", model);
            }
            return PartialView("_Form", model);
        }

        public ActionResult Report(TechnicalAffairsDepartmentModel model, string savedModel)
        {
            LoadModel(model, savedModel);
           var format = string.Format("yyyy-MM-dd", DateTime.Now);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "TechnicalAffairsDepartmentReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
          }

            if (!HumanResource.TechnicalAffairsDepartmentnReportBusiness.View(model))
                return HumanResourceState(model);

            var datasources = new HashSet<TechnicalAffairsDepartmentReport>();

            foreach (var row in model.TechnicalAffairsDepartmentGrid)
            {
                datasources.Add(new TechnicalAffairsDepartmentReport()
                {
                    EmployeeName = row.EmployeeName,
                    EmployeeType =
                                    row.EntrantsAndReviewersType == EntrantsAndReviewersType.Entrant ? "مدخل" :
                                    row.EntrantsAndReviewersType == EntrantsAndReviewersType.Reviewer ? "مراجع" :" " ,
                    MonthYearWork = row.YearWork + "/"+row.MonthWork,
                    DataEntryCount = row.DataEntry,
                    //FirstReviewCount =row.FirstReviewCount,
                    //AccommodationReviewCount=row.AccommodationReviewCount,
                    //ClincReviewCount=row.ClincReviewCount,
                    //TotalBalnace=row.TotalBalnace,
                });
            }

            //DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            //DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ////add by ali alherbade 26-05-2019
            //var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            //var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            //var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            //var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            //var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            //var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            //// end add 

            ReportDataSource rdc = new ReportDataSource("TechnicalAffairsDepartmentReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            //   // new ReportParameter("Date1", "كشف " + model.GetCauseOfEndService()),
                new ReportParameter("date", DateTime.Now.ToString("dd-MM-yyyy")),
            //    new ReportParameter("Date2", dateTo.ToString("dd-MM-yyyy")),
            //    new ReportParameter("CompanyName", LongName),
            //    new ReportParameter("Divetion", Department),
               new ReportParameter("name", "تقرير انهاء الخدمة"),
            };

            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            string mimeType;
            string encoding;
            string filenameextention;
            string deviceinfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            var renderedBytes = lr.Render(
                "PDF",
                deviceinfo,
                out mimeType,
                out encoding,
                out filenameextention,
                out stream,
                out warnings);

            return File(renderedBytes, mimeType);
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