using Almotkaml.HR.Resources;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR
{
    public enum SalarySettlement
    {
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.pledg))]
        //Pledge = 0,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SalaryCerit))]
        SalaryCertificate = 1,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.Pension))]
        //PensionFund = 2,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Clipord))]
        Clipord = 3,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SalaryForm))]
        SalaryForm = 4,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.TaxIndex))]
        TaxIndex = 5,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SocialSecyrtey))]
        SocialSecurety = 6,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.SolidrtyFound))]
        SolidrtyFound = 7,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Summary))]
        Summary = 8,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Premmium))]
        Premmium = 9,
        //[Display(ResourceType = typeof(Title), Name = nameof(Title.SalaryCard))]
        //SalaryCard = 10,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Advance))]
        Advance = 11,
             [Display(ResourceType = typeof(Title), Name = nameof(Title.LegalReport))]
        Legal = 12,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EndJob))]
        EndJob = 13,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.ReportSubsended))]
        ReportSubsended = 15,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Check))]
        Check = 14,
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AbstractClipboardBanking))]
        AbstractClipboardBanking = 16
        //    ,
        //      [Display(ResourceType = typeof(Title), Name = nameof(Title.Check))]
        //Pension = 15

    }
}