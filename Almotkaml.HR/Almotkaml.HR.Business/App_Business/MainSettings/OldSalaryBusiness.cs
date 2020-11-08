using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class OldSalaryBusiness : Business, IOldSalaryBusiness
    {
        public OldSalaryBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Salary_OldSalary && permission;

        public SalaryIndexModel Index()
        {
            if (!HavePermission())
                return Null<SalaryIndexModel>(RequestState.NoPermission);
            var salaryLast = UnitOfWork.Salaries.GetLastClosedSalary();
            var year = salaryLast?.MonthDate.Year;
            var month = salaryLast?.MonthDate.Month;

            var grid = UnitOfWork.Salaries.GetClosedSalaryByMonth(year ?? 0, month ?? 0).ToGrid(Settings).ToList();

            return new SalaryIndexModel()
            {
                SalaryGrid = grid,
                Year = year,
                Month = month,


            };
        }

        public SalaryIndexModel Index(SalaryIndexModel model)
        {
            model.SalaryGrid =
               UnitOfWork.Salaries.GetClosedSalaryByMonth(model.Year ?? 0, model.Month ?? 0).ToGrid(Settings).ToList();
            model.AdvancePaymentReportModel = new AdvancePaymentReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
            };
            model.SocialSecurityFundReportModel = new SocialSecurityFundReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
            };
            model.SolidarityFundReportModel = new SolidarityFundReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
            };
            model.TaxReportModel = new TaxReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
            };
            model.SalaryFormReportModel = new SalaryFormReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
                DivisionList = UnitOfWork.Divisions.GetAll().ToList(),
                JobList = UnitOfWork.Jobs.GetAll().ToList()
            };
            model.SalaryCardReportModel = new SalaryCardReportModel()
            {
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,
                EmployeeList = UnitOfWork.Employees.GetAll().ToEmployeeList()
            };
            return model;
        }

        public SalaryFormModel Find(long id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_OldSalary))
                return Null<SalaryFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<SalaryFormModel>(RequestState.BadRequest);

            var salary = UnitOfWork.Salaries.Find(id);

            if (salary == null)
                return Null<SalaryFormModel>(RequestState.NotFound);

            return new SalaryFormModel()
            {
                SalaryId = id,
                JobNumber = salary.JobNumber,
                AbsenceDays = salary.AbsenceDays,
                //AdvancePremium = salary.AdvancePremium,
                BankBranchId = salary.BankBranchId,
                BankBranchName = salary.BankBranch?.Name,
                BasicSalary = salary.BasicSalary,
                BoundNumber = salary.BondNumber,
                CompanyShare = salary.CompanyShare(Settings),
                Date = salary.Date.FormatToString(),
                EmployeeId = salary.EmployeeId,
                EmployeeName = salary.Employee?.GetFullName(),
                EmployeeShare = salary.EmployeeShare(Settings),
                ExemptionTax = salary.ExemptionTax(Settings),
                ExtraWorkHoures = salary.ExtraWorkHoures,
                ExtraWorkVacationHoures = salary.ExtraWorkVacationHoures,
                IncomeTax = salary.IncomeTax(Settings),
                JihadTax = salary.JihadTax(Settings),
                Month = salary.Month,
                MonthDate = salary.MonthDate.ToString(),
                NetSalary = salary.NetSalary(Settings),
                PrepaidSalary = salary.PrepaidSalary,
                Sanction = salary.Sanction,
                SickVacation = salary.SickVacation(Settings),
                SolidarityFund = salary.SolidarityFund(Settings),
                StampTax = salary.StampTax(Settings),
                SubjectSalary = salary.SubjectSalary(Settings),
                FinalSalary = salary.FinalSalary(Settings),
                TotalSalary = salary.TotalSalary(Settings),
                Absence = salary.Absence(),
                ExtraWork = salary.ExtraWork(Settings),
                ExtraWorkVacation = salary.ExtraWorkVacation(Settings),
                SalaryPremiumList = UnitOfWork.Salaries.GetSalaryPremiumBy(salary.SalaryId).ToList(),
             //   PremiumList = UnitOfWork.Premiums.GetAll().ToList(),
                TemporaryPremium = new TemporaryPremiumModel()
                {
                    TemporaryPremiumGrid = UnitOfWork.Salaries.GetTemporaryPremium(salary.SalaryId).ToGrid()
                },
                CanSubmit = ApplicationUser.Permissions.Salary_OldSalary,
                SalaryCardReportModel = new SalaryCardReportModel()
                {
                    Month = salary.MonthDate.Month,
                    Year = salary.MonthDate.Year
                }
            };
        }

        public SalaryFormModel Report(SalaryFormModel model)
        {
            DateTime date = Convert.ToDateTime(model.MonthDate);
            model.SalaryCardReportModel = new SalaryCardReportModel()
            {
                Year = date.Year,

                Month = date.Month
            };
            return model;
        }


        public bool View(AdvancePaymentReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<AdvancePaymentReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new AdvancePaymentReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    PrepaidSalary = salary.PrepaidSalary,
                    AdvancePaymentInside = salary.AdvancePremiumInside,//////////////////
                    AdvancePaymentOutside = salary.AdvancePremiumOutside,//////////////////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SocialSecurityFundReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SocialSecurityFundReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SocialSecurityFundReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CompanyShare = salary.CompanyShare(Settings),
                    EmployeeShare = salary.EmployeeShare(Settings),
                    GuaranteeType = salary.Employee?.SalaryInfo?.GuaranteeType ?? 0,
                    TotalSalary = salary.TotalSalary(Settings),
                    ShareSum = salary.EmployeeShare(Settings) + salary.CompanyShare(Settings),
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,

                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SolidarityFundReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SolidarityFundReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SolidarityFundReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    TotalSalary = salary.TotalSalary(Settings),
                    SolidarityFund = salary.SolidarityFund(Settings),//////////////////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(TaxReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<TaxReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new TaxReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    TotalSalary = salary.TotalSalary(Settings),
                    ExemptionTax = salary.ExemptionTax(Settings),
                    IncomeTax = salary.IncomeTax(Settings),
                    JihadTax = salary.JihadTax(Settings),
                    NetSalary = salary.NetSalary(Settings),
                    StampTax = salary.StampTax(Settings),
                    SubjectSalary = salary.SubjectSalary(Settings),
                    TaxSum = salary.IncomeTax(Settings) + salary.JihadTax(Settings),///////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SalaryFormReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SalaryFormReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SalaryFormReportGridRow()
                {
                    Name = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    TotalSalary = salary.TotalSalary(Settings),
                    ExemptionTax = salary.ExemptionTax(Settings),
                    IncomeTax = salary.IncomeTax(Settings),
                    JihadTax = salary.JihadTax(Settings),
                    NetSalary = salary.NetSalary(Settings),
                    StampTax = salary.StampTax(Settings),
                    SubjectSalary = salary.SubjectSalary(Settings),
                    BasicSalary = salary.BasicSalary,
                    Absence = salary.Absence(),
                    CompanyShare = salary.CompanyShare(Settings),
                    EmployeeShare = salary.EmployeeShare(Settings),
                    ExtraWork = salary.ExtraWork(Settings),
                    ExtraValue = salary.ExtraValue,
                    ExtraGeneralValue = salary.ExtraGeneralValue,
                    ExtraWorkVacation = salary.ExtraWorkVacation(Settings),
                    //PrepaidSalaryAndAdvancePremium = salary.PrepaidSalary + salary.AdvancePremium,
                    Sanction = salary.Sanction,//////////
                    SickVacation = salary.SickVacation(Settings),
                    SituationOnNet = salary.SalaryPremiums.Where(p => p.Premium.IsSubject == IsSubject.IsNotSubject).Sum(p => p.Value),///////////
                    SituationOnTotal = salary.SalaryPremiums.Where(p => p.Premium.IsSubject==IsSubject.IsSubject).Sum(p => p.Value),//////////
                    SolidarityFund = salary.SolidarityFund(Settings),
                    FinalSalary = salary.FinalSalary(Settings),
                    AdvancePremiumInside = salary.AdvancePremiumInside,
                    AdvancePremiumOutside = salary.AdvancePremiumOutside,
                    PrepaidSalary = salary.PrepaidSalary,
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                    EmployeeStat = salary.IsSuspended ? 1 : 0
                    //WithoutPay =/////////////
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SalaryCardReportModel model, int id)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByEmployeeAndMonth(model.Year, model.Month, id).ToList();

            if (salaries == null)
                return false;

            var grid = new HashSet<SalaryCardReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new SalaryCardReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    BondNumber = salary.BondNumber,
                    BasicSalary = salary.BasicSalary,
                    SolidarityFund = salary.SolidarityFund(Settings),
                    ExtraValue = salary.ExtraValue,
                    ExtraGeneralValue = salary.ExtraGeneralValue,
                    TotalSalary = salary.TotalSalary(Settings),
                    CompanyShare = salary.CompanyShare(Settings),
                    EmployeeShare = salary.EmployeeShare(Settings),
                    ExtraWork = salary.ExtraWork(Settings),
                    Sanction = salary.Sanction,
                    ExtraWorkVacation = salary.ExtraWorkVacation(Settings),
                    AdvancePremiumOutside = salary.AdvancePremiumOutside,
                    AdvancePremiumInside = salary.AdvancePremiumInside,
                    PrepaidSalary = salary.PrepaidSalary,
                    //WithoutPay = salary.w,
                    Absence = salary.Absence(),
                    SickVacation = salary.SickVacation(Settings),
                    BankBranchName = salary.BankBranch?.Name,
                    //BounName = salary.,
                    //BounValue = salary.,
                    ExemptionTax = salary.ExemptionTax(Settings),
                    FinancialNumber = salary.Employee?.SalaryInfo?.FinancialNumber,
                    GuaranteeType = salary.Employee?.SalaryInfo?.GuaranteeType ?? 0,
                    IncomeTax = salary.IncomeTax(Settings),
                    JihadTax = salary.JihadTax(Settings),
                    NetSalary = salary.NetSalary(Settings),
                    SecurityNumber = salary.Employee?.SalaryInfo?.SecurityNumber,
                    StampTax = salary.StampTax(Settings),
                    SubjectSalary = salary.SubjectSalary(Settings),
                    SalaryPremiumList = UnitOfWork.Salaries.GetSalaryPremiumBy(salary.SalaryId).ToList(),
                  //  PremiumList = UnitOfWork.Premiums.GetAll().ToList(),
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.CenterId ?? 0,
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }



        public bool View(ClipboardBankingReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<ClipboardBankingReportGridRow>();

            foreach (var salary in salaries.Where(s => s.IsSuspended == false))
            {
                var row = new ClipboardBankingReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    BankBranchId = salary.BankBranchId,
                    BankBranchName = salary.BankBranch?.Bank?.Name + " " + salary.BankBranch?.Name,
                    BondNumber = salary.BondNumber,
                    FinalySalary = salary.FinalSalary(Settings),
                    NationalNumber = salary.Employee?.NationalNumber
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}