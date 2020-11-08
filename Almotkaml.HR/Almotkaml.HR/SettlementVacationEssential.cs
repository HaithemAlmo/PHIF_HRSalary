using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum SettlementVacationEssential
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
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Other))]
        Other = 5,
    }
}