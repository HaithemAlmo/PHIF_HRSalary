using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.Extensions
{
    public static class ClassificationOnWorkExtensions
    {
        public static IEnumerable<ClassificationOnWorkListItem> ToList(this IEnumerable<ClassificationOnWork> ClassificationOnWorks)
            => ClassificationOnWorks.Select(d => new ClassificationOnWorkListItem()
            {
                Name = d.Name,
                ClassificationOnWorkId = d.ClassificationOnWorkId
            });

        public static IEnumerable<ClassificationOnWorkGridRow> ToGrid(this IEnumerable<ClassificationOnWork> ClassificationOnWorks)
            => ClassificationOnWorks.Select(d => new ClassificationOnWorkGridRow()
            {
                ClassificationOnWorkId = d.ClassificationOnWorkId,
                Name = d.Name
            });
    }
}