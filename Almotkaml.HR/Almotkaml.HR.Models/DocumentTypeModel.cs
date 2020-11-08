using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DocumentTypeModel
    {
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DocumentType))]
        public string Name { get; set; }
        public bool HaveDecisionNumber { get; set; }
        public bool HaveDecisionYear { get; set; }
        public bool HaveExpireDate { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public IEnumerable<DocumentTypeGridRow> DocumentTypeGrid { get; set; } = new HashSet<DocumentTypeGridRow>();
    }

    public class DocumentTypeGridRow
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public bool HaveDecisionNumber { get; set; }
        public bool HaveDecisionYear { get; set; }
        public bool HaveExpireDate { get; set; }
    }
}