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
        
       //[Display(ResourceType = typeof(Title), Name = nameof(Title.EntrantsAndReviewersId))]
        public string EntrantsAndReviewersId { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionMonth))]
        public int MonthWork { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1950, 2250, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionYear))]
        public int YearWork { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public string DataEntry { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool DataEntryDemand { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool DataEntryDemand1 { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public string FirstReview { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool FirstReviewDemand { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool FirstReviewDemand1 { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public string AccommodationReview { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool AccommodationReviewDemand { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool AccommodationReviewDemand1 { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public string ClincReview { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool ClincReviewDemand { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool ClincReviewDemand1 { get; set; }
        

        public void Validate(ModelState modelState)
        {
      
        }
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.CountKids))]
        //public int CountKids { get; set; }
        //public IEnumerable<CountKidsListItem> CountKidsList { get; set; } = new HashSet<CountKidsListItem>();


        //    public IEnumerable<VacationTypeListItem> VacationTypeList { get; set; } = new HashSet<VacationTypeListItem>();
        //    [Required(ErrorMessageResourceType = typeof(SharedMessages)
        //, ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]

        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        //    public int EmployeeId { get; set; }

        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        //    public string DecisionNumber { get; set; }
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        //    public string DecisionDate { get; set; }
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        //    public bool Place { get; set; }
        //    [Date]
        //    public string DateVacationBalanceYear { get; set; }
        //    public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        //    public bool CanSubmit { get; set; }

        //    public void Validate(ModelState modelState)
        //    {
        //        if (DateTo < DateFrom.ToDateTime())
        //            modelState.AddError(m => DateFrom, SharedMessages.InvalidDateRange);
        //    }
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        //    public string Note { get; set; }
        // public string NoteTest { get; set; }
        //    public bool IsReadOnly { get; set; }

        //}
        //public enum CountKids
        //{
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.One))]
        //    One = 1,
        //    [Display(ResourceType = typeof(Title), Name = nameof(Title.Tow))]
        //    Tow = 2,
        //}
        //public class CountKidsListItem
        //{
        //    public int countkidsID { get; set; }
        //    public string Name { get; set; }
        //}


        //public class TechnicalAffairsDepartmentGridRow
        //{
        //    public long TechnicalAffairsDepartmentId { get; set; }

        //    //public string  { get; set; }
        //    public string MonthWorh { get; set; }
        //    public string YearWork { get; set; }
        //    public int Days { get; set; }
        //    public string DecisionNumber { get; set; }
        //    public string DecisionDate { get; set; }
        //    public string Place { get; set; }


    }


}
