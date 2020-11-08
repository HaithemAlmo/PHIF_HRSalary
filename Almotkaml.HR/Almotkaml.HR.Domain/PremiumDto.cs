namespace Almotkaml.HR.Domain
{
    public class PremiumDto
    {
        public Premium Premium { get; set; }
        public decimal Value { get; set; }
        public decimal AllValue { get; set; }
        public decimal PartOfvalue { get; set; }
        public int IsAvance { get; set; }
        public int ValueIncpect { get; set; }
        public ISAdvancePremmium ISAdvancePremmium { get; set; }
        public IsTemporary IsTemporary { get; set; }
        public IsSubject IsSubject { get; set; }

    }

}