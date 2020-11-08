using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum SalaryInfoSearch
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SearchAll))]
        All = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Add))]
        Add = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Edit))]
        Edit = 2
    }
}