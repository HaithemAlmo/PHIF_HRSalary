using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SettlementReportController : BaseController
    {
        // GET: SettlementReport
        public ActionResult Index()
        {
            var model = HumanResource.SettlementReport.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SettlementReportModel model, string search, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return Report(model, savedModel);
            //return AjaxNotWorking();

            return AjaxIndex(model, search);
        }

        private PartialViewResult AjaxIndex(SettlementReportModel model, string search)
        {
            //LoadModel(model, savedModel);
            if (search == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.SettlementReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SettlementReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SettlementReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Grid = loadedModel.Grid;
        }

        public ActionResult Report(SettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "EndServicesReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SettlementReport.View(model))
                return HumanResourceState(model);

            var datasources = new HashSet<EndServicesReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EndServicesReport()
                {
                    EmployeeName = row.Name,
                    Cause =
                    //model.GetCauseOfEndService()
                            row.CauseOfEndService == CauseOfEndService.Death ? "متوفي" :
                            row.CauseOfEndService == CauseOfEndService.EndCollaborator ? "أنهاء تعاون" :
                            row.CauseOfEndService == CauseOfEndService.EndDelegation ? "أنهاء ندب" :
                            row.CauseOfEndService == CauseOfEndService.EndEmptied ? "أنهاء تفرغ" :
                            row.CauseOfEndService == CauseOfEndService.EndOut ? "نقل خارجي" :
                            row.CauseOfEndService == CauseOfEndService.EndService ? "أنهاء خدمة" :
                            row.CauseOfEndService == CauseOfEndService.Quit ? "استقالة" :
                            row.CauseOfEndService == CauseOfEndService.Retirement ? "تقاعد" :
                            row.CauseOfEndService == CauseOfEndService.RetireOptional ? "تقاعد أختياري" : " "
                            ,
                    WorkPlace = row.Unit,
                    DecisionDate = row.DecisionDate,
                    DecisionNumber = row.DecisionNumber,
                    JobTitle = row.JobTiTle,
                    Qualification = row.Qualification,
                    NationalNumber = row.NationalNumber,
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            //add by ali alherbade 26-05-2019
            var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            // end add 

            ReportDataSource rdc = new ReportDataSource("EndServicesReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
               // new ReportParameter("Date1", "كشف " + model.GetCauseOfEndService()),
                new ReportParameter("Date1", dateFrom.ToString("dd-MM-yyyy")),
                new ReportParameter("Date2", dateTo.ToString("dd-MM-yyyy")),
                new ReportParameter("CompanyName", LongName),
                new ReportParameter("Divetion", Department),
                new ReportParameter("ReportName", "تقرير انهاء الخدمة"),
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

    }
}