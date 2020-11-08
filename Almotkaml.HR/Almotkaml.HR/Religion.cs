using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum Religion
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Muslim))]
        Muslim = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Other))]
        Other = 1
    }
}