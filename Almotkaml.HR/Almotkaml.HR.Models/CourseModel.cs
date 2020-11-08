using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class CourseIndexModel
    {
        public IEnumerable<CourseGridRow> CourseGrid { get; set; } = new HashSet<CourseGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

    }

    public class CourseGridRow
    {
        public int CourseId { get; set; }
        public TrainingType TrainingType { get; set; }
        public string Name { get; set; }
        public CoursePlace CoursePlace { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string NameFoundation { get; set; }

    }
    public class CourseListItem
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }

    public class CourseFormModel
    {
        public int CourseId { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.TrainingType))]
        public TrainingType TrainingType { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]


        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.CoursePlace))]
        public CoursePlace CoursePlace { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]


        [Display(ResourceType = typeof(Title), Name = nameof(Title.City))]
        public int CityId { get; set; }

        public IEnumerable<CityListItem> CityList { get; set; } = new HashSet<CityListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]


        [Display(ResourceType = typeof(Title), Name = nameof(Title.Country))]
        public int CountryId { get; set; }


        public IEnumerable<CountryListItem> CountryList { get; set; } = new HashSet<CountryListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.FoundationName))]
        public string FoundationName { get; set; }

        public bool CanSubmit { get; set; }
    }
}
