using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SanctionTypeModel
    {
        public IEnumerable<SanctionTypeGridRow> SanctionTypeGrid { get; set; } = new HashSet<SanctionTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int SanctionTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.SanctionType))]
        public string Name { get; set; }
    }

    public class SanctionTypeGridRow
    {
        public int SanctionTypeId { get; set; }
        public string Name { get; set; }
    }

    public class SanctionTypeListItem
    {
        public int SanctionTypeId { get; set; }
        public string Name { get; set; }
    }

}