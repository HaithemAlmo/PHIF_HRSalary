using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class ClassificationOnSearchingExtensions
    {
        public static IEnumerable<ClassificationOnSearchingListItem> ToList(this IEnumerable<ClassificationOnSearching> ClassificationOnSearchings)
            => ClassificationOnSearchings.Select(d => new ClassificationOnSearchingListItem()
            {
                Name = d.Name,
                ClassificationOnSearchingId = d.ClassificationOnSearchingId
            });

        public static IEnumerable<ClassificationOnSearchingGridRow> ToGrid(this IEnumerable<ClassificationOnSearching> ClassificationOnSearchings)
            => ClassificationOnSearchings.Select(d => new ClassificationOnSearchingGridRow()
            {
                ClassificationOnSearchingId = d.ClassificationOnSearchingId,
                Name = d.Name
            });
    }
}