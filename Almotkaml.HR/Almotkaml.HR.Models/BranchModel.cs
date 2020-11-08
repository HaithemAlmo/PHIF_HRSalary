using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class BranchModel
    {
        public IEnumerable<BranchGridRow> BranchGrid { get; set; } = new HashSet<BranchGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int BranchId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Branch))]
        public string Name { get; set; }
    }
    public class BranchGridRow
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
    }
    public class BranchListItem
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
    }






}