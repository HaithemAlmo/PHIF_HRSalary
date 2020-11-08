using Almotkaml.Attributes;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class TrainingIndexModel
    {
        public IEnumerable<TrainingGridRow> TrainingGrid { get; set; } = new HashSet<TrainingGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }

    public class TrainingGridRow
    {
        public int TrainingId { get; set; }
        public string CorporationName { get; set; }
        public string DevelopmentTypeDName { get; set; }
        public string RequestedQualificationName { get; set; }
        public string ExecutingAgency { get; set; }// الجهة المانحة
        public string DecisionNumber { get; set; }
        public DeducationType DeducationType { get; set; }
        public string CityName { get; set; }
        public string Subject { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string DevelopmentState { get; set; }
        public TrainingPlace TrainingPlace { get; set; }
        public TrainingType TrainingType { get; set; }
    }

    public class TrainingFormModel
    {

        public int TrainingId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Corporation))]
        public int? CorporationId { get; set; }
        public string CorporationName { get; set; }
        public IEnumerable<CorporationGridRow> CorporationGrid { get; set; }
                  = new HashSet<CorporationGridRow>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentTypeA))]
        public int DevelopmentTypeAId { get; set; }
        public IEnumerable<DevelopmentTypeAListItem> DevelopmentTypeAList { get; set; }
            = new HashSet<DevelopmentTypeAListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentTypeB))]
        public int DevelopmentTypeBId { get; set; }
        public IEnumerable<DevelopmentTypeBListItem> DevelopmentTypeBList { get; set; }
            = new HashSet<DevelopmentTypeBListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentTypeC))]
        public int DevelopmentTypeCId { get; set; }
        public IEnumerable<DevelopmentTypeCListItem> DevelopmentTypeCList { get; set; }
            = new HashSet<DevelopmentTypeCListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentTypeD))]
        public int DevelopmentTypeDId { get; set; }
        public IEnumerable<DevelopmentTypeDListItem> DevelopmentTypeDList { get; set; }
            = new HashSet<DevelopmentTypeDListItem>();
        public IEnumerable<RequestedQualificationListItem> RequestedQualificationList { get; set; }
                      = new HashSet<RequestedQualificationListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.RequestedQualification))]
        public int? RequestedQualificationId { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExecutingAgency))]
        public string ExecutingAgency { get; set; }// الجهة المانحة

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        public string DecisionNumber { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeducationType))]
        public DeducationType DeducationType { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Country))]
        public int CountryId { get; set; }
        public IEnumerable<CountryListItem> CountryList { get; set; } = new HashSet<CountryListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.City))]
        public int CityId { get; set; }
        public IEnumerable<CityListItem> CityList { get; set; } = new HashSet<CityListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Subject))]
        public string Subject { get; set; }

        [Date]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.FromDate))]
        public string DateFrom { get; set; }

        [Date]
        [Display(ResourceType = typeof(SharedTitles), Name = nameof(SharedTitles.ToDate))]
        public string DateTo { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DevelopmentState))]
        public int? DevelopmentStateId { get; set; }
        public IEnumerable<DevelopmentStateListItem> DevelopmentStateList { get; set; }
                = new HashSet<DevelopmentStateListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingPlace))]
        public TrainingPlace TrainingPlace { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingType))]
        public TrainingType TrainingType { get; set; }
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionOrOkDate))]
        public string DecisionDate { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Course))]
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<CourseGridRow> CourseGrid { get; set; } = new HashSet<CourseGridRow>();
        public TrainingDetailForm TrainingDetailForm { get; set; } = new TrainingDetailForm();
        public bool CanSubmit { get; set; }
    }
}
