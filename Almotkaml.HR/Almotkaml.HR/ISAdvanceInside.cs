using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum ISAdvanceInside
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsAdvanceInside))]
        AdvanceInside = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IAdvanceOutside))]
        AdvanceOutside = 2
    }
}