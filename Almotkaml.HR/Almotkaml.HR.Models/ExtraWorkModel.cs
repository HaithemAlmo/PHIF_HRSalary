using Almotkaml.Attributes;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class ExtraWorkModel
    {
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<ExtraWorkGridRow> ExtraWorkGridRows { get; set; } = new HashSet<ExtraWorkGridRow>();
        public long ExtraWorkId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }

        public IEnumerable<EmployeeGridRow> EmployeeGrid = new HashSet<EmployeeGridRow>();
        public string EmployeeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 24, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TimeCount))]
        public decimal TimeCount { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AssigningBookNumber))]
        public string DecisionNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AssigningDate))]
        public string Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateFrom))]
        public string DateFrom { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DateTo))]
        public string DateTo { get; set; }

        public bool CanSubmit { get; set; }
    }

    public class ExtraWorkGridRow
    {
        public long ExtraworkId { get; set; }
        public string EmployeeName { get; set; }
        public decimal TimeCount { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }



}
