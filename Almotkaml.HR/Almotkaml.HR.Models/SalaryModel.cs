using Almotkaml.HR.Domain;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SalaryIndexModel
    {
        public string SuspendedNote { get; set; }
        public string SumTotalSalary { get; set; }// add by ali alherbade ãÌãæÚ ßá ÇáãÑÊÈÇÊ
        public string SumTotalDiscount { get; set; }// add by ali alherbade ãÌãæÚ ßá ÇáÎÕãíÇÊ
        public string SumFinalSalary { get; set; }
        public TotalGrid totalGridRow { get; set; } = new TotalGrid(); // add by ali alherbade 11-07-2019
        public SummaryReportModel summryreport { get; set; } = new SummaryReportModel();

        public IEnumerable<int> YearList { get; set; }
        public IEnumerable<int> MonthList { get; set; }
        //-------------Search
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Month))]
        public int? Month { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(2010, 2100, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Year))]
        public int? Year { get; set; }
        //------------------
        public IList<SalaryGridRow> SalaryGrid { get; set; } = new List<SalaryGridRow>();

        public AdvancePaymentReportModel AdvancePaymentReportModel { get; set; } = new AdvancePaymentReportModel();
        public SocialSecurityFundReportModel SocialSecurityFundReportModel { get; set; } = new SocialSecurityFundReportModel();
        public SolidarityFundReportModel SolidarityFundReportModel { get; set; } = new SolidarityFundReportModel();
        public SalaryFormReportModel SalaryFormReportModel { get; set; } = new SalaryFormReportModel();
        public ClipboardBankingReportModel ClipboardBankingReportModel { get; set; } = new ClipboardBankingReportModel();
        public SalaryCardReportModel SalaryCardReportModel { get; set; } = new SalaryCardReportModel();
        public SalariesTotalReportModel SalariesTotalReportModel { get; set; } = new SalariesTotalReportModel();
        public TaxReportModel TaxReportModel { get; set; } = new TaxReportModel();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthDate))]
        public string MonthDate { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.BoundNumber))]
        public string TaxBondNumber { get; set; }
        public string SolidarityFundBondNumber { get; set; }
        public string SocialSecurityFundBondNumber { get; set; }

        public bool CanClose { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanSpent { get; set; }
        public bool CanEdit { get; set; }
        public bool CanSuspended { get; set; }
        public bool CanFreeze { get; set; }
        public bool CanAllow { get; set; }
        public bool AdvancePremiumFreezeState { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]

        public string DateFrom { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]

        public string DateTo { get; set; }
        /// /// // ahmed alalem
        ///  //  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BankBranch))]
        public int? BankBranchId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bank))]
        public int BankId { get; set; }
        public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();
        public IEnumerable<BankBranchListItem> BankBranchList { get; set; } = new HashSet<BankBranchListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Txt12 { get; set; }
        public DifrancesModel DifrancesModel { get; set; } = new DifrancesModel();
        //-------------Search

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Tadawl))]
        public decimal Tadawl { get; set; }
        public int EmloyeeId { get; set; }

        public string JobNumber { get; set; }
        public string CloseNote { get; set; }

        ///  /// //
    }

    public class SalaryGridRow
    {
        public int BankId { get; set; }

        public int EmloyeeId { get; set; }
        // add by ali alherbade
        public decimal TotalDiscount { get; set; }// ãÌãæÚ ÇáÎÕãíÇÊ
        
        public int? MonthGrid { get; set; }
        
        public int? YearGrid { get; set; }
        public long SalaryId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal FinalSalary { get; set; }
        public string JobNumber { get; set; }
        public bool IsSuspended { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SuspendedNote))]
        public string SuspendedNote { get; set; }
        public string MonthDate { get; set; }

    }
    public class SalaryFormModel
    {
        //public int SalaryCertifiedNumber { get; set; }

        public int CheckNumber { get; set; }

        ///public int ClipordNumber { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Tadawl))]
        public decimal Tadawl { get; set; }
        public string Total { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TotalDiscount))]
        public decimal TotalDiscount { get; set; }
        public decimal GroupLife { get; set; }
        public long SalaryId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthDate))]
        public string MonthDate { get; set; }
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.DateSpent))]
        public int Month { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumber))]
        public string JobNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AbsenceDays))]
        public int AbsenceDays { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWorkFixed))]
        public decimal ExtraWorkFixed { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWorkHoures))]
        public decimal ExtraWorkHoures { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWorkVacationHoures))]
        public decimal ExtraWorkVacationHoures { get; set; }
        public int BankBranchId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BankBranch))]
        public string BankBranchName { get; set; }
        public int BankId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bank))]
        public string BankName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BoundNumber))]
        public string BoundNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BasicSalary))]
        public decimal BasicSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SickVacation))]
        public decimal SickVacation { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.sickLeave))]
        public decimal SickLeave { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SolidarityFund))]
        public decimal SolidarityFund { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CompanyShare))]
        public decimal CompanyShare { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeShare))]
        public decimal EmployeeShare { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.stamptest))]
        public decimal SafeShare{ get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SafeReducer))]
        public decimal SafeShareReduced { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdvancePremiumInside))]
        public decimal AdvancePremiumInside { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdvancePremiumOutside))]
        public decimal AdvancePremiumOutside { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdvancePremium))]
        public decimal AdvancePremium { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.PrepaidSalary))]

        public decimal PrepaidSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.stamptest))]
        public decimal StampTax { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SubjectSalary))]
        public decimal SubjectSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SubjectSalary))]
        public decimal Subject { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JihadTax))]
        public decimal JihadTax { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IncomeTax))]
        public decimal IncomeTax { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExemptionTax))]
        public decimal ExemptionTax { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.NetSalary))]
        public decimal NetSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TotalSalary))]
        public decimal TotalSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWork))]
        public decimal ExtraWork { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraWorkVacation))]
        public decimal ExtraWorkVacation { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Absence))]
        public decimal Absence { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FinalSalary))]
        public decimal FinalSalary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SanctionSalary))]
        public decimal Sanction { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraValue))]
        public decimal ExtraValue { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExtraGeneralValue))]
        public decimal ExtraGeneralValue { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FileNumber))]
        public string FileNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AccumulatedValue))]
        public decimal AccumulatedValue { get; set; } //المتراكم
        [Display(ResourceType = typeof(Title), Name = nameof(Title.RewindValue))]
        public decimal RewindValue { get;  set; } //الترجيع
        public TemporaryPremiumModel TemporaryPremium { get; set; } = new TemporaryPremiumModel();

       // public TemporaryPremiumModel TemporaryPremium { get; set; } = new TemporaryPremiumModel();
        public ICollection<PremiumListItem> PremiumList { get; set; } = new HashSet<PremiumListItem>();
        public IList<SalaryPremiumListItem> SalaryPremiumList { get; set; } = new List<SalaryPremiumListItem>();
        public IEnumerable<EmployeePremiumListItem> Premiums2 { get; set; } = new HashSet<EmployeePremiumListItem>();



        public ICollection<TemporaryPremiumList> TemporaryList { get; set; } = new HashSet<TemporaryPremiumList>();
        public ICollection<TemporaryPremiumList> NotTemporaryList { get; set; } = new HashSet<TemporaryPremiumList>();


        public ICollection<AdvanseListItem> AdvanseListItem { get; set; } = new HashSet<AdvanseListItem>();
       public IList<TemSalaryPremiumListItem> TemporaryPremiumList { get; set; } = new List<TemSalaryPremiumListItem>();
        public IList<TemSalaryPremiumListItem> NotTemporaryPremiumList { get; set; } = new List<TemSalaryPremiumListItem>();
        public IList<NotTemporaryPremmiumListE> NotTemporaryPremiumList1 { get; set; } = new List<NotTemporaryPremmiumListE>();

        public IList<SalaryAdvancePymentListItem> SalaryAdvancPremiumList { get; set; } = new List<SalaryAdvancePymentListItem>();
      //  public IList<EmployeeAdvancePymentListItem> AdvancPremiumList { get; set; } = new List<EmployeeAdvancePymentListItem>();
     
     
        public bool CanSubmit { get; set; }

        public SalaryCardReportModel SalaryCardReportModel { get; set; } = new SalaryCardReportModel();
     //   public IList<TemSalaryPremiumListItem> TemSalaryPremiumList { get; set; }
    }
    public class TemporaryPremiumModel
    {
        public IEnumerable<TemporaryPremiumGridRow> TemporaryPremiumGrid { get; set; } = new HashSet<TemporaryPremiumGridRow>();
        public int TemporaryPremiumId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsSubject))]
        public bool IsSubject { get; set; }
        public long SalaryId { get; set; }
        //public Salary Salary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Value))]
        public decimal Value { get; set; }
    }
    public class TemporaryPremiumGridRow
    {
        public int TemporaryPremiumId { get; set; }
        public string Name { get; set; }
        public bool IsSubject { get; set; }
        public long SalaryId { get; set; }
        //public Salary Salary { get; set; }
        public decimal Value { get; set; }
    }
    //public class TemSalaryPremiumListItem
    //{
    //   // public   { get; set; }
    //    public long SalaryId { get; set; }
    //    public int PremiumId { get; set; }
    //    public decimal Value { get; set; }
    //    public decimal alllValue { get; set; }
    //    public ISAdvancePremmium ISAdvancePremmium { get; set; }
    //    public int Inspect { get; set; }

    //}
    public class TemSalaryPremiumListItem
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal alllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsSubject IsSubject { get; set; }
        public int Inspect { get; set; }

    }
    

   
    public class SalaryPremiumListItem
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal alllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int Inspect { get; set; }

    }
    public class NotSalaryPremiumListItem
    {
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public decimal alllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int Inspect { get; set; }

    }
    public class SalaryAdvancePymentListItem
    {



        //public int PremiumId { get; set; }
        //public decimal Value { get; set; }

        //public int EmployeeID { get; set; }

        //  public ISAdvancePremmium ISAdvancePremmium { get; set; }
        //  public int AdvancePaymentId { get; set; }
        public int EmployeeID { get; set; }
        // public Employee Employee { get; set; }
        public int PremiumId { get; set; }

        // public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsFrozen IsFrozen { get; set; }

        //public DateTime DeductionDate { get; set; } // تاريخ بدء الخصم
        //public DateTime Date { get; set; } // تاريخ بدء الخصم
    }
   
    public class TotalGrid
    {
        public string BasicSalaryTotal { get; set; }        // ÇÌãÇáí ÇáãÑÊÈÇÊ ÇáÇÓÇÓíÉ
        public string ExtraValueTotal { get; set; }         // ÇÌãÇáí ÇáÒíÇÏÉ
        public string Total_BasicSalary_ExtraGeneralValue { get; set; } //  ÇÌãÇáí ÞíãÉ ÇáãÑÊÈÇÊ ÇáÇÓÇíÉ + ÇáÒíÇÏÉ ÇáÚÇãÉ
        public string ExtraGeneralValueTotal { get; set; }  // ÇÌãÇáí ÇáÒíÇÏÉ ÇáÚÇãÉ
        public string AbsenceTotal { get; set; }            // ÇÌãÇáí ÞíãÉ ÇáÛíÇÈ
        public string SickVacationTotal { get; set; }       // ÇÌãÇáí ÞíãÉ ÇáÇÌÇÒÇÊ ÇáãÑÖíÉ
        //=====================================================================================
        public string TotalSalary { get; set; }             // ÇÌãÇáí ÇáãÑÊÈÇÊ 
        //=====================================================================================
        public string SolidarityFundTotal { get; set; }     //ÇÌãÇáí ÞíãÉ ÇáÊÙÇãä
        public string EmployeeShareTotal { get; set; }      //ÇÌãÇáí ÍÕÉ ÇáãæÙÝ
        public string CompanyShareTotal { get; set; }       //ÇÌãÇáí ÍÕÉ ÇáÔÑßÉ
        public string SafeShareTotal { get; set; }          //ÇÌãÇáí ÖÑíÈÉ ÇáÎÒÇäÉ
        public string JihadTaxTotal { get; set; }           //ÇÌãÇáí ÖÑíÈÉ ÇáÌåÇÏ
        public string SalaryPremium { get; set; }           //ÇÌãÇáí ÎÕã ÇáãæÏÉ
        public string TotalDiscount { get; set; }           // ÇÌãÇáí ÇáÎÕãíÇÊ
        //=====================================================================================
        public string FinalSalaryTotal { get; set; }        //ÇÌãÇáí ÕÇÝí ÇáãÑÊÈ


    }
}