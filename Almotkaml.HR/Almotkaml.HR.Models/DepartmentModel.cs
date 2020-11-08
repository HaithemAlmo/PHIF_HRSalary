using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class DepartmentModel
    {
        public IEnumerable<DepartmentGridRow> DepartmentGrid { get; set; } = new HashSet<DepartmentGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
             ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public int CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        public int DepartmentId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Department))]
        public string Name { get; set; }
    }
    public class DepartmentGridRow
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string CenterName { get; set; }
        public int CenterId { get; set; }
    }
    public class DepartmentListItem
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }


}