using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class NationalityModel
    {
        public IEnumerable<NationalityGridRow> NationalityGrid { get; set; } = new HashSet<NationalityGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int NationalityId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Nationality))]
        public string Name { get; set; }
    }

    public class NationalityGridRow
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
    }
    public class NationalityListItem
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
    }


}