using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class RequestedQualificationExtensions
    {
        public static IEnumerable<RequestedQualificationGridRow> ToGrid(this IEnumerable<RequestedQualification> requestedQualifications)
           => requestedQualifications.Select(d => new RequestedQualificationGridRow()
           {
               RequestedQualificationId = d.RequestedQualificationId,
               Name = d.Name
           });
        public static IEnumerable<RequestedQualificationListItem> ToList(this IEnumerable<RequestedQualification> requestedQualifications)
            => requestedQualifications.Select(d => new RequestedQualificationListItem()
            {
                Name = d.Name,
                RequestedQualificationId = d.RequestedQualificationId
            });
    }
}