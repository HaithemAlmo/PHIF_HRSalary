using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class BankModel
    {
        public IEnumerable<BankGridRow> BankGrid { get; set; } = new HashSet<BankGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int BankId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Bank))]
        public string Name { get; set; }
    }
    public class BankGridRow
    {
        public int BankId { get; set; }
        public string Name { get; set; }
    }
    public class BankListItem
    {
        public int BankId { get; set; }
        public string Name { get; set; }
    }
}
