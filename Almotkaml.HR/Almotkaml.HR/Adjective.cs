using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum Adjective
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unknown))]
        Unknown = 0,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Civilian))]
        Civilian = 1,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Soldier))]
        Soldier = 2,
    }
}