using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum DiscountOrBoun
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Bouns))]
        Boun = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Discount))]
        Discount = 2
    }
}