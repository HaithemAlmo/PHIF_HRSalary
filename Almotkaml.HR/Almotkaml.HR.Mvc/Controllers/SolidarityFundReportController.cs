using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SolidarityFundReportController : BaseController
    {
        // GET: SolidarityFund
        public ActionResult Index()
        {
            var model = HumanResource.SolidarityFundReport.Prepare();
            if (model == null)
                return HumanResourceState();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SolidarityFundReportModel model, string search, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return Report(model);

            return AjaxIndex(model, search);
        }
        private PartialViewResult AjaxIndex(SolidarityFundReportModel model, string search)
        {
            if (search == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.SolidarityFundReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SolidarityFundReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SolidarityFundReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Grid = loadedModel.Grid;
        }

        public ActionResult Report(SolidarityFundReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SolidarityFundReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SolidarityFundReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SolidarityFundReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SolidarityFundReport()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    TotalSalary = row.TotalSalary,
                    SolidarityFund = row.SolidarityFund,
                    //BondNumber = 
                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("SolidarityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضامن"));
            reportParameters.Add(new ReportParameter("BondNumber", ""));
            reportParameters.Add(new ReportParameter("Date", ""));
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            string mimeType;
            string encoding;
            string filenameextention;
            string deviceinfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
                "<PageWidth>11.69in</PageWidth>" +
                "<PageHeight>8.27in</PageHeight>" +

                "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
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