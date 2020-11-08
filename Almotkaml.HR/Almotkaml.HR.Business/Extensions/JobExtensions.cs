using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class JobExtensions
    {
        public static IEnumerable<JobListItem> ToList(this IEnumerable<Job> jobs)
            => jobs.Select(d => new JobListItem()
            {
                Name = d.Name,
                JobId = d.JobId
            });

        public static IEnumerable<JobGridRow> ToGrid(this IEnumerable<Job> jobs)
            => jobs.Select(d => new JobGridRow()
            {
                JobId = d.JobId,
                Name = d.Name
            });
    }
}