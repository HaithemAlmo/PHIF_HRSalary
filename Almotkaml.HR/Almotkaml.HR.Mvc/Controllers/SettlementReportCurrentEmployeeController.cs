using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class SettlementReportCurrentEmployeeController : BaseController
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
            model.DateTo = DateTime.Now.ToString();
            model.DateFrom = DateTime.Now.ToString();

            LoadModel(model, savedModel);
      HumanResource.SettlementReport.Refresh(model);
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
            model.DepartmentList = loadedModel.DepartmentList;
            model.DivisionList = loadedModel.DivisionList;
            model.CenterList = loadedModel.CenterList;
            model.Grid = loadedModel.Grid;
        }

        public ActionResult Report(SettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "CurrentReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SettlementReport.PublicView(model))
                return HumanResourceState(model);

            var datasources = new HashSet<EmployeeReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new EmployeeReport()
                {
                    TafKeet=row.MoneyNumber,
                    DateOfAppointmentDecision=row.DateApp.ToString(),
                    DirectlydateFrom=row.DirectleyDate,
                    NumberOfAppointmentDecision=row.NumberApp,
                    JobTitle=row.JobTiTle,
                    DegreeNow=row.DegreeNow,
                    Employer=row.Employeer,
                    CurrentSituation=row.Current,
                    FullName = row.Name,
                    Center = row.Center,
                    Unit = row.Unit,
                    Division = row.Division,
                    JobNumber = row.JobNumber,
                    NationalityNumber = row.NationalNumber,
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("DataSet1", datasources);
           

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