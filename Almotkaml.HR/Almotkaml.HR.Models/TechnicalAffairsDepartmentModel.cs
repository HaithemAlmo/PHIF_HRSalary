using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;
using System;

namespace Almotkaml.HR.Models
{

    public class TechnicalAffairsDepartmentModel : IValidatable
    {

        //[Display(ResourceType = typeof(Title), Name = nameof(Title.CountKids))]
        //public CountKids CountKids { get; set; }
        //public IEnumerable<TechnicalAffairsDepartmentGridRow> VacationGrid { get; set; } = new HashSet<TechnicalAffairsDepartmentGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public long TechnicalAffairsDepartmentId { get; set; }


        public IEnumerable<EntrantsAndReviewersGridRow> EmployeeGrid { get; set; } = new HashSet<EntrantsAndReviewersGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EntrantsAndReviewers))]
        public string EntrantsAndReviewersId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //      [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthWork))]
        public int MonthWork { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1950, 2250, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.YearWork))]
        public int YearWork { get; set; }

        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.DataEntry))]
        public string DataEntry { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.DataEntryDemand))]
        public bool DataEntryDemand { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.DataEntryDemand1))]
        public bool DataEntryDemand1 { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstReview))]
        public string FirstReview { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstReviewDemand))]
        public bool FirstReviewDemand { get; set; }

        // [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstReviewDemand1))]
        public bool FirstReviewDemand1 { get; set; }

        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.AccommodationReview))]
        public string AccommodationReview { get; set; }

        // [Display(ResourceType = typeof(Title), Name = nameof(Title.AccommodationReviewDemand))]
        public bool AccommodationReviewDemand { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.AccommodationReviewDemand1))]
        public bool AccommodationReviewDemand1 { get; set; }

        // [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReview))]
        public string ClincReview { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReviewDemand))]
        public bool ClincReviewDemand { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReviewDemand1))]
        public bool ClincReviewDemand1 { get; set; }


        public void Validate(ModelState modelState)
        {

        }

        public class TechnicalAffairsDepartmentListItem
        {
            public long TechnicalAffairsDepartmentId { get; set; }
            public int EntrantsAndReviewersId { get; set; }
            public string EmployeeName { get; set; }
            public int MonthWork { get; set; }
            public int YearWork { get; set; }
            public string DataEntry { get; set; }
            public string DataEntryDemand { get; set; }
        }
        public class TechnicalAffairsDepartmentGridRow
        {
            public long TechnicalAffairsDepartmentId { get; set; }
            public int EntrantsAndReviewersId { get; set; }
            public string EmployeeName { get; set; }
            public int MonthWork { get; set; }
            public int YearWork { get; set; }
            public string DataEntry { get; set; }
            public string DataEntryDemand { get; set; }
        }

    }

}