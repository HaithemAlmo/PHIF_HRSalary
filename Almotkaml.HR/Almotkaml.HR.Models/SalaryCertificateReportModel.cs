using Almotkaml.HR.Resources;
using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class SalaryCertificateReportModel
    {
        public IEnumerable<SalaryCertificateReportGridRow> Grid { get; set; } =
            new HashSet<SalaryCertificateReportGridRow>();

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedMessages), ErrorMessageResourceName = nameof(SharedMessages.ShouldSelected))]
        [Display(ResourceType = typeof(Title), Name = nameof(Title.EmployeeName))]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public IEnumerable<EmployeeGridRow> EmployeeGrid { get; set; } = new HashSet<EmployeeGridRow>();
    }
    public class SalaryCertificateReportGridRow
    {
        public decimal premiumValue { get; set; }
        public decimal DiscountValue { get; set; }
        public string premiumName { get; set; }
        public string DiscountName { get; set; }

        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public string Degree { get; set; }
        public int Boun { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal SocialSecurityFund { get; set; }
        public decimal SolidarityFund { get; set; }
        public decimal JihadTax { get; set; }
        public decimal MawadaFund { get; set; }
        public string AdvancePaymentName { get; set; }
        public decimal AdvancePaymentValue { get; set; }
        public decimal SalaryTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal NetSalary { get; set; }
    }

}