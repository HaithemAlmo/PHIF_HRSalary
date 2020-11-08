using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum CoachType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Inside))]
        Inside = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Outside))]
        Outside = 1
    }
}