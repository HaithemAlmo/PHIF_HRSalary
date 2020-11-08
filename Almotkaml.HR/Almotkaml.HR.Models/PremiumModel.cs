using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class PremiumModel
    {
        public IEnumerable<PremiumGridRow> PremiumGrid { get; set; } = new HashSet<PremiumGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int PremiumId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Name))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsTemporary))]
        public IsTemporary IsTemporary { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsSubject))]
        public IsSubject IsSubject { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.IsFrozen))]
        public IsFrozen IsFrozen { get; set; }
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Inside))]
        public ISAdvanceInside ISAdvanceInside { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),

            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, 2, ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Premium))]
        public DiscountOrBoun DiscountOrBoun { get; set; }
        [Range(1, 2, ErrorMessageResourceType = typeof(SharedMessages),
           ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
               Name = nameof(Title.AdvacerOr))]
        public ISAdvancePremmium ISAdvancePremmium { get; set; }


        public decimal AllValue { get; set; }

    }
    public class PremiumGridRow
    {
        public DiscountOrBoun DiscountOrBoun { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }

        public int PremiumId { get; set; }
        public string Name { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsSubject IsSubject { get; set; }
        public IsFrozen IsFrozen { get; set; }        
        public int ISValueInpect { get; set; }

    }
    public class PremiumListItem
    {
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int EmployeeID { get; set; }

        public int PremiumId { get; set; }
        public string Name { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public int IsAdvance { get; set; }
        public int ISValueInpect { get; set; }

        public IsSubject IsSubject { get; set; }
    }
    public class TemporaryPremiumList
    {
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int EmployeeID { get; set; }

        public int PremiumId { get; set; }
        public string Name { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public int IsAdvance { get; set; }
      //  public int ISValueInpect { get; set; }

        public IsSubject IsSubject { get; set; }
        public IsFrozen IsFrozen { get; set; }
    }
        public class NotTemporaryPremiumList
    {
            public ISAdvancePremmium ISAdvancePremmium { get; set; }
            public int EmployeeID { get; set; }

            public int PremiumId { get; set; }
            public string Name { get; set; }
            public IsTemporary IsTemporary { get; set; }
            public int IsAdvance { get; set; }
          //  public int ISValueInpect { get; set; }

            public IsSubject IsSubject { get; set; }
            public IsFrozen IsFrozen { get; set; }
        }
    public class AdvanseListItem
    {
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public int EmployeeID { get; set; }

        public int PremiumId { get; set; }
        public string Name { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public ISAdvanceInside ISAdvanceInside { get; set; }
        public IsSubject IsSubject { get; set; }
        public IsFrozen IsFrozen { get; set; }
        //public int ISValueInpect { get; set; }

       
    }
    public class PremiumCheckListItem
    {
        public int PremiumId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int EmployeeID { get; set; }
        public bool IsSelected { get; set; }
    }
    public class PremiumCheckListItemReport
    {
        public string PremiumId { get; set; }
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public string PremiumCheck1 { get; set; }
        public string PremiumCheck2 { get; set; }
        public string PremiumCheck3 { get; set; }
        public string PremiumCheck4 { get; set; }
        public string PremiumCheck5 { get; set; }
        public string PremiumCheck6 { get; set; }
        public string PremiumCheck7 { get; set; }
        public string PremiumCheck8 { get; set; }
        public string PremiumCheck9 { get; set; }
    }
}