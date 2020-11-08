using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Aldo
{
    public enum JobClass
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Engineers))]
        Engineers = 11,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ThehnicalEngineers))]
        ThehnicalEngineers = 12,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Technicians))]
        Technicians = 20,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Physicists))]
        Physicists = 31,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Chemists))]
        Chemists = 32,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Programmers))]
        Programmers = 41,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Athletes))]
        Athletes = 42,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Statisticians))]
        Statisticians = 43,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Administrators))]
        Administrators = 51,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Malians))]
        Malians = 52,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Legal))]
        Legal = 61,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Journalists))]
        Journalists = 62,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IndustralSafety))]
        IndustralSafety = 71,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ProfessionalSafety))]
        ProfessionalSafety = 72,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Services))]
        Services = 80,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.OtherClasses))]
        OtherClasses = 90
    }
}
