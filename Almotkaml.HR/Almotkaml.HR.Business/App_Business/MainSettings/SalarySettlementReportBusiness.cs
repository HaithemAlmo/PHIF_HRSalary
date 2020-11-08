using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SalarySettlementReportBusiness : Business, ISalarySettlementReportBusiness
    {
        IList<decimal> NetSalarySum = new List<decimal>();
        IList<decimal> EmployeSahra = new List<decimal>();
        IList<decimal> Jihad = new List<decimal>();
        IList<int> AbsenceDay = new List<int>();
        IList<decimal> Absence = new List<decimal>();
        IList<decimal> SolidarityFundBondNumber = new List<decimal>();
        decimal xxx = 0;
        IList<decimal> subject = new List<decimal>();
        IList<decimal> Total = new List<decimal>();
        IList<decimal> Final = new List<decimal>();
        IList<decimal> SocialSecurityFundBondNumber = new List<decimal>();


        public SalarySettlementReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SalarySettlementReport && permission;

        public SalarySettlementReportModel Prepare()
        {
            var ddd = UnitOfWork.Centers.GetAll().ToList().ToList();

            if (!HavePermission(ApplicationUser.Permissions.SalarySettlementReport))
                return Null<SalarySettlementReportModel>(RequestState.NoPermission);

            return new SalarySettlementReportModel()
            {
                AdvanseNameList = UnitOfWork.Premiums.GetAll().ToListPremiumums(),

                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                BankList = UnitOfWork.Banks.GetAll().ToList(),
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                PremiumCheckListItem = UnitOfWork.Premiums.GetAll().ToCheckList(),
            };
        }

        public void Refresh(SalarySettlementReportModel model)
        {
            model.AdvanseNameList = UnitOfWork.Premiums.GetAll().ToListPremiumums();

            model.BankList = UnitOfWork.Banks.GetAll().ToList();
            model.CenterList = UnitOfWork.Centers.GetAll().ToList();

            model.BankBranchList = model.BankId > 0
            ? UnitOfWork.BankBranches.GetBankBranchWithBank(model.BankId ?? 0).ToList()
            : new HashSet<BankBranchListItem>();

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId ?? 0).ToList()
                : new HashSet<DepartmentListItem>();

            model.DivisionList = model.DepartmentId > 0
                ? UnitOfWork.Divisions.GetDivisionWithDepartment(model.DepartmentId ?? 0).ToList()
                : new HashSet<DivisionListItem>();

            if (model.DivisionId > 0)
                model.UnitList = UnitOfWork.Units.GetUnitWithDivision(model.DivisionId ?? 0).ToList();
            else
                model.UnitList = new HashSet<UnitListItem>();
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId ?? 0);
            if (!model.PremiumCheckListItem.Any())
                model.PremiumCheckListItem = UnitOfWork.Premiums.GetAll().ToCheckList();


            if (employee == null)
                return;

            model.EmployeeName = employee.GetFullName();


        }

        public bool ViewPledge(SalarySettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return false;

            var grid = new List<PledgeReportGridRow>();

            var row = new PledgeReportGridRow()
            {
                NationalNumber = employee.NationalNumber,
                BankName = employee.SalaryInfo?.BankBranch?.Bank?.Name + "-" + employee.SalaryInfo?.BankBranch?.Name,
                BondNumber = employee.SalaryInfo?.BondNumber,
                EmployeeName = employee.GetFullName()
            };

            grid.Add(row);
            model.PledgeReportGrid = grid;

            return true;
        }

        public bool ViewSalaryCertificate(SalarySettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var salary = UnitOfWork.Salaries.GetSalaryBy(model.EmployeeId??0 , model.DateFrom.ToDateTime());

            if (salary == null)
                return false;

            var grid = new List<SalaryCertificateReportGridRow>();

            var row = new SalaryCertificateReportGridRow()
            {
                NationalNumber = salary.Employee?.NationalNumber,
                EmployeeName = salary.Employee?.GetFullName(),
                //MawadaFund = salary.,
                BasicSalary = salary.BasicSalary,
                SolidarityFund = salary.SolidarityFund(Settings),
                SocialSecurityFund = salary.EmployeeShare(Settings),
                JihadTax = salary.JihadTax(Settings),
                NetSalary = salary.NetSalary(Settings),
                //AdvancePaymentName = salary.ad,
                //AdvancePaymentValue = salary.,
                Boun = salary.Employee?.JobInfo?.Bouns ?? 0,
                Degree = salary.Employee?.JobInfo?.DegreeNow.ToString(),
                //DiscountTotal = ,
                //SalaryTotal =
            };

            grid.Add(row);
            model.SalaryCertificateReportGrid = grid;

            return true;
        }

        public bool ViewPensionFund(SalarySettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryBy(model.EmployeeId ?? 0
                        , model.DateFrom.ToDateTime(), model.DateTo.ToDateTime());

            if (salaries == null)
                return false;

            var grid = new List<PensionFundReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new PensionFundReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    BasicSalary = salary.BasicSalary,
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo,
                    Month = salary.MonthDate.Year + "-" + salary.MonthDate.Month,
                    ExtraGeneralValue = salary.ExtraGeneralValue + salary.ExtraValue,
                    //Reward = ,
                    SecurityNumber = salary.Employee?.SalaryInfo?.SecurityNumber,
                    Total = salary.BasicSalary + salary.ExtraGeneralValue + salary.ExtraValue
                };
                grid.Add(row);
            }

            model.PensionFundReportGrid = grid;

            return true;
        }

        public bool Search(SalarySettlementReportModel model)
        {
            //if (!ModelState.IsValid(model))
            //    return false;

            var employeeReportDto = new EmployeeReportDto()
            {

                //DateOfAppointmentDecision=model.dateo


                JobNumberInt = model.JobNumber,

                BranchId = model.BankBranchId ?? 0,
                BankID = model.BankId ?? 0,
                DepartmentId = model.DepartmentId ?? 0,

                DivisionId = model.DivisionId ?? 0,


                UnitId = model.UnitId ?? 0
            };
            var employees = UnitOfWork.Salaries.GetEmployeeReport(employeeReportDto).ToList();

            if (employees == null)
                return false;

            var grid = new List<EmployeeReportGridRow>();


            foreach (var employee in employees)
            {
                grid.Add(new EmployeeReportGridRow()
                {
                    EmployeeName = employee?.GetFullName(),
                    BankBranchName = employee?.SalaryInfo?.BankBranch?.Name,
                    BankBranchId = employee?.SalaryInfo?.BankBranch?.BankBranchId ?? 0,
                    BondNumber = employee?.SalaryInfo?.BondNumber,
                    DateOfAppointmentDecision = employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Year + "-" + employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Month + "-" + employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Day,

                    BookFamilySourceNumber = employee?.BookFamilySourceNumber,
                    DegreeNote = employee?.JobInfo?.DegreeNote,
                    NationaltyMother = employee?.NationaltyMother,


                    FullName = employee?.GetFullName(),
                    DonorFoundation = employee?.Qualifications?.FirstOrDefault()?.NameDonorFoundation,
                    Qualification = employee?.Qualifications?.FirstOrDefault()?.QualificationType?.Name,
                    DateQualification = employee?.Qualifications?.FirstOrDefault()?.Date.Date,
                    Specialty = employee?.Qualifications?.FirstOrDefault()?.Specialty?.Name,
                    SecurityNumber = employee?.SalaryInfo?.SecurityNumber,
                    Notes = employee?.JobInfo?.Notes,
                    JobType = employee?.JobInfo?.JobType ?? 0,
                    Degree = employee?.JobInfo?.Degree ?? 0,
                    CenterName = employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                    ClassificationOnWorkName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                    ClassificationOnSearchingName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                    JobNumber = employee?.JobInfo?.GetJobNumber(),
                    Phone = employee?.Phone,
                    NationalityName = employee?.Nationality?.Name,
                    Address = employee?.Address,
                    DegreeNow = employee?.JobInfo?.DegreeNow ?? 0,
                    VacationBalance = employee?.JobInfo?.VacationBalance ?? 0,
                    AdjectiveEmployeeName = employee?.JobInfo?.AdjectiveEmployee?.Name,
                    AdjectiveEmployeeTypeName = employee?.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeType?.Name,
                    AdjectiveMilitary = employee?.MilitaryData?.AdjectiveMilitary ?? 0,
                    BirthDate = employee?.BirthDate?.FormatToString(),
                    BirthPlace = employee?.BirthPlace,
                    BloodType = employee?.BloodType ?? 0,
                    BookletCivilRegistry = employee?.Booklet?.CivilRegistry,
                    BookletFamilyNumber = employee?.Booklet?.FamilyNumber,
                    BookletIssueDate = employee?.Booklet?.IssueDate?.FormatToString(),
                    BookletIssuePlace = employee?.Booklet?.IssuePlace,
                    BookletNumber = employee?.Booklet?.Number,
                    BookletRegistrationNumber = employee?.Booklet?.RegistrationNumber,
                    Bouns = employee?.JobInfo?.Bouns ?? 0,
                    BranchName = employee?.Place?.Branch?.Name,
                    ChildernCount = employee?.ChildernCount ?? 0,
                    College = employee?.MilitaryData?.College,
                    ContactInfoAddress = employee?.ContactInfo?.Address,
                    ContactInfoNearKindr = employee?.ContactInfo?.NearKindr,
                    ContactInfoNearPoint = employee?.ContactInfo?.NearPoint,
                    ContactInfoNote = employee?.ContactInfo?.Note,
                    ContactInfoPhone = employee?.ContactInfo?.Phone,
                    ContactInfoRelativeRelation = employee?.ContactInfo?.RelativeRelation,
                    ContactInfoWorkAddress = employee?.ContactInfo?.WorkAddress,
                    CurrentSituationName = employee?.JobInfo?.CurrentSituation?.Name,
                    DateBouns = employee?.JobInfo?.DateBouns?.FormatToString(),
                    DateDegreeNow = employee?.JobInfo?.DateDegreeNow?.FormatToString(),
                    DateMeritBouns = employee?.JobInfo?.DateMeritBouns?.FormatToString(),
                    DateMeritDegreeNow = employee?.JobInfo?.DateMeritDegreeNow?.FormatToString(),
                    //DegreeLastResolutionNumber = employee?.JobInfo??.DegreeLastResolutionNumber ?? 0,
                    DepartmentName = employee?.JobInfo?.Unit?.Division?.Department?.Name,
                    DirectlyDate = employee?.JobInfo?.DirectlyDate?.FormatToString(),
                    DivisionName = employee?.JobInfo?.Unit?.Division?.Name,
                    Email = employee?.JobInfo?.Unit?.Division?.Department?.Name,
                    EnglishFatherName = employee?.EnglishFatherName,
                    EnglishFirstName = employee?.EnglishFirstName,
                    EnglishGrandfatherName = employee?.EnglishGrandfatherName,
                    EnglishLastName = employee?.EnglishLastName,
                    FatherName = employee?.FatherName,
                    FirstName = employee?.FirstName,
                    Gender = employee?.Gender ?? 0,
                    //  QualificationTypeId=employee.Qualifications.Select(s=>s.QualificationType.Name).First(),
                    GrandfatherName = employee?.GrandfatherName,
                    GranduationDate = employee?.MilitaryData?.GranduationDate?.FormatToString(),
                    IdentificationCardIssueDate = employee?.IdentificationCard?.IssueDate?.FormatToString(),
                    IdentificationCardIssuePlace = employee?.IdentificationCard?.IssuePlace,
                    IdentificationCardNumber = employee?.IdentificationCard?.Number,
                    JobName = employee?.JobInfo?.Job?.Name,
                    JobInfoNotes = employee?.JobInfo?.Notes,
                    JobNumberApproved = employee?.JobInfo?.JobNumberApproved ?? 0,
                    LastName = employee?.LastName,
                    LibyanOrForeigner = employee?.LibyanOrForeigner ?? 0,
                    MilitaryNumber = employee?.MilitaryData?.MilitaryNumber,
                    MotherName = employee?.MotherName,
                    MotherUnit = employee?.MilitaryData?.MotherUnit,
                    NationalNumber = employee?.NationalNumber,
                    PassportAutoNumber = employee?.Passport?.AutoNumber,
                    PassportIssueDate = employee?.Passport?.IssueDate?.FormatToString(),
                    PassportIssuePlace = employee?.Passport?.IssuePlace,
                    PassportNumber = employee?.Passport?.Number,
                    PlaceName = employee?.Place?.Name,
                    Rank = employee?.MilitaryData?.Rank,
                    Religion = employee?.Religion ?? 0,
                    SocialStatus = employee?.SocialStatus ?? 0,
                    StaffingName = employee?.JobInfo?.Staffing?.Name,
                    StaffingTypeName = employee?.JobInfo?.Staffing?.StaffingType?.Name,
                    Subunit = employee?.MilitaryData?.Subunit,
                    UnitName = employee?.JobInfo?.Unit?.Name,

                });
            }

            model.Grid = grid;
            return true;
        }
        //public bool TotalSummary(SalarySettlementReportModel model)
        //{

        //}
        //ÝáÊÑÉ ÈÇáäÊÇÆÌ ÇáãÑÓáÉ ãä ÇáæÇÌåÉ
        public bool SearchByDate(SalarySettlementReportModel model)
        {
            //if (model.SalarySettlement == SalarySettlement.SalaryForm && model.PremiumCheck)
            //{
            //    if (model.PremiumCheckListItem.Where(e => e.IsSelected == true).Count() > 9)
            //        return false;
            //}

            var employeeReportDto = new EmployeeReportDto()
            {
                ISadvanse = model.ISadvanse,
                ISsubsended = model.IsSubsended,
                //DateOfAppointmentDecision=model.dateo
                IsEndJob = model.IsEndJob,
                Islegal = model.IsLegal,
                JobNumberInt = model.JobNumber,
                BranchId = model.BankBranchId ?? 0,
                BankID = model.BankId ?? 0,
                DepartmentId = model.DepartmentId ?? 0,
                //  AdjectiveEmployeeId=model.EmployeeId,
                DivisionId = model.DivisionId ?? 0,
                Year = model.Year ?? 0,
                Month = model.Month ?? 0,

                UnitId = model.UnitId ?? 0,


            };

            var GetSalary = UnitOfWork.Salaries.GetSalaryByMonth(model.Year ?? 0, model.Month ?? 0);

            var employees = UnitOfWork.Salaries.GetEmployeeReportDate(employeeReportDto).ToList();
            var banks = UnitOfWork.BankBranches.GetAll().ToList();
            var grid = new List<EmployeeReportGridRow>();
            //***************************************************************
            var PremiumCheckListValues = new List<PremiumCheckListItem>();
            var employeePremiumList = new List<TemEmployeePremiumListItemEE>();
            var PremiumCheckListReport = new List<PremiumCheckListItemReport>();
            var PremiumCheckListReport2 = new List<PremiumCheckListItemReport>();
            //***************************************************************

            if (model.ISadvanse == 1)
            {
                var GetAdvanse = UnitOfWork.AdvancePayments.GetAll().Where(s => s.PremiumId == model.AdvanseNameID).ToGrid();
                foreach (var advancePayments in employees.Where(s => s.AdvancePayments.Count() != 0))
                {

                    foreach (var row2 in GetAdvanse.Where(s => s.EmployeeID == advancePayments.EmployeeId))
                    {
                        grid.Add(new EmployeeReportGridRow()
                        {
                            PremiumumName = row2.PremiumName,
                            EmployeeName = row2.EmployeeName,
                            JobNumber = advancePayments.JobInfo?.JobNumber.ToString(), ///////
                            Value = row2.AllValue,
                            InstallmentValue = row2.InstallmentValue,
                            Date = row2.DeductionDate,

                            Rest = row2.AllValue - row2.Value + advancePayments.Salaries.Sum(s => s.AdvancePremiumInside)
                        });
                    }

                }
                model.Grid = grid;

                return true;

            }

            var resultSalary = GetSalary?.Where(p => employees.Any(p2 => p2.EmployeeId == p.EmployeeId)).ToList();


            if (model.IsLegal == 1 && model.IsEndJob != 1)
            {
                var Employeepremiums = UnitOfWork.Salaries.GettAllSalaryPremmium();//////////

                var result = resultSalary?.Where(p => Employeepremiums.Any(p2 => p2.SalaryId == p.SalaryId)).ToList();
                GetSalary = resultSalary?.Where(p => result.Any(p2 => p2.SalaryId == p.SalaryId)).ToList();

                employees = employees?.Where(p => result.Any(p2 => p2.EmployeeId == p.EmployeeId)).ToList();

            }
            if (model.IsEndJob == 1 && model.IsLegal != 1)
            {
                var GetSalaryBydate = UnitOfWork.Salaries.GetSalaryByDateEndJob(model.DateFrom2, model.DateTo2);//////////

                var result = resultSalary?.Where(p => GetSalaryBydate.Any(p2 => p2.SalaryId == p.SalaryId)).ToList();
                GetSalary = resultSalary?.Where(p => result.Any(p2 => p2.SalaryId == p.SalaryId)).ToList();

                employees = employees?.Where(p => GetSalaryBydate.Any(p2 => p2.EmployeeId == p.EmployeeId)).ToList();
                GetSalary = GetSalaryBydate;
            }
            else
            {
                GetSalary.ToList().Clear();
                GetSalary = resultSalary.ToList();

            }

            var salary2 = GetSalary.ToList();
            if (employees == null)
                return false;

            var grid2 = new List<EmployeeReportGridRow>();

            decimal _Clamp = 0; // الهيئات القضائية
            var NameSolidrty = "خصم التضامن";
            var NameJihad = "خصم الجهاد";
            var NameShara = "خصم الضمان";
            foreach (var salaryss in GetSalary)
            {
                xxx += salaryss.SalaryPremiums.Where(w => w.PremiumId == 2).Sum(s => s.Value);
            }
            foreach (var employee in employees)
            {

                foreach (var salary in GetSalary?.Where(s => s.EmployeeId == employee.EmployeeId))
                {
                    if (salary.BasicSalary != 0)
                    {
                        //
                        if (salary.IsSuspended == false)
                        {
                            var GetSubsended = UnitOfWork.HistorySubsended.GetAll().Where(s => s.ISSubsended == false && s.IsClose == true && s.EmployeeId == employee.EmployeeId && s.MonthDate == salary.MonthDate.ToString()).ToList();

                            var Messgae = "";
                            var datesupsended = "";
                            bool issubeded = false;

                            foreach (var row2 in GetSubsended)
                            {
                                issubeded = true;
                                Messgae = row2.iSCloseMessage;
                                NetSalarySum.Add(row2.NetSalray);
                                Absence.Add(row2.Absence);
                                SolidarityFundBondNumber.Add(row2.SolidarityFundBondNumber);
                                Jihad.Add(row2.jihad);
                                AbsenceDay.Add(row2.AbsenceDays);
                                SocialSecurityFundBondNumber.Add(row2.SocialSecurityFundBondNumber);
                                subject.Add(row2.subject);

                            }


                            //else
                            //{

                            //    NetSalarySum.Add(salary.NetSalary(Settings));
                            //}
                            var SumNet = NetSalarySum.Sum();
                            var SumJihad = Jihad.Sum();
                            var SumabAbsensesDay = AbsenceDay.Sum();
                            var SumAbsence = Absence.Sum();
                            var SumEmployeShara = NetSalarySum.Sum();
                            var SumSeciurety = SocialSecurityFundBondNumber.Sum();
                            var SumSolidrty = SolidarityFundBondNumber.Sum();

                            //***************************************************************
                            if (model.SalarySettlement == SalarySettlement.Summary && model.PremiumCheck)
                            {
                                var PremiumCheckList = model.PremiumCheckListItem.Where(p => p.IsSelected == true);

                                decimal? PremiumValue = 0;
                                foreach (var premiumChecks in PremiumCheckList)
                                {
                                    PremiumValue = salary?.SalaryPremiums?.Where(s => s?.PremiumId == premiumChecks.PremiumId).Sum(s => s.Value) ?? 0;

                                    PremiumCheckListValues.Add(new PremiumCheckListItem()
                                    {
                                        Name = premiumChecks.Name,
                                        PremiumId = premiumChecks.PremiumId,
                                        Value = PremiumValue ?? 0,
                                        IsSelected = premiumChecks?.IsSelected ?? false
                                    });
                                }

                            }
                            else if (model.SalarySettlement == SalarySettlement.SalaryForm && model.PremiumCheck)
                            {
                                var PremiumList = model.PremiumCheckListItem.Where(p => p.IsSelected == true).Take(9).ToList(); //UnitOfWork.Premiums.GetAll().ToEmployeePremiumList();
                                var EmployeePremiumList = salary.SalaryPremiums.ToList();
                                foreach (var premiumList in PremiumList)
                                {

                                    PremiumCheckListValues.Add(new PremiumCheckListItem()
                                    {
                                        EmployeeID = employee.EmployeeId,
                                        PremiumId = premiumList.PremiumId,
                                        Value = EmployeePremiumList?.Where(e => e.PremiumId == premiumList.PremiumId)?.FirstOrDefault()?.Value ?? 0,
                                        Name = premiumList.Name,

                                    });

                                }
                                for (int i = PremiumCheckListValues.Where(e=>e.EmployeeID == employee.EmployeeId).Count(); i < 9; i++)
                                {
                                    PremiumCheckListValues.Add(new PremiumCheckListItem()
                                    {
                                        EmployeeID = employee.EmployeeId,
                                        PremiumId = 0,
                                        Value = 0,
                                        Name ="",

                                    });

                                }


                                var PremiumCheckListItemReport = new List<PremiumCheckListItemReport>();


                                var premium = PremiumCheckListValues.Where(e => e.EmployeeID == employee.EmployeeId);
                                List<string> PremiumCheckListPremiumID = new List<string>();
                                List<string> PremiumCheckListName = new List<string>();
                                for (int i = 0; i<premium.Count(); i++)
                                {
                                    PremiumCheckListPremiumID.Add(premium.ToList()[i].PremiumId.ToString());
                                    PremiumCheckListName.Add(premium.ToList()[i].Name.ToString());

                                }
                               
                                PremiumCheckListItemReport.Add(new PremiumCheckListItemReport()
                                {
                                    EmployeeID = employee.EmployeeId,
                                    PremiumId = string.Join(",", PremiumCheckListPremiumID.ToList()),//PremiumId.Add( PremiumCheckListPremiumID,
                                    Name = string.Join(",", PremiumCheckListName.ToArray()),
                                    PremiumCheck1 = premium.ToList()[0].Value.ToString(),
                                    PremiumCheck2 = premium.ToList()[1].Value.ToString(),
                                    PremiumCheck3 = premium.ToList()[2].Value.ToString(),
                                    PremiumCheck4 = premium.ToList()[3].Value.ToString(),
                                    PremiumCheck5 = premium.ToList()[4].Value.ToString(),
                                    PremiumCheck6 = premium.ToList()[5].Value.ToString(),
                                    PremiumCheck7 = premium.ToList()[6].Value.ToString(),
                                    PremiumCheck8 = premium.ToList()[7].Value.ToString(),
                                    PremiumCheck9 = premium.ToList()[8].Value.ToString(),
                                });
                                PremiumCheckListReport2.Add(new PremiumCheckListItemReport()
                                {
                                    EmployeeID = employee.EmployeeId,
                                    PremiumId = string.Join(",", PremiumCheckListPremiumID.ToList()),//PremiumId.Add( PremiumCheckListPremiumID,
                                    Name = string.Join(",", PremiumCheckListName.ToArray()),
                                    PremiumCheck1 = premium?.ToList()[0].Value.ToString() ?? "",
                                    PremiumCheck2 = premium?.ToList()[1].Value.ToString() ?? "",
                                    PremiumCheck3 = premium?.ToList()[2].Value.ToString() ?? "",
                                    PremiumCheck4 = premium?.ToList()[3].Value.ToString() ?? "",
                                    PremiumCheck5 = premium?.ToList()[4].Value.ToString() ?? "",
                                    PremiumCheck6 = premium?.ToList()[5].Value.ToString() ?? "",
                                    PremiumCheck7 = premium?.ToList()[6].Value.ToString() ?? "",
                                    PremiumCheck8 = premium?.ToList()[7].Value.ToString() ?? "",
                                    PremiumCheck9 = premium?.ToList()[8].Value.ToString() ?? "",
                                });


                                PremiumCheckListReport = PremiumCheckListItemReport.ToList();
                            }
                            //***************************************************************


                            grid.Add(new EmployeeReportGridRow()
                            {

                                Isubsended = issubeded,
                                IsclodseMessage = Messgae,
                                DateSubsended = datesupsended,

                                dateSalary = salary?.MonthDate.Month + "/" + salary?.MonthDate.Year,

                                BankName = employee?.SalaryInfo?.BankBranch?.Bank?.Name,
                                // d = salary?.AdvancePremiumInside??0,
                                //اجمالي الخصميات
                                DiscountTotal = salary?.TotalDiscount(Settings) ?? 0,
                                //اجمالي المرتبات كلها
                                SalaryTotal = salary?.TotalSalary(Settings) ?? 0,
                                //  SocialSecurityFund = salary?.SocialSecurityFundBondNumber(Settings),

                                //MawadaFund = salary.,
                                MawadaFund = xxx,
                                //AdvancePaymentName = salary.ad,
                                //AdvancePaymentValue = salary.,
                                //العلاوة
                                Boun = salary?.Employee?.JobInfo?.Bouns ?? 0,
                                AdvancePaymentInside = model.SalarySettlement == SalarySettlement.SalaryForm  ? salary?.ValueAdvancePremiumIsNotTemporary() ?? 0 : salary?.AdvancePremiumInside ?? 0,
                                AdvancePaymentOutside = model.SalarySettlement == SalarySettlement.SalaryForm ? salary?.ValueAdvancePremiumIsTemporary() ?? 0 : salary?.AdvancePremiumInside ?? 0,

                                //تاريخ المرتب
                                DateSalary = salary?.MonthDate.Month + "-" + salary.MonthDate.Year,

                                //  CostCenterName=employee?.
                                //اسم الموظف
                                Name = employee?.GetFullName(),
                                //صندوق التضامن 
                                SolidarityFund = salary?.IsSubsendedSalary == false ? salary?.SolidarityFund(Settings) + SumSolidrty ?? 0 : SumSolidrty,
                             
                               //المرتب الاساس
                                BasicSalary = salary?.BasicSalary ?? 0,
                                //هيئة قضائية
                                //Clamp = salary?.Employee.(Settings) ?? 0,
                                //قيمة الغياب
                                Absence = salary?.IsSubsendedSalary == false ? salary?.Absence() + SumAbsence ?? 0 : SumAbsence,
                                //حصة الشركة من الضمان
                                CompanyShare = salary?.CompanyShare(Settings) ?? 0,
                                //حصة الخزانة
                                SafeShare = salary?.SafeShare(Settings) ?? 0,
                                //حصة الموظف من الضظمان
                                EmployeeShare = salary?.IsSubsendedSalary == false ? salary?.EmployeeShare(Settings) + SumSeciurety ?? 0 : SumSeciurety,
                                //الاعفاء الضريبي 
                                ExemptionTax = salary?.ExemptionTax(Settings) ?? 0,
                                //عمل اضافي
                                ExtraWork = salary?.ExtraWork(Settings) ?? 0,
                                //اضافي ممتاز
                                ExtraWorkVacation = salary?.ExtraWorkVacation(Settings) ?? 0,
                                //ضريبة الدخل
                                IncomeTax = salary?.IncomeTax(Settings) ?? 0,
                                //ضريبة الجهاد
                                JihadTax = salary?.IsSubsendedSalary == false ? salary?.JihadTax(Settings) + SumJihad ?? 0 : SumJihad,
                                //صافي المرتب
                                NetSalary = salary?.NetSalary(Settings) ?? 0,
                                //إجمالي الخصميات
                                Discound = salary?.TotalDiscount(Settings) ?? 0,
                                // إجمالي العلاوات
                                AllBouns = (salary?.AllBouns(Settings) ?? 0),
                                //PrepaidSalaryAndAdvancePremium = row.PrepaidSalaryAndAdvancePremium,
                                //الاجزاءت
                                Sanction = salary?.SanctionDiscount() ?? 0,
                                //ضريبة اجازة مرضية
                                SickVacation = salary?.SickVacation(Settings) ?? 0,
                                //ضريبة الدمغة
                                StampTax = salary?.StampTax(Settings) ?? 0,
                                //المرتب الخاضع للضرائب
                                SubjectSalary = salary?.Subject(Settings) ?? 0,
                                //اجمالي المرتب
                                TotalSalary = salary?.TotalSalary(Settings) ?? 0,
                                //بدون مرتب
                                WithoutPay = salary?.WithoutPay ?? 0,
                                //سلفة داخلية
                                AdvancePremiumInside = salary?.AdvancePremiumInside ?? 0,
                                //سلفة خارجية
                                AdvancePremiumOutside = salary?.AdvancePremiumOutside ?? 0,
                                AccumulatedValue = salary?.AccumulatedValue ?? 0,
                                RewindValue = salary?.RewindValue ?? 0,
                                GroupLife = salary?.Grouplife(Settings) ?? 0,
                                //النفقة الشرعية
                                FinalSalaryLegal = salary?.SalaryPremiums?.Where(s => s.PremiumId == 1).FirstOrDefault()?.Value ?? 0,
                                //المرتب المحول للمصرف
                                FinalySalary = salary?.IsSubsendedSalary == false ? salary?.FinalSalary(Settings) + SumNet ?? 0 : SumNet,


                                FinalSalaryCertified = salary?.FinalSalary(Settings) ?? 0,

                                EmployeeName = employee?.GetFullName(),
                                FullName = employee?.GetFullName(),
                                BankBranchName = employee?.SalaryInfo?.BankBranch?.Name,
                                BankBranchId = employee?.SalaryInfo?.BankBranchId ?? 0,
                                //رقم الحساب
                                BondNumber = employee?.SalaryInfo?.BondNumber,

                                DateOfAppointmentDecision = employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Year + "-" + employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Month + "-" + employee?.JobInfo?.EmploymentValues?.DesignationResolutionDate.Value.Day,

                                BookFamilySourceNumber = employee?.BookFamilySourceNumber,
                                DegreeNote = employee?.JobInfo?.DegreeNote,
                                NationaltyMother = employee?.NationaltyMother,



                                DonorFoundation = employee?.Qualifications?.FirstOrDefault()?.NameDonorFoundation,
                                Qualification = employee?.Qualifications?.FirstOrDefault()?.QualificationType?.Name,
                                DateQualification = employee?.Qualifications?.FirstOrDefault()?.Date.Date,
                                Specialty = employee?.Qualifications?.FirstOrDefault()?.Specialty?.Name,
                                //الرقم الضماني
                                SecurityNumber = employee?.SalaryInfo?.SecurityNumber,
                                Notes = employee?.JobInfo?.Notes,
                                JobType = employee?.JobInfo?.JobType ?? 0,
                                Degree = employee?.JobInfo?.DegreeNow ?? 0,
                                CenterName = employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                                ClassificationOnWorkName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                                ClassificationOnSearchingName = employee?.JobInfo?.ClassificationOnSearching?.Name,
                                JobNumber = employee?.JobInfo?.GetJobNumber(),
                                Phone = employee?.Phone,
                                NationalityName = employee?.Nationality?.Name,
                                Address = employee?.Address,
                                DegreeNow = employee?.JobInfo?.DegreeNow ?? 0,
                                VacationBalance = employee?.JobInfo?.VacationBalance ?? 0,
                                AdjectiveEmployeeName = employee?.JobInfo?.AdjectiveEmployee?.Name,
                                AdjectiveEmployeeTypeName = employee?.JobInfo?.AdjectiveEmployee?.AdjectiveEmployeeType?.Name,
                                AdjectiveMilitary = employee?.MilitaryData?.AdjectiveMilitary ?? 0,
                                BirthDate = employee?.BirthDate?.FormatToString(),
                                BirthPlace = employee?.BirthPlace,
                                BloodType = employee?.BloodType ?? 0,
                                BookletCivilRegistry = employee?.Booklet?.CivilRegistry,
                                BookletFamilyNumber = employee?.Booklet?.FamilyNumber,
                                BookletIssueDate = employee?.Booklet?.IssueDate?.FormatToString(),
                                BookletIssuePlace = employee?.Booklet?.IssuePlace,
                                BookletNumber = employee?.Booklet?.Number,
                                BookletRegistrationNumber = employee?.Booklet?.RegistrationNumber,
                                Bouns = employee?.JobInfo?.Bouns ?? 0,
                                BranchName = employee?.Place?.Branch?.Name,
                                ChildernCount = employee?.ChildernCount ?? 0,
                                College = employee?.MilitaryData?.College,
                                ContactInfoAddress = employee?.ContactInfo?.Address,
                                ContactInfoNearKindr = employee?.ContactInfo?.NearKindr,
                                ContactInfoNearPoint = employee?.ContactInfo?.NearPoint,
                                ContactInfoNote = employee?.ContactInfo?.Note,
                                ContactInfoPhone = employee?.ContactInfo?.Phone,
                                ContactInfoRelativeRelation = employee?.ContactInfo?.RelativeRelation,
                                ContactInfoWorkAddress = employee?.ContactInfo?.WorkAddress,
                                CurrentSituationName = employee?.JobInfo?.CurrentSituation?.Name,
                                DateBouns = employee?.JobInfo?.DateBouns?.FormatToString(),
                                DateDegreeNow = employee?.JobInfo?.DateDegreeNow?.FormatToString(),
                                DateMeritBouns = employee?.JobInfo?.DateMeritBouns?.FormatToString(),
                                DateMeritDegreeNow = employee?.JobInfo?.DateMeritDegreeNow?.FormatToString(),
                                //DegreeLastResolutionNumber = employee?.JobInfo??.DegreeLastResolutionNumber ?? 0,
                                DepartmentName = employee?.JobInfo?.Unit?.Division?.Department?.Name,
                                DirectlyDate = employee?.JobInfo?.DirectlyDate?.FormatToString(),
                                DivisionName = employee?.JobInfo?.Unit?.Division?.Name,
                                Email = employee?.JobInfo?.Unit?.Division?.Department?.Name,
                                EnglishFatherName = employee?.EnglishFatherName,
                                EnglishFirstName = employee?.EnglishFirstName,
                                EnglishGrandfatherName = employee?.EnglishGrandfatherName,
                                EnglishLastName = employee?.EnglishLastName,
                                FatherName = employee?.FatherName,
                                FirstName = employee?.FirstName,
                                Gender = employee?.Gender ?? 0,
                                //  QualificationTypeId=employee.Qualifications.Select(s=>s.QualificationType.Name).First(),
                                GrandfatherName = employee?.GrandfatherName,
                                GranduationDate = employee?.MilitaryData?.GranduationDate?.FormatToString(),
                                IdentificationCardIssueDate = employee?.IdentificationCard?.IssueDate?.FormatToString(),
                                IdentificationCardIssuePlace = employee?.IdentificationCard?.IssuePlace,
                                IdentificationCardNumber = employee?.IdentificationCard?.Number,
                                JobName = employee?.JobInfo?.Job?.Name,
                                JobInfoNotes = employee?.JobInfo?.Notes,
                                JobNumberApproved = employee?.JobInfo?.JobNumberApproved ?? 0,
                                LastName = employee?.LastName,
                                LibyanOrForeigner = employee?.LibyanOrForeigner ?? 0,
                                MilitaryNumber = employee?.MilitaryData?.MilitaryNumber,
                                MotherName = employee?.MotherName,
                                MotherUnit = employee?.MilitaryData?.MotherUnit,
                                NationalNumber = employee?.NationalNumber,
                                PassportAutoNumber = employee?.Passport?.AutoNumber,
                                PassportIssueDate = employee?.Passport?.IssueDate?.FormatToString(),
                                PassportIssuePlace = employee?.Passport?.IssuePlace,
                                PassportNumber = employee?.Passport?.Number,
                                PlaceName = employee?.Place?.Name,
                                Rank = employee?.MilitaryData?.Rank,
                                Religion = employee?.Religion ?? 0,
                                SocialStatus = employee?.SocialStatus ?? 0,
                                StaffingName = employee?.JobInfo?.Staffing?.Name,
                                StaffingTypeName = employee?.JobInfo?.Staffing?.StaffingType?.Name,
                                Subunit = employee?.MilitaryData?.Subunit,
                                UnitName = employee?.JobInfo?.Unit?.Name,
                                EmployeeID = employee?.EmployeeId.ToString(),
                                PremiumListReport = PremiumCheckListReport,

                            });

                            if (employee.JobInfo?.SalayClassification == SalayClassification.Clamp)
                                _Clamp += salary?.TotalSalary(Settings) ?? 0;
                            NetSalarySum.Clear();
                            SumNet = 0;
                        }
                    }
                }
                model.EmployeeId = employee.EmployeeId;
            }
            var datasources = new List<EmployeeReportGridRow>();

            foreach (var salary in GetSalary?.Where(s => s.EmployeeId == model.EmployeeId))
            {

                datasources.Add(new EmployeeReportGridRow()
                {
                    ValueDiscountm = salary?.EmployeeShare(Settings) ?? 0,
                    DiscountName = NameShara
                });
            }
            foreach (var salary in GetSalary?.Where(s => s.EmployeeId == model.EmployeeId))
            {

                datasources.Add(new EmployeeReportGridRow()
                {
                    ValueDiscountm = salary?.SolidarityFund(Settings) ?? 0,
                    DiscountName = NameSolidrty
                });
            }
            foreach (var salary in GetSalary?.Where(s => s.EmployeeId == model.EmployeeId))
            {
                datasources.Add(new EmployeeReportGridRow()
                {
                    ValueDiscountm = salary?.JihadTax(Settings) ?? 0,
                    DiscountName = NameJihad
                });
                foreach (var salaryPremium in salary?.SalaryPremiums?.Where(s => s.Premium.DiscountOrBoun == DiscountOrBoun.Discount))
                {
                    datasources.Add(new EmployeeReportGridRow()
                    {
                        DiscountName = salaryPremium.Premium.Name,
                        ValueDiscountm = salaryPremium.Value
                    });
                }
                foreach (var Advance in salary?.Employee?.AdvancePayments?.Where(s => s.EmployeeId == model.EmployeeId))
                {
                    datasources.Add(new EmployeeReportGridRow()
                    {
                        DiscountName = Advance.Premium?.Name,
                        ValueDiscountm = Advance.Value
                    });
                }

                grid.AddRange(datasources);

                var datasourcesPremium = new List<EmployeeReportGridRow>();

                foreach (var salaryPremium in salary.SalaryPremiums.Where(s => s.Premium.DiscountOrBoun == DiscountOrBoun.Boun))
                {
                    datasourcesPremium.Add(new EmployeeReportGridRow()
                    {
                        ValuePremiumum = salaryPremium.Value,
                        PremiumumName = salaryPremium.Premium.Name
                    });
                }
                grid.AddRange(datasourcesPremium);

                var datasourcesClamp = new List<EmployeeReportGridRow>();

                datasourcesClamp.Add(new EmployeeReportGridRow()
                {
                    Clamp = _Clamp,
                });

                grid.AddRange(datasourcesClamp);



                model.PremiumListReport = PremiumCheckListReport2;
            }

            var Mawada = 0;
            if (grid.Select(s => s.MawadaFund) == null)
                Mawada = 1;

            //***********************************************************************
            if (model.PremiumCheck)
            {
                var PremiumCheckListValues2 = new List<PremiumCheckListItem>();

                foreach (var premium in model.PremiumCheckListItem)
                {
                    foreach (var premium2 in PremiumCheckListValues)
                    {
                        if (premium2.PremiumId == premium.PremiumId && !PremiumCheckListValues2.Any(s => s.PremiumId == premium2.PremiumId))
                            PremiumCheckListValues2.Add(new PremiumCheckListItem()
                            {
                                PremiumId = PremiumCheckListValues.Where(p => p.PremiumId == premium.PremiumId).FirstOrDefault().PremiumId,
                                Name = PremiumCheckListValues.Where(p => p.PremiumId == premium.PremiumId).FirstOrDefault().Name,
                                Value = PremiumCheckListValues.Where(p => p.PremiumId == premium.PremiumId).Sum(p => p.Value),
                                IsSelected = PremiumCheckListValues.Where(p => p.PremiumId == premium.PremiumId).FirstOrDefault().IsSelected,
                            });

                    }
                }


                model.PremiumCheckListItem = PremiumCheckListValues2;
            }
            else if (model.SalarySettlement == SalarySettlement.SalaryForm)
                model.PremiumCheckListItem = PremiumCheckListValues;

            model.PremiumListReport = PremiumCheckListReport2;



            model.Grid = grid;

            return true;

        }

    }


}

 