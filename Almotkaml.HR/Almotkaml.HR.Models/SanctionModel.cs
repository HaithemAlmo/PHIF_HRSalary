using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SanctionModel
    {
        public IEnumerable<SanctionGridRow> SanctionGrid { get; set; } = new HashSet<SanctionGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


        public int SanctionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.SanctionType))]
        public int SanctionTypeId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }
        public IEnumerable<SanctionTypeListItem> SanctionTypeList { get; set; } = new HashSet<SanctionTypeListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
       ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Date))]
        public string Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
      ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Cause))]
        public string Cause { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Employee))]
        public int EmployeeId { get; set; }

        [Display(ResourceType = typeof(Title),
       Name = nameof(Title.SanctionDays))]
        public int SanctionsDay { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionMonth))]
        public short DeductionMonth { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1950, 2250, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DeductionYear))]
        public short DeductionYear { get; set; }


        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
        public bool CanSubmit { get; set; }
    }
    public class SanctionGridRow
    {
        public int SanctionId { get; set; }
        public int SanctionTypeId { get; set; }
        public string SanctionTypeName { get; set; }
        public string Date { get; set; }
        public string Cause { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        //public int SanctionsDay { get; set; }
    }



}