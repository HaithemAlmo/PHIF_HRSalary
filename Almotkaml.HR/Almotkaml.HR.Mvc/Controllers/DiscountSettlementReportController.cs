using Almotkaml.HR.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class DiscountSettlementReportController : BaseController
    {
        // GET: DiscountSettlementReport
        public ActionResult Index()
        {
            var model = HumanResource.DiscountSettlementReport.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DiscountSettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.DiscountSettlementReport.Refresh(model);

            if (!Request.IsAjaxRequest())
                return Report(model, savedModel);
            //return AjaxNotWorking();

            return AjaxIndex(model);
        }

        private PartialViewResult AjaxIndex(DiscountSettlementReportModel model)
        {
            //LoadModel(model, savedModel);
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(DiscountSettlementReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DiscountSettlementReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.PremiumList = loadedModel.PremiumList;
        }

        public ActionResult Report(DiscountSettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "DiscountSettlementReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.DiscountSettlementReport.View(model))
                return HumanResourceState(model);

            var datasources = new HashSet<DiscountSettlementReportGridRow>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new DiscountSettlementReportGridRow()
                {
                    EmployeeName = row.EmployeeName,
                    JobNumber = row.JobNumber,
                    Month = row.Month,
                    MonthlyInstallment = row.MonthlyInstallment,
                    TotalValue = row.TotalValue,
                    Rest = row.Rest
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("DiscountSettlement", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
             //   new ReportParameter("ReportParameter1", model.PremiumList.FirstOrDefault(p=>p.PremiumId==model.PremiumId)?.Name),
                new ReportParameter("ReportParameter2", model.Titel),
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