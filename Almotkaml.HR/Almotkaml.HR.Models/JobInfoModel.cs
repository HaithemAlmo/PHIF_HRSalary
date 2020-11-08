using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class JobInfoModel
    {
        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.SitionsNew))]
        public SiutiontnType Situons { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobClass))]
        public JobClass JobClass { get; set; }
        public int EmployeeId { get; set; }
        public EmploymentValuesModel EmploymentValues { get; set; }

        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Adjective))]
        public Adjective Adjective { get; set; }
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.CurrentClassification))]
        public string CurrentClassification { get; set; }
        //[Display(ResourceType = typeof(Title),  Name = nameof(Title.HealthStatus))]
        public string HealthStatus { get; set; }

        //[Display(ResourceType = typeof(Title), Name = nameof(Title.OldJobNumber))]
        public string OldJobNumber { get; set; }
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DirectlyDate))]
    
        public string DirectlyDate { get; set; } // تاريخ المباشرة
        [Display(ResourceType = typeof(Title),
                Name = nameof(Title.LeaderType))]
        public LeaderType LeaderType { get; set; }


        //  [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        //[Range(1, 20, ErrorMessageResourceType = typeof(SharedMessages),
        //    ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Degree))]
        public int? Degree { get; set; } // درجة التوظيف


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        //[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.JobTitel))]
        public int? JobId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.JobType))]
        public JobType JobType { get; set; }

        public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.JobNumber))]
        public int JobNumber { get; set; } // الرقم الوظيفي 

      
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.JobNumberApproved))]
        public int? JobNumberApproved { get; set; } // ر.و لدى الملاك الوظيفي

        //[Display(ResourceType = typeof(Title),
        //    Name = nameof(Title.SituationResolveJob))]
        //public SituationResolveJob SituationResolveJob { get; set; } // تسوية الوضع الوظيفي

      //  [Required(ErrorMessageResourceType = typeof(SharedMessages),
      //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
      //  [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.CurrentSituation))]
        public int? CurrentSituationId { get; set; }

        public IEnumerable<CurrentSituationListItem> CurrentSituationList { get; set; } =
            new HashSet<CurrentSituationListItem>();

        //public string ResolveResolutionNumber { get; set; } // رقم قرار للتسوية الوظيفية
        //public DateTime ResolveResolutionDate { get; set; } // تاريخ قرار التسوية الوضيفية

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
      ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Unit))]
        public int UnitId { get; set; }

        public IEnumerable<UnitListItem> UnitList { get; set; } = new HashSet<UnitListItem>();


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Division))]
        public int DivisionId { get; set; }

        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Department))]
        public int DepartmentId { get; set; }

        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();

        // [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        //[Range(1, 20, ErrorMessageResourceType = typeof(SharedMessages),
        //    ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DegreeNow))]
        public int? DegreeNow { get; set; }

        //  [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateDegreeNow))]
        public string DateDegreeNow { get; set; } // تاريخ الدرجة
        public int? DegreeLastResolutionNumber { get; set; }// رقم قرار اخر درجة


        //  [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateMeritDegreeNow))]
        public string DateMeritDegreeNow { get; set; } // تاريخ استحقاق الدرجة


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        //[Range(1, 100, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Bouns))]
        public int? Bouns { get; set; } // العلاوات

        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.Bouns))]
        public int? Bounshr { get; set; } // العلاوات

        //  [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateBouns))]
        public string DateBouns { get; set; } // تاريخ العلاوة

        //   [Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateMeritBouns))]
        public string DateMeritBouns { get; set; } // تاريخ استحقاق العلاوة

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AdjectiveEmployee))]
        public int? AdjectiveEmployeeId { get; set; }

        public IEnumerable<AdjectiveEmployeeListItem> AdjectiveEmployeeList { get; set; }
            = new HashSet<AdjectiveEmployeeListItem>();


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AdjectiveEmployeeType))]
        public int? AdjectiveEmployeeTypeId { get; set; }

        public IEnumerable<AdjectiveEmployeeTypeListItem> AdjectiveEmployeeTypeList { get; set; }
            = new HashSet<AdjectiveEmployeeTypeListItem>();

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Staffing))]
        public int? StaffingId { get; set; }

        public IEnumerable<StaffingListItem> StaffingList { get; set; } = new HashSet<StaffingListItem>();

        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.SitionsNumber))]
        public int? SituionsNumber { get; set; }
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.StaffingType))]
        public int? StaffingTypeId { get; set; }

        public IEnumerable<StaffingTypeListItem> StaffingTypeList { get; set; } = new HashSet<StaffingTypeListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.StaffingClassification))]
        public int? StaffingClassificationId { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobNumberLIC))]
        public int? JobNumberLIC { get; set; }

        public IEnumerable<StaffingClassificationListItem> StaffingClassificationList { get; set; } = new HashSet<StaffingClassificationListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Notes))]
        public int? NoteId { get; set; }

        public IEnumerable<NoteListItem> NoteList { get; set; } = new HashSet<NoteListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages)
            , ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public int CenterId { get; set; }

        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnSearching))]
        public int? ClassificationOnSearchingId { get; set; }

        public IEnumerable<ClassificationOnSearchingListItem> ClassificationOnSearchingList { get; set; }
            = new HashSet<ClassificationOnSearchingListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnWork))]
        public int? ClassificationOnWorkId { get; set; }

        public IEnumerable<ClassificationOnWorkListItem> ClassificationOnWorkList { get; set; }
            = new HashSet<ClassificationOnWorkListItem>();

        //public int BankId { get; set; }

        //public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();
        //public IEnumerable<BankBranchListItem> BankBranchList { get; set; } = new HashSet<BankBranchListItem>();


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.SerialNumber))]
        public int? SerialNumber { get; set; }

        //public FinancialDataModel FinancialData { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationBalance))]
        public int VacationBalance { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Notes))]
        public string Notes { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Degree))]
        public ClampDegree? ClampDegree { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DegreeNow))]
        public ClampDegree? ClampDegreeNow { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeClassification))]
        public SalayClassification? SalayClassification { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Redirection))]
        public Redirection Redirection { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.RedirectionNote))]
        public string RedirectionNote { get; set; }

        public int? CenterNumber { get; set; }
        public virtual string GetJobNumber() => JobNumber.ToString();
     
        public bool CanSubmit { get; set; }
    }

    public class EmploymentValuesModel
    {

        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DesignationResolutionNumber))]
        public string DesignationResolutionNumber { get; set; } // رقم القرار للتعيين


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DesignationResolutionDate))]
        public string DesignationResolutionDate { get; set; } // تاريح القرار للتعيين


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DesignationIssue))]
        public string DesignationIssue { get; set; } // جهة الصدور للتعيين


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //  ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ContractDate))]
        public string ContractDateFrom { get; set; }


        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        // ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.DateTo))]
        public string ContractDateTo { get; set; }

        //[Display(ResourceType = typeof(Title),
        //    Name = nameof(Title.ContractDuration))]
        //public string ContractDuration { get; set; } //مدة العقد

        public string DelegationDate { get; set; }
        public string DelegationSide { get; set; }//جهة المنتدب منها
        //public string DelegationResolutionNumber { get; set; }// رقم القرار للندب
        public string TransferDate { get; set; }
        public string TransferSide { get; set; }
        public string LoaningDate { get; set; }
        public string LoaningSide { get; set; }
        public string BenefitFromServicesDate { get; set; }
        public string BenefitFromServicesSide { get; set; }
        public string EmptiedDate { get; set; }
        public string EmptiedSide { get; set; }
        public string CollaboratorDate { get; set; }
        public string CollaboratorSide { get; set; }

    }

    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Note { get; set; }
    }

    //public class FinancialDataModel
    //{
    //    public int BankBranchId { get; set; }
    //    public string BankName { get; set; }
    //    public string BankBranchName { get; set; }
    //    public string BondNumber { get; set; }
    //    public decimal Salary { get; set; }
    //    public string SecurityNumber { get; set; }
    //    public string FinancialNumber { get; set; }
    //}

}
