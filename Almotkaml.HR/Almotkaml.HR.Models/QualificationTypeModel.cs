using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class QualificationTypeModel
    {
        public IEnumerable<QualificationTypeGridRow> QualificationTypeGrid { get; set; } = new HashSet<QualificationTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int QualificationTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
           Name = nameof(Title.QualificationType))]
        public string Name { get; set; }
    }
    public class QualificationTypeGridRow
    {
        public int QualificationTypeId { get; set; }
        public string Name { get; set; }
    }
    public class QualificationTypeListItem
    {
        public int QualificationTypeId { get; set; }
        public string Name { get; set; }
    }


}