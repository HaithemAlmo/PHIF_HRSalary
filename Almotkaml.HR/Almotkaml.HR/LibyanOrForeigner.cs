using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum LibyanOrForeigner
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Libyan))]
        Libyan = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Foreigner))]
        Foreigner = 1
    }
}