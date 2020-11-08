using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class DocumentTypeExtensions
    {
        public static IEnumerable<DocumentTypeGridRow> ToGrid(this IEnumerable<DocumentType> documentTypes)
            => documentTypes.Select(d => new DocumentTypeGridRow()
            {
                DocumentTypeId = d.DocumentTypeId,
                Name = d.Name,
                HaveExpireDate = d.HaveExpireDate,
                HaveDecisionYear = d.HaveDecisionYear,
                HaveDecisionNumber = d.HaveDecisionNumber
            });

        public static IEnumerable<DocumentTypeListItem> ToList(this IEnumerable<DocumentType> documentTypes)
            => documentTypes.Select(d => new DocumentTypeListItem()
            {
                DocumentTypeId = d.DocumentTypeId,
                Name = d.Name
            });
    }
}