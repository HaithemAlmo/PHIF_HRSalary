using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum Grade
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Excellent))]
        Excellent = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VeryGood))]
        VeryGood = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Good))]
        Good = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Acceptable))]
        Acceptable = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Weak))]
        Weak = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.VeryWeak))]
        VeryWeak = 6


    }
}
