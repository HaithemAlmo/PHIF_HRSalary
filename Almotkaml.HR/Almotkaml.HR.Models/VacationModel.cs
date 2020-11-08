using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;
using System;

namespace Almotkaml.HR.Models
{

    public class VacationModel : IValidatable
    {

        [Display(ResourceType = typeof(Title), Name = nameof(Title.CountKids))]
        public CountKids CountKids { get; set; }
        public IEnumerable<VacationGridRow> VacationGrid { get; set; } = new HashSet<VacationGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanVacationBalance { get; set; }
        public long VacationId { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public string CenterName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Department))]
        public string DepartmentName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Division))]
        public string DivisionName { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unit))]
        public string UnitName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
                    ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]
        public string DateFrom { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]
        public DateTime DateTo { get; set; }
        public DateTime DateFrom2 { get; set; }
        public DateTime DateTo2 { get; set; }
        public string DateTo3 { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Days))]
        public int Days { get; set; }
        public int Days2 { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Balance))]
        public int Balance { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BalanceEmergency))]
        public int BalanceEmergency { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BalanceAlhuje))]
        public int BalanceAlhuje { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BalanceMarriage))]
        public int BalanceMarriage { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BalanceSick))]
        public int BalanceSick { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
                ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.sickLeave))]
        public int sickLeave { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
                ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationType))]
        public int VacationTypeId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CountKids))]
        //public int CountKids { get; set; }
        //public IEnumerable<CountKidsListItem> CountKidsList { get; set; } = new HashSet<CountKidsListItem>();


        public IEnumerable<VacationTypeListItem> VacationTypeList { get; set; } = new HashSet<VacationTypeListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages)
    , ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionNumber))]
        public string DecisionNumber { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DecisionDate))]
        public string DecisionDate { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationPlace))]
        public bool Place { get; set; }
        [Date]
        public string DateVacationBalanceYear { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public bool CanSubmit { get; set; }

        public void Validate(ModelState modelState)
        {
            if (DateTo < DateFrom.ToDateTime())
                modelState.AddError(m => DateFrom, SharedMessages.InvalidDateRange);
        }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }
     public string NoteTest { get; set; }
        public bool IsReadOnly { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionMonth))]
        public int DeductionMonth { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1950, 2250, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionYear))]
        public int DeductionYear { get; set; }

    }
    public enum CountKids
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.One))]
        One = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Tow))]
        Tow = 2,
    }
    //public class CountKidsListItem
    //{
    //    public int countkidsID { get; set; }
    //    public string Name { get; set; }
    //}


    public class VacationGridRow
    {
        public long VacationId { get; set; }
        public string VacationTypeName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int Days { get; set; }
        public string DecisionNumber { get; set; }
        public string DecisionDate { get; set; }
        public string Place { get; set; }

     
    }


}
