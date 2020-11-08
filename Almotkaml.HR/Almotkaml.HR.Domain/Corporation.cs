using Almotkaml.HR.Domain.TrainingCenterFactory;

namespace Almotkaml.HR.Domain
{
    public class Corporation
    {
        public static INameHolder New()
        {
            return new CorporationBuilder();
        }
        public int CorporationId { get; internal set; }
        public string Name { get; internal set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public int CityId { get; internal set; }
        public City City { get; internal set; }
        public string Note { get; internal set; }
        public DonorFoundationType DonorFoundationType { get; internal set; }// نوع الجهة المانحة
        public CorporationModifier Modify()
        {
            return new CorporationModifier(this);
        }

    }
}