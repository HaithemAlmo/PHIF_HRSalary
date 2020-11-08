using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class QualificationTypeExtensions
    {
        public static IEnumerable<QualificationTypeListItem> ToList(this IEnumerable<QualificationType> qualificationTypes)
            => qualificationTypes.Select(d => new QualificationTypeListItem()
            {
                Name = d.Name,
                QualificationTypeId = d.QualificationTypeId
            });
    }
}