using Almotkaml.HR.Models;
using Almotkaml.HR.Reports;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.HR.Mvc.Controllers
{
    public class OldSalaryController : BaseController
    {
        // GET: OldSalary
        public ActionResult Index(SalaryIndexModel fromModel)
        {
            var model = fromModel.Month != null && fromModel.Year != null
                ? HumanResource.OldSalary.Index(fromModel)
                : HumanResource.OldSalary.Index();

            if (model == null)
                return HumanResourceState();

            ModelState.Clear();
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = HumanResource.OldSalary.Find(id);

            if (model == null)
                return HumanResourceState();

            model.SalaryId = id;

            SaveModel(model);

            return View(model);
        }


        public void LoadModel(SalaryIndexModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalaryIndexModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Month = loadedModel.Month;
            model.Year = loadedModel.Year;
            model.SalaryGrid = loadedModel.SalaryGrid;

        }

        public void LoadModel(SalaryFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalaryFormModel>(savedModel);

            if (loadedModel == null)
                return;

            model.Month = loadedModel.Month;
            model.Year = loadedModel.Year;

        }

        public ActionResult SolidarityFund(SalaryIndexModel indexModel)
        {
            var model = HumanResource.OldSalary.Index(indexModel);

            return Report(model.SolidarityFundReportModel, indexModel);
        }
        public ActionResult SocialSecurityFund(SalaryIndexModel indexModel)
        {
            var model = HumanResource.OldSalary.Index(indexModel);

            return Report(model.SocialSecurityFundReportModel);
        }
        public ActionResult Tax(SalaryIndexModel indexModel)
        {
            var model = HumanResource.OldSalary.Index(indexModel);

            return Report(model.TaxReportModel);
        }
        public ActionResult AdvancePayment(SalaryIndexModel indexModel)
        {
            var model = HumanResource.OldSalary.Index(indexModel);

            return Report(model.AdvancePaymentReportModel);
        }
        public ActionResult SalaryForm(SalaryIndexModel indexModel)
        {
            var model = HumanResource.OldSalary.Index(indexModel);

            return Report(model.SalaryFormReportModel);
        }
        //public ActionResult SalaryCard(SalaryFormModel fromModel, int id, string savedModel)
        //{
        public ActionResult SalaryCard(int id)
        {
            //LoadModel(fromModel, savedModel);
            var model = HumanResource.OldSalary.Find(id);

            return Report(model.SalaryCardReportModel, id);
        }
        //public ActionResult ClipboardBanking()
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.ClipboardBankingReportModel);
        //}
        public ActionResult Report(SolidarityFundReportModel model, SalaryIndexModel indexModel)
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

            if (!HumanResource.Salary.View(model))
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

                    CostCenterId = row.CostCenterId,
                    CostCenterName = row.CostCenterName,
                    Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.SolidarityFund), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                    //BondNumber = 
                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("SolidarityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضامن"));
            reportParameters.Add(new ReportParameter("BondNumber", indexModel.SolidarityFundBondNumber));
            reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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

        public ActionResult Report(TaxReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "TaxReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<TaxReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new TaxReport()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    ExemptionTax = row.ExemptionTax,
                    IncomeTax = row.IncomeTax,
                    JihadTax = row.JihadTax,
                    NetSalary = row.NetSalary,
                    StampTax = row.StampTax,
                    SubjectSalary = row.SubjectSalary,
                    TotalSalary = row.TotalSalary,
                    TaxTotal = row.TaxSum,
                    CostCenterId = row.CostCenterId,
                    CostCenterName = row.CostCenterName,
                    Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.IncomeTax), 3, MidpointRounding.AwayFromZero)
                    + Math.Round(model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                    + Math.Round(model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.StampTax), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("TaxReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف الضرائب"));
            reportParameters.Add(new ReportParameter("BondNumber", ""));
            reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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
        public ActionResult Report(SocialSecurityFundReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SocialSecurityFund.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SocialSecurityFundReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SocialSecurityFundReport()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    TotalSalary = row.TotalSalary,
                    CompanyShare = row.CompanyShare,
                    EmployeeShare = row.EmployeeShare,
                    GuaranteeType = row.GuaranteeType,
                    ShareSum = row.ShareSum,
                    CostCenterName = row.CostCenterName,
                    CostCenterId = row.CostCenterId,
                    Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.ShareSum), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                    //
                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("SocialSecurityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف الضمان الاجتماعي"));
            reportParameters.Add(new ReportParameter("BondNumber", ""));
            reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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
        public ActionResult Report(AdvancePaymentReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "AdvancePaymentReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<AdvancePaymentReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new AdvancePaymentReport()
                {
                    AdvancePremium = row.AdvancePayment,
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    PrepaidSalary = row.PrepaidSalary,
                    CostCenterName = row.CostCenterName,
                    CostCenterId = row.CostCenterId
                    //Date = //////
                });
            }

            ReportDataSource rdc = new ReportDataSource("AdvancePayment", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف والمرتبات المقدمة"));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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
        public ActionResult Report(SalaryFormReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryFormReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryFormReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SalaryFormReport()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    BasicSalary = row.BasicSalary,
                    Absence = row.Absence,
                    CompanyShare = row.CompanyShare,
                    EmployeeShare = row.EmployeeShare,
                    ExemptionTax = row.ExemptionTax,
                    ExtraWork = row.ExtraWork,
                    ExtraWorkConst = row.ExtraWorkConst,
                    ExtraWorkVacation = row.ExtraWorkVacation,
                    IncomeTax = row.IncomeTax,
                    JihadTax = row.JihadTax,
                    NetSalary = row.NetSalary,
                    PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                    Sanction = row.Sanction,
                    SickVacation = row.SickVacation,
                    SituationOnNet = row.SituationOnNet,
                    SituationOnTotal = row.SituationOnTotal,
                    SolidarityFund = row.SolidarityFund,
                    StampTax = row.StampTax,
                    SubjectSalary = row.SubjectSalary,
                    TotalSalary = row.TotalSalary,
                    WithoutPay = row.WithoutPay,
                    CostCenterId = row.CostCenterId,
                    CostCenterName = row.CostCenterName,
                    EmployeeStat = row.EmployeeStat
                });
            }

            ReportDataSource rdc = new ReportDataSource("SalaryForm", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "استمارة المرتبات"));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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

        public ActionResult Report(SalaryCardReportModel model, int id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCardReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.OldSalary.View(model, id))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryCard>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SalaryCard()
                {
                    JobNumber = row.JobNumber,
                    Name = row.Name,
                    BasicSalary = row.BasicSalary,
                    Absence = row.Absence,
                    CompanyShare = row.CompanyShare,
                    EmployeeShare = row.EmployeeShare,
                    ExemptionTax = row.ExemptionTax,
                    ExtraWork = row.ExtraWork,
                    ExtraWorkVacation = row.ExtraWorkVacation,
                    IncomeTax = row.IncomeTax,
                    JihadTax = row.JihadTax,
                    NetSalary = row.NetSalary,
                    //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                    Sanction = row.Sanction,
                    SickVacation = row.SickVacation,
                    SolidarityFund = row.SolidarityFund,
                    StampTax = row.StampTax,
                    SubjectSalary = row.SubjectSalary,
                    TotalSalary = row.TotalSalary,
                    WithoutPay = row.WithoutPay,
                    BondNumber = row.BondNumber,
                    BankName = row.BankName,
                    EmployeeName = row.EmployeeName,
                    ExtraWorkFixed = row.ExtraWorkFixed,
                    BankBranchName = row.BankBranchName,
                    //PrepaidSalaryAndAdvancePremium = ,
                    //SituationOnTotal = ,
                    BounName = row.BounName,
                    BounValue = row.BounValue,
                    FinancialNumber = row.FinancialNumber,
                    GuaranteeType = row.GuaranteeType,
                    SecurityNumber = row.SecurityNumber,
                    //EmployeeId = row.em


                });
            }

            ReportDataSource rdc = new ReportDataSource("SalaryCard", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "بطاقة المرتب"));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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