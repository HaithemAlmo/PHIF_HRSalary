using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum AdjectiveMilitary
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Officer))]
        Officer = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Ranker))]
        Ranker = 2
    }
}