using Almotkaml.HR.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SettlementAbsenceReportController : BaseController
    {
        // GET: SettlementAbsenceReport
        public ActionResult Index()
        {
            var model = HumanResource.SettlementAbsenceReport.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SettlementAbsenceReportModel model, string search, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return Report(model, savedModel);
            //return AjaxNotWorking();

            return AjaxIndex(model, search);
        }

        private PartialViewResult AjaxIndex(SettlementAbsenceReportModel model, string search)
        {
            //LoadModel(model, savedModel);
            if (search == null)
            {
                ModelState.Clear();
                return PartialView("_Form", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (!HumanResource.SettlementAbsenceReport.View(model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        private void LoadModel(SettlementAbsenceReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SettlementAbsenceReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Grid = loadedModel.Grid;
        }

        public ActionResult Report(SettlementAbsenceReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SettlementAbsenceReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SettlementAbsenceReport.View(model))
                return HumanResourceState(model);

            var datasources = new HashSet<SettlementAbsenceReportGridRow>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SettlementAbsenceReportGridRow()
                {
                    Note=row.Note,
                    Name = row.Name,
                    Center = row.Center,
                    Unit = row.Unit,
                    Division = row.Division,
                    Department = row.Department,
                    JobNumber = row.JobNumber,
                    NationalNumber = row.NationalNumber,
                    DaysCount = row.DaysCount,
                    AbsenceValue=row.AbsenceValue,
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            ReportDataSource rdc = new ReportDataSource("SettlementAbsence", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                 new ReportParameter("Date1", dateFrom.ToString("dd-MM-yyyy")),
                new ReportParameter("Date2", dateTo.ToString("dd-MM-yyyy")),
                new ReportParameter("CompanyName", LongName),
                new ReportParameter("Department", Department),
                new ReportParameter("Title", "كشف الغياب" ),
                //new ReportParameter("ReportParameter2",
                //    "من التاريخ : " + dateFrom.ToString("dd-MM-yyyy") + " حتى التاريخ : " +
                //    dateTo.ToString("dd-MM-yyyy")),
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