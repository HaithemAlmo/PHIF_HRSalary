using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum Gender
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Male))]
        Male = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Female))]
        Female = 1
    }
}
