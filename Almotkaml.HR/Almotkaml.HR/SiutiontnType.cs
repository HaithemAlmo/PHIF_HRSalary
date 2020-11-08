using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum SiutiontnType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Sitionsone))]
        Sitionsone = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SitionTwo))]
        SitionTwo = 1
    }
}
