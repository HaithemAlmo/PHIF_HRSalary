using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR
{
    public enum EntrantsAndReviewersType
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Entrant))]
        Entrant = 1,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Reviewer))]
        Reviewer = 2
    }
}
