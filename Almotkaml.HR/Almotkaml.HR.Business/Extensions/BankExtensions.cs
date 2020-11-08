using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class BankExtensions
    {
        public static IEnumerable<BankGridRow> ToGrid(this IEnumerable<Bank> banks)
           => banks.Select(d => new BankGridRow()
           {
               BankId = d.BankId,
               Name = d.Name
           });
        public static IEnumerable<BankListItem> ToList(this IEnumerable<Bank> banks)
            => banks.Select(d => new BankListItem()
            {
                Name = d.Name,
                BankId = d.BankId
            });
    }
}