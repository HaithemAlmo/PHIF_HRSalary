using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum AbsenceType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Excuse))]
        Excuse = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.NoExcuse))]
        NoExcuse = 2
    }
}