using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class RequestedQualificationModel
    {
        public IEnumerable<RequestedQualificationGridRow> Grid { get; set; } = new HashSet<RequestedQualificationGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int RequestedQualificationId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.RequestedQualification))]
        public string Name { get; set; }
    }
    public class RequestedQualificationGridRow
    {
        public int RequestedQualificationId { get; set; }
        public string Name { get; set; }
    }
    public class RequestedQualificationListItem
    {
        public int RequestedQualificationId { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }
    }
}
