using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CityModel
    {
        public IEnumerable<CityGridRow> CityGrid { get; set; } = new HashSet<CityGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int CityId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
        ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
        Name = nameof(Title.City))]
        public string Name { get; set; }
        public IEnumerable<CountryListItem> CountryList { get; set; } = new HashSet<CountryListItem>();
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Country))]
        public int CountryId { get; set; }
    }
    public class CityGridRow
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }

    }
    public class CityListItem
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }


}