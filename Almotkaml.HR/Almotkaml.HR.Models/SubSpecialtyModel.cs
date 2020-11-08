using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SubSpecialtyModel
    {
        public IEnumerable<SubSpecialtyGridRow> SubSpecialtyGrid { get; set; } = new HashSet<SubSpecialtyGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int SubSpecialtyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.SubSpecialty))]
        public string Name { get; set; }
        public IEnumerable<SpecialtyListItem> SpecialtyList { get; set; } = new HashSet<SpecialtyListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Specialty))]
        public int SpecialtyId { get; set; }
    }
    public class SubSpecialtyGridRow
    {
        public int SubSpecialtyId { get; set; }
        public string Name { get; set; }
        public string SpecialtyName { get; set; }
        public int SpecialtyId { get; set; }

    }
    public class SubSpecialtyListItem
    {
        public int SubSpecialtyId { get; set; }
        public string Name { get; set; }
    }


}