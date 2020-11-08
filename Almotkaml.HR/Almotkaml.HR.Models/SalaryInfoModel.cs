using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SalaryInfoIndexModel
    {
        public IEnumerable<SalaryInfoGridRow> SalaryInfoGrid { get; set; } = new HashSet<SalaryInfoGridRow>();
        public SalaryInfoSearch SalaryInfoSearch { get; set; }
        public bool CanSubmit { get; set; }
        public bool CanEditeEmployee { get; set; }
    }
    public class SalaryInfoGridRow
    {
        public bool Active { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public bool Edit { get; set; }
    }
    public class TemEmployeePremiumListItemEE
    {
        public int EmployeeId { get; set; }
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal alllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int Inspect { get; set; }
        public IsTemporary IsTemporary { get; set; }

    }
    public class NotTemEmployeePremiumListItemEE
    {
        public int EmployeeId { get; set; }
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal alllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int Inspect { get; set; }
        public IsTemporary IsTemporary { get; set; }
    }
    public class SalaryInfoFormModel
    {
        public int EmployeeId { get; set; }
        public bool IsDesignation { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }
        /// <summary>
        /// add by ali alherbade
        /// </summary>
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DegreeNow))]
        public int? DegreeNow { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Bouns))]
        public int? Bouns { get; set; } // العلاوات

        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.Bounshr))]
        public int? Bounshr { get; set; } // العلاوات

      
        //
        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bank))]
        public int BankId { get; set; }

        public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();
        public IEnumerable<BankBranchListItem> BankBranchList { get; set; } = new HashSet<BankBranchListItem>();
        public ICollection<TemporaryPremiumList> TemporaryList { get; set; } = new HashSet<TemporaryPremiumList>();
        public ICollection<NotTemporaryPremiumList> NotTemporaryList { get; set; } = new HashSet<NotTemporaryPremiumList>();

        public ICollection<AdvanseListItem> AdvanseListItem { get; set; } = new HashSet<AdvanseListItem>();
        public IList<TemporaryPremmiumListItem> TemporaryPremiumListItem { get; set; } = new List<TemporaryPremmiumListItem>();
        public IList<NotTemporaryPremmiumListE> NotTemporaryPremiumList { get; set; } = new List<NotTemporaryPremmiumListE>();

        public IList<EmployeeAdvancePymentListItem> AdvancPremiumList { get; set; } = new List<EmployeeAdvancePymentListItem>();
        //  public IList<EmployeeAdvancePymentListItem> AdvancPremiumList { get; set; } = new List<EmployeeAdvancePymentListItem>();
        public IList<NotTemEmployeePremiumListItemEE> NotTemEmployeePremiumListItem { get; set; } = new List<NotTemEmployeePremiumListItemEE>();
    public IList<TemEmployeePremiumListItemEE> TemEmployeePremiumListItem { get; set; } = new List<TemEmployeePremiumListItemEE>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.NameSecurtey))]
        public string NameSecurity { get; set; }
        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BankBranch))]
        public int BankBranchId { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.stamptest))]
        public GuaranteeType GuaranteeTypeSafe { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.GuaranteeType))]
        public GuaranteeType GuaranteeType { get; set; }


        [Display(ResourceType = typeof(Title), Name = nameof(Title.BondNumber))]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        public string BondNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        //[Range(1, Double.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BasicSalary))]
        public decimal BasicSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraValue))]
        public decimal ExtraValue { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraGeneralValue))]
        public decimal ExtraGeneralValue { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SecurityNumber))]
        public string SecurityNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FinancialNumber))]
        public string FinancialNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SalayClassification))]
        public string SalayClassification { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FileNumber))]
        public string FileNumber { get; set; }
        public bool CanSubmit { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.GroupLifeChich))]
        public bool GroupLifeChich { get; set; }
        
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Tadawl))]
        public decimal  Tadawl { get; set; }
    }
}
