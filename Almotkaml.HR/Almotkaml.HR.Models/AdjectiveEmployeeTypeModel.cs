using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class AdjectiveEmployeeTypeModel
    {
        public IEnumerable<AdjectiveEmployeeTypeGridRow> AdjectiveEmployeeTypeGrid { get; set; }
            = new HashSet<AdjectiveEmployeeTypeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public int AdjectiveEmployeeTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdjectiveEmployeeType))]
        public string Name { get; set; }

    }
    public class AdjectiveEmployeeTypeGridRow
    {
        public int AdjectiveEmployeeTypeId { get; set; }
        public string Name { get; set; }

    }
    public class AdjectiveEmployeeTypeListItem
    {
        public int AdjectiveEmployeeTypeId { get; set; }
        public string Name { get; set; }
    }


}
