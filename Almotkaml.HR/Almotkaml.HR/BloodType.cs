using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum BloodType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unknown))]
        Unknown = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.OPlus))]
        OPlus = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AbPlus))]
        AbPlus = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.APlus))]
        APlus = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BPlus))]
        BPlus = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.OMinus))]
        OMinus = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AbMinus))]
        AbMinus = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AMinus))]
        AMinus = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.BMinus))]
        BMinus = 8
    }
}