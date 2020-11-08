
using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum IsSubject
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsSubject))]
        IsSubject = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsNotSubject))]
        IsNotSubject = 2
    }
}