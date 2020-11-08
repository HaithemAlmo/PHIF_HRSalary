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
    public class SalaryController : BaseController
    {

        // GET: Salary
        public ActionResult Index()
        {

            var model = HumanResource.Salary.Index();
            

            if (model == null)
                return HumanResourceState();

            return View(model);
        }
        // /// //ahmed alalem
        public ActionResult ClipordIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        public ActionResult SolidrtyFoundIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        public ActionResult CardIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        public ActionResult SocialSecurityFundIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        public ActionResult SalaryFormIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        //public ActionResult DifrancesIndex(SalaryIndexModel model, CheckDifrncess? Chceck, int? EmployeeId, string month)
        //{

        //    model = HumanResource.Salary.ClipordIndex(model);

        //    //if (model == null)
        //    //    return HumanResourceState();
        //    //if (Chceck == CheckDifrncess.Single)
        //    //{
        //    //    var model2 = HumanResource.Salary.UpdateDifrncess(EmployeeId ?? 0, month);
        //    //    ModelState.Clear();

        //    //    return View(model);


        //    //}
        //    //if (Chceck == CheckDifrncess.Single)

        //    //{
        //    //    return View(model);
        //    //}


        //    return View(model);
        //}
        [HttpPost]
        public ActionResult SummaryIndex(SalaryIndexModel model, FormCollection form, int? Month, int? Year)
        {



            LoadModel(model, form["savedModel"]);

            if (form["search"] != null)
            {
                model = HumanResource.Salary.SearchSummary(model);
            }
            if (form["Print"] != null)
            {

                return ReportSummary(model.summryreport, model);
            }

            return View(model);
        }
     
        [HttpPost]

        public ActionResult ClipordIndex(SalaryIndexModel model, FormCollection form, int? JubNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);
            }
            if (form["PrintCheck"] != null)
            {
                return ReportCheck(model.ClipboardBankingReportModel, JubNumber.ToString(), model.BankId, model.BankBranchId ?? 0, Month ?? 0, Year ?? 0);
            }
                if (form["Print"] != null)
            {

                return ClipordIndexReport(model, JubNumber ?? 0, model.BankId, model.BankBranchId ?? 0, Month ?? 0, Year ?? 0);
            }
            return View(model);
        }
        public ActionResult ClipordIndexReport(SalaryIndexModel mmx, int JobNumber, int BankId, int BranchId, int? Month, int? Year)
        {

            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return ReportClipordIndex(model.ClipboardBankingReportModel, JobNumber.ToString(), Month ?? 0, Year ?? 0, BankId, BranchId);

        }
        [HttpPost]
        public ActionResult AdvancePaymentIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.SearchSalaryAdvPayement(model);
            }
            if (form["Print"] != null)
            {
                return AdvancePaymentIndexReport(model, JobNumber ?? 0, model.BankId, model.BankBranchId, model.Month, model.Year);
            }
            return View(model);
        }
        public ActionResult AdvancePaymentIndexReport(SalaryIndexModel mmx, int JobNumber, int? BankId, int? BranchId, int? Month, int? Year)
        {

            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return ReportAdvancePaymentIndex(model.AdvancePaymentReportModel, JobNumber.ToString(), BankId ?? 0, BranchId ?? 0, Month ?? 0, Year ?? 0);

        }
        [HttpPost]

        public ActionResult SolidrtyFoundIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);
            }
            if (form["Print"] != null)
            {
                return SolidrtyFoundIndexReport(model, JobNumber, model.BankId, model.BankId, model.Month, model.Year);
            }
            return View(model);
        }
        public ActionResult SolidrtyFoundIndexReport(SalaryIndexModel mm, int? JobNumber, int? BranchId, int? BankId, int? month, int? year)
        {
            mm.BankId = 0;
            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return ReportSolidrtyFound(model.SolidarityFundReportModel, JobNumber.ToString(), BankId ?? 0, BranchId ?? 0, month ?? 0, year ?? 0);

        }
        [HttpPost]

        public ActionResult TaxIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);
            }
            if (form["Print"] != null)
            {
                return TaxIndexReport(model, JobNumber, model.BankBranchId, model.BankId, Month, Year);
            }
            return View(model);
        }
        public ActionResult TaxIndexReport(SalaryIndexModel mm, int? JobNumber, int? BranchId, int? BankId, int? month, int? year)
        {
            mm.BankId = 0;
            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return TaxReport(model.TaxReportModel, JobNumber.ToString(), BankId ?? 0, BranchId ?? 0, month ?? 0, year ?? 0);

        }
        [HttpPost]

        public ActionResult SocialSecurityFundIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);
            }
            if (form["Print"] != null)
            {
                return SocialSecurityFundIndexReport(model, JobNumber, model.BankBranchId, model.BankId, model.Month, model.Year);
            }
            return View(model);
        }
        public ActionResult SocialSecurityFundIndexReport(SalaryIndexModel mm, int? JobNumber, int? BranchId, int? BankId, int? month, int? year)
        {
            mm.BankId = 0;
            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return SocialFoundReport(model.SocialSecurityFundReportModel, JobNumber.ToString(), BankId ?? 0, BranchId ?? 0, month ?? 0, year ?? 0);

        }
        [HttpPost]

        public ActionResult CardIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);
            }
            if (form["Print"] != null)
            {
                return CardIndexReport(model, JobNumber, model.BankBranchId, model.BankId, model.Month, model.Year);
            }
            return View(model);
        }
        public ActionResult CardIndexReport(SalaryIndexModel mm, int? JobNumber, int? BranchId, int? BankId, int? month, int? year)
        {

            var model = HumanResource.Salary.Index();

            if (model == null)
                return HumanResourceState();
            return ReportCardIndex(model.SalaryCardReportModel, JobNumber.ToString(), BankId ?? 0, BranchId ?? 0, month ?? 0, year ?? 0);

        }
        //[HttpPost]

        //public ActionResult DifrancesIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? BankId, int? BranchId, int? Month, int? Year)
        //{

        //    LoadModel(model, form["savedModel"]);
        //    HumanResource.Salary.GetBranch(model);
        //    if (form["search"] != null)
        //    {
        //        model = HumanResource.Salary.SearchDifrancess(model);

        //    }
        //    if (form["Print"] != null)
        //    {
        //        return DifrancesReport(model, JobNumber ?? 0, model.BankId, model.BankBranchId ?? 0, model.Month, model.Year);
        //    }
        //    if (form["Zero"] != null)
        //    {
        //        model = HumanResource.Salary.Search(model);

        //    }
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult SalaryFormIndex(SalaryIndexModel model, FormCollection form, int? JobNumber, int? BankId, int? BranchId, int? Month, int? Year)
        {

            LoadModel(model, form["savedModel"]);
            HumanResource.Salary.GetBranch(model);
            if (form["search"] != null)
            {
                model = HumanResource.Salary.Search(model);

            }
            if (form["Print"] != null)
            {
                return SalaryFormReport(model, JobNumber ?? 0, model.BankId, model.BankBranchId ?? 0, model.Month, model.Year);
            }
            return View(model);
        }
        public ActionResult AdvancePaymentIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();


            return View(model);
        }
        public ActionResult TaxIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }
        public ActionResult SummaryIndex(SalaryIndexModel model)
        {

            model = HumanResource.Salary.ClipordIndex(model);

            if (model == null)
                return HumanResourceState();
            return View(model);
        }

        public ActionResult SolidarityFund(SalaryIndexModel indexModel)
        {
            var model = HumanResource.Salary.Index();

            return Report(model.SolidarityFundReportModel, indexModel);
        }
      
        public ActionResult SalaryFormReport(SalaryIndexModel model, int JobNumber, int BankId, int BranchId, int? Month, int? Year)
        {
            HumanResource.Salary.Index();

            return ReportSalaryForm(model.SalaryFormReportModel, JobNumber.ToString(), BankId, BranchId, Month ?? 0, Year ?? 0);
        }
        //public ActionResult Tax(SalaryIndexModel indexModel)
        //{
        //    var model = HumanResource.Salary.Index();


        //    return Report(model.TaxReportModel, indexModel);
        //}
        //public ActionResult DifrancesReport(SalaryIndexModel indexModel, int JobNumber, int BankId, int BranchId, int? Month, int? Year)
        //{
        //    var model = HumanResource.Salary.Index();

        //    return ReportDifrances(model.DifrancesModel, JobNumber.ToString(), BankId, BranchId, Month ?? 0, Year ?? 0);
        //}
        /// // /  / /// // // // card
        public ActionResult ReportCardIndex(SalaryCardReportModel model, string JobNumber, int BankId, int BankBranchId, int month, int year)
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



            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);


            //   var BankBranchId2 = model.Grid.Select(r => r.JobNumber);

            var datasources = new HashSet<SalaryCard>();

            var grid =
                 model.Grid.Where(f => f.JobNumber == JobNumber.ToString());
            var grid2 =
             model.Grid.Where(f => f.BankId == BankId);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BankBranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BankId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
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
                        Subject = row.Subject,
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
            }
            else if (list3 != null && list3.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list3.Contains(r.BankBranchId)))
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
                        Subject = row.Subject,
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
            }
            else
            {
                foreach (var row in model.Grid.Where(r => list2.Contains(r.BankId)))
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
                        Subject = row.Subject,
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

        public ActionResult AdvancePayment()
        {
            var model = HumanResource.Salary.Index();

            return Report(model.AdvancePaymentReportModel);
        }
        public ActionResult SalaryForm()
        {
            var model = HumanResource.Salary.Index();

            return Report(model.SalaryFormReportModel);
        }
        public ActionResult SalaryCard(SalaryIndexModel model)
        {
            return Report(model.SalaryCardReportModel);
        }
        public ActionResult ClipboardBanking()
        {
            var model = HumanResource.Salary.Index();

            return Report(model.ClipboardBankingReportModel, model.SalaryCardReportModel);
        }
        // /// / reportcheck


        // // // social found report
        public ActionResult ReportCheck(ClipboardBankingReportModel model, string jobNumber, int? BankId, int? BankBranchId ,int month, int year)
        {
            model.Month = month ;
            model.Year = year ;
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

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);
            var datasources = new HashSet<ClipboardBanking>();

            var grid =
                 model.Grid.Where(f => f.JobNumber == jobNumber);
            var grid2 =
              model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BankBranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BankBranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in grid)
                {
                    datasources.Add(new ClipboardBanking()
                    {
                        JobNumber = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        BankBranchId = row.BankBranchId,
                        BankBranchName=row.BankBranchName,
                        FinalySalary = row.FinalySalary,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }
            else if (list2 != null && list2.Count() != 0)
            {
                foreach (var row in grid2)
                {
                    datasources.Add(new ClipboardBanking()
                    {
                        BankBranchName = row.BankBranchName,
                        JobNumber = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        BankBranchId = row.BankBranchId,
                        FinalySalary = row.FinalySalary,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }
            else
            {
                foreach (var row in grid3)
                {
                    var sumSalary = 
                    datasources.Add(new ClipboardBanking()
                    {
                        BankBranchName = row.BankBranchName,
                        JobNumber = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        BankBranchId = row.BankBranchId,
                        FinalySalary = row.FinalySalary,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }
            /// //
         
            
            ReportDataSource rdc = new ReportDataSource("DataSet1", datasources);
         //   ReportParameterCollection reportParameters = new ReportParameterCollection();
            //reportParameters.Add(new ReportParameter("Title", "كشف التضمان الاجتماعي"));
            //reportParameters.Add(new ReportParameter("CompanyName", ""));
            //reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
           //lr.SetParameters(reportParameters);
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
             // /// //
             // // // social found report
        public ActionResult SocialFoundReport(SocialSecurityFundReportModel model, string JobNumber, int BankId, int BankBranchId, int? month, int? year)
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

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SocialSecurityFundReport1>();
            var grid =
                model.Grid.Where(f => f.JobNumber == JobNumber.ToString());
            var grid2 =
             model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
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
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.JobNumber == row.JobNumber).Sum(r => r.ShareSum), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                        //
                        //Date = //////
                    });
                }
            }
            else if (list2 != null && list2.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list2.Contains(r.BankId)))
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
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BranchId == row.BranchId).Sum(r => r.ShareSum), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                        //
                        //Date = //////
                    });

                }
            }
            else if (list3 != null && list3.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list3.Contains(r.BranchId)))
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
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BranchId == row.BranchId).Sum(r => r.ShareSum), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                        //
                        //Date = //////
                    });
                }
            }
            ReportDataSource rdc = new ReportDataSource("SocialSecurityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضمان الاجتماعي"));
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


        // /// // /
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
        public ActionResult ReportClipordIndex(ClipboardBankingReportModel model, string jobNumber, int month, int year, int? BankId, int? BankBranchId)
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



            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);






            /// / // // //
            var datasources = new HashSet<ClipboardBanking>();

            var grid =
                 model.Grid.Where(f => f.JobNumber == jobNumber);
            var grid2 =
              model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0).ToList();
            var list2 = grid2
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BankBranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BankBranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (grid != null && grid.Count() != 0)
            {
                foreach (var row in grid)
                {
                    datasources.Add(new ClipboardBanking()
                    {
                        JobNumber = row.JobNumber,
                        BondNumber = row.BondNumber,
                        EmployeeName = row.EmployeeName,
                        BankBranchId = row.BankBranchId,
                        BankBranchName = row.BankBranchName,
                        FinalySalary = row.FinalySalary,
                        NationalNumber = row.NationalNumber,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.JobNumber == row.JobNumber).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }
            else if (grid2 != null && grid2.Count() != 0)
            {
                foreach (var row in grid2)
                {
                    datasources.Add(new ClipboardBanking()
                    {
                        JobNumber = row.JobNumber,
                        BondNumber = row.BondNumber,
                        EmployeeName = row.EmployeeName,
                        BankBranchId = row.BankBranchId,
                        BankBranchName = row.BankBranchName,
                        FinalySalary = row.FinalySalary,
                        NationalNumber = row.NationalNumber,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }
            else
            {
                foreach (var row in grid3)
                {
                    datasources.Add(new ClipboardBanking()
                    {
                        JobNumber = row.JobNumber,
                        BondNumber = row.BondNumber,
                        EmployeeName = row.EmployeeName,
                        BankBranchId = row.BankBranchId,
                        BankBranchName = row.BankBranchName,
                        FinalySalary = row.FinalySalary,
                        NationalNumber = row.NationalNumber,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                    });
                }
            }

            ReportDataSource rdc = new ReportDataSource("ClipboardBanking", datasources);
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
        public ActionResult ReportSolidrtyFound(SolidarityFundReportModel model, string JobNumber, int BankId, int BankBranchId, int month, int year)
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

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<SolidarityFundReport>();

            var grid =
              model.Grid.Where(f => f.JobNumber == JobNumber.ToString());

            var grid2 =
              model.Grid.Where(f => f.BankId == BankId && f.BranchId == BankBranchId);
            var list2 = grid2.Select(n => n.BranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId);
            var list3 = grid3.Select(n => n.BankId)
               .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
                {
                    datasources.Add(new SolidarityFundReport()
                    {
                        JobNumber = row.JobNumber,
                        Name = row.Name,
                        TotalSalary = row.TotalSalary,
                        SolidarityFund = row.SolidarityFund,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.JobNumber == row.JobNumber).Sum(r => r.SolidarityFund), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                        //BondNumber = 
                        //Date = //////
                    });
                }
            }


            else if (list2 != null && list2.Count() != 0)
            {
                {
                    foreach (var row in model.Grid.Where(r => list2.Contains(r.BranchId)))

                        datasources.Add(new SolidarityFundReport()
                        {
                            JobNumber = row.JobNumber,
                            Name = row.Name,
                            TotalSalary = row.TotalSalary,
                            SolidarityFund = row.SolidarityFund,
                            CostCenterId = row.CostCenterId,
                            CostCenterName = row.CostCenterName,
                            Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BranchId == row.BranchId).Sum(r => r.SolidarityFund), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                            //BondNumber = 
                            //Date = //////
                        });
                }
            }
            else if (list3 != null && list3.Count() != 0)
            {
                {
                    foreach (var row in model.Grid.Where(r => list3.Contains(r.BankId)))

                        datasources.Add(new SolidarityFundReport()
                        {
                            JobNumber = row.JobNumber,
                            Name = row.Name,
                            TotalSalary = row.TotalSalary,
                            SolidarityFund = row.SolidarityFund,
                            CostCenterId = row.CostCenterId,
                            CostCenterName = row.CostCenterName,
                            Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankId == row.BankId).Sum(r => r.SolidarityFund), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()
                            //BondNumber = 
                            //Date = //////
                        });
                }
            }



            ReportDataSource rdc = new ReportDataSource("SolidarityFund", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف التضامن"));
            //reportParameters.Add(new ReportParameter("BondNumber", indexModel.SolidarityFundBondNumber));
            //reportParameters.Add(new ReportParameter("CompanyName", ""));
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
        public ActionResult ReportSalaryForm(SalaryFormReportModel model, string JobNumber, int? BankId, int? BankBranchId, int month, int year)
        {
            model.Month = month;
            model.Year = year;
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

            var grid =
                 model.Grid.Where(f => f.JobNumber == JobNumber);
            var grid2 =
              model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
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
                        //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                        Sanction = row.Sanction,
                        SickVacation = row.SickVacation,
                        SituationOnNet = row.SituationOnNet,
                        SituationOnTotal = row.SituationOnTotal,
                        SolidarityFund = row.SolidarityFund,
                        StampTax = row.StampTax,
                        SubjectSalary = row.SubjectSalary,
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        WithoutPay = row.WithoutPay,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        EmployeeStat = row.EmployeeStat,
                        AdvancePremiumInside = row.AdvancePremiumInside,
                        AdvancePremiumOutside = row.AdvancePremiumOutside,
                        FinalySalary = row.FinalSalary,
                        PrepaidPremium = row.PrepaidSalary,


                    });
                }
            }
            if (list2 != null && list2.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list2.Contains(r.BankId)))
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
                        //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                        Sanction = row.Sanction,
                        SickVacation = row.SickVacation,
                        SituationOnNet = row.SituationOnNet,
                        SituationOnTotal = row.SituationOnTotal,
                        SolidarityFund = row.SolidarityFund,
                        StampTax = row.StampTax,
                        SubjectSalary = row.SubjectSalary,
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        WithoutPay = row.WithoutPay,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        EmployeeStat = row.EmployeeStat,
                        AdvancePremiumInside = row.AdvancePremiumInside,
                        AdvancePremiumOutside = row.AdvancePremiumOutside,
                        FinalySalary = row.FinalSalary,
                        PrepaidPremium = row.PrepaidSalary,
                        RewindValue = row.RewindValue,
                        AccumulatedValue = row.AccumulatedValue


                    });
                }
            }
            else if (list3 != null && list3.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list3.Contains(r.BranchId)))
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
                        //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                        Sanction = row.Sanction,
                        SickVacation = row.SickVacation,
                        SituationOnNet = row.SituationOnNet,
                        SituationOnTotal = row.SituationOnTotal,
                        SolidarityFund = row.SolidarityFund,
                        StampTax = row.StampTax,
                        SubjectSalary = row.SubjectSalary,
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        WithoutPay = row.WithoutPay,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        EmployeeStat = row.EmployeeStat,
                        AdvancePremiumInside = row.AdvancePremiumInside,
                        AdvancePremiumOutside = row.AdvancePremiumOutside,
                        FinalySalary = row.FinalSalary,
                        PrepaidPremium = row.PrepaidSalary,
                        RewindValue = row.RewindValue,
                        AccumulatedValue = row.AccumulatedValue

                    });
                }
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
        // // /// /// //
        /// /// /// /// /السلف والرواتب تقرير
        public ActionResult ReportAdvancePaymentIndex(AdvancePaymentReportModel model, string jobNumber, int BankId, int BankBranchId, int Month, int Year)
        {
            model.Month = Month;
            model.Year = Year;

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
            var grid =
                 model.Grid.Where(f => f.JobNumber == jobNumber);
            var grid2 =
              model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))

                {
                    datasources.Add(new AdvancePaymentReport()
                    {
                        AdvancePremium = row?.AdvancePaymentInside ?? row.AdvancePaymentOutside,//////////////////////////


                        JobNumber = row.JobNumber,
                        Name = row.Name,
                        PrepaidSalary = row.PrepaidSalary,
                        CostCenterName = row.CostCenterName,
                        CostCenterId = row.CostCenterId
                        //Date = //////
                    });
                }
            }
            else if (list2 != null && list2.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list2.Contains(r.BankId)))

                {
                    datasources.Add(new AdvancePaymentReport()
                    {
                        AdvancePremium = row?.AdvancePaymentInside == 0 ? row.AdvancePaymentOutside : row.AdvancePaymentInside,//////////////////////////

                        JobNumber = row.JobNumber,
                        Name = row.Name,
                        PrepaidSalary = row.PrepaidSalary,
                        CostCenterName = row.CostCenterName,
                        CostCenterId = row.CostCenterId
                        //Date = //////
                    });
                }
            }
            else if (list3 != null && list3.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list3.Contains(r.BranchId)))

                {
                    datasources.Add(new AdvancePaymentReport()
                    {
                        AdvancePremium = row?.AdvancePaymentInside == 0 ? row.AdvancePaymentOutside : row.AdvancePaymentInside,//////////////////////////
                        JobNumber = row.JobNumber,
                        Name = row.Name,
                        PrepaidSalary = row.PrepaidSalary,
                        CostCenterName = row.CostCenterName,
                        CostCenterId = row.CostCenterId
                        //Date = //////
                    });
                }
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
        // // / tax index report
        public ActionResult TaxReport(TaxReportModel model, string JobNumber, int BankId, int BankBranchId, int month, int year)
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

            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<TaxReport>();

            var grid =
                 model.Grid.Where(f => f.JobNumber == JobNumber.ToString());
            var grid2 =
             model.Grid.Where(f => f.BankId == BankId && BankBranchId == 0);
            var list2 = grid2.Select(n => n.BankId)
               .ToList();
            var grid3 =
              model.Grid.Where(f => f.BankId == BankId && f.BranchId == BankBranchId);
            var list3 = grid3.Select(n => n.BranchId)
               .ToList();
            var list = grid.Select(n => n.JobNumber)
                .ToList();

            // /
            foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
            {
                var tax = Math.Round(
                    model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.IncomeTax), 3,
                    MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model.Grid.Where(r => r.CostCenterId == row.CostCenterId)
                                .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model.Grid.Where(r => r.CostCenterId == row.CostCenterId)
                                .Sum(r => r.StampTax), 3, MidpointRounding.AwayFromZero);
            }
            if (list != null && list.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list.Contains(r.JobNumber)))
                {
                    var tax = Math.Round(
                  model.Grid.Where(r => r.JobNumber == row.JobNumber).Sum(r => r.IncomeTax), 3,
                  MidpointRounding.AwayFromZero)
                      + Math.Round(
                          model.Grid.Where(r => r.JobNumber == row.JobNumber)
                              .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                      + Math.Round(
                          model.Grid.Where(r => r.JobNumber == row.JobNumber)
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
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        TaxTotal = row.TaxSum,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        Tafkeet = new Maths.NumberToWord(tax).ConvertToArabic()

                        //Date = //////
                    });
                }
            }
            else if (list2 != null && list2.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list2.Contains(r.BankId)))
                {
                    var tax = Math.Round(
              model.Grid.Where(r => r.BankId == row.BankId).Sum(r => r.IncomeTax), 3,
              MidpointRounding.AwayFromZero)
                  + Math.Round(
                      model.Grid.Where(r => r.BankId == row.BankId)
                          .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                  + Math.Round(
                      model.Grid.Where(r => r.BankId == row.BankId)
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
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        TaxTotal = row.TaxSum,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        Tafkeet = new Maths.NumberToWord(tax).ConvertToArabic()

                        //Date = //////
                    });
                }
            }
            else if (list3 != null && list3.Count() != 0)
            {
                foreach (var row in model.Grid.Where(r => list3.Contains(r.BranchId)))
                {
                    var tax = Math.Round(
          model.Grid.Where(r => r.BranchId == row.BranchId).Sum(r => r.IncomeTax), 3,
          MidpointRounding.AwayFromZero)
              + Math.Round(
                  model.Grid.Where(r => r.BranchId == row.BranchId)
                      .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
              + Math.Round(
                  model.Grid.Where(r => r.BranchId == row.BranchId)
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
                        Subject = row.Subject,
                        TotalSalary = row.TotalSalary,
                        TaxTotal = row.TaxSum,
                        CostCenterId = row.CostCenterId,
                        CostCenterName = row.CostCenterName,
                        Tafkeet = new Maths.NumberToWord(tax).ConvertToArabic()


                        //Date = //////
                    });

                }
            }
            ReportDataSource rdc = new ReportDataSource("TaxReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف الضرائب"));
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
        // /// // 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SalaryIndexModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            if (Request.IsAjaxRequest())
                return AjaxIndex(model, form);

            switch (form["reportType"])
            {
                case "tax":
                    return HumanResource.Salary.SaveBondNumber(model)
                        ? Tax(model)
                        : HumanResourceState(model);

                case "solidarityFund":
                    return HumanResource.Salary.SaveBondNumber(model)
                        ? SolidarityFund(model)
                        : HumanResourceState(model);

                case "socialSecurityFund":
                    return HumanResource.Salary.SaveBondNumber(model)
                        ? SocialSecurityFund(model)
                        : HumanResourceState(model);

                case "SalaryFormReport":
                    return Report(model.SalaryFormReportModel);

                case "SalaryCardReport":
                    return SalaryCard(model);

                case "salariesTotal":
                    return SalariesTotal();

                case "ClipboardBanking":
                    return Report(model.ClipboardBankingReportModel, model.SalaryCardReportModel);
            }

            return AjaxNotWorking();
        }

        private PartialViewResult AjaxIndex(SalaryIndexModel model, FormCollection form)
        {
            if (form["insideAdvancePremiumFrezh"] != null && !HumanResource.Salary.InsideAdvancePremiumFreeze(model))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["outsideAdvancePremiumFrezh"] != null && !HumanResource.Salary.OutsideAdvancePremiumFreeze(model))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["insideAdvancePremiumAllow"] != null && !HumanResource.Salary.InsideAdvancePremiumAllow(model))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["outsideAdvancePremiumAllow"] != null && !HumanResource.Salary.OutsideAdvancePremiumAllow(model))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["AdvancePremiumFreezeState"] != null && !HumanResource.Salary.AdvancePremiumFreeze(true))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["DEAdvancePremiumFreezeState"] != null && !HumanResource.Salary.AdvancePremiumFreeze(false))
                return AjaxHumanResourceState("_IndexForm", model);
            if (form["update"] != null && !HumanResource.Salary.Update(model))
                return AjaxHumanResourceState("_IndexForm", model);

            if (form["close"] != null && !HumanResource.Salary.Close(model))
                return AjaxHumanResourceState("_IndexForm", model);

            var suspendedTrueSalaryId = LongValue(form["suspendedTrueSalaryId"]);


            if (suspendedTrueSalaryId > 0 && !HumanResource.Salary.SuspendedTrue(model, suspendedTrueSalaryId, model.SuspendedNote))
                return AjaxHumanResourceState("_IndexForm", model);

            var suspendedFalseSalaryId = LongValue(form["suspendedFalseSalaryId"]);

            if (suspendedFalseSalaryId > 0 && !HumanResource.Salary.SuspendedFalse(model, suspendedFalseSalaryId))
                return AjaxHumanResourceState("_IndexForm", model);

            model = HumanResource.Salary.Index();
            return PartialView("_IndexForm", model);
        }
      
        public ActionResult SalariesTotal()
        {
            var model = HumanResource.Salary.Index();

            return Report(model.SalariesTotalReportModel);
        }
     
        public ActionResult SocialSecurityFund(SalaryIndexModel indexModel)
        {
            var model = HumanResource.Salary.Index();

            return Report(model.SocialSecurityFundReportModel, indexModel);
        }

        public ActionResult Tax(SalaryIndexModel indexModel)
        {
            var model = HumanResource.Salary.Index();

            return Report(model.TaxReportModel, indexModel);
        }
        //public ActionResult AdvancePayment()
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.AdvancePaymentReportModel);
        //}
        //public ActionResult SalaryForm()
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.SalaryFormReportModel);
        //}
        //public ActionResult SalaryCard(SalaryIndexModel model)
        //{
        //    return Report(model.SalaryCardReportModel);
        //}
        //public ActionResult ClipboardBanking()
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.ClipboardBankingReportModel, model.SalaryCardReportModel);
        //}
        //public ActionResult SalaryCard()
        //{
        //    var model = HumanResource.Salary.Index();

        //    return Report(model.SalaryCardReportModel);
        //}

        // GET: Salary/Spent
        public ActionResult Spent()
        {
            var model = HumanResource.Salary.Prepare();

            if (model == null)
                return HumanResourceState();

            SaveModel(model);

            return View(model);
        }

        // POST: Salary/Spent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Spent(SalaryFormModel model, string spent, string savedModel)
        {
            LoadModel(model, savedModel);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxSpent(model, spent);
        }

        public PartialViewResult AjaxSpent(SalaryFormModel model, string spent)
        {
            HumanResource.Salary.Refresh(model);

            if (spent == null)
            {
                ModelState.Clear();
                return PartialView("_FormSpent", model);
            }

            if (!ModelState.IsValid)
                return PartialView("_FormSpent", model);

            if (!HumanResource.Salary.Spent(model))
                return AjaxHumanResourceState("_FormSpent", model);

            CallRedirect();

            return PartialView("_FormSpent", model);
        }

        public ActionResult Edit(long id)






        {
            var model = HumanResource.Salary.Find(id);

            if (model == null)
                return HumanResourceState();

            model.SalaryId = id;

         
            SaveModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, SalaryFormModel model, string save, string savePremium
            , string savedModel, int? editPremiumId, int? deleteTemporaryPremiumId)
        {
            LoadModel(model, savedModel);
            model.TemporaryPremiumList.ToList().AddRange(model.NotTemporaryPremiumList.ToList());
            foreach (var row in model.TemporaryPremiumList)
            {
                foreach (var row2 in model.TemporaryPremiumList.Where(s => s.PremiumId == row.PremiumId))
                {
                    row2.ISAdvancePremmium = row.ISAdvancePremmium;
                    row2.Value = row.Value;


                }

            }
            //foreach (var row in model.NotTemporaryPremiumList)
            //{
            //    foreach (var row2 in model.NotTemporaryPremiumList.Where(s => s.PremiumId == row.PremiumId))
            //    {
            //        row2.ISAdvancePremmium = row.ISAdvancePremmium;
            //        row2.Value = row.Value;


            //    }

            //}
            foreach (var row in model.PremiumList)
            {
                foreach (var row2 in model.TemporaryPremiumList.Where(s => s.PremiumId == row.PremiumId))
                {
                    row2.ISAdvancePremmium = row.ISAdvancePremmium;
                    row2.Inspect = row.ISValueInpect;


                }
            }
            return ManageRequest(model, save, savePremium, editPremiumId, deleteTemporaryPremiumId);
        }

        private PartialViewResult ManageRequest(SalaryFormModel model, string save, string savePremium
            , int? editPremiumId, int? deleteTemporaryPremiumId)
        {
            // Save
            if (save != null)
            {
                if (!HumanResource.Salary.Edit(model))
                    return AjaxHumanResourceState("_Form", model);
                model = HumanResource.Salary.Find(model.SalaryId);
            }
            else
            {
                // SelectPremium
                if (editPremiumId != null && editPremiumId > 0)
                    return SelectPremium(model, editPremiumId.Value);

                // DeletePremium
                if (deleteTemporaryPremiumId != null && deleteTemporaryPremiumId > 0)
                    return DeletePremium(model, deleteTemporaryPremiumId.Value);

                if (savePremium != null)
                {
                    if (model.TemporaryPremium.TemporaryPremiumId == 0)
                    {
                        if (!HumanResource.Salary.CreatePremium(model))
                            return AjaxHumanResourceState("_Form", model);
                    }

                    if (model.TemporaryPremium.TemporaryPremiumId > 0)
                    {
                        if (!HumanResource.Salary.EditPremium(model))
                            return AjaxHumanResourceState("_Form", model);
                    }
                    ModelState.Clear();
                }
            }

            //CallRedirect();
            return PartialView("_Form", model);
        }

        private PartialViewResult SelectPremium(SalaryFormModel model, int temporaryPremiumId)
        {
            ModelState.Clear();
            model.TemporaryPremium.TemporaryPremiumId = temporaryPremiumId;

            if (!HumanResource.Salary.SelectPremium(model))
            {
                return AjaxHumanResourceState("_Form", model);
            }

            return PartialView("_Form", model);
        }

        private PartialViewResult DeletePremium(SalaryFormModel model, int temporaryPremiumId)
        {
            ModelState.Clear();
            model.TemporaryPremium.TemporaryPremiumId = temporaryPremiumId;

            if (!HumanResource.Salary.DeletePremium(temporaryPremiumId, model))
                return AjaxHumanResourceState("_Form", model);

            return PartialView("_Form", model);
        }

        public void LoadModel(SalaryFormModel model, string savedModel)
        {
     
            var loadedModel = LoadSavedModel<SalaryFormModel>(savedModel);

            if (loadedModel == null)
                return;
            model.Subject = loadedModel.Subject;
            model.SalaryId = loadedModel.SalaryId;
            model.TemporaryPremium.TemporaryPremiumGrid = loadedModel.TemporaryPremium.TemporaryPremiumGrid;
            model.CanSubmit = loadedModel.CanSubmit;
            model.MonthDate = loadedModel.MonthDate;
            model.BankName = loadedModel.BankName;
            model.EmployeeName = loadedModel.EmployeeName;
            model.SolidarityFund = loadedModel.SolidarityFund;
            model.Absence = loadedModel.Absence;
            //model.ExtraWork = loadedModel.ExtraWork;
            model.JihadTax = loadedModel.JihadTax;
            model.SickVacation = loadedModel.SickVacation;
            //model.ExtraWorkVacation = loadedModel.ExtraWorkVacation;
            model.EmployeeShare = loadedModel.EmployeeShare;
            model.StampTax = loadedModel.StampTax;
            model.ExemptionTax = loadedModel.ExemptionTax;
            model.NetSalary = loadedModel.NetSalary;
            model.BasicSalary = loadedModel.BasicSalary;
            model.CompanyShare = loadedModel.CompanyShare;
            model.SubjectSalary = loadedModel.SubjectSalary;
            model.TotalSalary = loadedModel.TotalSalary;
            model.IncomeTax = loadedModel.IncomeTax;
            model.BankBranchName = loadedModel.BankBranchName;
            //model.AbsenceDays = loadedModel.AbsenceDays;
            model.EmployeeId = loadedModel.EmployeeId;
            model.BankBranchId = loadedModel.BankBranchId;
            model.BankId = loadedModel.BankId;
            model.BoundNumber = loadedModel.BoundNumber;
            model.Date = loadedModel.Date;
            //model.ExtraWorkHoures = loadedModel.ExtraWorkHoures;
            //model.ExtraWorkVacationHoures = loadedModel.ExtraWorkVacationHoures;
            model.FinalSalary = loadedModel.FinalSalary;
            model.JobNumber = loadedModel.JobNumber;
            model.SalaryPremiumList = loadedModel.SalaryPremiumList.Select(s => new SalaryPremiumListItem()
            {
                PremiumId = s.PremiumId,
                Value = model.PremiumList.Any(p => p.PremiumId == s.PremiumId && p.IsTemporary==IsTemporary.IsTemporary)
                 ? model.SalaryPremiumList.FirstOrDefault(p => p.PremiumId == s.PremiumId)?.Value ?? 0
                 : s.Value
            }).ToList();
            //model.TemporaryPremiumList = loadedModel.TemporaryPremiumList;
            //model.AccumulatedValue = loadedModel.AccumulatedValue;
            //model.RewindValue = loadedModel.RewindValue;
            //model.TemporaryPremiumList = loadedModel.TemporaryPremiumList.Select(s => new TemSalaryPremiumListItem()
            //{
            //    PremiumId = s.PremiumId,
            //    Value = model.TemporaryPremiumList.Any(p => p.PremiumId == s.PremiumId)
            //        ? model.TemporaryPremiumList.FirstOrDefault(p => p.PremiumId == s.PremiumId)?.Value ?? 0
            //        : s.Value
            //}).ToList();
        }
        public void LoadModel(SalaryIndexModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<SalaryIndexModel>(savedModel);

            if (loadedModel == null)
                return;

            model.SalaryGrid = loadedModel.SalaryGrid;
            //model.SalaryGrid = loadedModel.SalaryGrid.Select(r => new SalaryGridRow()
            //{
            //    SuspendedNote = model.SalaryGrid.FirstOrDefault(m => m.SalaryId == r.SalaryId)?.SuspendedNote,
            //    SalaryId = r.SalaryId,
            //    JobNumber = r.JobNumber,
            //    BasicSalary = r.BasicSalary,
            //    EmployeeName = r.EmployeeName,
            //    FinalSalary = r.FinalSalary,
            //    IsSuspended = r.IsSuspended,
            //    TotalSalary = r.TotalSalary,
            //}).ToList();
            model.CanEdit = loadedModel.CanEdit;
            model.CanSpent = loadedModel.CanSpent;
            model.CanSuspended = loadedModel.CanSuspended;
            model.CanClose = loadedModel.CanClose;
            model.CanUpdate = loadedModel.CanUpdate;
            model.AdvancePaymentReportModel = loadedModel.AdvancePaymentReportModel;
            model.SocialSecurityFundReportModel = loadedModel.SocialSecurityFundReportModel;
            model.SolidarityFundReportModel = loadedModel.SolidarityFundReportModel;
            model.TaxReportModel = loadedModel.TaxReportModel;
            model.SalaryFormReportModel = loadedModel.SalaryFormReportModel;
            model.ClipboardBankingReportModel = loadedModel.ClipboardBankingReportModel;
            model.SalaryCardReportModel = loadedModel.SalaryCardReportModel;
            model.BankList = loadedModel.BankList;
        }
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

        public ActionResult Report(TaxReportModel model, SalaryIndexModel indexModel)
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
                var tax = Math.Round(
                    model.Grid.Where(r => r.CostCenterId == row.CostCenterId).Sum(r => r.IncomeTax), 3,
                    MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model.Grid.Where(r => r.CostCenterId == row.CostCenterId)
                                .Sum(r => r.JihadTax), 3, MidpointRounding.AwayFromZero)
                        + Math.Round(
                            model.Grid.Where(r => r.CostCenterId == row.CostCenterId)
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

            ReportDataSource rdc = new ReportDataSource("TaxReport", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Title", "كشف الضرائب"));
            reportParameters.Add(new ReportParameter("BondNumber", indexModel.TaxBondNumber));
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
        public ActionResult Report(SocialSecurityFundReportModel model, SalaryIndexModel indexModel)
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
            reportParameters.Add(new ReportParameter("BondNumber", indexModel.SocialSecurityFundBondNumber));
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
                    AdvancePremium = row.AdvancePaymentInside,//////////////////////////
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
        public ActionResult Report(SalariesTotalReportModel model)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "SalariesTotalReport.rdlc");
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

            var datasources = new HashSet<SalariesTotalReport>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new SalariesTotalReport()
                {
                    SolidarityFund = row.SolidarityFund,
                    JihadTax = row.JihadTax,
                    StampTax = row.StampTax,
                    ContributionInSecurity = row.ContributionInSecurity,
                    SocialSecurityFund = row.SocialSecurityFund,
                    SafeShareSocialSecurity = row.SafeShareSocialSecurity,
                    CompanyShareSocialSecurity = row.CompanyShareSocialSecurity,
                    DeducationTotal = row.DeducationTotal,
                    MawadaFund = row.MawadaFund,
                    SalariesNumber = row.SalariesNumber,
                    SalariesTotal = row.SalariesTotal,
                    SalariesNet = row.SalariesNet,
                    BasicSalaries = row.BasicSalaries
                });
            }

            ReportDataSource rdc = new ReportDataSource("SalariesTotal", datasources);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter1", "وزارة الدفاع جهاز البحوث التطبيقية والبحوث"));
            reportParameters.Add(new ReportParameter("ReportParameter2", "اجماليات المرتبات المدفوعة"));
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
                    FinalySalary = row.FinalSalary,
                    PrepaidPremium = row.PrepaidSalary,


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
        public ActionResult Report(SalaryCardReportModel model)
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

            if (!HumanResource.Salary.View(model))
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
        public ActionResult Report(ClipboardBankingReportModel model, SalaryCardReportModel smodel)
        {
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

            //-----
            //List<string> lst = new List<string>();
            //lst.Add("ClipboardBankingReport.rdlc");
            //lst.Add("SalaryCardReport.rpt");
            //string reportpath = "";
            //foreach (string rpt in lst)
            //{
            //    // Refresh  report viewer
            //    reportpath = Path.Combine(Server.MapPath("~/Reports"), rpt);
            //    lr.ReportEmbeddedResource = reportpath;



            //}

            //------


            if (!HumanResource.Salary.View(model))
                return AjaxHumanResourceState("_Form", model);

            var datasources = new HashSet<ClipboardBanking>();

            foreach (var row in model.Grid)
            {
                datasources.Add(new ClipboardBanking()
                {
                    JobNumber = row.JobNumber,
                    BondNumber = row.BondNumber,
                    EmployeeName = row.EmployeeName,
                    BankBranchId = row.BankBranchId,
                    BankBranchName = row.BankBranchName,
                    FinalySalary = row.FinalySalary,
                    NationalNumber = row.NationalNumber,
                    Tafkeet = new Maths.NumberToWord(Math.Round(model.Grid.Where(r => r.BankBranchId == row.BankBranchId).Sum(r => r.FinalySalary), 3, MidpointRounding.AwayFromZero)).ConvertToArabic()

                });
            }

            ReportDataSource rdc = new ReportDataSource("ClipboardBanking", datasources);
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

            //------------------------
            //    LocalReport lr2 = new LocalReport();

            //    path = Path.Combine(Server.MapPath("~/Reports"), "SalaryCardReport.rdlc");


            //    if (System.IO.File.Exists(path))
            //    {
            //        lr2.ReportPath = path;
            //        lr2.ReportEmbeddedResource = path;
            //    }
            //    else
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }

            //    if (!HumanResource.Salary.View(smodel))
            //        return AjaxHumanResourceState("_Form", model);

            //    var datasources1 = new HashSet<SalaryCard>();

            //    foreach (var row in smodel.Grid)
            //    {
            //        datasources1.Add(new SalaryCard()
            //        {
            //            JobNumber = row.JobNumber,
            //            Name = row.Name,
            //            BasicSalary = row.BasicSalary,
            //            Absence = row.Absence,
            //            CompanyShare = row.CompanyShare,
            //            EmployeeShare = row.EmployeeShare,
            //            ExemptionTax = row.ExemptionTax,
            //            ExtraWork = row.ExtraWork,
            //            ExtraWorkVacation = row.ExtraWorkVacation,
            //            IncomeTax = row.IncomeTax,
            //            JihadTax = row.JihadTax,
            //            NetSalary = row.NetSalary,
            //            //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
            //            Sanction = row.Sanction,
            //            SickVacation = row.SickVacation,
            //            SolidarityFund = row.SolidarityFund,
            //            StampTax = row.StampTax,
            //            SubjectSalary = row.SubjectSalary,
            //            TotalSalary = row.TotalSalary,
            //            WithoutPay = row.WithoutPay,
            //            BondNumber = row.BondNumber,
            //            BankName = row.BankName,
            //            EmployeeName = row.EmployeeName,
            //            ExtraWorkFixed = row.ExtraWorkFixed,
            //            BankBranchName = row.BankBranchName,
            //            //PrepaidSalaryAndAdvancePremium = ,
            //            //SituationOnTotal = ,
            //            BounName = row.BounName,
            //            BounValue = row.BounValue,
            //            FinancialNumber = row.FinancialNumber,
            //            GuaranteeType = row.GuaranteeType,
            //            SecurityNumber = row.SecurityNumber,
            //            //EmployeeId = row.em


            //        });
            //    }

            //    ReportDataSource rdc1 = new ReportDataSource("SalaryCard", datasources1);
            //    ReportParameterCollection reportParameters1 = new ReportParameterCollection();
            //    reportParameters1.Add(new ReportParameter("Title", "بطاقة المرتب"));
            //    reportParameters1.Add(new ReportParameter("Date", model.Year + "-" + model.Month));
            //    lr2.SetParameters(reportParameters1);
            //    lr2.DataSources.Add(rdc1);


            //    //------------------------
            //    string mimeType2;
            //    string encoding2;
            //    string filenameextention2;
            //    string deviceinfo2 =
            //        "<DeviceInfo>" +
            //        "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
            //        "</DeviceInfo>";
            //    Warning[] warnings2;
            //    string[] stream2;
            //    byte[] renderedBytes2;
            //    renderedBytes2 = lr2.Render(
            //        "PDF",
            //        deviceinfo2,
            //        out mimeType2,
            //        out encoding2,
            //        out filenameextention2,
            //        out stream2,
            //        out warnings2);

            //    var rd = renderedBytes.ToList();
            //    rd.AddRange(renderedBytes2);

            //    return File(rd.ToArray(), mimeType + mimeType2);
        }

        //public ActionResult SalaryFormReport(SalaryFormReportModel model)
        //{
        //    var other = new Others.SalaryFormReport(HumanResource);

        //    var lrs = other.Report(model, Path.Combine(Server.MapPath("~/Reports"), "SalaryFormReport.rdlc"));

        //    if (lrs == null)
        //        return AjaxHumanResourceState("_Form", model);

        //    string mimeType;
        //    string encoding;
        //    string filenameextention;
        //    string deviceinfo =
        //        "<DeviceInfo>" +
        //        "<OutPutFormat>" + "PDF" + "</OutPutFormat>" +
        //        "</DeviceInfo>";
        //    Warning[] warnings;
        //    string[] stream;
        //    var renderedBytes = lrs.Render(
        //        "PDF",
        //        deviceinfo,
        //        out mimeType,
        //        out encoding,
        //        out filenameextention,
        //        out stream,
        //        out warnings);

        //    return File(renderedBytes, mimeType);
        //}
    }
}