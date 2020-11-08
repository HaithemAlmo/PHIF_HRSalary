using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SalarySettlementReportModel
    {
        public int ISadvanse { get; set; }
        public IEnumerable<AdvanseNameListItem> AdvanseNameList { get; set; } = new HashSet<AdvanseNameListItem>();

        public int IsLegal { get; set; }
        public int AbstractClipboard { get; set; }
        public int IsEndJob { get; set; }
        public string TextboxFrom { get; set; }
        public string TextboxTo { get; set; }
        public bool IsSubsended { get; set; }
        public bool IsSubsendedSalary { get; set; }

        public string NumberCheck { get; set; }
        public int Number { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.InstrumentNumber))]
        public string InstrumentNumber { get; set; }//رقم الصك 
        public int AccreditationNumber { get; set; }
        public IList<TemEmployeePremiumListItemEE> EmployeePremiumList { get; set; } = new List<TemEmployeePremiumListItemEE>();

        public AdvancePaymentReportModel AdvancePaymentReportModel { get; set; } = new AdvancePaymentReportModel();
        public SocialSecurityFundReportModel SocialSecurityFundReportModel { get; set; } = new SocialSecurityFundReportModel();
        public SolidarityFundReportModel SolidarityFundReportModel { get; set; } = new SolidarityFundReportModel();
        public SalaryFormReportModel SalaryFormReportModel { get; set; } = new SalaryFormReportModel();
        public ClipboardBankingReportModel ClipboardBankingReportModel { get; set; } = new ClipboardBankingReportModel();
        public SalaryCardReportModel SalaryCardReportModel { get; set; } = new SalaryCardReportModel();
        public SalariesTotalReportModel SalariesTotalReportModel { get; set; } = new SalariesTotalReportModel();
        public TaxReportModel TaxReportModel { get; set; } = new TaxReportModel();
        public IEnumerable<EmployeeReportGridRow> Grid { get; set; } = new HashSet<EmployeeReportGridRow>();
        public IEnumerable<EmployeeReportGridRow> Grid2 { get; set; } = new HashSet<EmployeeReportGridRow>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.CostCenter))]
        public int? CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public int? UnitId { get; set; }
        public IEnumerable<UnitListItem> UnitList { get; set; } = new HashSet<UnitListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public int? DivisionId { get; set; }
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Department))]
        public int? DepartmentId { get; set; }
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Month))]
        public int? Month { get; set; }
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Year))]
        public int? Year { get; set; }

        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public int JobNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public int LICJobNumber { get; set; }
        public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();
        public IEnumerable<BankBranchListItem> BankBranchList { get; set; } = new HashSet<BankBranchListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BankBranch))]
        public int? BankBranchId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bank))]
        public int? BankId { get; set; }
        public IEnumerable<PensionFundReportGridRow> PensionFundReportGrid { get; set; } =
            new HashSet<PensionFundReportGridRow>();
        public IEnumerable<PledgeReportGridRow> PledgeReportGrid { get; set; } =
            new HashSet<PledgeReportGridRow>();
        public IEnumerable<SalaryCertificateReportGridRow> SalaryCertificateReportGrid { get; set; } =
            new HashSet<SalaryCertificateReportGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }
        [Display(ResourceType = typeof(SharedTitles),
            Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Report))]
        public SalarySettlement SalarySettlement { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.NameAdvanse))]
        public int AdvanseNameID { get; set; }
        public DateTime DateTo2 { get; set; }
        public DateTime DateFrom2 { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Clamp))]
        public bool ClampCheck { get; set;}
        [Display(ResourceType = typeof(Title), Name = nameof(Title.RewardAndExtraWork))]
        public bool SubsistenceCheck { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Premium))]
        public bool PremiumCheck { get; set; }
        public IList<PremiumCheckListItem> PremiumCheckListItem { get; set; } = new List<PremiumCheckListItem>();
        public IList<PremiumCheckListItemReport> PremiumListReport { get; set; } = new List<PremiumCheckListItemReport>();

    }
}