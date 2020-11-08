using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class JobModel
    {
        public IEnumerable<JobGridRow> JobGrid { get; set; } = new HashSet<JobGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int JobId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.Job))]
        public string Name { get; set; }
    }
    public class JobGridRow
    {
        public int JobId { get; set; }
        public string Name { get; set; }
    }
    public class JobListItem
    {
        public int JobId { get; set; }
        public string Name { get; set; }
    }



}