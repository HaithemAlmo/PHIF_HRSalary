using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum DonorFoundationType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Goverment))]
        Goverment = 1,// حكومية
        [Display(ResourceType = typeof(Title), Name = nameof(Title.General))]
        General = 2 //اهلية
    }
}