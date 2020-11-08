using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum PlaceCourse
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Inside))]
        Inside = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Outside))]
        Outside = 2
    }
}
