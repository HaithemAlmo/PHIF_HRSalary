using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class CompanyInfoModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.ShortName))]
        public string ShortName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.LongName))]
        public string LongName { get; set; }

        //[Display(ResourceType = typeof(Title), Name = nameof(Title.DivisionInGovernment))]
        //public string DivisionInGovernment { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.EnglishName))]
        public string EnglishName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Phone))]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Mobile))]
        public string Mobile { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Email))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Address))]
        public string Address { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Website))]
        public string Website { get; set; }

        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Logo))]
        public string LogoPath { get; set; }

        // add by ali alherbade 26-05-2019
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.PayrollUnit))]
        public string PayrollUnit { get; set; }// وحدة المرتبات
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.References))]
        public string References { get; set; }// المراجع 
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.FinancialAuditor))]
        public string FinancialAuditor { get; set; }// المراقب المالي
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.FinancialAffairs))]
        public string FinancialAffairs { get; set; }// الشئون المالية
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.Department))]
        public string Department { get; set; }// القسم

        public bool CanSubmit { get; set; }
    }
}