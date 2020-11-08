using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum Redirection
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.No))]
        No = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Yes))]
        Yes = 1
    }
}