using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class AdvancePaymentExtensions
    {
        public static IEnumerable<AdvancePaymentGridRow> ToGrid(this IEnumerable<AdvancePayment> advancePayments)
            => advancePayments.Select(d => new AdvancePaymentGridRow()
            {
                EmployeeID=d.EmployeeId,
                AdvancePaymentId = d.AdvancePaymentId,
                DeductionDate = d.DeductionDate.FormatToString(),
                EmployeeName = d.Employee?.GetFullName(),
                InstallmentValue = d.InstallmentValue,
                Value = d.Value,
                PremiumName=d?.Premium?.Name,
                AllValue=d.AllValue,
                jobnumber=d.Employee?.JobInfo?.JobNumber.ToString(),
               
                IsInside = d.IsInside ? "داخلية" : "خارجية"
            });
        public static IEnumerable<AdvanseNameListItem> ToListPremiumums(this IEnumerable<Premium> premium)
            => premium.Where(s => s.ISAdvancePremmium == ISAdvancePremmium.ISAdvance &&s.DiscountOrBoun==DiscountOrBoun.Discount).Select(d => new AdvanseNameListItem()
            {
                Name = d.Name,
                AdvanseNameID = d.PremiumId
            });
    }
}