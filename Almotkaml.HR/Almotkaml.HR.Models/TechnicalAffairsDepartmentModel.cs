using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;
using System;

namespace Almotkaml.HR.Models
{

    public class TechnicalAffairsDepartmentModel 
    {
        //: IValidatable
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.CountKids))]
        //public CountKids CountKids { get; set; }
        //public IEnumerable<TechnicalAffairsDepartmentGridRow> VacationGrid { get; set; } = new HashSet<TechnicalAffairsDepartmentGridRow>();
        //public IEnumerable<TechnicalAffairsDepartmentGridRow> TechnicalAffairsDepartmentGrid { get; set; } = new HashSet<TechnicalAffairsDepartmentGridRow>();
        public IEnumerable<EntrantsAndReviewersGridRow > EntrantsAndReviewersGrid { get; set; } = new HashSet<EntrantsAndReviewersGridRow>();
        public IEnumerable<TechnicalAffairsDepartmentGridRow> TechnicalAffairsDepartmentGrid { get; set; } = new HashSet<TechnicalAffairsDepartmentGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int TechnicalAffairsDepartmentId { get; set; }



        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EntrantsAndReviewers))]
        public int  EntrantsAndReviewersId { get; set; }

     
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.EntrantsAndReviewersType))]
        public EntrantsAndReviewersType EntrantsAndReviewersType { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //      [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthWork))]
        public int MonthWork { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1950, 2250, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.YearWork))]
        public int YearWork { get; set; }

        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.DataEntry))]
        public int DataEntry { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.DataEntryDemand))]
        public decimal  DataEntryBalance { get; set; }

 

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstReview))]
        public int FirstReview { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.FirstReviewDemand))]
        public decimal  FirstReviewBalance { get; set; }

   
        //   [Display(ResourceType = typeof(Title), Name = nameof(Title.AccommodationReview))]
        public int AccommodationReview { get; set; }

        // [Display(ResourceType = typeof(Title), Name = nameof(Title.AccommodationReviewDemand))]
        public decimal  AccommodationReviewBalance { get; set; }


        // [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReview))]
        public int ClincReview { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReviewDemand))]
        public decimal  ClincReviewBalance { get; set; }

        //  [Display(ResourceType = typeof(Title), Name = nameof(Title.ClincReviewDemand1))]
        public decimal TotalBalance { get; set; }

        public string Note { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsPaid))]
        public bool  IsPaid { get; set; }
        //public void Validate(ModelState modelState)
        //{

        //}

        public class TechnicalAffairsDepartmentListItem
        {
            public long TechnicalAffairsDepartmentId { get; set; }
            public int EntrantsAndReviewersId { get; set; }
            public string EmployeeName { get; set; }
            public int MonthWork { get; set; }
            public int YearWork { get; set; }
            public decimal TotalBalance { get; set; }
            //public string DataEntryDemand { get; set; }
        }
        public class TechnicalAffairsDepartmentGridRow
        {
            public long TechnicalAffairsDepartmentId { get; set; }
            public int EntrantsAndReviewersId { get; set; }
            public string EmployeeName { get; set; }
            public int MonthWork { get; set; }
            public int YearWork { get; set; }
            public decimal  TotalBalance { get; set; }
            public EntrantsAndReviewersType EntrantsAndReviewersType { get; set; }
            //public string DataEntryDemand { get; set; }
        }

    }

}