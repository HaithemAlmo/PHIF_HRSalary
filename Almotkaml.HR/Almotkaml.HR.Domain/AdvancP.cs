namespace Almotkaml.HR.Domain
{
    public class AdvanceP

    {
        public Premium Premium { get; set; }
        public int PremiumId { get; set; }
        public decimal Value { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public ISAdvanceInside ISAdvanceInside { get; set; }
        public IsSubject IsSubject { get; set; }
        public IsFrozen IsFrozen { get; set; }
        public int EmployeeID { get; set; }

        public ISAdvancePremmium ISAdvancePremmium { get; set; }

    }

}