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
    public class SalarySettlementReportController : BaseController
    {
        IList<decimal> dd = new List<decimal>();
        public string repType;
        // GET: SalarySettlementReport
        public ActionResult Index()
        {
            var model = HumanResource.SalarySettlementReport.Prepare();

            if (model == null)
                return HumanResourceState();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SalarySettlementReportModel model, string savedModel, FormCollection form)
        {
            if (form["print"] != null)
            { repType = form["PDF"]; }
            else if (form["Excel"] != null)
            { repType = form["Excel"]; }
            repType = form["PDF"];
            if (model.TextboxFrom != "" && model.TextboxFrom != null && model.NumberCheck != "" && model.NumberCheck != null)
            {
                

                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    if (model.Number == 0)
                    {
                        model.Number = 1;
                    }
                        var sum = int.Parse(model.TextboxFrom) + (int.Parse(model.NumberCheck)* model.Number);
                    model.TextboxTo = sum.ToString();
                }
            }
            LoadModel(model, savedModel);

            HumanResource.SalarySettlementReport.Refresh(model);
            if (form["search"] != null)
            {
                if (!HumanResource.SalarySettlementReport.Search(model))
                    return AjaxHumanResourceState("_Form", model);
            }
            if (!Request.IsAjaxRequest())
            {
               

                switch (model.SalarySettlement)
                {
                    //case SalarySettlement.Pledge:
                    //    return PledgeReport(model, savedModel);
                    //case SalarySettlement.PensionFund:
                    //    return PensionFundReport(model, savedModel);
                    case SalarySettlement.SalaryCertificate:
                        return SalaryCertificateReport(model, savedModel);
                    case SalarySettlement.Clipord:
                        return ClipordIndexReport(model, savedModel,repType);
                    //case SalarySettlement.SalaryCard:
                    //    return CardIndexReport(model, savedModel);
                    case SalarySettlement.SalaryForm:
                        return SalaryFormReport(model, savedModel);
                    case SalarySettlement.AbstractClipboardBanking:
                        return AbstractClipboardBanking(model, savedModel);
                    case SalarySettlement.SocialSecurety:
                        return SocialSecurityFundIndexReport(model, savedModel);
                    case SalarySettlement.SolidrtyFound:
                        return SolidrtyFoundIndexReport(model, savedModel);
                    case SalarySettlement.Legal:
                        return ClipordLegalIndexReport(model, savedModel);
                    case SalarySettlement.TaxIndex:
                        return TaxIndexReport(model, savedModel);
                    case SalarySettlement.Advance:
                        return AdvancePaymentIndexReport(model, savedModel);
                    case SalarySettlement.EndJob:
                        return SalaryEndJob(model, savedModel);
                    //case SalarySettlement.Premmium:
                    ////    return SalaryEndJob(model, savedModel);
                    case SalarySettlement.Check:
                        return SalaryCheck(model, savedModel);

                    case SalarySettlement.Summary:
                        return SalariesTotalReport(model, savedModel);

                    case SalarySettlement.ReportSubsended:
                        return ReportSubunded(model, savedModel);
                }
            }
       

            return AjaxIndex(model);
        }
       
        private PartialViewResult AjaxIndex(SalarySettlementReportModel model)
        {

            HumanResource.SalarySettlementReport.Refresh(model);
         
            //LoadModel(model, savedModel);
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            // Select
            
            return PartialView("_Form", model);
        }

        private void LoadModel(SalarySettlementReportModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalarySettlementReportModel>(savedModel);

            if (loadedModel == null)
                return;

            model.EmployeeGrid = loadedModel.EmployeeGrid;
            model.PremiumCheckListItem = loadedModel.PremiumCheckListItem
             .Select(l => new PremiumCheckListItem()
             {
                 Name = l.Name,
                 PremiumId = l.PremiumId,
                 IsSelected = model.PremiumCheckListItem.FirstOrDefault(m => m.PremiumId == l.PremiumId)?.IsSelected ?? false
             }).ToList();
        }
       
        //الحاظفة المصرفية
        public ActionResult ClipordIndexReport(SalarySettlementReportModel model2, string savedModel, string PrintType)
        {
            return ReportClipordIndex(model2.ClipboardBankingReportModel, model2, model2.LICJobNumber.ToString(), model2.Month ?? 0, model2.Year ?? 0, model2.BankId, model2.BankBranchId,PrintType);
        }
        public ActionResult ReportClipordIndex(ClipboardBankingReportModel model, SalarySettlementReportModel model2 ,string LICJobNumber, int month, int year, int? BankId, int? BankBranchId,string PrintType)
        {
            model.Month = month;
            model.Year = year;


            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ClipboardBankingReport.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }



            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                    return AjaxHumanResourceState("_Form", model);


           
          


            /// / // // //
            var datasources = new HashSet<ClipboardBanking>();
                foreach (var row in model2.Grid)
                {
                if (row.FinalySalary != 0)
                {
                    dd.Add(row.FinalySalary);
                    datasources.Add(new ClipboardBanking()
                    {
                        
                        CostCenterName = row.dateSalary,
                        CostCenterId = row.BankId,
                        JobNumber = row.JobNumber,
                        BondNumber = row.BondNumber,
                        EmployeeName = row.EmployeeName,
                        BankBranchId = row.BankId,
                        BankBranchName = row.BankName + " " + row.BankBranchName,
                        FinalySalary = row.FinalySalary,
                        NationalNumber = row.NationalNumber,
                        
                        
                        Tafkeet = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                       
                    });
                }
                }


            var dsd = dd.Sum();
            //add by ali alherbade 26-05-2019
            var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            // end add 
            
            // add by ali alherbade 26-05-2019
           

            //
            ReportDataSource rdc = new ReportDataSource("ClipboardBanking", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "الحافظة المصرفية"));
            reportParameters.Add(new ReportParameter("Department", Department));//القسم
            reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة
            //reportParameters.Add(new ReportParameter("FinancialAffairs", FinancialAffairs));// الشئون المالية
            //reportParameters.Add(new ReportParameter("FinancialAuditor", FinancialAuditor));//المراقب المالي
            //reportParameters.Add(new ReportParameter("PayrollUnit", PayrollUnit));//وحدة المرتبات
            //reportParameters.Add(new ReportParameter("References", References));// المراجع
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
            reportParameters.Add(new ReportParameter("InstrumentNumber", model2.InstrumentNumber));
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);


            //string reportType = "pdf" /*"Excel"*/;//PrintType;
            //string mimeType;
            //string encoding;
            //string fileNameextention;
            //if (reportType == "Excel")
            //{
            //    fileNameextention = "xlsx";
            //}
            //else
            //{
            //    fileNameextention = "pdf";
            //}

            //string deviceinfo =
            //    "<DeviceInfo>" +
            //        "<OutPutFormat>" + fileNameextention + "</OutPutFormat>" +
            //        "<PageWidth>11.69in</PageWidth>" +
            //        "<PageHeight>8.27in</PageHeight>" +
            //        "<MarginTop>0.1in</MarginTop>" +
            //        "<MarginLeft>0.1in</MarginLeft>" +
            //        "<MarginRight>0.1in</MarginRight>" +
            //        "<MarginBottom>0.1in</MarginBottom>" +
            //     "</DeviceInfo>";
            //Warning[] warnings;
            //string[] stream;
            //byte[] renderedBytes;
            //renderedBytes = lr.Render(
            //    reportType,
            //    deviceinfo,
            //    out mimeType,
            //   out encoding,
            //   out fileNameextention,
            //   out stream,
            //   out warnings);

            //return File(renderedBytes, mimeType);



            //  --حافظة مصرفية 8 / 8

            string reportType = "PDF";//PrintType;
            string mimeType;
            string encoding;
            string fileNameextention;
            if (reportType == "Excel")
            {
                fileNameextention = "xlsx";
            }
            else
            {
                fileNameextention = "pdf";
            }

            string deviceinfo =
                "<DeviceInfo>" +
                    "<OutPutFormat>" + fileNameextention + "</OutPutFormat>" +

                 "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType,
                deviceinfo,
                out mimeType,
               out encoding,
               out fileNameextention,
               out stream,
               out warnings);

            return File(renderedBytes, mimeType);
        }
        //
        //النفقة الشرعية
        public ActionResult ClipordLegalIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportCliporLegaldIndex(model2.ClipboardBankingReportModel, model2, model2.JobNumber.ToString(), model2.Month ?? 0, model2.Year ?? 0, model2.BankId, model2.BankBranchId);
        }
        public ActionResult ReportCliporLegaldIndex(ClipboardBankingReportModel model, SalarySettlementReportModel model2, string jobNumber, int month, int year, int? BankId, int? BankBranchId)
        {
            model.Month = month;
            model.Year = year;

            model2.IsLegal = 1;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ClipboardBankingLegal.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }



            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);


         



            /// / // // //hafeeda
            var datasources = new HashSet<ClipboardBanking>();

            foreach (var row in model2.Grid)
            {
                datasources.Add(new ClipboardBanking()
                {
                    JobNumber = row.JobNumber,
                    BondNumber = row.BondNumber,
                    EmployeeName = row.EmployeeName,
                    BankBranchId = row.BankBranchId,
                    BankBranchName = row.BankBranchName,
                    FinalySalary = row.FinalSalaryLegal,
                    NationalNumber = row.NationalNumber,
                    Tafkeet = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId)
                                                    .Sum(r => r.FinalSalaryLegal), 3, MidpointRounding.AwayFromZero))
                                                    .ConvertToArabic()

                });
            }









            ReportDataSource rdc = new ReportDataSource("ClipboardBanking", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "النفقة الشرعية"));
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
        //
        //استمارة تعهد
        public ActionResult PledgeReport(SalarySettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "PledgeReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SalarySettlementReport.ViewPledge(model))
                return HumanResourceState(model);

            var datasources = new HashSet<PledgeReportGridRow>();

            foreach (var row in model.PledgeReportGrid)
            {
                datasources.Add(new PledgeReportGridRow()
                {
                    NationalNumber = row.NationalNumber,
                    BondNumber = row.BondNumber,
                    EmployeeName = row.EmployeeName,
                    BankName = row.BankName
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("Pledge", datasources);
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
        //
        //تقرير تفصيل بين فترتين
        public ActionResult PensionFundReport(SalarySettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "PensionFundReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SalarySettlementReport.ViewPensionFund(model))
                return HumanResourceState(model);

            var datasources = new HashSet<PensionFundReportGridRow>();

            foreach (var row in model.PensionFundReportGrid)
            {
                datasources.Add(new PensionFundReportGridRow()
                {
                    EmployeeName = row.EmployeeName,
                    BasicSalary = row.BasicSalary,
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo,
                    Month = row.Month,
                    ExtraGeneralValue = row.ExtraGeneralValue,
                    SecurityNumber = row.SecurityNumber,
                    Total = row.Total,
                    Reward = row.Reward
                });
            }

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("PensionFund", datasources);
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
        //
        //بطاقة مرتب
        public ActionResult ReportCardIndex(SalaryCardReportModel model, SalarySettlementReportModel model2,string JobNumber, int BankId, int BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCardReport.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }



            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);



            //   var BankBranchId2 = model.Grid.Select(r => r.JobNumber);

            var datasources = new HashSet<SalaryCard>();

           
                foreach (var row in model2.Grid)
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
            reportParameters.Add(new ReportParameter("Title", "الحافظة المصرفية"));
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
        public ActionResult CardIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportCardIndex(model2.SalaryCardReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        //
        //الضمان الاجتماعي
        public ActionResult SocialSecurityFundIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return SocialFoundReport(model2.SocialSecurityFundReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult SocialFoundReport(SocialSecurityFundReportModel model, SalarySettlementReportModel model2,string JobNumber, int BankId, int BankBranchId, int? month, int? year)
        {
            model.Month = month ?? 0;
            model.Year = year ?? 0;
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

            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SocialSecurityFundReport1>();
           
                foreach (var row in model2.Grid)
                {
                    datasources.Add(new SocialSecurityFundReport1()
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
                        Tafkeet = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId).Sum(r => r.ShareSum), 3, MidpointRounding.AwayFromZero)).ConvertToArabic(),
                        SecurityNumber = row.SecurityNumber,
                        NationalNumber=row.NationalNumber,
                        //
                        //Date = //////
                    });
                }

            var _tafkeet = datasources.Sum(e => e.CompanyShare + e.EmployeeShare);

            ReportDataSource rdc = new ReportDataSource("SocialSecurityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضمان الاجتماعي"));
            reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
            reportParameters.Add(new ReportParameter("Tafkeet", new Maths.NumberToWord(Math.Round(_tafkeet, 3, MidpointRounding.AwayFromZero)).ConvertToArabic()));
            reportParameters.Add(new ReportParameter("InstrumentNumber", model2.InstrumentNumber));
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
        // 
        //ملخص المرتبات
        public ActionResult ReportSummary(SummaryReportModel model, SalaryIndexModel mm)
        {
            model.Month = mm.Month ?? 0;
            model.Year = mm.Year ?? 0;

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SummaryReport.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            // //------
            // var grid =
            //model.Grid.Where(f => f.y == BankId && f.BranchId == BankBranchId);
            // var list3 = grid3.Select(n => n.BranchId)
            //    .ToList();

            //if (list != null && list.Count() != 0)
            //{
            //    foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
            //    {

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SummaryReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SummaryReport()
                {
                    Premiumdiscrimination = row.Premiumdiscrimination,
                    PremiumHome = row.PremiumHome,
                    PremiumOther = row.PremiumOther,
                    Premiumscar = row.Premiumscar,
                    PremiumTechar = row.PremiumTechar,
                    Reward = row.Reward,
                    Advanced = row.Advanced,
                    Basic = row.Basic,
                    EmployeeCount = row.EmployeeCount,
                    CompanySalary = row.CompanySalary,
                    EmployeeNet = row.EmployeeNet,
                    EmployeePremiumNet = row.EmployeePremiumNet,
                    EmployeeSalaryCount = row.EmployeeSalaryCount,
                    EmployeesalaryStop = row.EmployeesalaryStop,
                    Employeesetting =
                                    row.SettingAbsence +
                                    row.Settingexpense +
                                    row.SettingGuarantee +
                                    row.Settingin +
                                    row.Settinginsurance +
                                    row.SettingJihad +
                                    row.SettingMony +
                                    row.SettingOther +
                                    row.SettingPresented +
                                    row.SettingPunishment +
                                    row.SettingSolidrty +
                                    row.Settingstamp,


                    /////,
                    EmployeeStop = row.EmployeeStop,
                    SaveSalary = row.SaveSalary,
                    SettingAbsence = row.SettingAbsence,
                    Settingexpense = row.Settingexpense,
                    SettingGuarantee = row.SettingGuarantee,
                    Settingin = row.Settingin,
                    Settinginsurance = row.Settinginsurance,
                    SettingJihad = row.SettingJihad,
                    SettingMony = row.SettingMony,
                    SettingOther = row.SettingOther,
                    SettingPresented = row.SettingPresented,
                    SettingPunishment = row.SettingPunishment,
                    SettingSolidrty = row.SettingSolidrty,
                    Settingstamp = row.Settingstamp
                });
            }

            ReportDataSource rdc = new ReportDataSource("SumaryReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            //reportParameters.Add(new ReportParameter("Title", "الحافظة المصرفية"));
            //reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
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
        //
        // 
        //الخلاصة
        public ActionResult SalariesTotalReport(SalarySettlementReportModel model2, string savedModel/*,SummaryReportModel model, SalaryIndexModel mm*/)
        {
            //model2.Month = mm.Month ?? 0;
            //model2.Year = mm.Year ?? 0;

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalariesTotalReport.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }



            //if (!HumanResource.Salary.View(model))
            //    return AjaxHumanResourceState("_Form", model);

            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model2);

            var datasources = new HashSet<SalariesTotalReport>();
            //var MawadaFund = model2.Grid.Select(s => s.MawadaFund).Sum();
            var AdvancePaymentInside = model2.Grid.Select(s => s.AdvancePaymentInside).Sum();
            var AdvancePaymentOutside = model2.Grid.Select(s => s.AdvancePaymentOutside).Sum();
            //string sumFinalSalaryString = string.Format("{0:#,#.00}", sumFinalSalary);

            //foreach (var row in model.Grid)
            //{
            decimal salary = model2.Grid.Select(s => s.BasicSalary).Sum();
            if (model2.ClampCheck)
                salary = salary - model2.Grid.Select(s => s.Clamp).Sum();
            if (model2.SubsistenceCheck)
                salary = salary - model2.Grid.Select(s => s.Subsistence).Sum();
            if (model2.PremiumCheck)
            {
                salary = salary - model2.Grid.Select(s => s.Premium).Sum();
                //salary = salary - model2.PremiumCheckListItem.Select(s => s.Value).Sum();
            }

            var zero = decimal.Parse("0,00");
            datasources.Add(new SalariesTotalReport()
            {
                SalariesTotal = model2.Grid.Select(s => s.TotalSalary).Sum(),
                BasicSalaries = salary ,//model2.Grid.Select(s => s.BasicSalary).Sum(),
                CompanyShareSocialSecurity = model2.Grid.Select(s => s.CompanyShare).Sum(),
                ContributionInSecurity = model2.Grid.Select(s => s.SafeShare + s.CompanyShare).Sum(),
                DeducationTotal = model2.Grid.Select(s => s.DiscountTotal).Sum(),
                JihadTax = model2.Grid.Select(s => s.JihadTax).Sum(),
                IncomeTax = model2.Grid.Select(s => s.IncomeTax).Sum(),
                AdvancePayment = AdvancePaymentInside + AdvancePaymentOutside,
                GroupLife = model2.Grid.Select(s => s.GroupLife).Sum(),
                //MawadaFund = MawadaFund ,
                SafeShareSocialSecurity = model2.Grid.Select(s => s.SafeShare).Sum(),
                SalariesNet = model2.Grid.Select(s => s.FinalySalary).Sum(),
                SalariesNumber = model2.Grid.Select(s => s.EmployeeID).Count(),
                SocialSecurityFund = model2.Grid.Select(s => s.EmployeeShare).Sum(),
                SolidarityFund = model2.Grid.Select(s => s.SolidarityFund).Sum(),
                StampTax = model2.Grid.Select(s => s.StampTax).Sum(),
                Sanction = model2.Grid.Select(s => s.Sanction).Sum(),
                Absence = model2.Grid.Select(s => s.Absence).Sum(),
                Clamp = model2.Grid.Select(s => s.Clamp).Sum(),
                Subsistence = model2.Grid.Select(s => s.Subsistence).Sum(),
                Premium = model2.Grid.Select(s => s.Premium).Sum(),
                // OtherDiscount = AdvancePaymentInside + AdvancePaymentOutside,
                OtherDiscount = model2.Grid.Select(s => s.AdvancePremium).Sum(),
            });
            //}
            //add by ali alherbade 26-05-2019
            var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            var UserName = HumanResource.StartUp.ApplicationUser.Title;
            // end add 



            ReportDataSource rdc = new ReportDataSource("SalariesTotal", datasources);
            ReportDataSource rdc2 = new ReportDataSource("DataSetPremium", model2.PremiumCheckListItem);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "إجمالي المرتبات المدفوعة"));
            reportParameters.Add(new ReportParameter("Month", model2.Year + "-" + model2.Month));//
            reportParameters.Add(new ReportParameter("UserTitle", UserName));
            //reportParameters.Add(new ReportParameter("Department", "الحافظة المصرفية"));
            //add by ali alherbade 26-05-2019
            reportParameters.Add(new ReportParameter("Department", Department));//القسم
            reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة
            reportParameters.Add(new ReportParameter("FinancialAffairs", FinancialAffairs));// الشئون المالية
            reportParameters.Add(new ReportParameter("FinancialAuditor", FinancialAuditor));//المراقب المالي
            //reportParameters.Add(new ReportParameter("PayrollUnit", PayrollUnit));//وحدة المرتبات
            reportParameters.Add(new ReportParameter("References", References));// المراجع

            if (!model2.ClampCheck)
                reportParameters.Add(new ReportParameter("ClampTitle", ""));
            else
                reportParameters.Add(new ReportParameter("ClampTitle", "الهيئات القضائية"));

            if (!model2.SubsistenceCheck)
                reportParameters.Add(new ReportParameter("SubsistenceTitle", ""));
            else
                reportParameters.Add(new ReportParameter("SubsistenceTitle", "الإعاشة"));

            if (!model2.PremiumCheck)
                reportParameters.Add(new ReportParameter("PremiumTitle", ""));
            else
                reportParameters.Add(new ReportParameter("PremiumTitle", "مكافئات والعمل الإضافي"));


            //
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            lr.DataSources.Add(rdc2);
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
        //
        //التظامن الاجتماعي
        public ActionResult SolidrtyFoundIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSolidrtyFound(model2.SolidarityFundReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult PremiumReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSolidrtyFound(model2.SolidarityFundReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportSolidrtyFound(SolidarityFundReportModel model, SalarySettlementReportModel model2,string JobNumber, int BankId, int BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
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


            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SolidarityFundReport>();

        
                foreach (var row in model2.Grid)
                {
                    datasources.Add(new SolidarityFundReport()
                    {
                        
                        JobNumber = row.JobNumber,
                        Name = row.Name,
                        TotalSalary = row.TotalSalary,
                        SolidarityFund = row.SolidarityFund,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId).Sum(r => r.SolidarityFund), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                        //BondNumber = 
                        //Date = //////
                    });
                }




            var _tafkeet = datasources.Sum(e => e.SolidarityFund);


            ReportDataSource rdc = new ReportDataSource("SolidarityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضامن"));
            //reportParameters.Add(new ReportParameter("BondNumber", indexModel.SolidarityFundBondNumber));
            //reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Tafkeet", new Maths.NumberToWord(Math.Round(_tafkeet, 3, MidpointRounding.AwayFromZero)).ConvertToArabic()));
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
        //
        //استمارة مرتب
        public ActionResult SalaryFormReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSalaryForm(model2.SalaryFormReportModel, model2, model2.JobNumber.ToString(), model2.BankId, model2.BankBranchId, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportSalaryForm(SalaryFormReportModel model, SalarySettlementReportModel model2, string JobNumber, int? BankId, int? BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;           

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryFormReport001.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }


            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryFormReport>();
            var PremiumCheckListHeader = new List<string[]>();
            var PremiumCheckListValues = new List<string[]>();

            var AdvancePaymentInside = model2.Grid.Select(s => s.AdvancePaymentInside).Sum();
            var AdvancePaymentOutside = model2.Grid.Select(s => s.AdvancePaymentOutside).Sum();


            foreach (var row in model2.Grid)
            {
                if (row.FinalySalary != 0)
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
                        NationalNumber = row.NationalNumber,
                        MonyeNumber = row.JobNumber,
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
                        EmployeeStat = row.EmployeeStat,
                        AdvancePremiumInside = row.AdvancePaymentInside,
                        AdvancePremiumOutside = row.AdvancePaymentOutside,
                        FinalySalary = row.FinalySalary,
                        PrepaidPremium = row.PrepaidSalary,
                        RewindValue = row.RewindValue,
                        AccumulatedValue = row.AccumulatedValue,
                        GroupLife = row.GroupLife,
                        AllBouns = row.AllBouns,
                        Discound = row.Discound,
                        PremiumCheckListItemReport = row.PremiumListReport.ToList(),
                    });
                }
                //********************************************************************

                foreach (var premiumList in model2.PremiumCheckListItem.Where(e => e.EmployeeID.ToString() == row.EmployeeID))
                {
                    PremiumCheckListValues.Add(new string[]
                     {
                            premiumList.PremiumId.ToString() ,
                            premiumList.Name,
                            premiumList.EmployeeID.ToString(),
                     });




                }
                //*********************************************************************

            }


            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم


            ReportDataSource rdc = new ReportDataSource("SalaryForm", datasources);
            ReportDataSource rdc2 = new ReportDataSource("DataSetPremium2", model2.PremiumListReport);

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "استمارة المرتبات"));
            reportParameters.Add(new ReportParameter("Date", model.Year + " - " + model.Month));
            reportParameters.Add(new ReportParameter("Department", Department));
            //*********************************************************************
            if(model2.PremiumListReport.Count < 0)
            {
                return RedirectToAction(nameof(Index));
            }
            PremiumCheckListHeader.Add(new string[]
             {
                            model2.PremiumListReport.FirstOrDefault().Name,
             });
            string[] premiums = (PremiumCheckListHeader.ToList().FirstOrDefault()[0]).Split(',');
            reportParameters.Add(new ReportParameter("PremiumName1", premiums[0]));
            reportParameters.Add(new ReportParameter("PremiumName2", premiums[1]));
            reportParameters.Add(new ReportParameter("PremiumName3", premiums[2]));
            reportParameters.Add(new ReportParameter("PremiumName4", premiums[3]));
            reportParameters.Add(new ReportParameter("PremiumName5", premiums[4]));
            reportParameters.Add(new ReportParameter("PremiumName6", premiums[5]));
            reportParameters.Add(new ReportParameter("PremiumName7", premiums[6]));
            reportParameters.Add(new ReportParameter("PremiumName8", premiums[7]));
            reportParameters.Add(new ReportParameter("PremiumName9", premiums[8]));
            //********************************
            reportParameters.Add(new ReportParameter("HiddenCol1", Boolean.FalseString, false));
            reportParameters.Add(new ReportParameter("HiddenCol2", Boolean.FalseString, false));
            reportParameters.Add(new ReportParameter("HiddenCol3", Boolean.FalseString, false));
            reportParameters.Add(new ReportParameter("HiddenColsPremium", Boolean.FalseString, false));
            //*********************************************************************
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            lr.DataSources.Add(rdc2);
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
            //string reportType = "Excel";//PrintType;
            //string mimeType;
            //string encoding;
            //string fileNameextention;
            //if (reportType == "Excel")
            //{
            //    fileNameextention = "xlsx";
            //}
            //else
            //{
            //    fileNameextention = "pdf";
            //}

            //string deviceinfo =
            //    "<DeviceInfo>" +
            //        "<OutPutFormat>" + fileNameextention + "</OutPutFormat>" +
            //        "<PageWidth>11.69in</PageWidth>" +
            //        "<PageHeight>8.27in</PageHeight>" +
            //        "<MarginTop>0.1in</MarginTop>" +
            //        "<MarginLeft>0.1in</MarginLeft>" +
            //        "<MarginRight>0.1in</MarginRight>" +
            //        "<MarginBottom>0.1in</MarginBottom>" +
            //     "</DeviceInfo>";
            //Warning[] warnings;
            //string[] stream;
            //byte[] renderedBytes;
            //renderedBytes = lr.Render(
            //    reportType,
            //    deviceinfo,
            //    out mimeType,
            //   out encoding,
            //   out fileNameextention,
            //   out stream,
            //   out warnings);

            //return File(renderedBytes, mimeType);
        }
        //
        //استمارة المتقاعدين
        public ActionResult SalaryEndJob(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSalaryEndJob(model2.SalaryFormReportModel, model2, model2.JobNumber.ToString(), model2.BankId, model2.BankBranchId, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult SalarySummary(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSalaryEndJob(model2.SalaryFormReportModel, model2, model2.JobNumber.ToString(), model2.BankId, model2.BankBranchId, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportSalaryEndJob(SalaryFormReportModel model, SalarySettlementReportModel model2, string JobNumber, int? BankId, int? BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryFormEndJob.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            model2.IsEndJob = 1;
            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryFormReport>();


            foreach (var row in model2.Grid)
            {

                datasources.Add(new SalaryFormReport()
                {
                    DateSalary=row.DateSalary,
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
                    //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
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
                    EmployeeStat = row.EmployeeStat,
                    AdvancePremiumInside = row.AdvancePremiumInside,
                    AdvancePremiumOutside = row.AdvancePremiumOutside,
                    FinalySalary = row.FinalySalary,
                    PrepaidPremium = row.PrepaidSalary,
                    RewindValue = row.RewindValue,
                    AccumulatedValue = row.AccumulatedValue,
                    GroupLife=row.GroupLife
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
        //
        //شهادة المرتب
        public ActionResult SalaryCertificateReport(SalarySettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCertificateReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }


            if (!HumanResource.SalarySettlementReport.SearchByDate(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryCertificatReport>();
            var datasources2 = new HashSet<SalaryCertificatReport>();

            foreach (var row in model.Grid)
            {


                datasources.Add(new SalaryCertificatReport()
                {

                    NationalNumber = row.NationalNumber,
                    EmployeeName = row.EmployeeName,
                    MawadaFund = row.MawadaFund,
                    BasicSalary = row.BasicSalary,
                    SolidarityFund = row.SolidarityFund,
                    SocialSecurityFund = row.SocialSecurityFund,
                    JihadTax = row.JihadTax,
                    NetSalary = row.FinalySalary,
                    AdvancePaymentValue = row.AdvancePaymentValue,
                    DiscountTotal = row.DiscountTotal,
                    Boun = row.Boun,
                    SalaryTotal = row.SalaryTotal,
                    AdvancePaymentName = row.AdvancePaymentName,
                    Degree = row.Degree.ToString(),
                    DiscountName = row.DiscountName,
                    premiumName = row.PremiumumName,
                    DiscountValue = row.ValueDiscountm,
                    premiumValue = row.ValuePremiumum
                });
            }

            var SaveList = datasources.FirstOrDefault();

            var delete = datasources.ToList();
            if(delete.Any())
                delete.RemoveAt(0);
            var Newdatasources = delete.ToList();

            var row2 = Newdatasources.FirstOrDefault();

            if (SaveList != null)
            {
                row2.NationalNumber = SaveList.NationalNumber;
                row2.EmployeeName = SaveList.EmployeeName;
                row2.MawadaFund = SaveList.MawadaFund;
                row2.BasicSalary = SaveList.BasicSalary;
                row2.SolidarityFund = SaveList.SolidarityFund;
                row2.SocialSecurityFund = SaveList.SocialSecurityFund;
                row2.JihadTax = SaveList.JihadTax;
                row2.NetSalary = SaveList.NetSalary;
                row2.AdvancePaymentValue = SaveList.AdvancePaymentValue;
                row2.DiscountTotal = SaveList.DiscountTotal;
                row2.Boun = SaveList.Boun;
                row2.SalaryTotal = SaveList.SalaryTotal;
                row2.AdvancePaymentName = SaveList.AdvancePaymentName;
                row2.Degree = SaveList.Degree.ToString();
            }


            var word = new Maths.NumberToWord(Newdatasources.Sum(r => r.NetSalary)).ConvertToArabic();

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("SalaryCertificate", Newdatasources);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("ReportParameter1", word),
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
        public ActionResult SalaryCertificateTotalReport(SalarySettlementReportModel model, string savedModel)
        {
            LoadModel(model, savedModel);
            //var format = string.Format("yyyy-MM-dd", dateFrom);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCertificateReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }


            if (!HumanResource.SalarySettlementReport.SearchByDate(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SalaryCertificatReport>();
            var datasources2 = new HashSet<SalaryCertificatReport>();

            foreach (var row in model.Grid)
            {


                datasources.Add(new SalaryCertificatReport()
                {

                    NationalNumber = row.NationalNumber,
                    EmployeeName = row.EmployeeName,
                    MawadaFund = row.MawadaFund,
                    BasicSalary = row.BasicSalary,
                    SolidarityFund = row.SolidarityFund,
                    SocialSecurityFund = row.SocialSecurityFund,
                    JihadTax = row.JihadTax,
                    NetSalary = row.FinalySalary,
                    AdvancePaymentValue = row.AdvancePaymentValue,
                    DiscountTotal = row.DiscountTotal,
                    Boun = row.Boun,
                    SalaryTotal = row.SalaryTotal,
                    AdvancePaymentName = row.AdvancePaymentName,
                    Degree = row.Degree.ToString(),
                    DiscountName = row.DiscountName,
                    premiumName = row.PremiumumName,
                    DiscountValue = row.ValueDiscountm,
                    premiumValue = row.ValuePremiumum
                });
            }

            var SaveList = datasources.First();

            var delete = datasources.ToList();
            delete.RemoveAt(0);
            var Newdatasources = delete.ToList();

            var row2 = Newdatasources.FirstOrDefault();


            row2.NationalNumber = SaveList.NationalNumber;
            row2.EmployeeName = SaveList.EmployeeName;
            row2.MawadaFund = SaveList.MawadaFund;
            row2.BasicSalary = SaveList.BasicSalary;
            row2.SolidarityFund = SaveList.SolidarityFund;
            row2.SocialSecurityFund = SaveList.SocialSecurityFund;
            row2.JihadTax = SaveList.JihadTax;
            row2.NetSalary = SaveList.NetSalary;
            row2.AdvancePaymentValue = SaveList.AdvancePaymentValue;
            row2.DiscountTotal = SaveList.DiscountTotal;
            row2.Boun = SaveList.Boun;
            row2.SalaryTotal = SaveList.SalaryTotal;
            row2.AdvancePaymentName = SaveList.AdvancePaymentName;
            row2.Degree = SaveList.Degree.ToString();



    var word = new Maths.NumberToWord(Newdatasources.Sum(r => r.NetSalary)).ConvertToArabic();

            DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
            DateTime dateTo = Convert.ToDateTime(model.DateTo);
            ReportDataSource rdc = new ReportDataSource("SalaryCertificate", Newdatasources);

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("ReportParameter1", word),
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
        //
        //الصكوك
        public ActionResult SalaryCheck(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSalaryCheck(model2.SalaryFormReportModel, model2, model2.JobNumber.ToString(), model2.BankId, model2.BankBranchId, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportSalaryCheck(SalaryFormReportModel model, SalarySettlementReportModel model2, string JobNumber, int? BankId, int? BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "ReportExtForClipord.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<ClipboardBanking>();


            foreach (var row in model2.Grid)
            {
                

                datasources.Add(new ClipboardBanking()
                {
                    BankBranchId=row.BankBranchId,
                    FinalySalary=row.FinalySalary,
           JobNumber=row.DateSalary,
           BankBranchName=row.BankBranchName,

                        Tafkeet = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()



                });
            }
            var LastData = datasources.Where(s => s.FinalySalary != 0).ToList();

            ReportDataSource rdc = new ReportDataSource("DataSet1", LastData);
            
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
        //
        //تقرير الموقفين
        public ActionResult ReportSubunded(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportSalarySubended(model2.SalaryFormReportModel, model2, model2.JobNumber.ToString(), model2.BankId, model2.BankBranchId, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportSalarySubended(SalaryFormReportModel model, SalarySettlementReportModel model2, string JobNumber, int? BankId, int? BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "HistoreySubsended.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        
            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<EmployeeReport>();


            foreach (var row in model2.Grid.Where(s=>s.Isubsended==true))
            {

                datasources.Add(new EmployeeReport()
                {
                    
DateDegreeNow=row.DateSubsended,
FullName=row.FullName,
JobNumber=row.JobNumber,
Employer=row.IsclodseMessage,
LastName=row.FinalySalary.ToString()

                });
            }

            ReportDataSource rdc = new ReportDataSource("DataSet1", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
           
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
        // 
        //السلف والرواتب تقرير
        public ActionResult AdvancePaymentIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportAdvancePaymentIndex(model2.AdvancePaymentReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult ReportAdvancePaymentIndex(AdvancePaymentReportModel model, SalarySettlementReportModel model2,string jobNumber, int BankId, int BankBranchId, int Month, int Year)
        {
            model.Month = Month;
            model.Year = Year;
            model2.ISadvanse = 1;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "AdvanceDetectionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<AdvanceDetection>();

            foreach (var row in model2.Grid)
            {
                datasources.Add(new AdvanceDetection()
                {
                    TafKeet=row.PremiumumName,
                 
                    JobNumber = row.JobNumber,
                    EmployeeName = row.EmployeeName,
                    Value = row.Value,
                    Date = row.Date,
                    //DeductionDate = row.DeductionDate,
                    InstallmentValue = row.InstallmentValue,
                    Rest = row.Rest
                });
            }

            var _dateMonth = HumanResource.Salary.GetMonthDate();
            //add by ali alherbade 26-05-2019
            var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            var _advanceName = datasources.FirstOrDefault()?.TafKeet;
            // end add 

            ReportDataSource rdc = new ReportDataSource("AdvanceDetection", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف بالسلف الداخلية "));
            reportParameters.Add(new ReportParameter("DateFrom", _dateMonth));
            reportParameters.Add(new ReportParameter("DateTo", ""));
            // add by ali alherbade 26-05-2019
            reportParameters.Add(new ReportParameter("Department", Department));//القسم
            reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة
            reportParameters.Add(new ReportParameter("FinancialAffairs", FinancialAffairs));// الشئون المالية
            reportParameters.Add(new ReportParameter("FinancialAuditor", FinancialAuditor));//المراقب المالي
            reportParameters.Add(new ReportParameter("PayrollUnit", PayrollUnit));//وحدة المرتبات
            reportParameters.Add(new ReportParameter("References", References));// المراجع
            reportParameters.Add(new ReportParameter("AdvanceName", _advanceName));// السلفة
            //
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
        //
        // tax index report
        public ActionResult TaxIndexReport(SalarySettlementReportModel model2, string savedModel)
        {
            return TaxReport(model2.TaxReportModel, model2, model2.JobNumber.ToString(), model2.BankId ?? 0, model2.BankBranchId ?? 0, model2.Month ?? 0, model2.Year ?? 0);
        }
        public ActionResult TaxReport(TaxReportModel model, SalarySettlementReportModel model2,string JobNumber, int BankId, int BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
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

            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<TaxReport>();

            
            // /
            foreach (var row in model2.Grid)
            {
                var Tax = Math.Round(
                    model2.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.IncomeTax), 3,
                    MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model2.Grid.Where(r => r.CostCenterId == row.CostCenterId)
                                .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model2.Grid.Where(r => r.CostCenterId == row.CostCenterId)
                                .Sum(r => r.StampTax), 3, MidpointRounding.AwayFromZero);
            }
            decimal tax = 0;
                foreach (var row in model2.Grid)
                {
                  tax = Math.Round(
                  model2.Grid.Where(r => r.JobNumber == row.JobNumber).Sum(r => r.IncomeTax), 3,
                  MidpointRounding.AwayFromZero)
                      + Math.Round(
                          model2.Grid.Where(r => r.JobNumber == row.JobNumber)
                              .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                      + Math.Round(
                          model2.Grid.Where(r => r.JobNumber == row.JobNumber)
                              .Sum(r => r.StampTax), 3, MidpointRounding.AwayFromZero);
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
                        Tafkeet = new Maths.NumberToWord(tax).ConvertToArabic()

                        //Date = //////
                    });
                }
            var _tafkeet = datasources.Sum(e => e.IncomeTax + e.JihadTax + e.StampTax);

            ReportDataSource rdc = new ReportDataSource("TaxReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف الضرائب"));
            reportParameters.Add(new ReportParameter("CompanyName", ""));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
            reportParameters.Add(new ReportParameter("Tafkeet", new Maths.NumberToWord(Math.Round(_tafkeet, 3, MidpointRounding.AwayFromZero)).ConvertToArabic()));
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
        // add by ali alherbade 28-05-2019
        // ملخص الرواتب
        public ActionResult AbstractClipboardBanking(SalarySettlementReportModel model2, string savedModel)
        {
            return ReportAbstractClipboardBanking(model2.ClipboardBankingReportModel, model2, model2.JobNumber.ToString(), model2.Month ?? 0, model2.Year ?? 0, model2.BankId, model2.BankBranchId);

        }
        public ActionResult ReportAbstractClipboardBanking(ClipboardBankingReportModel model, SalarySettlementReportModel model2, string jobNumber, int month, int year, int? BankId, int? BankBranchId)
        {
            model.Month = month;
            model.Year = year;

            model2.AbstractClipboard = 1;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "AbstractClipboardBanking.rdlc");


            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
                lr.ReportEmbeddedResource = path;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
            if (!HumanResource.SalarySettlementReport.SearchByDate(model2))
                return AjaxHumanResourceState("_Form", model);
           
            /// / // // //
            var datasources = new HashSet<AbstractClipboardBanking>();
            // var BankBranchName = model2.Grid.GroupBy(g => g.BankBranchName);
            List<string> bank = new List<string>();
            foreach (var row in model2.Grid.OrderBy(o => o.BankName))
            {
               
                dd.Add(model2.Grid.Where(w => w.BankBranchId == row.BankBranchId).Sum(s => s.FinalySalary));
                if (!bank.Contains(row.BankName + " " + row.BankBranchName))
                {
                    bank.Add(row.BankName + " " + row.BankBranchName);
                    //foreach (var item in row.BankBranchName)
                    //{
                    
                    //datasources.Add(new AbstractClipboardBanking()
                    //{
                    //    // BankName = row.BankName
                    //    //BankID = row.BankId,
                    //    //BankBranchId = row.BankBranchId,
                    //    //BankBranchName = row.BankBranchName.FirstOrDefault().ToString(),
                    //    // BankName = row.BankName,
                    //    // BankBranchName = row.BankBranchName.FirstOrDefault().ToString(),
                    //});
                }
                //}
                //datasources.Add(new AbstractClipboardBanking()
                //    {
                //    //BankName = row.BankName,
                //    //BankID = row.BankId,
                //    //BankBranchId = row.BankBranchId,
                //    //BankBranchName = row.BankBranchName,
                //    //Value = model2.Grid.Where(b => b.BankBranchId == row.BankBranchId)
                //    //.Sum(s => s.FinalySalary),

                //    //Word = new Maths.NumberToWord(Math.Round(model2.Grid.Where(s => s.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                //});



            }
            foreach (var item in bank)
            {
                datasources.Add(new AbstractClipboardBanking()
                {
                    BankName = item,
                    Value = model2.Grid
                            .Where(w => w.BankName + " " + w.BankBranchName == item)
                            .Sum(s => s.FinalySalary)

                });
            }
            //add by ali alherbade 26-05-2019
            var PayrollUnit = HumanResource.StartUp.CompanyInfo.PayrollUnit;// وحدة المرتبات
            var References = HumanResource.StartUp.CompanyInfo.References;//المراجع
            var FinancialAuditor = HumanResource.StartUp.CompanyInfo.FinancialAuditor;//المراقب المالي
            var FinancialAffairs = HumanResource.StartUp.CompanyInfo.FinancialAffairs;// الشئون المالية
            var LongName = HumanResource.StartUp.CompanyInfo.LongName;// اسم الشركة
            var Department = HumanResource.StartUp.CompanyInfo.Department;// القسم
            // end add 
            ReportDataSource rdc = new ReportDataSource("AbstractCliboardBanking", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "ملخص الحافظة المصرفية  "));
            // add by ali alherbade 26-05-2019
            reportParameters.Add(new ReportParameter("Department", Department));//القسم
            reportParameters.Add(new ReportParameter("CompanyName", LongName));// اسم الشركة
            reportParameters.Add(new ReportParameter("FinancialAffairs", FinancialAffairs));// الشئون المالية
            reportParameters.Add(new ReportParameter("FinancialAuditor", FinancialAuditor));//المراقب المالي
            reportParameters.Add(new ReportParameter("PayrollUnit", PayrollUnit));//وحدة المرتبات
            reportParameters.Add(new ReportParameter("References", References));// المراجع

            //
            lr.SetParameters(reportParameters);
            lr.DataSources.Add(rdc);
            string reportType = "Excel";//PrintType;
            string mimeType;
            string encoding;
            string fileNameextention;
            if (reportType == "Excel")
            {
                fileNameextention = "xlsx";
            }
            else
            {
                fileNameextention = "pdf";
            }

            string deviceinfo =
                "<DeviceInfo>" +
                    "<OutPutFormat>" + fileNameextention + "</OutPutFormat>" +
                    "<PageWidth>11.69in</PageWidth>" +
                    "<PageHeight>8.27in</PageHeight>" +
                    "<MarginTop>0.1in</MarginTop>" +
                    "<MarginLeft>0.1in</MarginLeft>" +
                    "<MarginRight>0.1in</MarginRight>" +
                    "<MarginBottom>0.1in</MarginBottom>" +
                 "</DeviceInfo>";
            Warning[] warnings;
            string[] stream;
            byte[] renderedBytes;
            renderedBytes = lr.Render(
                reportType,
                deviceinfo,
                out mimeType,
               out encoding,
               out fileNameextention,
               out stream,
               out warnings);

            return File(renderedBytes, mimeType);


            //***--ملخص الحافظة 8/8
            //lr.SetParameters(reportParameters);
            //lr.DataSources.Add(rdc);
            //string mimeType;
            //string encoding;
            //string filenameextention;
            //string deviceinfo =
            //    "<DeviceInfo>" +
            //    "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
            //    "</DeviceInfo>";
            //Warning[] warnings;
            //string[] stream;
            //byte[] renderedBytes;
            //renderedBytes = lr.Render(
            //    "PDF",
            //    deviceinfo,
            //    out mimeType,
            //    out encoding,
            //    out filenameextention,
            //    out stream,
            //    out warnings);

            //return File(renderedBytes, mimeType);
        }
        //

        //public ActionResult SalaryCertificateReport(SalarySettlementReportModel model, string savedModel)
        //{
        //    LoadModel(model, savedModel);
        //    //var format = string.Format("yyyy-MM-dd", dateFrom);
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCertificateReport.rdlc");
        //    if (System.IO.File.Exists(path))
        //    {
        //        lr.ReportPath = path;
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }


        //    if (!HumanResource.SalarySettlementReport.SearchByDate(model))
        //        return AjaxHumanResourceState("_Form", model);

        //    var datasources = new HashSet<SalaryCertificatReport>();
        //    var datasources2 = new HashSet<SalaryCertificatReport>();

        //    foreach (var row in model.Grid)
        //    {


        //        datasources.Add(new SalaryCertificatReport()
        //        {

        //            NationalNumber = row.NationalNumber,
        //            EmployeeName = row.EmployeeName,
        //            MawadaFund = row.MawadaFund,
        //            BasicSalary = row.BasicSalary,
        //            SolidarityFund = row.SolidarityFund,
        //            SocialSecurityFund = row.SocialSecurityFund,
        //            JihadTax = row.JihadTax,
        //            NetSalary = row.FinalSalaryCertified,
        //            AdvancePaymentValue = row.AdvancePaymentValue,
        //            DiscountTotal = row.DiscountTotal,
        //            Boun = row.Boun,
        //            SalaryTotal = row.SalaryTotal,
        //            AdvancePaymentName = row.AdvancePaymentName,
        //            Degree = row.Degree.ToString(),
        //            DiscountName = row.DiscountName,
        //            premiumName = row.PremiumumName,
        //            DiscountValue = row.ValueDiscountm,
        //            premiumValue = row.ValuePremiumum
        //        });
        //    }
        //    if (datasources.Count() != 0)
        //    {
        //        var SaveList = datasources.First();

        //        var delete = datasources.ToList();
        //        delete.RemoveAt(0);
        //        var Newdatasources = delete.ToList();

        //        var row2 = Newdatasources.FirstOrDefault();


        //        row2.NationalNumber = SaveList.NationalNumber;
        //        row2.EmployeeName = SaveList.EmployeeName;
        //        row2.MawadaFund = SaveList.MawadaFund;
        //        row2.BasicSalary = SaveList.BasicSalary;
        //        row2.SolidarityFund = SaveList.SolidarityFund;
        //        row2.SocialSecurityFund = SaveList.SocialSecurityFund;
        //        row2.JihadTax = SaveList.JihadTax;
        //        row2.NetSalary = SaveList.NetSalary;
        //        row2.AdvancePaymentValue = SaveList.AdvancePaymentValue;
        //        row2.DiscountTotal = SaveList.DiscountTotal;
        //        row2.Boun = SaveList.Boun;
        //        row2.SalaryTotal = SaveList.SalaryTotal;
        //        row2.AdvancePaymentName = SaveList.AdvancePaymentName;
        //        row2.Degree = SaveList.Degree.ToString();



        //        var word = new Maths.NumberToWord(Newdatasources.Sum(r => r.NetSalary)).ConvertToArabic();

        //        DateTime dateFrom = Convert.ToDateTime(model.DateFrom);
        //        DateTime dateTo = Convert.ToDateTime(model.DateTo);
        //        ReportDataSource rdc = new ReportDataSource("DataSet1", Newdatasources);//"SalaryCertificate"

        //        ReportParameterCollection reportParameters = new ReportParameterCollection
        //    {
        //        new ReportParameter("ReportParameter1", word),
        //    };

        //        lr.SetParameters(reportParameters);
        //        lr.DataSources.Add(rdc);
        //    }
        //    string mimeType;
        //    string encoding;
        //    string filenameextention;
        //    string deviceinfo =
        //        "<DeviceInfo>" +
        //        "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
        //        "</DeviceInfo>";
        //    Warning[] warnings;
        //    string[] stream;
        //    var renderedBytes = lr.Render(
        //        "PDF",
        //        deviceinfo,
        //        out mimeType,
        //        out encoding,
        //        out filenameextention,
        //        out stream,
        //        out warnings);

        //    return File(renderedBytes, mimeType);
        //}
        // add by ali alherbade 25-05-2019


        //end add
        //
        //بطاقة مرتب

        //public ActionResult SolidarityFund(SalaryIndexModel indexModel)
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.SolidarityFundReportModel, indexModel);
        //}
    }
}