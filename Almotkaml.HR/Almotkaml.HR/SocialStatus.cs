using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum SocialStatus
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unknown))]
        Unknown = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Single))]
        Single = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Marrid))]
        Marrid = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Divorcee))]
        Divorcee = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Widower))]
        Widower = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.MarridAndNurture))]
        MarridAndNurture = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.DivorceeAndNurture))]
        DivorceeAndNurture = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.WidowerAndNurture))]
        WidowerAndNurture = 7

    }
}