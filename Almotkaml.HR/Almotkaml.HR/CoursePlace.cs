using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum CoursePlace
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.CenterInside))]
        Inside = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.OtherFoundation))]
        Outside = 1
    }
}