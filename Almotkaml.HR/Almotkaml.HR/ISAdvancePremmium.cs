using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum ISAdvancePremmium
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.isAdvance))]
        ISAdvance = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.isNotAdvance))]
        ISNotAdvance = 2
    }
}