using Almotkaml.Attributes;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Almotkaml.HR.Models
{
    public class JobInfoDegreeModel
    {
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.SitionsNew))]
        public SiutiontnType Situons { get; set; }

        public int EmployeeId { get; set; }
        public EmploymentValuesModel EmploymentValues { get; set; }
        public SituationResolveJobModel SituationResolveJob { get; set; }

       
      
        public Adjective Adjective { get; set; }

        public string CurrentClassification { get; set; }

        public string HealthStatus { get; set; }


        public string OldJobNumber { get; set; }
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DirectlyDate))]
        public string DirectlyDate { get; set; } // تاريخ المباشرة



        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Degree))]
        public int? Degree { get; set; } // درجة التوظيف


        [Display(ResourceType = typeof(Title),Name = nameof(Title.JobTitel))]
        public int? JobId { get; set; }
 
        public JobType JobType { get; set; }


        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DegreeNow))]
        public int? DegreeNow { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateDegreeNow))]
        public string DateDegreeNow { get; set; } // تاريخ الدرجة
        public int? DegreeLastResolutionNumber { get; set; }// رقم قرار اخر درجة


        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateMeritDegreeNow))]
        public string DateMeritDegreeNow { get; set; } // تاريخ استحقاق الدرجة

        public int? NewVal => Convert.ToInt16((Convert.ToDateTime(DateDegreeNow).Date.Year));
        public int? NewVal2 => Convert.ToInt16((Convert.ToDateTime(DateDegreeNow).Date.Month));
        public int NewVal3 => Convert.ToInt16((DateTime.Now.Month));
        public int NewVal1 => Convert.ToInt16((DateTime.Now.Year));
        public int Sum => Convert.ToInt16((NewVal1 - NewVal)) - 1;
        public int Sum1 => Convert.ToInt16((NewVal1 - NewVal));
        public int TenVal = 10;
        public int SituationResolveJobId;

        public int? NewVal4 => Convert.ToInt16((Convert.ToDateTime(DateDegreeNow).Date.Year + 4));
        public int? NewVal5 => Convert.ToInt16((Convert.ToDateTime(DateDegreeNow).Date.Year + 5));
        public int? NewVal7 => Convert.ToInt16((Convert.ToDateTime(DateDegreeNow).Date.Year + 7));

        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.Bouns))]
        public int? Bounshr { get; set; } // العلاوات
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Bouns))]
        public int? Bouns { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DateBouns))]
        public string DateBouns { get; set; } // تاريخ العلاوة

        
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

       

        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnSearching))]
        public int? ClassificationOnSearchingId { get; set; }

        public IEnumerable<ClassificationOnSearchingListItem> ClassificationOnSearchingList { get; set; }
            = new HashSet<ClassificationOnSearchingListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ClassificationOnWork))]
        public int? ClassificationOnWorkId { get; set; }

        public IEnumerable<ClassificationOnWorkListItem> ClassificationOnWorkList { get; set; }
            = new HashSet<ClassificationOnWorkListItem>();



        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.SerialNumber))]
        public int? SerialNumber { get; set; }


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

        public IEnumerable<JobListItem> JobList { get; set; } = new HashSet<JobListItem>();

        //*******************************************************************************
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }
        public bool CanSubmit { get; set; }
        public bool CanEdit { get; set; }
        public bool CanPromotion { get; set; }
        public bool CanSettlement { get; set; }
        
        public IList<DegreeGridRow> DegreeGrid { get; set; } = new List<DegreeGridRow>();
        public PromotionType PromotionType { get; set; }
        public PromotionSeason PromotionSeason { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        public string DecisionNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        public string DecisionDate { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.JobTitel))]
        public int? NewJobId { get; set; }
        


    }



    public enum PromotionType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.PromotionEnt))]
        PromotionEnt = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.PromotionReq))]
        PromotionReq = 2

    }

    public enum PromotionSeason
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.All))]
        All = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstOfYear))]
        FirstOfYear = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SecondOfYear))]
        SecondOfYear = 2

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
