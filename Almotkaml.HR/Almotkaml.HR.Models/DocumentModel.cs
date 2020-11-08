using Almotkaml.Attributes;
using Almotkaml.Extensions;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class DocumentModel : IValidatable
    {
        public int EmployeeId { get; set; }
        public int DocumentId { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages)
            , ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DocumentType))]
        public int DocumentTypeId { get; set; }
        public IEnumerable<DocumentTypeListItem> DocumentTypeList { get; set; } = new HashSet<DocumentTypeListItem>();

        [Date]
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssueDate))]
        public string IssueDate { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.IssuePlace))]
        public string IssuePlace { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Notes))]
        public string Note { get; set; }
        public int Number { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DecisionNumber))]
        public int? DecisionNumber { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.DecisionYear))]
        public int? DecisionYear { get; set; }

        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ExpireDate))]
        public string ExpireDate { get; set; }
        public bool HaveDecisionNumber { get; set; }
        public bool HaveDecisionYear { get; set; }
        public bool HaveExpireDate { get; set; }

        public ICollection<int> LoadedImages { get; set; } = new HashSet<int>();
        public IList<byte[]> SavedImages { get; set; } = new List<byte[]>();

        //public IList<DocumentImageForm> Images { get; set; } = new List<DocumentImageForm>();

        public IEnumerable<DocumentGridRow> DocumentGrid { get; set; } = new HashSet<DocumentGridRow>();

        public void Validate(ModelState modelState)
        {
            if (HaveDecisionNumber && (DecisionNumber == null || DecisionNumber <= 0))
                modelState.AddError(m => DecisionNumber, string.Format(SharedMessages.IsRequired, Title.DecisionNumber));

            if (HaveDecisionYear && (DecisionYear == null || DecisionYear < 1900 || DecisionYear > 2100))
                modelState.AddError(m => DecisionYear, string.Format(SharedMessages.IsRequired, Title.DecisionYear));

            var expireDate = ExpireDate.ToDateTime();

            if (HaveExpireDate && (expireDate.Year < 1900 || expireDate.Year > 2100))
                modelState.AddError(m => ExpireDate, SharedMessages.InvalidDate);
        }
    }

    public class DocumentGridRow
    {
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string IssueDate { get; set; }
        public string IssuePlace { get; set; }
        public int Number { get; set; }
        public int? DecisionNumber { get; set; }
        public int? DecisionYear { get; set; }
        public string ExpireDate { get; set; }
    }

    public class DocumentTypeListItem
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
    }

    public class DocumentImageForm
    {
        public byte[] Image { get; set; }
        public int DocumentImageId { get; set; }
    }
}