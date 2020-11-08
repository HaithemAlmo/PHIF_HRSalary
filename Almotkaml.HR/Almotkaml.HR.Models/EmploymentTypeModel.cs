using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class EmploymentTypeIndexModel
    {
        public IEnumerable<EmploymentTypeGridRow> EmploymentTypeGrid { get; set; } = new HashSet<EmploymentTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }
    public class EmploymentTypeGridRow
    {
        public int EmploymentTypeId { get; set; }
        public string Name { get; set; }
        public bool DesignationResolutionNumber { get; set; } // رقم القرار للتعيين
        public bool DesignationResolutionDate { get; set; }// تاريح القرار للتعيين
        public bool DesignationIssue { get; set; } // جهة الصدور للتعيين
        public bool ContractDate { get; set; }
        public bool ContractDuration { get; set; } //مدة العقد

    }
    public class EmploymentTypeListItem
    {
        public int EmploymentTypeId { get; set; }
        public string Name { get; set; }
    }

    public class EmploymentTypeFormModel
    {
        public int EmploymentTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.EmploymentType))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.DesignationResolutionNumber))]
        public bool DesignationResolutionNumber { get; set; } // رقم القرار للتعيين

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DesignationResolutionDate))]
        public bool DesignationResolutionDate { get; set; } // تاريح القرار للتعيين

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DesignationIssue))]
        public bool DesignationIssue { get; set; } // جهة الصدور للتعيين

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ContractDate))]
        public bool ContractDate { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ContractDuration))]
        public bool ContractDuration { get; set; } //مدة العقد

        public bool CanSubmit { get; set; }
    }
}