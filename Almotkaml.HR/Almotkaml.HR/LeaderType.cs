using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum LeaderType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unknown))]
        unknown = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF1))]
        HIF1 = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF2))]
        HIF2 = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF3))]
        HIF3 = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF4))]
        HIF4 = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF5))]
        HIF5 = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF6))]
        HIF6 = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF7))]
        HIF7 = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF8))]
        HIF8 = 8,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF9))]
        HIF9 = 9,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF10))]
        HIF10 = 10,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF11))]
        HIF11 = 11,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.HIF12))]
        HIF12 = 12
    }
}
