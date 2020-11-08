using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum DeducationType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Totaller))]
        Totaller = 1, // كلي
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Partial))]
        Partial = 2 // جزئي
    }
}