using System;

namespace Almotkaml.HR.Domain
{
    public class Settings : ISettings
    {
        private DateTime dateTime;

        public IYearlyVacationRule YearlyVacationRule { get; private set; }
        public DateTime Date { get; protected set; }
        public decimal SickVacation { get; protected set; }
        public decimal SickLeave { get; protected set; }
        public decimal ExtraWork { get; protected set; }
        public decimal ExtraWorkVacation { get; protected set; }
        public decimal SolidarityFund { get; protected set; }
        public decimal EmployeeShareAll { get; protected set; }
        public decimal EmployeeShareReduced { get; protected set; }
        public string TextboxFrom { get; protected set; }
        public string TextboxTo { get; protected set; }

        public string NumberCheck { get; protected set; }
        public int Number { get; protected set; }
        public decimal SafeShareAll { get; protected set; }
        public decimal SafeShareReduced { get; protected set; }
        public decimal EmployeeShareWithoutReduced { get; protected set; }
        public decimal EmployeeShareReduced35Year { get; protected set; }
        public decimal CompanyShareAll { get; protected set; }
        public decimal CompanyShareReduced { get; protected set; }
        public decimal CompanyShareWithoutReduced { get; protected set; }
        public decimal CompanyShareReduced35Year { get; protected set; }
        public decimal JihadTax { get; protected set; }
        public decimal ExemptionTaxOne { get; protected set; }
        public decimal ExemptionTaxTwo { get; protected set; }
        public decimal IncomeTaxOne { get; protected set; }
        public decimal IncomeTaxTwo { get; protected set; }
        public decimal StampTax { get; protected set; }
        public decimal ChilderPermium { get; protected set; }
        public bool Saturday { get; protected set; }
        public bool Sunday { get; protected set; }
        public bool Monday { get; protected set; }
        public bool Thursday { get; protected set; }
        public bool Wednesday { get; protected set; }
        public bool Tuesday { get; protected set; }
        public bool Friday { get; protected set; }
        public bool VacationIncludesHolidays { get; set; }
        public decimal Grouplife { get; set; }

        public decimal AccumulatedValue { get; protected set; } //المتراكم
        public decimal RewindValue { get; protected set; } //الترجيع
        public void Initialize(ISettings settings)
        {
            var setting = (Settings)settings;
            TextboxFrom = setting.TextboxFrom;
            TextboxTo = setting.TextboxTo;
            Number = setting.Number;
            NumberCheck = setting.NumberCheck;
            YearlyVacationRule = setting.YearlyVacationRule;
            SafeShareAll = setting.SafeShareAll;
            SafeShareReduced = setting.SafeShareReduced;
            SickVacation = setting.SickVacation;
            SickLeave = setting.SickLeave;
            ExtraWork = setting.ExtraWork;
            ExtraWorkVacation = setting.ExtraWorkVacation;
            SolidarityFund = setting.SolidarityFund;
            EmployeeShareAll = setting.EmployeeShareAll;
            EmployeeShareReduced = setting.EmployeeShareReduced;
            EmployeeShareWithoutReduced = setting.EmployeeShareWithoutReduced;
            EmployeeShareReduced35Year = setting.EmployeeShareReduced35Year;
            CompanyShareAll = setting.CompanyShareAll;
            CompanyShareReduced = setting.CompanyShareReduced;
            CompanyShareWithoutReduced = setting.CompanyShareWithoutReduced;
            CompanyShareReduced35Year = setting.CompanyShareReduced35Year;
            JihadTax = setting.JihadTax;
            ExemptionTaxOne = setting.ExemptionTaxOne;
            ExemptionTaxTwo = setting.ExemptionTaxTwo;
            IncomeTaxOne = setting.IncomeTaxOne;
            IncomeTaxTwo = setting.IncomeTaxTwo;
            StampTax = setting.StampTax;
            ChilderPermium = setting.ChilderPermium;
            Date = setting.Date;
            Saturday = setting.Saturday;
            Sunday = setting.Sunday;
            Monday = setting.Monday;
            Thursday = setting.Thursday;
            Wednesday = setting.Wednesday;
            Tuesday = setting.Tuesday;
            Friday = setting.Friday;
            VacationIncludesHolidays = setting.VacationIncludesHolidays;
            //AccumulatedValue = setting.AccumulatedValue;
            //RewindValue = setting.RewindValue;

        }

