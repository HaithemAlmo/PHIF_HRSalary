using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class AdjectiveEmployeeModel
    {
        public IEnumerable<AdjectiveEmployeeGridRow> AdjectiveEmployeeGrid { get; set; }
            = new HashSet<AdjectiveEmployeeGridRow>();
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }


        public int AdjectiveEmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
         ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdjectiveEmployee))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
          ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.AdjectiveEmployeeType))]
        public int AdjectiveEmployeeTypeId { get; set; }
        public IEnumerable<AdjectiveEmployeeTypeListItem> AdjectiveEmployeeTypeList { get; set; }
            = new HashSet<AdjectiveEmployeeTypeListItem>();

    }
    public class AdjectiveEmployeeGridRow
    {
        public int AdjectiveEmployeeId { get; set; }
        public string Name { get; set; }
        public int AdjectiveEmployeeTypeId { get; set; }
        public string AdjectiveEmployeeTypeName { get; set; }

    }
    public class AdjectiveEmployeeListItem
    {
        public int AdjectiveEmployeeId { get; set; }
        public string Name { get; set; }
    }


}