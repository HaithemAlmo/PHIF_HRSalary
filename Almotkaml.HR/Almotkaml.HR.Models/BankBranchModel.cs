using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class BankBranchModel
    {
        public IEnumerable<BankBranchGridRow> BankBranchGrid { get; set; } = new HashSet<BankBranchGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int BankBranchId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
         Name = nameof(Title.BankBranch))]
        public string Name { get; set; }
        public IEnumerable<BankListItem> BankList { get; set; } = new HashSet<BankListItem>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title),
          Name = nameof(Title.Bank))]
        public int BankId { get; set; }
        public IEnumerable<AccountingManualListItem> AccountingManualList { get; set; } = new HashSet<AccountingManualListItem>();

        [Display(ResourceType = typeof(Title), Name = nameof(Title.AccountingManual))]
        public int? AccountingManualId { get; set; }
    }
    public class BankBranchGridRow
    {
        public int BankBranchId { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public int BankId { get; set; }
        public string AccountingManualName { get; set; }
    }
    public class BankBranchListItem
    {
        public int BankBranchId { get; set; }
        public string Name { get; set; }
    }
    public class AccountingManualListItem
    {
        public int AccountingManualId { get; set; }
        public int AccountingLevelId { get; set; }
        public string Number { get; set; }
        public string ManualName { get; set; }
        public string LevelName { get; set; }
        public string FullName => ManualName + "--" + Number;
        public override string ToString() => FullName;
    }


}
