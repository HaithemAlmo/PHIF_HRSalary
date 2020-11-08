using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum IsTemporary
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsTemporary))]
        IsTemporary = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsNotTemporary))]
        IsNotTemporary = 2
    }
}