        public Settings()
        {

        }
        public Settings(decimal sickVacation, decimal sickLeave, decimal extraWork, decimal extraWorkVacation, decimal solidarityFund, decimal employeeShareAll
            , decimal employeeShareReduced, decimal employeeShareWithoutReduced, decimal employeeShareReduced35Year, decimal companyShareAll
            , decimal companyShareReduced, decimal companyShareWithoutReduced, decimal companyShareReduced35Year, decimal jihadTax
            , decimal exemptionTaxOne, decimal exemptionTaxTwo, decimal stampTax, decimal childerPermium, decimal incomeTaxOne
            , decimal incomeTaxTwo, DateTime date, bool saturday, bool sunday, bool monday, bool thursday, bool wednesday
            , bool tuesday, bool friday,bool vacationIncludesHolidays, decimal safeShareAll, decimal safeShareReduced,string textboxFrom,string textboxTo,int number,string numberCheck/*,decimal rewindValue,decimal accumulatedValue*/)
        {
            NumberCheck = numberCheck;
            Number = number;
            TextboxFrom = textboxFrom;
            TextboxTo = textboxTo;
            SafeShareAll = safeShareAll;
            SafeShareReduced = safeShareReduced;
            SickVacation = sickVacation;
            SickLeave = sickLeave;
            ExtraWork = extraWork;
            ExtraWorkVacation = extraWorkVacation;
            SolidarityFund = solidarityFund;
            EmployeeShareAll = employeeShareAll;
            EmployeeShareReduced = employeeShareReduced;
            EmployeeShareWithoutReduced = employeeShareWithoutReduced;
            EmployeeShareReduced35Year = employeeShareReduced35Year;
            CompanyShareAll = companyShareAll;
            CompanyShareReduced = companyShareReduced;
            CompanyShareWithoutReduced = companyShareWithoutReduced;
            CompanyShareReduced35Year = companyShareReduced35Year;
            JihadTax = jihadTax;
            ExemptionTaxOne = exemptionTaxOne;
            ExemptionTaxTwo = exemptionTaxTwo;
            IncomeTaxOne = incomeTaxOne;
            IncomeTaxTwo = incomeTaxTwo;
            StampTax = stampTax;
            ChilderPermium = childerPermium;
            Date = date;
            Saturday = saturday;
            Sunday = sunday;
            Monday = monday;
            Thursday = thursday;
            Wednesday = wednesday;
            Tuesday = tuesday;
            Friday = friday;
            VacationIncludesHolidays = vacationIncludesHolidays;
            //AccumulatedValue = accumulatedValue;
            //RewindValue = rewindValue;

        }

        public Settings(decimal grouplife, decimal sickVacation, decimal sickLeave, decimal extraWork, decimal extraWorkVacation, decimal solidarityFund
            , decimal employeeShareAll, decimal employeeShareReduced, decimal employeeShareWithoutReduced
            , decimal employeeShareReduced35Year, decimal companyShareAll, decimal companyShareReduced
            , decimal companyShareWithoutReduced, decimal companyShareReduced35Year, decimal jihadTax
            , decimal exemptionTaxOne, decimal exemptionTaxTwo, decimal stampTax, decimal childerPermium
            , decimal incomeTaxOne, decimal incomeTaxTwo, DateTime dateTime, bool saturday, bool sunday
            , bool monday, bool thursday, bool wednesday, bool tuesday, bool friday, decimal safeShareAll
            , decimal safeShareReduced, string textboxFrom, string textboxTo, int number, string numberCheck,bool vacationIncludesHolidays)
        {
            Grouplife = grouplife;
            SickVacation = sickVacation;
            SickLeave = sickLeave;
            ExtraWork = extraWork;
            ExtraWorkVacation = extraWorkVacation;
            SolidarityFund = solidarityFund;
            EmployeeShareAll = employeeShareAll;
            EmployeeShareReduced = employeeShareReduced;
            EmployeeShareWithoutReduced = employeeShareWithoutReduced;
            EmployeeShareReduced35Year = employeeShareReduced35Year;
            CompanyShareAll = companyShareAll;
            CompanyShareReduced = companyShareReduced;
            CompanyShareWithoutReduced = companyShareWithoutReduced;
            CompanyShareReduced35Year = companyShareReduced35Year;
            JihadTax = jihadTax;
            ExemptionTaxOne = exemptionTaxOne;
            ExemptionTaxTwo = exemptionTaxTwo;
            StampTax = stampTax;
            ChilderPermium = childerPermium;
            IncomeTaxOne = incomeTaxOne;
            IncomeTaxTwo = incomeTaxTwo;
            this.dateTime = dateTime;
            Date = dateTime;
            Saturday = saturday;
            Sunday = sunday;
            Monday = monday;
            Thursday = thursday;
            Wednesday = wednesday;
            Tuesday = tuesday;
            Friday = friday;
            SafeShareAll = safeShareAll;
            SafeShareReduced = safeShareReduced;
            TextboxFrom = textboxFrom;
            TextboxTo = textboxTo;
            Number = number;
            NumberCheck = numberCheck;
            VacationIncludesHolidays = vacationIncludesHolidays;
            //AccumulatedValue = accumulatedValue;
            //RewindValue = rewindValue;
        }
    }
}