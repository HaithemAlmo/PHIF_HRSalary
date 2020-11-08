using Almotkaml.HR.Domain.SalaryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.Extensions;
namespace Almotkaml.HR.Domain
{
    public class Salary
    {
        internal Salary()
        {

        }
        public decimal DifrancessSetting { get; set; }
        public bool IsSubsendedSalary { get; internal set; }
        public SalaryInfo SalaryInfo { get; set; }

        public static IMonthDateHolder New() => new SalaryBuilder();
        public long SalaryId { get; private set; }
        public DateTime Date { get; internal set; }
        public DateTime MonthDate { get; internal set; }
        public int Month { get; internal set; }
        public bool IsClose { get; internal set; }
        public string SuspendedNote { get; internal set; }
        public bool IsSuspended { get; internal set; }//ايقاف مرتب
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public string JobNumber { get; internal set; }//الرقم الوظيفي
        public string TaxBondNumber { get; internal set; }
        public string SolidarityFundBondNumber { get; internal set; }//الرقم الضمان
        public string SocialSecurityFundBondNumber { get; internal set; }
        public int AbsenceDays { get; internal set; }
        public decimal ExtraValue { get; internal set; }// الزيادة
        public decimal ExtraGeneralValue { get; internal set; }// الزيادة العامة
        public decimal ExtraWorkHoures { get; internal set; }//عمل الاضافي 
        public decimal ExtraWorkVacationHoures { get; internal set; }// عمل الاضافي الممتاز
        public int BankBranchId { get; internal set; }
        public BankBranch BankBranch { get; internal set; }
        public string BondNumber { get; internal set; }//رقم الحساب المصرفي
        public string FileNumber { get; internal set; }//رق المالية
        //public decimal ExtraWorkFixed { get; internal set; }
        public decimal BasicSalary { get; internal set; }//المرتب الاساسي
        public decimal WithoutPay { get; internal set; }//بدون مرتب
        public decimal AdvancePremiumInside { get; internal set; }//سلف داخلية
        public decimal AdvancePremiumOutside { get; internal set; }//سلف خارجية
        public decimal PrepaidSalary { get; protected set; }
        public decimal Sanction { get; internal set; } //الجزاءات
                                                       //    public bool AdvancePremiumFreezeState { get; internal set; }                   //////////// //edit by Haithem 13/10/2020
        public decimal AccumulatedValue { get; internal set; } //المتراكم
        public decimal RewindValue { get; internal set; } //الترجيع
        public decimal tadawel { get; internal set; }                                                //public bool GroupLifeChick { get; internal set; } // اختيار الحياة الجماعي
                                                                                                         ////--/////////////////////////////
        public Premium Premium { get; set; }
        // public decimal Vacation { get; internal set; }  // الإجازات 


