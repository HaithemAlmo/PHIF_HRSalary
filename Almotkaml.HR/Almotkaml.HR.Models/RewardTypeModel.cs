using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class RewardTypeModel
    {
        public IEnumerable<RewardTypeGridRow> RewardTypeGrid { get; set; } = new HashSet<RewardTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int RewardTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.RewardType))]

        public string Name { get; set; }
    }

    public class RewardTypeGridRow
    {
        public int RewardTypeId { get; set; }
        public string Name { get; set; }
    }

    public class RewardTypeListItem
    {
        public int RewardTypeId { get; set; }
        public string Name { get; set; }
    }


}