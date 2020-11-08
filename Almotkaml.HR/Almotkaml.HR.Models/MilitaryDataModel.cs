using Almotkaml.Resources;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class MilitaryDataModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 2, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.AdjectiveMilitary))]
        public AdjectiveMilitary AdjectiveMilitary { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.MilitaryNumber))]
        public string MilitaryNumber { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Subunit))]
        public string Subunit { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Rank))]
        public string Rank { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.GranduationDate))]
        public string GranduationDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.MotherUnit))]
        public string MotherUnit { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.College))]
        public string College { get; set; }

        public bool CanSubmit { get; set; }

    }


}
