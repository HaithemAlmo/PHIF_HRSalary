using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DivisionModel
    {
        public IEnumerable<DivisionGridRow> DivisionGrid { get; set; } = new HashSet<DivisionGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int DivisionId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Division))]
        public string Name { get; set; }
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.Department))]
        public int DepartmentId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
             ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public int CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
    }
    public class DivisionGridRow
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string CenterName { get; set; }
        public int DepartmentId { get; set; }

    }
    public class DivisionListItem
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
    }




}