        public decimal _VacationDays() => Employee?.Vacations?.Where(v => v.VacationTypeId == (int)VacationEssential.Sick &&
         v.DateTo.Date.Month == MonthDate.Date.Month).Sum(v => v.GetDays(v.DateFrom, v.DateTo, v.VacationTypeId)) ?? 0;
        public decimal _VacationDays1() => Employee?.Vacations?.Where(v => v.VacationTypeId == (int)VacationEssential.sickleave &&
         v.DateTo.Date.Month == MonthDate.Date.Month).Sum(v => v.GetDays(v.DateFrom, v.DateTo, v.VacationTypeId)) ?? 0;
        public decimal _VacationDaysSick() => Employee?.Vacations?.Where(v => v.VacationTypeId == (int)VacationEssential.Sick &&
         v.DateTo.Date.Month == MonthDate.Date.Month && (v.DeductionMonth == MonthDate.Date.Month) && (v.DeductionYear == MonthDate.Date.Year)).Sum(v => v.GetDays(v.DateFrom, v.DateTo, v.VacationTypeId)) ?? 0;
        public decimal SickVacation(ISettings settings) => ((BasicSalary + ExtraValue + ExtraGeneralValue + (SalaryPremiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)+ Employee.Premiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value))) * (decimal)(_VacationDaysSick() / 30) * settings.SickVacation);  // settings.SickVacation /** 0*/; // * ايام الاجازة المرضية
        public decimal SickLeave(ISettings settings) => (BasicSalary + ExtraValue + ExtraGeneralValue + (SalaryPremiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)+ Employee.Premiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value))) * ((decimal)_VacationDays1() / 30) * settings.SickLeave;

        public decimal SolidarityFund(ISettings settings)
        {
            decimal SolidarityFundValu = 0;
            SolidarityFundValu = TotalSalary(settings) * settings.SolidarityFund;
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/SolidarityFundValu * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }
        public decimal accumulatedValue()
        {
            decimal accumulatedValue = 0;

            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/AccumulatedValue * 1000/*)*/ / 1000);
            return decimal.Parse(value2);

        }
        public decimal Tadawel()
        {
          

            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/ Employee.SalaryInfo.Tadawl * 1000/*)*/ / 1000);
            return decimal.Parse(value2);

        }
        public decimal rewindValue()
        {
            decimal rewindValue = 0;

            var value2 = string.Format("{0:0.000}",/* Math.Truncate(*/RewindValue * 1000/*)*/ / 1000);
            return decimal.Parse(value2);

        }
        /// <summary>
        /// حصة الشركة
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal CompanyShare(ISettings settings)
        {
            decimal value = 0;
            switch (Employee.SalaryInfo.GuaranteeType)
            {
                case GuaranteeType.All:
                    value = settings.CompanyShareAll * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.Reduced:
                    value = settings.CompanyShareReduced * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.WithoutReduced:
                    value = settings.CompanyShareWithoutReduced * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.Reduced35Year:
                    value = settings.CompanyShareReduced35Year * (TotalSalary(settings) + Absence());
                    break;
            }
            var value2 = string.Format("{0:0.000}", /*Math.Truncate(*/value * 1000/*)*/ / 1000);

            return decimal.Parse(value2);
        }
        /// <summary>
        /// حصة الموظف
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal EmployeeShare(ISettings settings)
        {
            decimal value = 0;
            switch (Employee.SalaryInfo.GuaranteeType)
            {
                case GuaranteeType.All:
                    value = settings.EmployeeShareAll * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.Reduced:
                    value = settings.EmployeeShareReduced * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.WithoutReduced:
                    value = settings.EmployeeShareWithoutReduced * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.Reduced35Year:
                    value = settings.EmployeeShareReduced35Year * (TotalSalary(settings) + Absence());
                    break;
            }
            var value2 = string.Format("{0:0.000}", value /*Math.Truncate(value * 1000) / 1000*/);

            return decimal.Parse(value2);
        }
        /// <summary>
        /// حصة الخزانة
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal SafeShare(ISettings settings)
        {
            decimal value = 0;
            switch (Employee.SalaryInfo.GuaranteeType)
            {
                case GuaranteeType.All:
                    value = settings.SafeShareAll * (TotalSalary(settings) + Absence());
                    break;
                case GuaranteeType.Reduced:
                    value = settings.SafeShareReduced * (TotalSalary(settings) + Absence());
                    break;

            }
            var value2 = string.Format("{0:0.000}", Math.Truncate(value * 1000) / 1000);

            return decimal.Parse(value2);
        }

        // public decimal StampTax(ISettings settings) => NetSalary(settings) * settings.StampTax;
        /// <summary>
        /// الخاضع
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal SubjectSalary(ISettings settings)
            => TotalSalary(settings) - SanctionDiscount() - EmployeeShare(settings) - SolidarityFund(settings) - Grouplife(settings);

        public decimal SubjectSalary1(ISettings settings)
           => NetSalary(settings) - ExemptionTax(settings) + IncomeTax(settings);

        //public decimal StampTax(ISettings settings)
        //{
        //    string stampTaxLen = ""; string stampTaxLen2 = ""; string stampTaxLen1 = ""; int Len = 0;

        //    var x = Math.Round((NetSalary(settings) * settings.StampTax), 3);
        //    stampTaxLen = x.ToString();//((NetSalary(settings) * settings.StampTax)).ToString(); 
        //    stampTaxLen1 = (stampTaxLen).Substring(0, (stampTaxLen).LastIndexOf("."));
        //    stampTaxLen2 = (stampTaxLen).Substring((stampTaxLen).LastIndexOf(".") + 1, 3);
        //    Len = Convert.ToInt32((stampTaxLen2.ToString()).Substring(0, 3));
        //    if (Len > 500)
        //    {
        //        stampTaxLen = Math.Round(x).ToString();
        //        //stampTaxLen2 = ".500";
        //        //stampTaxLen = stampTaxLen1 + stampTaxLen2;
        //    }
        //    else
        //    {
        //        stampTaxLen2 = ".500";
        //        stampTaxLen = stampTaxLen1 + stampTaxLen2;

        //    }
        //    //stampTaxLen = Math.Round(x).ToString();
        //    decimal stampTax = 0;
        //    stampTax = Convert.ToDecimal(stampTaxLen);//(NetSalary(settings) * settings.StampTax);
        //    var value = string.Format("{0:0.000}", Math.Truncate(stampTax * 1000) / 1000);
        //    return decimal.Parse(value);

        //}

        //public decimal StampTax(ISettings settings) => (TotalSalary(settings) * settings.StampTax);

        /// <summary>
        /// /////////////////منفرد الخاضع
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal Subject(ISettings settings)
                => TotalSalary(settings) /*- Absence()*/ - SanctionDiscount() - ExemptionTax(settings) - EmployeeShare(settings) - SolidarityFund(settings) - Grouplife(settings);







        /// <summary>
        /// ضريبة الدمغة
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal StampTax(ISettings settings)
        { 
            var Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId).Sum(pp => pp.InstallmentValue);
            decimal StampTaxvalue = 0;
            StampTaxvalue = 
                ((TotalSalary(settings) 
                -(SolidarityFund(settings)  + JihadTax(settings) + IncomeTax(settings) + Tadawel() + EmployeeShare(settings) + Grouplife(settings) + AdvancePeymentFreez() + AdvancePeymentNOtFreez() + DiscountPrimuimm())
                + Math.Round((Employee.Premiums.Where(p => p.Premium.IsSubject == IsSubject.IsNotSubject && p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)), 3)
            + rewindValue())*settings.StampTax);
            var value2 = string.Format("{0:0.000}", Math.Truncate(StampTaxvalue * 1000) / 1000);
            return decimal.Parse(value2);

        }

        /// <summary>
        /// EDIT BY HAITHEM الحياة الجماعي
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal Grouplife(ISettings settings)
        {
            if (Employee.SalaryInfo.GroupLifeChich == false)
            {
                decimal Grouplife = 0;
                Grouplife = ((TotalSalary(settings) + Absence()) * settings.Grouplife);
                var value2 = string.Format("{0:0.000}", Math.Truncate(Grouplife * 1000) / 1000);
                return decimal.Parse(value2);
            }
            else return 0;
        }

        // public decimal JihadTax(ISettings settings) => (SubjectSalary(settings) * settings.JihadTax);

        /// <summary>
        /// ضريبة الجهاد
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal JihadTax(ISettings settings)
        {
            decimal jihadValu = 0;
            jihadValu = Math.Round(((TotalSalary(settings) - EmployeeShare(settings) - SolidarityFund(settings) - Absence()) * settings.JihadTax), 3);
            var value2 = string.Format("{0:0.000}", Math.Truncate(jihadValu * 1000) / 1000);
            return decimal.Parse(value2);

        }


        /// <summary>
        /// مجموع الخصميات
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        /// 

        public decimal TotalDiscount(ISettings settings)

        {
            //decimal stamp = 0;
            //stamp = StampTax(settings);
            var Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId).Sum(pp => pp.InstallmentValue);
            decimal DiscountValues = 0;
            DiscountValues = +SolidarityFund(settings)
                     + JihadTax(settings) + IncomeTax(settings) + Tadawel() + EmployeeShare(settings) + Grouplife(settings) + AdvancePeymentFreez() + AdvancePeymentNOtFreez() + DiscountPrimuimm()+StampTax(settings)/* + StampTax(settings)*/;//*+ CompanyShare(settings) /*(SalaryPremiums.Where(p => p.Premium.IsSubject == false && p.Premium.IsTemporary == false && p.Premium.DiscountOrBoun == DiscountOrBoun.Discount).Sum(p => p.Value)*/;

            //if(SalaryPremiums.Any(p=>p.Premium.DiscountOrBoun == DiscountOrBoun.Discount))
            //{
            //   var Total= DiscountValues + SalaryPremiums.Where(p => p.Premium.IsSubject == false).Sum(p => p.Value);
            //    DiscountValues = Total;
            //}
            // var Advance = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId).Sum(pp => pp.InstallmentValue);
            //var TotlaSum = Advance1 + DiscountValues;
            //DiscountValues = TotlaSum ?? 0;
            var value2 = string.Format("{0:0.000}", Math.Truncate(DiscountValues * 1000) / 1000);

            return decimal.Parse(value2);
        }



        public decimal AdvancePeymentNOtFreez()

        {
            decimal Advance1 = 0;

            decimal DiscountValues = 0;
            if (Employee.SalaryInfo.AdvancePremiumFreezeState == false)

            {
                Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId && s.Premium?.IsFrozen == IsFrozen.IsNotFrozen && s.Premium?.ISAdvancePremmium == ISAdvancePremmium.ISAdvance)?.Sum(pp => pp.InstallmentValue) ?? 0;
            }
            else
            {
                Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId && s.Premium?.IsFrozen == IsFrozen.IsNotFrozen && s.Premium?.ISAdvancePremmium == ISAdvancePremmium.ISAdvance)?.Sum(pp => pp.InstallmentValue) ?? 0;

            }
            DiscountValues = Advance1;



            var value2 = string.Format("{0:0.000}", Math.Truncate(DiscountValues * 1000) / 1000);

            return decimal.Parse(value2);


        }
        public decimal AdvancePeymentFreez()

        {
            decimal Advance1 = 0;

            decimal DiscountValues = 0;
            if (Employee.SalaryInfo.AdvancePremiumFreezeState==false)

            {
                Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId && s.Premium?.IsFrozen == IsFrozen.IsFrozen && s.Premium?.ISAdvancePremmium == ISAdvancePremmium.ISAdvance)?.Sum(pp => pp.InstallmentValue) ?? 0;
            }
            else
            {
                return 0;
            }
            DiscountValues = Advance1 ;



            var value2 = string.Format("{0:0.000}", Math.Truncate(DiscountValues * 1000) / 1000);

            return decimal.Parse(value2);

        }

        public decimal DiscountPrimuimm()

        {
           // var Advance1 = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId).Sum(pp => pp.InstallmentValue);
            decimal DiscountValues = 0;
            DiscountValues = (SalaryPremiums.Where(p => /*p.Premium.IsSubject == IsSubject.IsNotSubject  &&*/ p.Premium.DiscountOrBoun == DiscountOrBoun.Discount && p.Premium.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance).Sum(p => p.Value)
                + Employee.Premiums.Where(p => /*p.Premium.IsSubject == IsSubject.IsNotSubject  &&*/ p.Premium.DiscountOrBoun == DiscountOrBoun.Discount && p.Premium.ISAdvancePremmium == ISAdvancePremmium.ISNotAdvance).Sum(p => p.Value));

            //if(SalaryPremiums.Any(p=>p.Premium.DiscountOrBoun == DiscountOrBoun.Discount))
            //{
            //   var Total= DiscountValues + SalaryPremiums.Where(p => p.Premium.IsSubject == false).Sum(p => p.Value);
            //    DiscountValues = Total;
            //}
            // var Advance = Employee?.AdvancePayments.Where(s => s.EmployeeId == EmployeeId).Sum(pp => pp.InstallmentValue);


            var value2 = string.Format("{0:0.000}", Math.Truncate(DiscountValues * 1000) / 1000);

            return decimal.Parse(value2);
        }

        /// <summary>
        /// ضريبة الدخل
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal IncomeTax(ISettings settings)
        {
            decimal incomeTax = 0;
            if (SubjectSalary(settings) - ExemptionTax(settings) <= 1000)
                return (SubjectSalary(settings) - ExemptionTax(settings)) * settings.IncomeTaxOne;

            var value = 1000 * settings.IncomeTaxOne;
            incomeTax = (SubjectSalary(settings) - ExemptionTax(settings) - 1000) * settings.IncomeTaxTwo;
            var value2 = string.Format("{0:0.000}", Math.Truncate(incomeTax * 1000) / 1000);

            return decimal.Parse(value2) + value;
        }

        /// <summary>
        /// ضريبة الاعفاء
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal ExemptionTax(ISettings settings)
        {
            decimal exemptionTax = 0;
            if (Employee.SocialStatus == SocialStatus.Single)
            {
                exemptionTax = settings.ExemptionTaxOne;
            }
            else if ((Employee.SocialStatus == SocialStatus.Divorcee || Employee.SocialStatus == SocialStatus.Marrid ||
                     Employee.SocialStatus == SocialStatus.Widower || Employee.SocialStatus == SocialStatus.MarridAndNurture) && Employee.Gender == Gender.Male)
            {
                if (Employee.ChildernCount > 0)
                    exemptionTax = settings.ExemptionTaxTwo
                                   + (settings.ChilderPermium
                                   * Employee.ChildernCount ?? 0);
                else
                    exemptionTax = settings.ExemptionTaxTwo;
            }
            else if ((Employee.SocialStatus == SocialStatus.Divorcee ||
                   Employee.SocialStatus == SocialStatus.Widower || Employee.SocialStatus == SocialStatus.MarridAndNurture) && Employee.Gender == Gender.Female)
            {
                if (Employee.ChildernCount > 0)
                    exemptionTax = settings.ExemptionTaxTwo
                                   + (settings.ChilderPermium
                                   * Employee.ChildernCount ?? 0);
                else
                    exemptionTax = settings.ExemptionTaxTwo;
            }
            else if ((Employee.SocialStatus == SocialStatus.Marrid) && Employee.Gender == Gender.Female)
            {
                exemptionTax = settings.ExemptionTaxOne;
            }
            var value = string.Format("{0:0.000}", Math.Truncate(exemptionTax * 1000) / 1000);

            return decimal.Parse(value);
        }

        ////
        /////////////////////////////////////////////////////////// // LIC Haithem 7/4/2020

        /// <summary>
        /// اجمالي الخصميات
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal Discount(ISettings settings)
        {
            //// update by Haithem  



            decimal dd = 0;

            dd = (SalaryPremiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Discount).Sum(p => p.Value));

            var value = string.Format("{0:0.000}", Math.Truncate(dd * 1000) / 1000);

            return decimal.Parse(value);




        }

        /// <summary>
        /// اجمالي الخصميات
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal AllBouns(ISettings settings)
        {
            //// update by Haithem  



            decimal dd = 0;

            //if (SalaryPremiums.Any(p => p.Premium.IsSubject == true && p.Premium.IsSubject == true &&(p.Premium.DiscountOrBoun == DiscountOrBoun.Boun || p.Premium.DiscountOrBoun == DiscountOrBoun.Boun)))
            //{

            dd = (SalaryPremiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)+Employee.Premiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value));


            //}


            var value = string.Format("{0:0.000}", Math.Truncate(dd * 1000) / 1000);

            return decimal.Parse(value);




        }




        decimal dd, gg, hh = 0;
        /// <summary>
        /// صافي المرتب
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal NetSalary(ISettings settings)
        {
            //// update by Haithem  
            decimal dd = 0;
            dd = FinalSalary(settings) + StampTax(settings);
            var value = string.Format("{0:0.000}", Math.Truncate(dd * 1000) / 1000);

            return decimal.Parse(value);




        }
        /// <summary>
        /// اجمالي المرتب
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal TotalSalary(ISettings settings)
        {
            decimal basicSalary;
            //if (Employee.Vacations?.Any(d => d.VacationType.VacationEssential == VacationEssential.Sick))
            //    basicSalary = (BasicSalary + ExtraValue + ExtraGeneralValue + AccumulatedValue) * SickVacation(settings);
            //else if (Employee.Vacations.Any(d => d.VacationType.VacationEssential == VacationEssential.sickleave))
            //    basicSalary = (BasicSalary + ExtraValue + ExtraGeneralValue + AccumulatedValue) * SickLeave(settings);
            //else
            basicSalary = (BasicSalary + ExtraValue + ExtraGeneralValue + accumulatedValue());

            var employeePremium = Employee.Premiums.Count > 0 ? Employee.Premiums.Where(p => p.Premium.IsSubject == IsSubject.IsSubject).Sum(p => p.Value) : 0;
            var value3 = basicSalary + SalaryPremiums.Where(p => p.Premium.IsSubject==IsSubject.IsSubject &&p.Premium.DiscountOrBoun==DiscountOrBoun.Boun).Sum(p => p.Value) + Employee.Premiums.Where(p => p.Premium.IsSubject == IsSubject.IsSubject && p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value) + ExtraWork(settings) + ExtraWorkVacation(settings) + ExtraWork(settings) - Absence() - SickVacation(settings) - SickLeave(settings);
            var value2 = string.Format("{0:0.000}", value3);

            return decimal.Parse(value2);

        }

        /// <summary>
        /// الاضافي
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal ExtraWork(ISettings settings)
        {
            if (ExtraWorkHoures != 0 && settings.ExtraWork != 0)
                return (BasicSalary + ExtraValue + ExtraGeneralValue) / 210 * (ExtraWorkHoures * settings.ExtraWork);
            return 0;
        }
        /// <summary>
        /// الاضافي الممتاز
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal ExtraWorkVacation(ISettings settings)
        {
            if (ExtraWorkVacationHoures != 0 && settings.ExtraWorkVacation != 0)
                return (BasicSalary + ExtraValue + ExtraGeneralValue) / 210 * (ExtraWorkVacationHoures
                       * settings.ExtraWorkVacation);
            return 0;
        }
        public decimal SanctionDiscount1()
        {
            decimal Ab = 0;

            if (Sanction != 0)

                Ab = (BasicSalary) / 30 * Sanction;
            var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

            return decimal.Parse(value);
        }
        /// <summary>
        /// الغياب
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// الغياب
        /// </summary>
        /// <returns></returns>
        public decimal Absence()
        {
            decimal Ab = 0;

            //if (AbsenceDays != 0)

            //    Ab= (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * AbsenceDays;
            // if (AbsenceDays != 0)
            DateTime monthDate;
            DateTime date = DateTime.Now.Date;
            monthDate = MonthDate;


            //&& s.Date.Month == monthDate.Month
            //    && s.Date.Year == monthDate.Year)
            int Abs = Employee?.Absences.Where(s => s.EmployeeId == EmployeeId
                   && s.DeductionMonth == monthDate.Month
                && s.DeductionYear == monthDate.Year).Sum(abc => abc.AbsenceDay) ?? 0;

            if (Abs != 0)
            {
                Ab = (BasicSalary + ExtraValue + ExtraGeneralValue + (SalaryPremiums.Where(p => p.Premium.IsSubject==IsSubject.IsSubject).Sum(p => p.Value))) / 30 * Abs;

            }

            var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

            return decimal.Parse(value);
        }

        public decimal Absence(DateTime date)
        {
            decimal Ab = 0;

            //if (AbsenceDays != 0)

            //    Ab= (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * AbsenceDays;
            // if (AbsenceDays != 0)

            DateTime monthDate;
            monthDate = date;

            int Abs = Employee?.Absences.Where(s => s.EmployeeId == EmployeeId
                && s.Date.Month == monthDate.Month
                && s.Date.Year == monthDate.Year).Sum(abc => abc.AbsenceDay) ?? 0;

            if (Abs != 0)
                Ab = (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * Abs;

            var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

            return decimal.Parse(value);
        }
        /// <summary>
        /// أيام الغياب
        public int AbsenceDayEmployee(DateTime date)
        {
            DateTime monthDate;
            monthDate = date;

            int Abs = Employee?.Absences.Where(s => s.EmployeeId == EmployeeId
                && s.Date.Month == monthDate.Month
                && s.Date.Year == monthDate.Year).Sum(abc => abc.AbsenceDay) ?? 0;



            return Abs;
        }

        //***////*/*/*//////////////// الجزاءات

        /// <summary>
        /// الجزاءات
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// الجزاءات
        /// </summary>
        /// <returns></returns>
        public decimal Sanction1()
        {
            decimal Ab = 0;

            //if (AbsenceDays != 0)

            //    Ab= (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * AbsenceDays;
            // if (AbsenceDays != 0)
            DateTime monthDate;
            DateTime date = DateTime.Now.Date;
            monthDate = MonthDate;
            //int g = int.Parse(monthDate.Month.ToString());

            int Abs = Employee?.Sanctions.Where(s => s.EmployeeId == EmployeeId
                && s.DeductionMonth == monthDate.Month
                && s.DeductionYear == monthDate.Year).Sum(abc => abc.SanctionDay) ?? 0;

            if (Abs != 0)
                Ab = (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * Abs;

            var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

            return decimal.Parse(value);
        }

        public decimal SanctionDiscount()
        {
            decimal Ab = 0;

            int Abs = Employee?.Sanctions.Where(s => s.EmployeeId == EmployeeId
                && s.Date.Month == MonthDate.Month
                && s.Date.Year == MonthDate.Year).Sum(abc => abc.Date.Day) ?? 0;

            if (Abs != 0)
                Ab = (BasicSalary + ExtraValue + ExtraGeneralValue + (SalaryPremiums.Where(p => p.Premium.IsSubject==IsSubject.IsSubject).Sum(p => p.Value))) / 30 * Abs;

            var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

            return decimal.Parse(value);


        }
        /// <summary>
        /// أيام العقوبة
        public int SanctionDayEmployee(DateTime date)
        {
            DateTime monthDate;
            monthDate = date;

            int Abs = Employee?.Sanctions.Where(s => s.EmployeeId == EmployeeId
                && s.Date.Month == monthDate.Month
                && s.Date.Year == monthDate.Year).Sum(abc => abc.Date.Day) ?? 0;



            return Abs;
        }



        ///// <summary>
        ///// حساب منفرد للغياب
        ///// </summary>
        ///// <returns></returns>
        //public decimal Absence()
        //{
        //    decimal Ab = 0;

        //    if (AbsenceDays != 0)

        //        Ab = (BasicSalary + ExtraValue + ExtraGeneralValue) / 30 * AbsenceDays;
        //    var value = string.Format("{0:0.000}", Math.Truncate(Ab * 1000) / 1000);

        //    return decimal.Parse(value);
        //}
        /// <summary>
        /// المحول للمصرف
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public decimal FinalSalary(ISettings settings) => TotalSalary(settings) - TotalDiscount(settings)
            + Math.Round((Employee.Premiums.Where(p => p.Premium.IsSubject == IsSubject.IsNotSubject && p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)), 3) 
            + rewindValue();
        /// <summary>
        /// المحول للمصرف
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
 public decimal FinalSalaryStamp(ISettings settings) => FinalSalary(settings)+StampTax(settings);
        
        //+ SalaryPremiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)
        //+ Employee.Premiums.Where(p => p.Premium.DiscountOrBoun == DiscountOrBoun.Boun).Sum(p => p.Value)
        /* NetSalary(settings) - (SalaryPremiums.Where(p => p.Premium.IsSubject == false && p.Premium.DiscountOrBoun == DiscountOrBoun.Discount).Sum(p => p.Value) - (AdvancePremiumInside + AdvancePremiumOutside) - PrepaidSalary - Absence() );*/

        //add by ali alherbade
        public decimal GetBasicSalary()
        {

            var result = BasicSalary + ExtraValue + ExtraGeneralValue + Absence(); 
            var value = string.Format("{0:0.000}", result);
            return decimal.Parse(value);

        }
        /// <summary>
        /// المرتب الاساسي للطلبة 
        ///  add by ali alherbade 20-07-2019
        /// </summary>
        /// <returns>المرتب الاساسي + الزياد (100)/ 4</returns>
        public decimal StudyBasicSalary() => (BasicSalary + ExtraValue) / 4;

        //السلف
        public decimal InstallmentValueAdvancePremiumInside()
        {

            decimal installmentValueInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate.Month < MonthDate.Month && a.IsInside).Sum(a => a.InstallmentValue);

            return installmentValueInside;
        }
        // السلف عادية - غير مؤقتة
        public decimal ValueAdvancePremiumIsNotTemporary()
        {

            decimal IsNotTemporaryValue = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate.Month == MonthDate.Month && a.Premium.IsTemporary == IsTemporary.IsNotTemporary).Sum(a => a.InstallmentValue);

            return IsNotTemporaryValue;
        }
        // السلف مؤقتة
        public decimal ValueAdvancePremiumIsTemporary()
        {

            decimal IsTemporaryValue = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate.Month == MonthDate.Month && a.Premium.IsTemporary==IsTemporary.IsTemporary).Sum(a => a.InstallmentValue);

            return IsTemporaryValue;
        }
        public decimal InstallmentValueAdvancePremiumOutside()
        {

            decimal installmentValueOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                 && a.DeductionDate.Month < MonthDate.Month && a.IsInside == false).Sum(a => a.InstallmentValue);

            return installmentValueOutside;
        }
        public decimal InstallmentValue()
        {
            decimal valueAdvancePremiumInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                    && a.IsInside).Sum(a => a.Value);
            decimal installmentValueInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < MonthDate && a.IsInside).Sum(a => a.InstallmentValue);

            decimal valueAdvancePremiumOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                    && a.IsInside == false).Sum(a => a.Value);
            decimal installmentValueOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < MonthDate && a.IsInside == false).Sum(a => a.InstallmentValue);

            decimal sumAdvancePremiumInside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < MonthDate)
                            .Sum(s => s.AdvancePremiumInside);

            decimal sumAdvancePremiumOutside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < MonthDate)
                            .Sum(s => s.AdvancePremiumOutside);

            if (sumAdvancePremiumInside >= valueAdvancePremiumInside)
                installmentValueInside = 0;
            else if (sumAdvancePremiumInside + installmentValueInside > valueAdvancePremiumInside)
                installmentValueInside = valueAdvancePremiumInside - sumAdvancePremiumInside;

            if (sumAdvancePremiumOutside >= valueAdvancePremiumOutside)
                installmentValueOutside = 0;
            else if (sumAdvancePremiumOutside + installmentValueOutside > valueAdvancePremiumOutside)
                installmentValueOutside = valueAdvancePremiumOutside - sumAdvancePremiumOutside;

            return installmentValueInside + installmentValueOutside;
        }
        public ICollection<EmployeePremium> EmployeePremium { get; } = new HashSet<EmployeePremium>();
        //public ICollection<EmployeePremium> SalaryPremiums { get; } = new HashSet<SalaryPremium>();

        public ICollection<SalaryPremium> SalaryPremiums { get; } = new HashSet<SalaryPremium>();
        // public ICollection<SalaryInfo> SalaryInfo { get; } = new HashSet<SalaryInfo>();
        public ICollection<TemporaryPremium> TemporaryPremiums { get; } = new HashSet<TemporaryPremium>();
        public void Closed() => IsClose = true;
        public void SuspendedTrue(string suspendedNote)
        {
            SuspendedNote = suspendedNote;
            IsSuspended = true;
        }
        public void InsideAdvancePremiumFreeze()
        {
            AdvancePremiumInside = 0;
        }
        public void OutsideAdvancePremiumFreeze()
        {
            AdvancePremiumOutside = 0;
        }
        public void InsideAdvancePremiumAllow()
        {
            decimal valueAdvancePremiumInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                   && a.IsInside).Sum(a => a.Value);
            decimal installmentValueInside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < MonthDate && a.IsInside).Sum(a => a.InstallmentValue);

            decimal sumAdvancePremiumInside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < MonthDate)
                            .Sum(s => s.AdvancePremiumInside);

            if (sumAdvancePremiumInside >= valueAdvancePremiumInside)
                installmentValueInside = 0;
            else if (sumAdvancePremiumInside + installmentValueInside > valueAdvancePremiumInside)
                installmentValueInside = valueAdvancePremiumInside - sumAdvancePremiumInside;

            AdvancePremiumInside = installmentValueInside;
        }
        public void OutsideAdvancePremiumAllow()
        {
            decimal valueAdvancePremiumOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                                    && a.IsInside == false).Sum(a => a.Value);
            decimal installmentValueOutside = Employee.AdvancePayments.Where(a => a.EmployeeId == Employee.EmployeeId
                                    && a.DeductionDate < MonthDate && a.IsInside == false).Sum(a => a.InstallmentValue);

            decimal sumAdvancePremiumOutside = Employee.Salaries.Where(s => s.IsClose && s.MonthDate < MonthDate)
                            .Sum(s => s.AdvancePremiumOutside);

            if (sumAdvancePremiumOutside >= valueAdvancePremiumOutside)
                installmentValueOutside = 0;
            else if (sumAdvancePremiumOutside + installmentValueOutside > valueAdvancePremiumOutside)
                installmentValueOutside = valueAdvancePremiumOutside - sumAdvancePremiumOutside;

            AdvancePremiumOutside = installmentValueOutside;
        }
        public void SuspendedSalary() => IsSubsendedSalary = true;

        public void SuspendedFalse() => IsSuspended = false;
        public void Modify(string taxBondNumber, string solidarityFundBondNumber, string socialSecurityFundBondNumber)
        {
            TaxBondNumber = taxBondNumber;
            SolidarityFundBondNumber = solidarityFundBondNumber;
            SocialSecurityFundBondNumber = socialSecurityFundBondNumber;
        }
        public void ModifySubsended()
        {
            IsSuspended = true;
        }
        public void Modify(decimal extraWorkHoures, decimal extraWorkVacationHoures, int absenceDays
            , decimal prepaidSalary, decimal sanction, decimal advancePremiumInside, decimal advancePremiumOutside, decimal accumulatedValue, decimal rewindValue
            , IEnumerable<PremiumDto> premiumDtos)
        {
            if (IsClose)
                throw new Exception("cannot modify the salaies is closed");

            PrepaidSalary = prepaidSalary;
            Sanction = sanction;
            AdvancePremiumInside = advancePremiumInside;
            AdvancePremiumOutside = advancePremiumOutside;
            AbsenceDays = absenceDays;
            ExtraWorkHoures = extraWorkHoures;
            ExtraWorkVacationHoures = extraWorkVacationHoures;
            AccumulatedValue = accumulatedValue;
            RewindValue = rewindValue;
            foreach (var dto in premiumDtos.ToList())
            {
                var salaryPremium = SalaryPremiums.FirstOrDefault(e => e.PremiumId == dto.Premium.PremiumId
                                                                           && e.SalaryId == SalaryId);

                if (salaryPremium == null)
                {

                    SalaryPremiums.Add(new SalaryPremium()
                    {
                        Salary = this,
                        Premium = dto?.Premium,
                        PremiumId = dto?.Premium.PremiumId ?? 0,
                        SalaryId = SalaryId,
                        IsAdvansePremmium = dto.Premium?.ISAdvancePremmium??0,
                        IsTemporary=dto.Premium?.IsTemporary??0,
                        Value = dto.Value,
                        MonthDate= this.MonthDate,
                        ////////////////////////////
                    });
                }

                else
                {
                    salaryPremium.Modify(dto.Value);
                }
                //foreach (var premium in Employee.Premsiums)
                //{
                //    var salaryPremium = SalaryPremiums.FirstOrDefault(e => e.PremiumId == premium.PremiumId
                //                                                           && e.SalaryId == SalaryId);

                //    if (salaryPremium == null)
                //    {

                //        SalaryPremiums.Add(new SalaryPremium()
                //        {
                //            Salary = this,
                //            Premium = premium?.Premium,
                //            PremiumId = premium?.PremiumId ?? 0,
                //            SalaryId = SalaryId,

                //            Value = premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance && premium.IsTemporary == IsTemporary.IsNotTemporary ? premium.AdvancePayment.InstallmentValue : premium.Value

                //            ////////////////////////////
                //        });
                //    }

                //    else
                //    {
                //        if (premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance && premium.IsTemporary == IsTemporary.IsNotTemporary)

                //            salaryPremium.Modify(premium.AdvancePayment.InstallmentValue);

                //        else
                //        {

                //            salaryPremium.Modify(premium.Value);
                //        }
                //    }
                //}


            }
        }
        public void Update(IList<Holiday> holidays, IList<Employee> employees, ISettings settings
            , IList<SalaryUnit> salaryUnits)
        {
            var year = MonthDate.Year;
            decimal extraWorkHoure = 0;
            decimal extraWorkVacationHoure = 0;

            var extraworks = Employee.Extraworks.Where(e => (e.DateFrom.Year == MonthDate.Year
                                                             && e.DateFrom.Date.Month == MonthDate.Month)
                                                            || (e.DateTo.Year == MonthDate.Year &&
                                                                e.DateTo.Month == MonthDate.Month));

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
                    // التأكد من التاريخ(اخر يوم من الشهر)
                    if (calculatedDate.Day < DateTime.DaysInMonth(calculatedDate.Year, calculatedDate.Month))
                        calculatedDate = calculatedDate.AddDays(1);
                    else
                        break;
                }
            }
            //var employee = employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
            //if (employee != null)
            //{
            BasicSalary = Employee.JobInfo.JobType == JobType.Designation
                ? Employee.GetBasicSalaryByDegree(salaryUnits, Employee.JobInfo, Employee.JobInfo.SalayClassification ?? 0, Employee.JobInfo.leaderType ?? 0)
                : Employee.SalaryInfo.BasicSalary;
            AbsenceDays = Employee.Absences.Count(a => a.Date.Month == MonthDate.Month && a.Date.Year == MonthDate.Year);
            BankBranchId = Employee.SalaryInfo.BankBranchId;
            ExtraValue = Employee.JobInfo.JobType == JobType.Designation
                ? Employee.GetExtraValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0)
                : Employee.SalaryInfo.ExtraValue;
            ExtraGeneralValue = Employee.JobInfo.JobType == JobType.Designation
                ? Employee.GetExtraGeneralValueByDegree(salaryUnits, Employee.JobInfo.SalayClassification ?? 0)
                : Employee.SalaryInfo.ExtraGeneralValue;
            BondNumber = Employee.SalaryInfo.BondNumber;
            FileNumber = Employee.SalaryInfo.FileNumber;
            ////حسبة الايام من غير العطل
            //ExtraWorkHoures = extraWorkHoure;
            // حسبة ايام العطل
            //ExtraWorkVacationHoures = extraWorkVacationHoure;
            JobNumber = Employee?.JobInfo?.GetJobNumber();

            
            foreach (var premium in Employee.Premiums)
            {
                var salaryPremium = SalaryPremiums.FirstOrDefault(e => e.PremiumId == premium.PremiumId
                                                                       && e.SalaryId == SalaryId);

//                if (salaryPremium == null)
//                {

//                    SalaryPremiums.Add(new SalaryPremium()
//                    {
//                        Salary = this,
//                        Premium = premium?.Premium,
//                        PremiumId = premium?.PremiumId ?? 0,
//                        SalaryId = SalaryId,
//                        IsAdvansePremmium = premium.Premium?.ISAdvancePremmium ?? 0,
//                        IsTemporary = premium.Premium?.IsTemporary ?? 0,
//                        Value = premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance && premium.Premium.IsTemporary == IsTemporary.IsNotTemporary ? premium.AdvancePayment.InstallmentValue : premium.Value,
//                        MonthDate= this.MonthDate,
                        
//                        ////////////////////////////
//                    });
//                }

//                else
//                {
//                    if (premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance && premium.Premium.IsTemporary == IsTemporary.IsNotTemporary)

//                        salaryPremium.Modify(premium.ISAdvancePremmium == ISAdvancePremmium.ISAdvance && premium.Premium.IsTemporary == IsTemporary.IsNotTemporary ? premium.AdvancePayment?.InstallmentValue ??0: premium.Value
//);

//                    else
//                    {

//                        salaryPremium.Modify(premium.Value);
//                    }
                //}



            }
            //foreach (var salaryPremium in SalaryPremiums)
            //{
            //    salaryPremium.Modify(premium.Value);
            //}


            //public decimal TotalSolidarityFund() => TotalSalary()*ISettings<ISettings>.GetISettings.SolidarityFund;

            //public decimal SubjectSalary
            //{
            //    decimal value = 0;
            //    switch (Employee.SalaryInfo.GuaranteeType)
            //    {
            //        case GuaranteeType.All:
            //            value = TotalSalary() - SolidarityFund - ISettings<ISettings>.GetISettings.EmployeeShareAll;
            //            break;
            //        case GuaranteeType.Reduced:
            //            value = TotalSalary() - SolidarityFund - ISettings<ISettings>.GetISettings.EmployeeShareReduced;
            //            break;
            //        case GuaranteeType.WithoutReduced:
            //            value = TotalSalary() - SolidarityFund -
            //                    ISettings<ISettings>.GetISettings.EmployeeShareWithoutReduced;
            //            break;
            //        case GuaranteeType.Reduced35Year:
            //            value = TotalSalary() - SolidarityFund -
            //                    ISettings<ISettings>.GetISettings.EmployeeShareReduced35Year;
            //            break;
            //    }
            //    return value;
            //}

            //public decimal TotalIncomeTax()
            //{
            //    decimal exemptionTax = 0;
            //    decimal incomeTax = 0;
            //    if (Employee.SocialStatus == SocialStatus.Single)
            //    {
            //        exemptionTax = ISettings<ISettings>.GetISettings.ExemptionTaxOne;
            //    }
            //    else if (Employee.SocialStatus == SocialStatus.Divorcee || Employee.SocialStatus == SocialStatus.Marrid ||
            //             Employee.SocialStatus == SocialStatus.Widower)
            //    {
            //        if (Employee.ChildernCount > 0)
            //            exemptionTax = ISettings<ISettings>.GetISettings.ExemptionTaxTwo + Employee.ChildernCount ?? 0
            //                * ISettings<ISettings>.GetISettings.ChilderPermium;
            //        else
            //            exemptionTax = ISettings<ISettings>.GetISettings.ExemptionTaxTwo;
            //    }
            //    if (SubjectSalary - exemptionTax <= 1000)
            //    {
            //        incomeTax = SubjectSalary * ISettings<ISettings>.GetISettings.IncomeTaxOne;
            //    }
            //    if (SubjectSalary - exemptionTax > 1000)
            //    {
            //        incomeTax += SubjectSalary - 1000 * ISettings<ISettings>.GetISettings.IncomeTaxTwo;
            //    }
            //    return incomeTax;
            //}
            //public decimal TotalStampTax() => Math.Round(NetSalary - ISettings<ISettings>.GetISettings.StampTax, MidpointRounding.ToEven);
        }
    }
}