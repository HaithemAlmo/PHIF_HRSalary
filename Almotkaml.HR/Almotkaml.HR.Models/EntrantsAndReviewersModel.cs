using Almotkaml.Attributes;
using Almotkaml.HR.Models.Resources;
using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Models
{
    public class EntrantsAndReviewersModel
    { 
        public IEnumerable<EntrantsAndReviewersGridRow> EntrantsAndReviewersGrid { get; set; } = new HashSet<EntrantsAndReviewersGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeNumber))]
        public int EmployeeNumber { get; set; }
        public int EntrantsAndReviewersId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public string EmployeeName { get; set; }

        [MaxLength(12, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.NationalNumber))]
        [MinLength(12, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = nameof(ValidationMessages.NationalNumber))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.NationalNumber))]
        public string NationalNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Gender))]
        public Gender Gender { get; set; }
        
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Phone))]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Email))]
        public string Email { get; set; }

        [Date]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.StartDate))]
        public string StartDate { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EntrantsAndReviewersType))]
        public EntrantsAndReviewersType EntrantsAndReviewersType { get; set; }

        public TechnicalAffairsDepartmentModel TechnicalAffairsDepartmentModel { get; set; } = new TechnicalAffairsDepartmentModel();
       }

    public class EntrantsAndReviewersGridRow
    {
        public int EntrantsAndReviewersId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
        public string Note { get; set; }
        public EntrantsAndReviewersType EntrantsAndReviewersType { get; set; }

    }

    public class EntrantsAndReviewersListItem
    {
        public int EntrantsAndReviewersId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
        public string Note { get; set; }
    }
}
