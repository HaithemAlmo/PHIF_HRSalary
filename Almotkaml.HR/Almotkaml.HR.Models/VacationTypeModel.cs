using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class VacationTypeModel
    {
        public IEnumerable<VacationTypeGridRow> Grid { get; set; }
            = new HashSet<VacationTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int VacationTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationType))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DiscountPercentage))]
        public int? DiscountPercentage { get; set; }
        public VacationEssential VacationEssential { get; internal set; }
        public int? Days { get; set; }
    }
    public class VacationTypeGridRow
    {
        public int VacationTypeId { get; set; }
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }
        public int Days { get; set; }
        public bool CanEditAndDelete { get; set; }
    }
    public class VacationTypeListItem
    {
        public int VacationTypeId { get; set; }
        public string Name { get; set; }
    }


}
