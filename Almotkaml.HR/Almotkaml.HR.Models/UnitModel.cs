using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class UnitModel
    {
        public IEnumerable<UnitGridRow> UnitGrid { get; set; } = new HashSet<UnitGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int UnitId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.Unit))]
        public string Name { get; set; }
        public IEnumerable<DepartmentListItem> DepartmentList { get; set; } = new HashSet<DepartmentListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Department))]
        public int DepartmentId { get; set; }
        public IEnumerable<DivisionListItem> DivisionList { get; set; } = new HashSet<DivisionListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Division))]
        public int DivisionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
             ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Center))]
        public int CenterId { get; set; }
        public IEnumerable<CenterListItem> CenterList { get; set; } = new HashSet<CenterListItem>();
        public bool CanSubmit { get; set; }
    }
    public class UnitGridRow
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string CenterName { get; set; }
        public int DivisionId { get; set; }
    }
    public class UnitListItem
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
    }


}