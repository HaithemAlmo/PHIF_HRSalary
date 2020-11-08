using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SalaryBusiness : Business, ISalaryBusiness
    {
        public SalaryBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Salary && permission;

        public SalaryIndexModel ClipordIndex(SalaryIndexModel model)
        {
            var salary = UnitOfWork.Salaries.GetOpenedSalary().ToList();
            return new SalaryIndexModel()
            {
                //MonthList = salary.Select(y => y.MonthDate.Month),
                //YearList = salary.Select(y => y.MonthDate.Year),
                //BankList = UnitOfWork.Banks.GetAll().ToList(),


            };
        }

        public SalaryIndexModel Index()
        {
            if (!HavePermission())
                return Null<SalaryIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid(Settings).ToList();

            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            // add by ali alherbade 09-07-2019 
            //قيمة صافي كل المرتبات
            decimal sumFinalSalary = grid.Select(s => s.FinalSalary).Sum();
            string sumFinalSalaryString = string.Format("{0:#,#.00}", sumFinalSalary);


            //مجموع الخصميات
            var sumTotalDiscount = grid.Select(s => s.TotalDiscount).Sum();
            string sumTotalDiscountString = string.Format("{0:#,#.00}", sumTotalDiscount);

            //مجموع اجمالي المرتبات
            var sumTotalSalary = grid.Select(s => s.TotalSalary).Sum();
            string sumTotalSalaryString = string.Format("{0:#,#.00}", sumTotalSalary);
            //
            DateTime monthDate;
            monthDate = salaryLast?.MonthDate ?? Settings.Date;

            return new SalaryIndexModel()
            {
                
                SalaryGrid = grid,
                // add by ali alherbade 09-07-2019
                SumFinalSalary = sumFinalSalaryString,
                SumTotalDiscount = sumTotalDiscountString,
                SumTotalSalary = sumTotalSalaryString,
                //
                MonthDate = monthDate.FormatToString(),
                // add by ali alherbade 09-07-2019
                totalGridRow = new TotalGrid() {
                    
                },
                AdvancePaymentReportModel = new AdvancePaymentReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year
                },
                SocialSecurityFundReportModel = new SocialSecurityFundReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year
                },
                SolidarityFundReportModel = new SolidarityFundReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year
                },
                TaxReportModel = new TaxReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year
                },
                SalaryFormReportModel = new SalaryFormReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year,
                    JobList = UnitOfWork.Jobs.GetAll().ToList(),
                    DivisionList = UnitOfWork.Divisions.GetAll().ToList()
                },
                SalaryCardReportModel = new SalaryCardReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year
                },
                ClipboardBankingReportModel = new ClipboardBankingReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year,
                    BankList = UnitOfWork.Banks.GetAll().ToList(),
                },
                SalariesTotalReportModel = new SalariesTotalReportModel()
                {
                    Month = monthDate.Month,
                    Year = monthDate.Year,
                },
                SocialSecurityFundBondNumber = salaryLast?.SocialSecurityFundBondNumber,
                SolidarityFundBondNumber = salaryLast?.SolidarityFundBondNumber,
                TaxBondNumber = salaryLast?.TaxBondNumber,
                CanSpent = ApplicationUser.Permissions.Salary_Spent,
                CanEdit = ApplicationUser.Permissions.Salary_Edit,
                CanSuspended = ApplicationUser.Permissions.Salary_Suspend,
                CanClose = ApplicationUser.Permissions.Salary_Close,
                CanUpdate = ApplicationUser.Permissions.Salary_Update,
                CanFreeze = ApplicationUser.Permissions.Salary_Freeze,
                CanAllow = ApplicationUser.Permissions.Salary_Allow,
                AdvancePremiumFreezeState= UnitOfWork.Salaries.AdvancePremiumFreeze1()
            };
        }

        public bool AdvancePremiumFreeze(bool IsActive)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Allow))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            foreach (var salary in salaries)
            {
                salary.Employee.SalaryInfo.AdvancePremiumFreeze(IsActive);
            }
            if (IsActive)
                UnitOfWork.Complete(n => n.AdvancePremium_FreezeState);
            else
                UnitOfWork.Complete(n => n.DEAdvancePremium_FreezeState);
            return true;
        }


        public bool Create(SalaryFormModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            var salary = Salary.New()
                .WithMonthDate(model.MonthDate.ToDateTime())
                .WithEmployee(model.EmployeeId)
                .WithJobNumber(model.JobNumber)
                .WithAbsenceDays(model.AbsenceDays)
                .WithExtraValue(model.ExtraValue)
                .WithExtraGeneralValue(model.ExtraGeneralValue)
                .WithBankBranch(model.BankBranchId)
                .WithBondNumber(model.BoundNumber)
                .WithFileNumber(model.FileNumber)
                .WithBasicSalary(model.BasicSalary)
                .WithAdvancePremiumInside(model.AdvancePremiumInside)
                .WithAdvancePremiumOutside(model.AdvancePremiumOutside)
                .WithSanction(model.Sanction)
                .WithAccumulatedValue(model.AccumulatedValue)
                .WithRewindValue(model.RewindValue)
                .WithSalaryPremium(employee)
                .Biuld();

            UnitOfWork.Salaries.Add(salary);

            UnitOfWork.Complete(n => n.Salary_Close);

            return SuccessCreate();

        }

        public SalaryFormModel Find(long id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Null<SalaryFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<SalaryFormModel>(RequestState.BadRequest);

            var salary = UnitOfWork.Salaries.Find(id);
            var employee = UnitOfWork.Employees.Find(salary.EmployeeId);

            
var salaryLast = UnitOfWork.Salaries.GetLastSalary();
            if (salary == null)
                return Null<SalaryFormModel>(RequestState.NotFound);


            return new SalaryFormModel()
            {

                SafeShare = salary.SafeShare(Settings),
                // SafeShareReduced= salary.SafeShare(Settings),
                TotalDiscount = salary.TotalDiscount(Settings),
                SalaryId = id,
                JobNumber = salary.JobNumber,
                // AbsenceDays = salary.AbsenceDayEmployee(salaryLast.MonthDate),
                AdvancePremiumInside = salary.InstallmentValueAdvancePremiumInside(),// salary.AdvancePremiumInside,//UnitOfWork.AdvancePayments.GetAll().Where(p => p.Premium.IsSubject == false && p.Premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance).Sum(p => p.Value),
                AdvancePremiumOutside = salary.InstallmentValueAdvancePremiumOutside(),//salary.AdvancePremiumOutside,
                BankBranchId = salary.BankBranchId,
                BankBranchName = salary.BankBranch?.Name,
                BankId = salary.BankBranch?.BankId ?? 0,
                BankName = salary.BankBranch?.Bank?.Name,
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
                GroupLife = salary.Grouplife(Settings),
                Month = salary.Month,
                NetSalary = salary.NetSalary(Settings),
                PrepaidSalary = salary.PrepaidSalary,
                Sanction = salary.Sanction1(),
                SickVacation = salary.SickVacation(Settings),
                SickLeave = salary.SickLeave(Settings),
                SolidarityFund = salary.SolidarityFund(Settings),
                StampTax = salary.StampTax(Settings),
                SubjectSalary = salary.SubjectSalary1(Settings),
                Subject = salary.Subject(Settings),
                FinalSalary = salary.FinalSalary(Settings),
                TotalSalary = salary.TotalSalary(Settings),
                Absence = salary.Absence(),
                ExtraWork = salary.ExtraWork(Settings),
                ExtraWorkVacation = salary.ExtraWorkVacation(Settings),
                MonthDate = salary.MonthDate.FormatToString(),
                ExtraValue = salary.ExtraValue,
                ExtraGeneralValue = salary.ExtraGeneralValue,
                AccumulatedValue = salary.accumulatedValue(),
                RewindValue = salary.rewindValue(),
                Tadawl = salary.Tadawel(),
                TemporaryPremiumList = UnitOfWork.Salaries.GetTemSalaryPremiumBy(salary.SalaryId).ToTemList().ToList(),
                SalaryPremiumList = UnitOfWork.Salaries.GetSalaryPremiumBy(salary.SalaryId).ToList().ToList(),
                SalaryAdvancPremiumList = UnitOfWork.Salaries.GetSalaryAdvanceBy(employee?.EmployeeId??0).ToSalartAdvanseList(),
                TemporaryList = UnitOfWork.Premiums.GetAll().Where(d => d.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance &&d.IsTemporary==IsTemporary.IsTemporary).ToTemList().ToList(),
                NotTemporaryList = UnitOfWork.Premiums.GetAll().Where(d => d.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance && d.IsTemporary == IsTemporary.IsNotTemporary).ToTemList().ToList(),

                AdvanseListItem = UnitOfWork.Premiums.GetAll().Where(s => s.ISAdvancePremmium == ISAdvancePremmium.ISAdvance).ToListAdvance(),
                NotTemporaryPremiumList = UnitOfWork.Employees.GetTemEmployeePremiumBy(salary.EmployeeId).ToTemList().ToList(),
                NotTemporaryPremiumList1 = UnitOfWork.Employees.GetTemEmployeePremiumBy(salary.EmployeeId).ToTemList1().ToList(),
                //SalaryPremiumList = UnitOfWork.Salaries.GetSalaryPremiumBy(salary.SalaryId).ToList(),
                PremiumList = UnitOfWork.Premiums.GetAll().ToList(),
                TemporaryPremium = new TemporaryPremiumModel()
                {
                    TemporaryPremiumGrid = UnitOfWork.Salaries.GetTemporaryPremium(salary.SalaryId).ToGrid()
                },
                CanSubmit = ApplicationUser.Permissions.Salary_Edit,
            };
        }

        public SalaryFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Spent))
                return Null<SalaryFormModel>(RequestState.NoPermission);

            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            DateTime monthDate;
            monthDate = salaryLast?.MonthDate.AddMonths(1) ?? Settings.Date;

            return new SalaryFormModel()
            {
                MonthDate = monthDate.FormatToString(),
            };
        }
        public string GetMonthDate()
        {
            //if (!HavePermission(ApplicationUser.Permissions.Salary_Spent))
            //    return Null<SalaryFormModel>(RequestState.NoPermission);

            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            DateTime monthDate;
            monthDate = salaryLast?.MonthDate ?? Settings.Date;


            return monthDate.FormatToString();
        }

        public bool Spent(SalaryFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Spent))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employees = UnitOfWork.Employees.GetAll();

            if (employees == null)
                return false;

            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            if (salaryLast != null && !salaryLast.IsClose)
                return false;

            DateTime monthDate;
            monthDate = salaryLast?.MonthDate.AddMonths(1) ?? Settings.Date;

            var holiday = UnitOfWork.Holidays.GetAll().ToList();

            var salaryUnits = UnitOfWork.SalaryUnits.GetAll().ToList();
            var salaryISsubsended = UnitOfWork.Salaries.GetAll().Where(s=>s.IsSuspended==true).ToList();


            DateTime monthDate2;
            monthDate2 = salaryLast?.MonthDate ?? Settings.Date;
            foreach (var employee in employees)
            {
                employee.SalaryInfo?.GetSalary(monthDate, monthDate2, model.Date.ToDateTime(),  holiday, salaryISsubsended, Settings
                       , salaryUnits.Where(s => s.SalayClassification == employee.JobInfo.SalayClassification).ToList());
            }

            UnitOfWork.Complete(n => n.Salary_Spent);

            return SuccessCreate();
        }
        //private bool Spent()
        //{
        //    var employees = UnitOfWork.Employees.GetAll();

        //    if (employees == null)
        //        return false;

        //    var salaryLast = UnitOfWork.Salaries.GetLastSalary();

        //    if (salaryLast != null && !salaryLast.IsClose)
        //        return false;

        //    DateTime monthDate;
        //    monthDate = salaryLast?.MonthDate.AddMonths(1) ?? Settings.Date;

        //    var holiday = UnitOfWork.Holidays.GetAll().ToList();
        //    var salary = UnitOfWork.Salaries.GetAll().ToList();

        //    foreach (var employee in employees)
        //    {
        //        employee.SalaryInfo?.GetSalary(monthDate, DateTime.Now, holiday, Settings);
        //    }

        //    return true;
        //}

        public bool Update(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Update))
                return Fail(RequestState.NoPermission);

            //if (!salaries.Any())
            //    return false;

            var salaries = UnitOfWork.Salaries.GetOpenedSalary().ToList();
            var monthDate = salaries?.FirstOrDefault()?.MonthDate!= null ? salaries.FirstOrDefault().MonthDate : Settings.Date;

            var employees = UnitOfWork.Employees.GetEmployeeWithoutSaraies(monthDate).ToList();

            if (!employees.Any() && !salaries.Any())
                return false;

            var holiday = UnitOfWork.Holidays.GetAll().ToList();
            var salaryUnits = UnitOfWork.SalaryUnits.GetAll().ToList();
            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            DateTime monthDate2;
            monthDate2 = salaryLast?.MonthDate ?? Settings.Date;
            foreach (var salary in salaries)
            {
                salary.Update(holiday, employees, Settings
                     , salaryUnits.ToList());

            }
            var salaryISsubsended = UnitOfWork.Salaries.GetAll().Where(s => s.IsSuspended == true).ToList();

            foreach (var employee in employees)
            {
                employee.SalaryInfo?.GetSalary(monthDate, monthDate2, DateTime.Now, holiday, salaryISsubsended, Settings
                    , salaryUnits.ToList());
               
            }

            UnitOfWork.Complete(n => n.Salary_Update);
          
            var historey = UnitOfWork.HistorySubsended.GetAll().Where(s => DateTime.Parse(s.MonthDate).Year >= monthDate.Year &&
                                                                        DateTime.Parse(s.MonthDate).Year <= monthDate.Year &&
                                                                        DateTime.Parse(s.MonthDate).Month >= monthDate.Month && 
                                                                        DateTime.Parse(s.MonthDate).Month <= monthDate.Month).ToList();

            foreach (var row in salaries.Where(s => s.MonthDate.Year >= monthDate.Year && s.MonthDate.Year <= monthDate.Year && s.MonthDate.Month >= monthDate.Month && s.MonthDate.Month <= monthDate.Month && s.IsSuspended == true))
            {
                foreach (var row2 in historey.Where(s => s.SalaryID == row.SalaryId.ToString()))
                {
                    row2.ModifySubsended(row.EmployeeId, model.SuspendedNote, "لم يتم  الافراج", row.MonthDate.ToString(), row.JobNumber, row.SalaryId.ToString(), true, false, row.FinalSalary(Settings), row.MonthDate.ToString(), false, row.EmployeeShare(Settings), row.SolidarityFund(Settings), row.Absence(), row.AbsenceDays, row.JihadTax(Settings));
                }
            }
            UnitOfWork.Complete(n => n.AddSupsended);
            model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid(Settings).ToList();
            return true;
        }

        public bool Close(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Close))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();
            
            foreach (var row in salaries)
            {
             
                row.Closed();
            }
            //======
            var employees = UnitOfWork.Employees.GetAll().ToList();/////////get without endservices

            if (employees == null)
                return false;

            var salaryLast = UnitOfWork.Salaries.GetLastSalary();

            
            if (salaryLast != null && !salaryLast.IsClose)
                return false;

            DateTime monthDate;
            monthDate = salaryLast?.MonthDate.AddMonths(1) ?? Settings.Date;


            DateTime monthDate2;
            monthDate2 = salaryLast?.MonthDate?? Settings.Date;
            var holiday = UnitOfWork.Holidays.GetAll().ToList();

            var salaryUnits = UnitOfWork.SalaryUnits.GetAll().ToList();
            var salaryISsubsended = UnitOfWork.Salaries.GetAll().Where(s=>s.IsSuspended==true && s.MonthDate== monthDate2).ToList();


            foreach (var employee in employees)
            {
                //employee.SalaryInfo?.GetSalary(monthDate, monthDate2, DateTime.Now, holiday,salaryISsubsended,Settings
                //    , salaryUnits.Where(s => s.SalayClassification == employee.JobInfo.SalayClassification).ToList());
                employee.SalaryInfo?.GetSalary(monthDate, monthDate2, DateTime.Now, holiday, salaryISsubsended, Settings
                   , salaryUnits.ToList());


            }
            //======

            UnitOfWork.Complete(n => n.Salary_Close);

            var getHistorey = UnitOfWork.HistorySubsended.GetAll().Where(s => s.ISSubsended == false && s.IsClose == true ).ToList();

            foreach (var row2 in getHistorey)
            {
                row2.AbsenceDays = 0;
                row2.ModifySubsended(row2.EmployeeId, model.SuspendedNote, "تم الافراج", row2.MonthDate.ToString(), row2.JoubNumber, row2.SalaryID.ToString(), false, true, row2.NetSalray, row2.MonthDate.ToString(), true, row2.SocialSecurityFundBondNumber, row2.SolidarityFundBondNumber, row2.Absence, row2.AbsenceDays, row2.jihad);

            }
            foreach (var row in salaryISsubsended)
            {
              
                var salaryLast2 = UnitOfWork.Salaries.GetAll().Where(s => s.EmployeeId==row.EmployeeId).OrderByDescending(m=>m.MonthDate).FirstOrDefault();

                var getEmID = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == row.SalaryId).EmployeeId;
                var getJobNumber = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == row.SalaryId).JobNumber;

                //var salary = UnitOfWork.Salaries.GetAll().Where(s => s.EmployeeId == getEmID && s.MonthDate.Year >= DateTime.Parse(model.DateFrom).Year && s.MonthDate.Year <= DateTime.Parse(model.DateTo).Year && s.MonthDate.Month >= DateTime.Parse(model.DateFrom).Month && s.MonthDate.Month <= DateTime.Parse(model.DateTo).Month && s.IsSuspended == true).ToList();
            
                var getHistoreyNew = UnitOfWork.HistorySubsended.GetAll().Where(s => s.ISSubsended == true && s.IsClose == false && s.EmployeeId == row.EmployeeId &&s.IsClipord==false).ToList();

             

                    var historey = HistorySubsended.New(getEmID, model.SuspendedNote, "لم يتم  الافراج", monthDate.ToString(), getJobNumber, salaryLast2.SalaryId.ToString(), true, false, salaryLast2.FinalSalary(Settings), salaryLast2.MonthDate.ToString(), false, salaryLast2.EmployeeShare(Settings), salaryLast2.SolidarityFund(Settings), salaryLast2.Absence(), salaryLast2.AbsenceDays, salaryLast2.JihadTax(Settings));
                    UnitOfWork.HistorySubsended.Add(historey);
                    UnitOfWork.Complete(n => n.AddSupsended);
                
                 

            }
            model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid(Settings).ToList();
            model.MonthDate = monthDate.FormatToString();


            return true;
        }

        public bool InsideAdvancePremiumFreeze(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Freeze))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            foreach (var salary in salaries)
            {
                salary.InsideAdvancePremiumFreeze();
            }

            UnitOfWork.Complete(n => n.Salary_Freeze);
            //model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid().ToList();

            return true;
        }

        public bool OutsideAdvancePremiumFreeze(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Freeze))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            foreach (var salary in salaries)
            {
                salary.OutsideAdvancePremiumFreeze();
            }

            UnitOfWork.Complete(n => n.Salary_Freeze);

            //model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid().ToList();
            return true;
        }

        public bool InsideAdvancePremiumAllow(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Allow))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            foreach (var salary in salaries)
            {
                salary.InsideAdvancePremiumAllow();
            }

            UnitOfWork.Complete(n => n.Salary_Allow);

            //model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid().ToList();
            return true;
        }

        public bool OutsideAdvancePremiumAllow(SalaryIndexModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Allow))
                return Fail(RequestState.NoPermission);

            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            foreach (var salary in salaries)
            {
                salary.OutsideAdvancePremiumAllow();
            }

            UnitOfWork.Complete(n => n.Salary_Allow);

            //model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid().ToList();
            return true;
        }

        public bool SaveBondNumber(SalaryIndexModel model)
        {
            var salaries = UnitOfWork.Salaries.GetOpenedSalary();

            if (salaries == null)
                return false;

            foreach (var salary in salaries)
            {
                salary.Modify(model.TaxBondNumber, model.SolidarityFundBondNumber, model.SocialSecurityFundBondNumber);
            }

            UnitOfWork.Complete(null);

            return true;
        }

        public bool SuspendedTrue(SalaryIndexModel model, long id,string note)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Suspend))
                return false;

            if (id <= 0)
                return false;
            var getEmID = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == id).EmployeeId;
            var getJobNumber = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == id).JobNumber;

            //var salary = UnitOfWork.Salaries.GetAll().Where(s => s.EmployeeId == getEmID && s.MonthDate.Year >= DateTime.Parse(model.DateFrom).Year && s.MonthDate.Year <= DateTime.Parse(model.DateTo).Year && s.MonthDate.Month >= DateTime.Parse(model.DateFrom).Month && s.MonthDate.Month <= DateTime.Parse(model.DateTo).Month && s.IsSuspended == true).ToList();
            var salary = UnitOfWork.Salaries.Find(id);

            var salaryLast = UnitOfWork.Salaries.GetAll().Where(s => s.SalaryId == id).FirstOrDefault();


            if (salary == null)
                return false;
      
                var historey = HistorySubsended.New(getEmID, model.SuspendedNote, "لم يتم  الافراج", salary.MonthDate.ToString(), getJobNumber, id.ToString(),true,false,salaryLast.FinalSalary(Settings),salaryLast.MonthDate.ToString(),false, salaryLast.EmployeeShare(Settings), salaryLast.SolidarityFund(Settings), salaryLast.Absence(), salaryLast.AbsenceDays, salaryLast.JihadTax(Settings));
                UnitOfWork.HistorySubsended.Add(historey);

           
                salary.SuspendedTrue(note);

            
            UnitOfWork.Complete(n => n.Salary_Suspend);

            model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid(Settings).ToList();
            model.MonthDate = salary.MonthDate.FormatToString();

            return true;
        }

        public bool SuspendedFalse(SalaryIndexModel model, long id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Unsuspend))
                return false;

            if (id <= 0)
                return false;
            var getEmID = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == id).EmployeeId;
            var getJobNumber = UnitOfWork.Salaries.GetAll().FirstOrDefault(s => s.SalaryId == id).JobNumber;
            var salaryLast = UnitOfWork.Salaries.GetAll().Where(s=>s.SalaryId==id).FirstOrDefault();

            var salary = UnitOfWork.Salaries.GetAll().Where(s=>s.EmployeeId== getEmID && s.MonthDate.Year>= DateTime.Parse( model.DateFrom).Year && s.MonthDate.Year<= DateTime.Parse(model.DateTo).Year && s.MonthDate.Month >= DateTime.Parse(model.DateFrom).Month && s.MonthDate.Month <= DateTime.Parse(model.DateTo).Month &&  s.IsSuspended == true).ToList();
            var salary2 = UnitOfWork.Salaries.Find(id);
            var historey = UnitOfWork.HistorySubsended.GetAll().Where(s=>s.EmployeeId== getEmID).ToList();
            if (salary == null)
                return false;
            foreach (var row in salary)
            {
                foreach (var row2 in historey.Where(s=>s.SalaryID==row.SalaryId.ToString()))
                {
                    row2.ModifySubsended(row.EmployeeId, model.SuspendedNote, "تم الافراج", row.MonthDate.ToString(), row.JobNumber, row.SalaryId.ToString(),false,true,salaryLast.FinalSalary(Settings),salaryLast.MonthDate.ToString(), false, row2.SocialSecurityFundBondNumber, row2.SolidarityFundBondNumber, row2.Absence, row2.AbsenceDays, row2.jihad);
                }
            }
           
                foreach (var row in salary)
            {
                row.SuspendedFalse();
                row.SuspendedSalary();
            }
            UnitOfWork.Complete(n => n.Salary_Unsuspend);
         

            model.SalaryGrid = UnitOfWork.Salaries.GetOpenedSalary().ToGrid(Settings).ToList();
            model.MonthDate = salary2.MonthDate.FormatToString();

            return true;
        }



        //public bool Delete(long id, SalaryFormModel model)
        //{
        //    if (!HavePermission(ApplicationUser.Permissions.Salary_Delete))
        //        return Fail(RequestState.NoPermission);

        //    if (id <= 0)
        //        return Fail(RequestState.BadRequest);

        //    var salary = UnitOfWork.Salaries.Find(id);

        //    if (salary == null)
        //        return Fail(RequestState.NotFound);

        //    UnitOfWork.Salaries.Remove(salary);

        //    if (!UnitOfWork.TryComplete())
        //        return Fail(UnitOfWork.Message);

        //    return SuccessDelete();
        //}

        public void Refresh(SalaryFormModel model)
        {
        }

        public bool Edit(SalaryFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var salary = UnitOfWork.Salaries.Find(model.SalaryId);

            if (salary == null)
                return Fail(RequestState.NotFound);

            if (model.SalaryId <= 0)
                return Fail(RequestState.BadRequest);

            var premiums = UnitOfWork.Premiums.GetAll();//////////

            var premiumDto = new Collection<PremiumDto>();//////////////
            
         model.TemporaryPremiumList.ToList().AddRange(model.NotTemporaryPremiumList.ToList());
            // foreach (var premium in premiums)
            //{
            //    var dto = new PremiumDto()
            //    {
            //        Premium = premium,
            //        Value = model.SalaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.Value ?? 0,
            //        AllValue = model.SalaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.alllValue ?? 0,
            //    };
            //    premiumDto.Add(dto);
            //}

            foreach (var premium in premiums)
            {
                var dto = new PremiumDto()

                {
                    Premium = premium,
                    Value = model.TemporaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.Value ?? 0,
                    AllValue = model.TemporaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.alllValue ?? 0,
                    
                };
                var dto1 = new PremiumDto()
                {
                    Premium = premium,
                    Value = model.NotTemporaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.Value ?? 0,
                    AllValue = model.NotTemporaryPremiumList.FirstOrDefault(e => e.PremiumId == premium.PremiumId)?.alllValue ?? 0,
                    
                };

                premiumDto.Add(dto);
            }


            salary.Modify(model.ExtraWork, model.ExtraWorkVacation, model.AbsenceDays, model.PrepaidSalary
                , model.Sanction, model.AdvancePremiumInside, model.AdvancePremiumOutside, model.AccumulatedValue,model.RewindValue, premiumDto);

            UnitOfWork.Complete(n => n.Salary_Edit);
            model.CanSubmit = ApplicationUser.Permissions.Salary_Edit;

            return SuccessEdit();
        }

        private void UpdateGrid(SalaryFormModel model) => model.TemporaryPremium = new TemporaryPremiumModel()
        {
            TemporaryPremiumGrid = UnitOfWork.Salaries.GetTemporaryPremium(model.SalaryId).ToGrid()
        };
        public bool SelectPremium(SalaryFormModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Fail(RequestState.NoPermission);

            if (model.TemporaryPremium.TemporaryPremiumId <= 0)
                return Fail(RequestState.BadRequest);

            var temporaryPremium = UnitOfWork.Salaries.FindTemporaryPremium(model.TemporaryPremium.TemporaryPremiumId);

            if (temporaryPremium == null)
                return Fail(RequestState.NotFound);

            model.TemporaryPremium.Name = temporaryPremium.Name;
            model.TemporaryPremium.Value = temporaryPremium.Value;
            model.TemporaryPremium.IsSubject = temporaryPremium.IsSubject;

            return true;
        }
        public bool CreatePremium(SalaryFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Fail(RequestState.NoPermission);

            var salary = UnitOfWork.Salaries.Find(model.SalaryId);

            if (salary == null)
                return Fail(RequestState.NotFound);

            //if (UnitOfWork.Salaries.TemporaryPremiumIsExisted(model.TemporaryPremium.TemporaryPremiumId, salary.SalaryId <= 0)
            //    return NameExisted();

            var temporaryPremium = TemporaryPremium.New(model.TemporaryPremium.Name, model.TemporaryPremium.IsSubject,
                        model.TemporaryPremium.SalaryId, model.TemporaryPremium.Value);

            salary.TemporaryPremiums.Add(temporaryPremium);

            UnitOfWork.Complete(n => n.Salary_Edit);
            UpdateGrid(model);
            //model.TotalSalary = 80;
            Clear(model);
            return true;
        }

        public bool EditPremium(SalaryFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Fail(RequestState.NoPermission);

            var temporaryPremium = UnitOfWork.Salaries.FindTemporaryPremium(model.TemporaryPremium.TemporaryPremiumId);

            if (temporaryPremium == null)
                return Fail(RequestState.NotFound);

            //if (UnitOfWork.Salaries.TemporaryPremiumIsExisted(model.TemporaryPremium.TemporaryPremiumId, temporaryPremium.SalaryId
            //            , temporaryPremium.TemporaryPremiumId <= 0)
            //    return NameExisted();

            temporaryPremium.Modify(model.TemporaryPremium.Name, model.TemporaryPremium.IsSubject
                , model.TemporaryPremium.Value);

            UnitOfWork.Complete(n => n.Salary_Edit);
            UpdateGrid(model);
            Find(temporaryPremium.SalaryId);
            Clear(model);
            return true;
        }
        public bool DeletePremium(int id, SalaryFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Salary_Edit))
                return Fail(RequestState.NoPermission);

            if (model.TemporaryPremium.TemporaryPremiumId <= 0)
                return Fail(RequestState.BadRequest);

            var temporaryPremium = UnitOfWork.Salaries.FindTemporaryPremium(model.TemporaryPremium.TemporaryPremiumId);

            if (temporaryPremium == null)
                return Fail(RequestState.NotFound);

            var salaryId = temporaryPremium.SalaryId;

            UnitOfWork.Salaries.RemoveTemporaryPremium(temporaryPremium);

            if (!UnitOfWork.TryComplete(n => n.Salary_Edit))
                return Fail(UnitOfWork.Message);

            UpdateGrid(model);
            Find(salaryId);

            return SuccessDelete();
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
                    EmployeeStat = salary.IsSuspended ? 1 : 0,
                    BankId = salary.BankBranch.BankId,
                    BranchId = salary.BankBranchId,
                    AccumulatedValue=salary.AccumulatedValue,
                    RewindValue=salary.RewindValue
                
                
             
                    
                    //WithoutPay =/////////////
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SalaryCardReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month).ToList();

            //if (salaries == null)
            //    return false;

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
                    SalaryPremiumList = UnitOfWork.Salaries.GetSalaryPremiumBy(salary.SalaryId).ToList().ToList(),
                  PremiumList = UnitOfWork.Premiums.GetAll().ToList(),

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
                    NationalNumber = salary.Employee?.NationalNumber,
                    BankId = salary.BankBranch?.Bank?.BankId??0

                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool View(SalariesTotalReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByMonth(model.Year, model.Month);

            if (salaries == null)
                return false;

            var grid = new HashSet<SalariesTotalReportGridRow>();
            var count = 1;
            var row = new SalariesTotalReportGridRow();
            foreach (var salary in salaries.Where(s => s.IsSuspended == false))
            {
                row.BasicSalaries += salary.BasicSalary;
                row.CompanyShareSocialSecurity += salary.CompanyShare(Settings);
                row.ContributionInSecurity += salary.CompanyShare(Settings) + 0;
                //row.DeducationTotal = ;
                row.JihadTax += salary.JihadTax(Settings);
                //MawadaFund = ;
                //SafeShareSocialSecurity = ;
                row.SalariesNet += salary.NetSalary(Settings);
                row.SalariesNumber = count;
                row.SalariesTotal += salary.TotalSalary(Settings);
                row.SocialSecurityFund += salary.EmployeeShare(Settings);
                row.SolidarityFund += salary.SolidarityFund(Settings);
                row.StampTax += salary.StampTax(Settings);
                count += 1;
            }
            grid.Add(row);

            model.Grid = grid;

            return true;
        }


        private void Clear(SalaryFormModel model)
        {
            model.TemporaryPremium.Value = 0;
            model.TemporaryPremium.IsSubject = false;
            model.TemporaryPremium.Name = "";

        }

        public bool View(DifrancesModel model)
        {
            throw new NotImplementedException();
        }

        public bool View(SummaryReportModel model)
        {
            //    if (!ModelState.IsValid(model))
            //        return false;

            //    var salaries = UnitOfWork.Salaries.GetSalaryPremium(model.Year, model.Month);
            //    var salariesAll = UnitOfWork.Salaries.GetAll();

            //    var PremiumHome = salaries.Where(i => i.PremiumId == 1).Sum(s => s.Value);
            //    var Premiumscar = salaries.Where(i => i.PremiumId == 2).Sum(s => s.Value);
            //    var Premiumdiscrimination = salaries.Where(i => i.PremiumId == 3).Sum(s => s.Value);
            //    var PremiumTechar = salaries.Where(i => i.PremiumId == 4).Sum(s => s.Value);
            //    var Reward = salaries.Where(i => i.PremiumId == 6).Sum(s => s.Value);
            //    var PremiumOther = salaries.Where(i => i.PremiumId == 5).Sum(s => s.Value);

            //    var EmployeeCount = salariesAll.Select(s => s.Employee.EmployeeId).Count();
            //    var EmployeeStop = salariesAll.Where(i => i.IsSuspended == true).Select(i => i.EmployeeId).Count();
            //    var EmployeesalaryStop = salariesAll.Where(i => i.IsSuspended == true).Sum(s => s.NetSalarySetting);
            //    var EmployeeNet = salariesAll.Sum(s => s.NetSalarySetting);
            //    var EmployeePremiumNet = salariesAll.Sum(s => s.BasicSalary);

            //    var EmployeeSalaryCount = salariesAll.Sum(s => s.BasicSalary) + salaries.Sum(s => s.Value);
            //    var CompanySalary = salariesAll.Sum(s => s.CompanyShareAllSetting) + salariesAll.Sum(s => s.CompanyShareReducedSetting)
            //        + salariesAll.Sum(s => s.CompanyShareReduced35YearSetting) + salariesAll.Sum(s => s.CompanyShareWithoutReducedSetting);
            //    var SaveSalary = salariesAll.Sum(s => s.BasicSalary);
            //    var Employeesetting = salariesAll.Sum(s => s.BasicSalary);
            //    var SettingSolidrty = salariesAll.Sum(s => s.SolidarityFundSetting);
            //    var SettingGuarantee = salariesAll.Sum(s => s.EmployeeShare(Settings));
            //    var SettingJihad = salariesAll.Sum(s => s.JihadTax(Settings));
            //    var Settingin = salariesAll.Sum(s => s.IncomeTaxOneSetting) + salariesAll.Sum(s => s.IncomeTaxTwoSetting);

            //    var SettingMony = salariesAll.Sum(s => s.JihadTaxSetting);
            //    var SettingPunishment = salariesAll.Sum(s => s.Sanction);
            //    var Settingstamp = salariesAll.Sum(s => s.StampTax(Settings));
            //    var SettingAbsence = salariesAll.Sum(s => s.Absence());
            //    // var Settingexpense = salariesAll.Sum(s => s.Absence());
            //    var SettingPresented = salariesAll.Sum(s => s.PrepaidSalary);
            //    //var SettingOther = salariesAll.Sum(s => s.Absence());
            //    //var Settinginsurance = salariesAll.Sum(s => s.Absence());



            //    var Basic = salariesAll.Sum(s => s.BasicSalary);
            //    var Advanced = salariesAll.Sum(s => s.AdvancePremiumInside);

            //    if (salaries == null)
            //        return false;

            //    var grid = new HashSet<SummaryReportGridRow>();


            //    var row = new SummaryReportGridRow()
            //    {

            //        Premiumdiscrimination = Premiumdiscrimination,
            //        PremiumHome = PremiumHome,
            //        PremiumOther = PremiumOther,
            //        Premiumscar = Premiumscar,
            //        PremiumTechar = PremiumTechar,
            //        Reward = Reward,
            //        Advanced = Advanced,
            //        Basic = Basic,
            //        EmployeeCount = EmployeeCount,
            //        CompanySalary = CompanySalary,
            //        EmployeeNet = EmployeeNet,
            //        EmployeePremiumNet = EmployeePremiumNet,
            //        EmployeeSalaryCount = EmployeeSalaryCount,
            //        EmployeesalaryStop = EmployeesalaryStop,
            //        Employeesetting = Employeesetting,
            //        EmployeeStop = EmployeeStop,
            //        SaveSalary = SaveSalary,
            //        SettingAbsence = SettingAbsence,
            //        //  Settingexpense = Settingexpense,
            //        SettingGuarantee = SettingGuarantee,
            //        Settingin = Settingin,
            //        //     Settinginsurance = Settinginsurance,
            //        SettingJihad = SettingJihad,
            //        SettingMony = SettingMony,
            //        //   SettingOther = SettingOther,
            //        SettingPresented = SettingPresented,
            //        SettingPunishment = SettingPunishment,
            //        SettingSolidrty = SettingSolidrty,
            //        Settingstamp = Settingstamp


            //    };

            //    grid.Add(row);


            //    model.Grid = grid;

            return true;
        }
        public bool View(SalarySettlementReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryPremium(model.Year??0, model.Month??0);
            var salariesAll = UnitOfWork.Salaries.GetAll();

            var PremiumHome = salaries.Where(i => i.PremiumId == 1).Sum(s => s.Value);//علاوة السكن
            var Premiumscar = salaries.Where(i => i.PremiumId == 2).Sum(s => s.Value);//علاوة نذب
            var Premiumdiscrimination = salaries.Where(i => i.PremiumId == 3).Sum(s => s.Value);//علاوة تميز
            var PremiumTechar = salaries.Where(i => i.PremiumId == 4).Sum(s => s.Value);//علاوة تدريس
            var Reward = salaries.Where(i => i.PremiumId == 6).Sum(s => s.Value);//مكفاة
            var PremiumOther = salaries.Where(i => i.PremiumId == 5).Sum(s => s.Value);//علاوات اخرى

            var EmployeeCount = salariesAll.Select(s => s.Employee.EmployeeId).Count();//عدد الموظفين
            var EmployeeStop = salariesAll.Where(i => i.IsSuspended == true).Select(i => i.EmployeeId).Count();// عدد الموظفين الموقفين
           // var SettingSolidrty = salariesAll.Sum(s => s.SolidarityFundSetting);//تضامن

            //var EmployeesalaryStop = salariesAll.Where(i => i.IsSuspended == true).Sum(s => s.NetSalarySetting);
            //var EmployeeNet = salariesAll.Sum(s => s.NetSalarySetting);
            var EmployeePremiumNet = salariesAll.Sum(s => s.BasicSalary);

            var EmployeeSalaryCount = salariesAll.Sum(s => s.BasicSalary) + salaries.Sum(s => s.Value);
            //var CompanySalary = salariesAll.Sum(s => s.CompanyShareAllSetting) + salariesAll.Sum(s => s.CompanyShareReducedSetting)
            //    + salariesAll.Sum(s => s.CompanyShareReduced35YearSetting) + salariesAll.Sum(s => s.CompanyShareWithoutReducedSetting);
            //var SaveSalary = salariesAll.Sum(s => s.BasicSalary);
            var Employeesetting = salariesAll.Sum(s => s.BasicSalary);
            //
            var SettingGuarantee = salariesAll.Sum(s => s.EmployeeShare(Settings));
            var SettingJihad = salariesAll.Sum(s => s.JihadTax(Settings));
           // var Settingin = salariesAll.Sum(s => s.IncomeTaxOneSetting) + salariesAll.Sum(s => s.IncomeTaxTwoSetting);

            //var SettingMony = salariesAll.Sum(s => s.JihadTaxSetting);
            var SettingPunishment = salariesAll.Sum(s => s.Sanction);
            var Settingstamp = salariesAll.Sum(s => s.StampTax(Settings));
            var SettingAbsence = salariesAll.Sum(s => s.Absence());
            // var Settingexpense = salariesAll.Sum(s => s.Absence());
            var SettingPresented = salariesAll.Sum(s => s.PrepaidSalary);
            //var SettingOther = salariesAll.Sum(s => s.Absence());
            //var Settinginsurance = salariesAll.Sum(s => s.Absence());



            var Basic = salariesAll.Sum(s => s.BasicSalary);
            var Advanced = salariesAll.Sum(s => s.AdvancePremiumInside);

            if (salaries == null)
                return false;

            var grid = new HashSet<SummaryReportGridRow>();


            var row = new SummaryReportGridRow()
            {

                Premiumdiscrimination = Premiumdiscrimination,
                PremiumHome = PremiumHome,
                PremiumOther = PremiumOther,
                Premiumscar = Premiumscar,
                PremiumTechar = PremiumTechar,
                Reward = Reward,
                Advanced = Advanced,
                Basic = Basic,
                EmployeeCount = EmployeeCount,
                //CompanySalary = CompanySalary,
                //EmployeeNet = EmployeeNet,
                //EmployeePremiumNet = EmployeePremiumNet,
                EmployeeSalaryCount = EmployeeSalaryCount,
                //EmployeesalaryStop = EmployeesalaryStop,
                Employeesetting = Employeesetting,
                EmployeeStop = EmployeeStop,
                //SaveSalary = SaveSalary,
                SettingAbsence = SettingAbsence,
                //  Settingexpense = Settingexpense,
                SettingGuarantee = SettingGuarantee,
                //Settingin = Settingin,
                //     Settinginsurance = Settinginsurance,
                SettingJihad = SettingJihad,
                //SettingMony = SettingMony,
                //   SettingOther = SettingOther,
                SettingPresented = SettingPresented,
                SettingPunishment = SettingPunishment,
                //SettingSolidrty = SettingSolidrty,
                Settingstamp = Settingstamp


            };

            grid.Add(row);


            //model.Grid = grid;

            return true;
        }
        public SalaryIndexModel SearchSummary(SalaryIndexModel model)
        {

            var grid = UnitOfWork.Salaries.GetSerchSalarySummary(model.Year ?? 0, model.Month ?? 0).ToGridSerch(Settings).ToList();

            return new SalaryIndexModel()
            {
                Month = model.Month,
                Year = model.Year,

                SalaryGrid = grid,

            };
        }
        public void GetBranch(SalaryIndexModel model)
        {

            model.BankBranchList = model.BankId > 0
           ? UnitOfWork.BankBranches.GetBankBranchWithBank(model.BankId).ToList()
           : new HashSet<BankBranchListItem>();


        }


        public SalaryIndexModel Search(SalaryIndexModel model)
        {

            var grid = UnitOfWork.Salaries.GetSerchSalary(model.BankId, model.BankBranchId ?? 0, model.Year ?? 0, model.Month ?? 0).ToGridSerch(Settings).ToList();

            return new SalaryIndexModel()
            {
                Month = model.Month,
                Year = model.Year,
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                BankId = model.BankId,
                BankBranchList = UnitOfWork.BankBranches?.GetBankBranchWithBank(model.BankId).ToList(),
                BankBranchId = model.BankBranchId,
                SalaryGrid = grid,

            };
        }

        public SalaryIndexModel SearchSalaryAdvPayement(SalaryIndexModel model)
        {

            var grid = UnitOfWork.Salaries.GetSerchSalaryAdvPayement(model.BankId, model.BankBranchId ?? 0, model.Year ?? 0, model.Month ?? 0).ToGridSerch(Settings).ToList();

            return new SalaryIndexModel()
            {
                Month = model.Month,
                Year = model.Year,
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                BankId = model.BankId,
                BankBranchList = UnitOfWork.BankBranches?.GetBankBranchWithBank(model.BankId).ToList(),
                BankBranchId = model.BankBranchId,
                SalaryGrid = grid,

            };

        }
        public SalaryIndexModel SearchDifrancess(SalaryIndexModel model)
        {

            var grid = UnitOfWork.Salaries.GetSerchSalaryDifrancess(model.BankId, model.BankBranchId ?? 0, model.Year ?? 0, model.Month ?? 0).ToGridSerch(Settings).ToList();

            return new SalaryIndexModel()
            {
                Month = model.Month,
                Year = model.Year,
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                BankId = model.BankId,
                BankBranchList = UnitOfWork.BankBranches?.GetBankBranchWithBank(model.BankId).ToList(),
                BankBranchId = model.BankBranchId,
                SalaryGrid = grid,

            };

        }



    }
}