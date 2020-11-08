using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SpecialtyModel
    {
        public IEnumerable<SpecialtyGridRow> SpecialtyGrid { get; set; } = new HashSet<SpecialtyGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int SpecialtyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Specialty))]
        public string Name { get; set; }


      


    }

    public class SpecialtyGridRow
    {
        public int SpecialtyId { get; set; }
        public string Name { get; set; }
    }

    public class SpecialtyListItem
    {
        public int SpecialtyId { get; set; }
        public string Name { get; set; }

    }



}