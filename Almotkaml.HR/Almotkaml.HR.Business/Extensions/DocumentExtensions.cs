using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DocumentExtensions
    {
        public static IEnumerable<DocumentGridRow> ToGrid(this IEnumerable<Document> documents)
            => documents.Select(d => new DocumentGridRow()
            {
                DecisionNumber = d.DecisionNumber,
                IssuePlace = d.IssuePlace,
                DocumentType = d.DocumentType?.Name,
                IssueDate = d.IssueDate.FormatToString(),
                ExpireDate = d.ExpireDate?.FormatToString(),
                DocumentId = d.DocumentId,
                DecisionYear = d.DecisionYear,
                Number = d.Number
            }).ToList();
    }
}