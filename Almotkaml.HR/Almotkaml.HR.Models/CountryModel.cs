using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CountryModel
    {
        public IEnumerable<CountryGridRow> CountryGrid { get; set; } = new HashSet<CountryGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int CountryId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Country))]
        public string Name { get; set; }
    }

    public class CountryGridRow
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class CountryListItem
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }



}