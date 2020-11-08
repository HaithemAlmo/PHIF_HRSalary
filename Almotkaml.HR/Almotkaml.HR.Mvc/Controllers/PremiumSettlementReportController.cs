using Almotkaml.HR.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class PremiumSettlementReportController : BaseController
    {
        // GET: PremiumSettlementReport
        public ActionResult Index()
        {
            var model = HumanResource.PremiumSettlementReport.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PremiumSettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);

            HumanResource.PremiumSettlementReport.Refresh(model);

            if (!Request.IsAjaxRequest())
                return Report(model, savedModel);
            //return AjaxNotWorking();

            return AjaxIndex(model);
        }

        private PartialViewResult AjaxIndex(PremiumSettlementReportModel model)
        {
            //LoadModel(model, savedModel);
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(PremiumSettlementReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<PremiumSettlementReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.EmployeeGrid = loadedModel.EmployeeGrid;
        }

        public ActionResult Report(PremiumSettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "PremiumSettlementReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.PremiumSettlementReport.View(model))
                return HumanResourceState(model);

            var datasources = new HashSet<PremiumSettlementReportGridRow>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new PremiumSettlementReportGridRow()
                {
                    EmployeeName = row.EmployeeName,
                    Month = row.Month,
                    Value = row.Value,
                    NationalNumber = row.NationalNumber,
                    PremiumName = row.PremiumName
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("PremiumSettlement", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
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