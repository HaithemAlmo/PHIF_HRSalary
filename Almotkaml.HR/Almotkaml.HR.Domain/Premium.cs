using System;

namespace Almotkaml.HR.Domain
{
    public class Premium
    {
        public static Premium New(DiscountOrBoun discountOrBoun, string name, IsTemporary isTemporary, IsSubject isSubject, ISAdvancePremmium isAdvancePremmium, IsFrozen isFrozen)
        {
            Check.NotEmpty(name, nameof(name));

            var premium = new Premium()
            {
                DiscountOrBoun = discountOrBoun,
                Name = name,
                IsTemporary = isTemporary,
                IsSubject = isSubject,
                ISAdvancePremmium = isAdvancePremmium,
                IsFrozen=isFrozen
            };

            return premium;
        }
        public int PremiumId { get; set; }
        public string Name { get; set; }
        public DiscountOrBoun DiscountOrBoun { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public ISAdvanceInside ISAdvanceInside { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsSubject IsSubject { get; set; }
        public IsFrozen IsFrozen { get; set; }
        public void Modify(DiscountOrBoun discountOrBoun, string name, IsTemporary isTemporary, IsSubject isSubject, ISAdvancePremmium isAdvancePremmium, IsFrozen isFrozen)
        {
            Check.NotEmpty(name, nameof(name));
            DiscountOrBoun = discountOrBoun;
            Name = name;
            IsTemporary = isTemporary;
            IsSubject = isSubject;
            ISAdvancePremmium = isAdvancePremmium;
            IsFrozen = isFrozen;

        }

     
    }
}