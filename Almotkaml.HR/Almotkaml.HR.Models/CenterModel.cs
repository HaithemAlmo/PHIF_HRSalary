using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class CenterModel
    {
        public IEnumerable<CenterGridRow> CenterGrid { get; set; } = new HashSet<CenterGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int CenterId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public string Name { get; set; }
        public IEnumerable<CostCenterListItem> CostCenterList { get; set; } = new HashSet<CostCenterListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CostCenter))]
        public int? CostCenterId { get; set; }
    }
    public class CenterGridRow
    {
        public int CenterId { get; set; }
        public string Name { get; set; }
        public string CostCenterName { get; set; }
    }
    public class CenterListItem
    {
        public int CenterId { get; set; }
        public string Name { get; set; }
    }
    public class CostCenterListItem
    {
        public int CostCenterId { get; set; }
        public string Name { get; set; }
    }


}