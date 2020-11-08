using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class ExactSpecialtyModel
    {
        public IEnumerable<ExactSpecialtyGridRow> ExactSpecialtyGrid { get; set; } = new HashSet<ExactSpecialtyGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int ExactSpecialtyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ExactSpecialty))]
        public string Name { get; set; }
        public IEnumerable<SpecialtyListItem> SpecialtyList { get; set; } = new HashSet<SpecialtyListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Specialty))]
        public int SpecialtyId { get; set; }
        public IEnumerable<SubSpecialtyListItem> SubSpecialtyList { get; set; } = new HashSet<SubSpecialtyListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.SubSpecialty))]
        public int SubSpecialtyId { get; set; }
        public bool CanSubmit { get; set; }
    }
    public class ExactSpecialtyGridRow
    {
        public int ExactSpecialtyId { get; set; }
        public string Name { get; set; }
        public string SubSpecialtyName { get; set; }
        public string SpecialtyName { get; set; }
        public int SubSpecialtyId { get; set; }
    }
    public class ExactSpecialtyListItem
    {
        public int ExactSpecialtyId { get; set; }
        public string Name { get; set; }
    }


}