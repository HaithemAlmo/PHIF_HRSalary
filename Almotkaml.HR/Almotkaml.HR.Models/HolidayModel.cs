using Almotkaml.HR.Models.Resources;
using Almotkaml.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class HolidayModel : IValidatable
    {
        public IEnumerable<HolidayGridRow> HolidayGrid { get; set; } = new HashSet<HolidayGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int HolidayId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 31, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DayFrom))]
        public short DayFrom { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 31, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DayTo))]
        public short DayTo { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthFrom))]
        public short MonthFrom { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 12, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.MonthTo))]
        public short MonthTo { get; set; }

        public void Validate(ModelState modelState)
        {
            var dateFrom = new DateTime(DateTime.Now.Year, MonthFrom, DayFrom);
            var dateTo = new DateTime(DateTime.Now.Year, MonthTo, DayTo);

            if (dateFrom > dateTo)
                modelState.AddError(m => DayFrom, ValidationMessages.HolidayError);
        }
    }
    public class HolidayGridRow
    {
        public int HolidayId { get; set; }
        public string Name { get; set; }
        public short DayFrom { get; set; }
        public short DayTo { get; set; }
        public short MonthFrom { get; set; }
        public short MonthTo { get; set; }

    }
}
