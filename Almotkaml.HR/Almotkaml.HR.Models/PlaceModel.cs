using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class PlaceModel
    {
        public IEnumerable<PlaceGridRow> PlaceGrid { get; set; } = new HashSet<PlaceGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int PlaceId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.Place))]
        public string Name { get; set; }
        public IEnumerable<BranchListItem> BranchList { get; set; } = new HashSet<BranchListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Branch))]
        public int BranchId { get; set; }
    }
    public class PlaceGridRow
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string BranchName { get; set; }
        public int BranchId { get; set; }

    }
    public class PlaceListItem
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
    }


}