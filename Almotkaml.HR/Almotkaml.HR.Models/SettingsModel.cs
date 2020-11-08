using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SettingsModel
    {

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
     ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        public string TextboxFrom { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
     ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        public string TextboxTo { get; set; }

        public string NumberCheck { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
     ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        public int Number { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateSpent))]
        public string Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SickVacation))]
        public decimal SickVacation { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.sickLeave))]
        public decimal SickLeave { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWork))]
        public decimal ExtraWork { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWorkVacation))]
        public decimal ExtraWorkVacation { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SolidarityFund))]
        public decimal SolidarityFund { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeShareAll))]
        public decimal EmployeeShareAll { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeShareReduced))]
        public decimal EmployeeShareReduced { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeShareWithoutReduced))]
        public decimal EmployeeShareWithoutReduced { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeShareReduced35Year))]
        public decimal EmployeeShareReduced35Year { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CompanyShareAll))]
        public decimal CompanyShareAll { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.SafeAll))]
        public decimal SafeShareAll { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SafeReducer))]
        public decimal SafeShareReduced { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CompanyShareReduced))]
        public decimal CompanyShareReduced { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CompanyShareWithoutReduced))]
        public decimal CompanyShareWithoutReduced { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CompanyShareReduced35Year))]
        public decimal CompanyShareReduced35Year { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JihadTax))]
        public decimal JihadTax { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExemptionTaxOne))]
        public decimal ExemptionTaxOne { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExemptionTaxTwo))]
        public decimal ExemptionTaxTwo { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IncomeTaxOne))]
        public decimal IncomeTaxOne { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IncomeTaxTwo))]
        public decimal IncomeTaxTwo { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.StampTax))]
        public decimal StampTax { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ChilderPermium))]
        public decimal ChilderPermium { get; set; }

        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Thursday { get; set; }
        public bool Wednesday { get; set; }
        public bool Tuesday { get; set; }
        public bool Friday { get; set; }
        public bool CanSubmit { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationIncludesHolidays))]
        public bool VacationIncludesHolidays { get; set; }
        public decimal Grouplife { get; set; }
    }
}