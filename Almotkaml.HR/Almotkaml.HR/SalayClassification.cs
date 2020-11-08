using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum SalayClassification
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Default))]
        Default = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Clamp))]
        Clamp = 1,
             [Display(ResourceType = typeof(Title), Name = nameof(Title.Leader))]
        Leader =2

    }
}