using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum GuaranteeType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.GuaranteeTypeAll))]
        All = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Reduced))]
        Reduced = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Reduced35Year))]
        Reduced35Year = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.WithoutReduced))]
        WithoutReduced = 3,

    }
}