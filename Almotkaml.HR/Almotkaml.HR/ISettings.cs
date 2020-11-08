using System;

namespace Almotkaml.HR
{
    public interface ISettings
    {
        DateTime Date { get; }
        decimal SickVacation { get; }
        decimal SickLeave { get; }
        decimal ExtraWork { get; }
        decimal ExtraWorkVacation { get; }
        decimal SolidarityFund { get; }
        decimal EmployeeShareAll { get; }
        decimal EmployeeShareReduced { get; }
        decimal EmployeeShareWithoutReduced { get; }
        decimal EmployeeShareReduced35Year { get; }
        decimal CompanyShareAll { get; }
        decimal CompanyShareReduced { get; }
        decimal SafeShareAll { get; }
        decimal SafeShareReduced { get; }
        decimal CompanyShareWithoutReduced { get; }
        decimal CompanyShareReduced35Year { get; }
        decimal JihadTax { get; }
        decimal ExemptionTaxOne { get; }
        decimal ExemptionTaxTwo { get; }
        decimal IncomeTaxOne { get; }
        decimal IncomeTaxTwo { get; }
        decimal StampTax { get; }
        decimal Grouplife { get; }
        decimal ChilderPermium { get; }

         //decimal AccumulatedValue { get; } //المتراكم
         //decimal RewindValue { get; } //الترجيع
        bool Saturday { get; }
        bool Sunday { get; }
        bool Monday { get; }
        bool Thursday { get; }
        bool Wednesday { get; }
        bool Tuesday { get; }
        bool Friday { get; }
    }
}