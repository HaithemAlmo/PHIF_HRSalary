using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum ClampDegree
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Seven))]
        Seven = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Nine))]
        Nine = 9,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TenB))]
        TenB = 102,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TenA))]
        TenA = 101,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Eleven))]
        Eleven = 11,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Twelve))]
        Twelve = 12,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ThirteenB))]
        ThirteenB = 132,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ThirteenA))]
        ThirteenA = 131,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FourteenB))]
        FourteenB = 142,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.FourteenA))]
        FourteenA = 141,
    }
}