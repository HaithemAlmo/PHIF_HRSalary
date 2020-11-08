using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CorporationIndexModel
    {
        public IEnumerable<CorporationGridRow> CorporationGrid { get; set; } = new HashSet<CorporationGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }

    public class CorporationGridRow
    {
        public int CorporationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string Note { get; set; }
    }

    public class CorporationFormModel
    {
        public int CorporationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Phone))]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Email))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Address))]
        public string Address { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.City))]
        public int CityId { get; set; }
        public IEnumerable<CityListItem> CityList { get; set; } = new HashSet<CityListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Country))]
        public int CountryId { get; set; }
        public IEnumerable<CountryListItem> CountryList { get; set; } = new HashSet<CountryListItem>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Note))]
        public string Note { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DonorFoundationType))]
        public DonorFoundationType DonorFoundationType { get; set; }// نوع الجهة المانحة
        public bool CanSubmit { get; set; }
    }
}
