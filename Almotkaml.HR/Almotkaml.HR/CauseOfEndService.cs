using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum CauseOfEndService
    {
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Unknown))]
        UnKnown = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Death))]
        Death = 1,//وفاة
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Quit))]
        Quit = 2,//استقالة
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Retirement))]
        Retirement = 3,//تقاعد
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndService))]
        EndService = 4,//انهاءالخدمة
        [Display(ResourceType = typeof(Title), Name = nameof(Title.RetireOptional))]
        RetireOptional = 5,//تقاغد اختياري
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndDelegation))]
        EndDelegation = 6,//ندب
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndEmptied))]
        EndEmptied = 7, // تفرغ
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndCollaborator))]
        EndCollaborator = 8,//متعاون
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndOut))]
        EndOut = 9
    }
}
