using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Models;
using Almotkaml.HR.Others.linqq;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Others
{
    public class SalaryFormReport
    {
        private readonly IHumanResource _humanResource;

        public SalaryFormReport(IHumanResource humanResource)
        {
            _humanResource = humanResource;
        }
        public LocalReport Report(SalaryFormReportModel model, string path)
        {
            if (model.DivisionId == null)
            {
                model.DivisionId = 0;
            }

            if (model.JobId == null)
            {
                model.JobId = 0;
            }


            if (!_humanResource.Salary.View(model))
                return null;

            var db = new DataClasses1DataContext(_humanResource.StartUp.AppConfig.ConnectionString);

            var employeeIds = db.serch_reprt_withe_division1(model.DivisionId, model.JobId)
                .Select(r => r.EmployeeId)
                .ToList();

            var getAllFactDetails1 = new HashSet<serch_reprt_withe_division1Result>();

            foreach (var row1 in model.Grid.Where(r => employeeIds.Contains(r.EmployeeId)))
            {
                getAllFactDetails1.Add(new serch_reprt_withe_division1Result()
                {
                    JobNumber = row1.JobNumber,
                    Name = row1.Name,
                    BasicSalary = row1.BasicSalary,
                    AbsenceDays = row1.Absence,
                    CompanyShare = row1.CompanyShare,
                    EmployeeShare = row1.EmployeeShare,
                    ExemptionTax = row1.ExemptionTax,
                    Extrawork = row1.ExtraWork,
                    ExtraWorkHoures = row1.ExtraWorkConst,
                    ExtraWorkVacationHoures = row1.ExtraWorkVacation,
                    IncomeTax = row1.IncomeTax,
                    JihadTax = row1.JihadTax,
                    NetSalary = row1.NetSalary,
                    Sanction = row1.Sanction,
                    SickVaction = row1.SickVacation,
                    SituationOnNet = row1.SituationOnNet,
                    SituationOnTotal = row1.SituationOnTotal,
                    SolidarityFund = row1.SolidarityFund,
                    StampTax = row1.StampTax,
                    SubjectSalary = row1.SubjectSalary,
                    TotalSalary = row1.TotalSalary,
                    WithoutPay = row1.WithoutPay,

                    EmployeeStat = row1.EmployeeStat,
                    AdvancePremiumInside = row1.AdvancePremiumInside,
                    AdvancePremiumOutside = row1.AdvancePremiumOutside,
                    FinalySalary = row1.FinalSalary,
                    PrepaidPremium = row1.PrepaidSalary
                });
            }

            var lrs = new LocalReport();
            if (System.IO.File.Exists(path))
            {
                lrs.ReportPath = path;
            }
            else
            {
                return null;
            }

            var reportParameters = new ReportParameterCollection();
            var reportViewer = new ReportViewer();

            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource rdc1 = new ReportDataSource("SalaryForm", getAllFactDetails1);
            reportViewer.LocalReport.DataSources.Add(rdc1);
            reportParameters.Add(new ReportParameter("Title", "استمارة المرتبات"));
            reportParameters.Add(new ReportParameter("Date", model.Year + "-" + model.Month));


            lrs.SetParameters(reportParameters);

            lrs.DataSources.Add(rdc1);

            return lrs;
        }
    }
}
