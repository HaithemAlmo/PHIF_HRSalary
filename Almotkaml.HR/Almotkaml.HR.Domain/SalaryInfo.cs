
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Domain
{
    public class SalaryInfo
    {
        private SalaryInfo()
        {

        }

        public SalaryInfo(BankBranch bankBranch, GuaranteeType guaranteeType, string bondNumber
            , decimal basicSalary, string securityNumber, string financialNumber
            , string fileNumber, decimal extraValue, decimal extraGeneralValue, bool groupLifeChick)
        {
            BankBranchId = bankBranch.BankBranchId;
            BankBranch = bankBranch;
            GuaranteeType = guaranteeType;
            BondNumber = bondNumber;
            BasicSalary = basicSalary;
            //ExtraWorkFixed = extraWorkFixed;
            SecurityNumber = securityNumber;
            FinancialNumber = financialNumber;
            FileNumber = fileNumber;
            ExtraValue = extraValue;
            ExtraGeneralValue = extraGeneralValue;
            GroupLifeChich = groupLifeChick;
        }

        public SalaryInfo(Employee employee)
        {
            Employee = employee;
        }
        public Employee Employee { get; set; }
        public int BankBranchId { get; set; }
        public BankBranch BankBranch { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public GuaranteeType SafeType { get; set; }
        public string BondNumber { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Tadawl { get; set; }
        public decimal ExtraValue { get; set; }
        public decimal ExtraGeneralValue { get; set; }
        public string SecurityNumber { get; set; }
        public string FileNumber { get; set; }
        public string FinancialNumber { get; set; }
        public string NameSecutry { get; set; }
        public bool GroupLifeChich { get; set; }
        public bool AdvancePremiumFreezeState { get;  set; }

        //builder
        public void Modify(Employee employee, int bankBranchId, GuaranteeType guaranteeType, string bondNumber
            , decimal basicSalary, string securityNumber, string financialNumber, IEnumerable<PremiumDto> premiumDtos
            , string fileNumber, decimal extraValue, decimal extraGeneralValue,
            GuaranteeType safeType, bool groupLifeChich,decimal tadawl)
        {
            SafeType = safeType;
            Employee = employee;
            BankBranchId = bankBranchId;
            GuaranteeType = guaranteeType;
            BondNumber = bondNumber;
            BasicSalary = basicSalary;
            //ExtraWorkFixed = extraWorkFixed;
            SecurityNumber = securityNumber;
            FinancialNumber = financialNumber;
            FileNumber = fileNumber;
            ExtraValue = extraValue;
            ExtraGeneralValue = extraGeneralValue;
            GroupLifeChich = groupLifeChich;
            Tadawl = tadawl;
            foreach (var dto in premiumDtos.ToList())
            {
                var employeePremium = employee.Premiums.FirstOrDefault(e => e.PremiumId == dto.Premium.PremiumId
                                       && e.EmployeeId == employee.EmployeeId);
                if (employeePremium == null)
                {
                    Employee.Premiums.Add(new EmployeePremium()
                    {
                        Employee = employee,
                        Premium = dto.Premium,
                        PremiumId = dto.Premium.PremiumId,
                        EmployeeId = Employee.EmployeeId,
                        ISAdvancePremmium = dto.ISAdvancePremmium,
                     
                      //  IsTemporary = dto.IsTemporary ,
                        Value = dto.Value////////////////////////////

                    });
                }
                else
                {
                    employeePremium.Modify(dto.Value, dto.IsAvance, dto.ISAdvancePremmium);
                }
            }


        }
        public static SalaryInfo New(Employee employee, int bankBranchId, GuaranteeType guaranteeType, string bondNumber
            , decimal basicSalary, string securityNumber, string financialNumber, IEnumerable<PremiumDto> premiumDtos
            , string fileNumber, decimal extraValue, decimal extraGeneralValue, GuaranteeType safeType, bool groupLifeChich,decimal tadawl)
        {
            var sararyInfo = new SalaryInfo()
            {
                SafeType = safeType,
                Employee = employee,
                BankBranchId = bankBranchId,
                GuaranteeType = guaranteeType,
                BondNumber = bondNumber,
                BasicSalary = basicSalary,
                //ExtraWorkFixed = extraWorkFixed,
                SecurityNumber = securityNumber,
                FinancialNumber = financialNumber,
                FileNumber = fileNumber,
                ExtraValue = extraValue,
                ExtraGeneralValue = extraGeneralValue,
                GroupLifeChich = groupLifeChich,
                Tadawl = tadawl
        };

            foreach (var dto in premiumDtos.ToList())
            {
                var employeePremium = employee.Premiums.FirstOrDefault(e => e.PremiumId == dto.Premium.PremiumId
                                       && e.EmployeeId == employee.EmployeeId);
                if (employeePremium == null)
                {
                    sararyInfo.Employee.Premiums.Add(new EmployeePremium()
                    {
                        Employee = employee,
                        Premium = dto.Premium,
                        PremiumId = dto.Premium.PremiumId,
                        EmployeeId = sararyInfo.Employee.EmployeeId,
                        IsAdvansePremmium = dto.IsAvance,
                   //     IsTemporary=dto.IsTemporary,
                        Value = dto.Value,////////////////////////////

                    });
                }
                else
                {
                    employeePremium.Modify(dto.Value, dto.IsAvance, dto.ISAdvancePremmium);
                }
            }
            return sararyInfo;
        }
        //public void AddListSalaryinfos(IList<SalaryUnit> salaryUnits,IList<SalaryInfo> infos)
        //{
        //    HrDbContext hh = new HrDbContext();
        //    if (Employee?.JobInfo?.CurrentSituationId != 26 && Employee?.SalaryInfo?.BasicSalary == 0 )
        //    {

        //        var mm = infos.Where(s => s.Employee.EmployeeId == Employee.EmployeeId).FirstOrDefault();
        //        var dd = hh.SalaryInfos.Find(mm);
        //        dd.BasicSalary = Employee.JobInfo.JobType == JobType.Designation
        //                                         ? Employee.GetBasicSalaryByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0) 
        //                                         : Employee.SalaryInfo.BasicSalary;
        //        dd.ExtraValue = Employee.JobInfo.JobType == JobType.Designation
        //                                         ? Employee.GetExtraValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0) 
        //                                         : Employee.SalaryInfo.ExtraValue;
        //        dd.ExtraGeneralValue = Employee.JobInfo.JobType == JobType.Designation
        //                                         ? Employee.GetExtraGeneralValueByDegree(salaryUnits
        //                                                , Employee.JobInfo.SalayClassification ?? 0) 
        //                                         : Employee.SalaryInfo.ExtraGeneralValue;




        //        hh.SaveChanges();

        //    };
        //    if (Employee?.JobInfo?.CurrentSituationId != 26 && Employee?.SalaryInfo?.BasicSalary == 0)
        //    {
        //            var mm = infos.Where(s => s.Employee.EmployeeId == Employee.EmployeeId).FirstOrDefault();
        //       var ff= hh.SalaryInfos.Find(mm.Employee.EmployeeId);
        //        ff.BasicSalary = Employee.JobInfo.JobType == JobType.Designation
        //                                              ? Employee.GetBasicSalaryByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0) / 2
        //                                              : Employee.SalaryInfo.BasicSalary;
        //        ff.ExtraValue = Employee.JobInfo.JobType == JobType.Designation
        //                                         ? Employee.GetExtraValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0) / 2
        //                                         : Employee.SalaryInfo.ExtraValue;
        //        ff.ExtraGeneralValue = Employee.JobInfo.JobType == JobType.Designation
        //                                         ? Employee.GetExtraGeneralValueByDegree(salaryUnits
        //                                                , Employee.JobInfo.SalayClassification ?? 0) / 2
        //                                         : Employee.SalaryInfo.ExtraGeneralValue;
        //        hh.SalaryInfos.Update(ff);
        //        hh.SaveChanges();
        //    };

        //}
        public void GetSalary(DateTime monthDate, DateTime monthdate2, DateTime date, IList<Holiday> holidays, IList<Salary> salarySubsended, ISettings settings,
              IList<SalaryUnit> salaryUnits)
        {


            if (Employee.AdvancePayments.Count() != 0)
            {
                var ff = "";
            }
            var year = monthDate.Year;
            decimal extraWorkHoure = 0;
            decimal extraWorkVacationHoure = 0;
            decimal valueAdvancePremiumInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                    && a.IsInside).Sum(a => a.Value);
            decimal installmentValueInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < monthDate && a.IsInside).Sum(a => a.InstallmentValue);

            decimal valueAdvancePremiumOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                    && a.IsInside == false).Sum(a => a.Value);
            decimal installmentValueOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < monthDate && a.IsInside == false).Sum(a => a.InstallmentValue);

            decimal sumAdvancePremiumInside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < monthDate)
                            .Sum(s => s.AdvancePremiumInside);

            decimal sumAdvancePremiumOutside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < monthDate)
                            .Sum(s => s.AdvancePremiumOutside);

            if (sumAdvancePremiumInside >= valueAdvancePremiumInside)
                installmentValueInside = 0;
            else if (sumAdvancePremiumInside + installmentValueInside > valueAdvancePremiumInside)
                installmentValueInside = valueAdvancePremiumInside - sumAdvancePremiumInside;

            if (sumAdvancePremiumOutside >= valueAdvancePremiumOutside)
                installmentValueOutside = 0;
            else if (sumAdvancePremiumOutside + installmentValueOutside > valueAdvancePremiumOutside)
                installmentValueOutside = valueAdvancePremiumOutside - sumAdvancePremiumOutside;

            var extraworks = Employee.Extraworks.Where(e => (e.DateFrom.Year == monthDate.Year
                                                             && e.DateFrom.Date.Month == monthDate.Month)
                                                            || (e.DateTo.Year == monthDate.Year &&
                                                                e.DateTo.Month == monthDate.Month));

            foreach (var extrawork in extraworks)
            {
                var calculatedDate = extrawork.DateFrom.Date;

                while (calculatedDate.Day <= extrawork.DateTo.Day)
                {
                    if (holidays.Any(h => h.DateFrom(year) <= calculatedDate && h.DateTo(year) >= calculatedDate))
                    {
                        extraWorkVacationHoure += extrawork.TimeCount;
                        calculatedDate = calculatedDate.AddDays(1);
                        continue;
                    }

                    switch (calculatedDate.DayOfWeek)
                    {
                        case DayOfWeek.Friday:
                            if (settings.Friday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Monday:
                            if (settings.Monday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Saturday:
                            if (settings.Saturday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Sunday:
                            if (settings.Sunday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Thursday:
                            if (settings.Thursday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Tuesday:
                            if (settings.Tuesday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        case DayOfWeek.Wednesday:
                            if (settings.Wednesday)
                                extraWorkVacationHoure += extrawork.TimeCount;
                            else
                                extraWorkHoure += extrawork.TimeCount;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(calculatedDate));
                    }

                    calculatedDate = calculatedDate.AddDays(1);
                }
            }

            if (Employee?.SalaryInfo?.BasicSalary != 0 && Employee?.JobInfo?.CurrentSituationId == 26)
            {
                var salary = new Salary()
                {
                    Employee = Employee,
                    BasicSalary = Employee.JobInfo.JobType == JobType.Designation
                                                 ? Employee.GetBasicSalaryByDegree(salaryUnits, Employee.JobInfo, Employee.JobInfo.SalayClassification ?? 0, Employee.JobInfo.leaderType ?? 0) / 2
                                                 : BasicSalary,

                    AbsenceDays = Employee.Absences.Count(a => a.Date.Month == monthDate.Month && a.Date.Year == monthDate.Year),
                    BankBranchId = BankBranchId,
                    BankBranch = BankBranch,
                    BondNumber = BondNumber,
                    Date = date,
                    MonthDate = monthDate,
                    ////حسبة الايام من غير العطل
                    //ExtraWorkHoures = extraWorkHoure,
                    // حسبة ايام العطل
                    //ExtraWorkVacationHoures = extraWorkVacationHoure,
                    //Month = month,
                    JobNumber = Employee.JobInfo.GetJobNumber(),
                    // حسبة السلفة
                    AdvancePremiumInside = installmentValueInside,
                    AdvancePremiumOutside = installmentValueOutside,
                    ExtraValue = Employee.JobInfo.JobType == JobType.Designation
                                                 ? Employee.GetExtraValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0) / 2
                                                 : ExtraValue,
                    ExtraGeneralValue = Employee.JobInfo.JobType == JobType.Designation
                                                 ? Employee.GetExtraGeneralValueByDegree(salaryUnits
                                                        , Employee.JobInfo.SalayClassification ?? 0) / 2
                                                 : ExtraGeneralValue,
                    FileNumber = FileNumber
                    //WithoutPay = // معادلة الاجازة بدون مرتب
                };

                //foreach (var premium in Employee.Premiums)
                //{
                //    salary.SalaryPremiums.Add(new SalaryPremium()
                //    {
                //        PremiumId = premium.PremiumId,
                //        Premium = premium.Premium,
                //        Salary = salary,
                //        Value = premium.Value,
                //        MonthDate = monthDate,
                //        IsAdvansePremmium = premium.Premium?.ISAdvancePremmium ?? 0,
                //        IsTemporary = premium.Premium?.IsTemporary ?? 0,
                //    });
                //}

                Employee.Salaries.Add(salary);

            }
            if (Employee?.SalaryInfo?.BasicSalary != 0 && Employee?.JobInfo?.CurrentSituationId != 26)
            {
                var salary = new Salary()
                {
                    Employee = Employee,
                    BasicSalary = Employee.JobInfo.JobType == JobType.Designation
                                    ? Employee.GetBasicSalaryByDegree(salaryUnits, Employee.JobInfo, Employee.JobInfo.SalayClassification ?? 0, Employee.JobInfo.leaderType ?? 0)
                                    : BasicSalary,
                    IsSuspended = Employee.JobInfo.JobType == JobType.Designation
                                    ? Employee.GetSubsended(salarySubsended, monthdate2)
                                    : false,

                    SuspendedNote = Employee.JobInfo.JobType == JobType.Designation
                                    ? Employee.GetSubsendedNote(salarySubsended, monthdate2)
                                    : "",
                    // SuspendedNote = getFiltersubsnded?.FirstOrDefault().SuspendedNote,

                    AbsenceDays = Employee.Absences.Count(a => a.Date.Month == monthDate.Month && a.Date.Year == monthDate.Year),
                    BankBranchId = BankBranchId,
                    BankBranch = BankBranch,
                    BondNumber = BondNumber,
                    Date = date,
                    MonthDate = monthDate,
                    ////حسبة الايام من غير العطل
                    //ExtraWorkHoures = extraWorkHoure,
                    // حسبة ايام العطل
                    //ExtraWorkVacationHoures = extraWorkVacationHoure,
                    //Month = month,
                    JobNumber = Employee.JobInfo.GetJobNumber(),
                    // حسبة السلفة
                    AdvancePremiumInside = installmentValueInside,
                    AdvancePremiumOutside = installmentValueOutside,
                    ExtraValue = Employee.JobInfo.JobType == JobType.Designation
                                    ? Employee.GetExtraValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0)
                                    : ExtraValue,
                    ExtraGeneralValue = Employee.JobInfo.JobType == JobType.Designation
                                    ? Employee.GetExtraGeneralValueByDegree(salaryUnits
                                           , Employee.JobInfo.SalayClassification ?? 0)
                                    : ExtraGeneralValue,
                    FileNumber = FileNumber
                    //WithoutPay = // معادلة الاجازة بدون مرتب
                };




                //foreach (var premium in Employee.Premiums)
                //{
                //    salary.SalaryPremiums.Add(new SalaryPremium()
                //    {
                //        PremiumId = premium.PremiumId,
                //        Premium = premium.Premium,
                //        Salary = salary,
                //        Value = premium.Value,
                //        MonthDate = monthDate,
                //        IsAdvansePremmium = premium.Premium?.ISAdvancePremmium ?? 0,
                //        IsTemporary = premium.Premium?.IsTemporary ?? 0,
                //    });
                //}

                Employee.Salaries.Add(salary);
            }
        }
        public void AdvancePremiumFreeze(bool active)
        {
            AdvancePremiumFreezeState = active;
        }
    }
}
