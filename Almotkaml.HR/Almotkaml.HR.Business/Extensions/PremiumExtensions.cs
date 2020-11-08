using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class PremiumExtensions
    {
        public static IEnumerable<PremiumGridRow> ToGrid(this IEnumerable<Premium> premiums)
            => premiums.Select(d => new PremiumGridRow()
            {
                PremiumId = d.PremiumId,
                Name = d.Name,
                IsSubject = d.IsSubject ,
                IsTemporary = d.IsTemporary ,
                IsFrozen = d.IsFrozen ,                 
                DiscountOrBoun = d.DiscountOrBoun,
                ISAdvancePremmium =d.ISAdvancePremmium
                
            });
        public static ICollection<TemporaryPremiumList> ToTemList(this IEnumerable<Premium> premiums)
            => premiums.Select(d => new TemporaryPremiumList()
            {
           
                PremiumId = d.PremiumId,
                Name = d.Name,
                ISAdvancePremmium=d.ISAdvancePremmium,
                IsTemporary = d.IsTemporary,
                IsSubject = d.IsSubject,
                IsFrozen = d.IsFrozen,
            }).ToList();

        public static ICollection<NotTemporaryPremiumList> ToTemNotList(this IEnumerable<Premium> premiums)
         => premiums.Select(d => new NotTemporaryPremiumList()
         {

             PremiumId = d.PremiumId,
             Name = d.Name,
             ISAdvancePremmium = d.ISAdvancePremmium,
             IsTemporary = d.IsTemporary,
             IsSubject = d.IsSubject,
             IsFrozen = d.IsFrozen,
         }).ToList();

        public static ICollection<AdvanseListItem> ToListAdvance(this IEnumerable<Premium> premiums)
              => premiums.Select(d => new AdvanseListItem()
              {

                  PremiumId = d.PremiumId,
                  Name = d.Name,
                  ISAdvancePremmium = d.ISAdvancePremmium,
                  IsTemporary = d.IsTemporary,
                  IsSubject = d.IsSubject,
                  IsFrozen = d.IsFrozen,
              }).ToList();
        public static IList<PremiumCheckListItem> ToCheckList(this IEnumerable<Premium> premiums)
         => premiums.Select(d => new PremiumCheckListItem()
         {
             PremiumId = d.PremiumId,
             Name = d.Name,
             IsSelected = false,
         }).ToList();
        public static IList<PremiumCheckListItem> ToEmployeePremiumList(this IEnumerable<Premium> premiums)
          => premiums.Select(d => new PremiumCheckListItem()
          {
              PremiumId = d.PremiumId,
              Name = d.Name,
              EmployeeID = 0,
              IsSelected = false,
          }).ToList();
        public static ICollection<PremiumListItem> ToList(this IEnumerable<Premium> premiums)
          => premiums.Select(d => new PremiumListItem()
          {

              PremiumId = d.PremiumId,
              Name = d.Name,
              ISAdvancePremmium = d.ISAdvancePremmium,
              IsTemporary = d.IsTemporary,
              IsSubject = d.IsSubject,
          }).ToList();
    }
}