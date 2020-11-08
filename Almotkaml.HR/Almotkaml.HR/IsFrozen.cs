using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum IsFrozen
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsFrozen))]
        IsFrozen = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsNotFrozen))]
        IsNotFrozen = 2
    }
}