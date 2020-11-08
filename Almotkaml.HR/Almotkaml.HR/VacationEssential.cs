using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum VacationEssential
    {
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.UnKounw))]
        UnKounw = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VacationYear))]
        Year = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Emergency))]
        Emergency = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.WithoutPay))]
        WithoutPay = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Sick))]
        Sick = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.alhaju))]
        alhaju = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.marriage))]
        marriage = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.maternityleave))]
        maternityleave = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.PaternityLeave))]
        PaternityLeave = 8,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.sickLeave))]
        sickleave = 9
    }
}