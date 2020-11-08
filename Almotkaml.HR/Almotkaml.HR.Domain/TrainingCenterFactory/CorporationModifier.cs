namespace Almotkaml.HR.Domain.TrainingCenterFactory
{
    public class CorporationModifier
    {
        internal CorporationModifier(Corporation corporation)
        {
            Corporation = corporation;
        }

        private Corporation Corporation { get; }

        public CorporationModifier Name(string name)
        {
            Check.NotEmpty(name, nameof(name));
            Corporation.Name = name;
            return this;
        }

        public CorporationModifier Phone(string phone)
        {
            Corporation.Phone = phone;
            return this;
        }

        public CorporationModifier Email(string email)
        {
            Corporation.Email = email;
            return this;
        }

        public CorporationModifier Address(string address)
        {
            Corporation.Address = address;
            return this;
        }

        public CorporationModifier CityId(int cityId)
        {
            Check.MoreThanZero(cityId, nameof(cityId));
            Corporation.CityId = cityId;
            return this;
        }

        public CorporationModifier City(City city)
        {
            Check.NotNull(city, nameof(city));
            Corporation.City = city;
            Corporation.CityId = city.CityId;
            return this;
        }
        public CorporationModifier WithNote(string note)
        {
            Corporation.Note = note;
            return this;
        }
        public CorporationModifier DonorFoundationType(DonorFoundationType donorFoundationType)
        {
            Corporation.DonorFoundationType = donorFoundationType;
            return this;
        }
        public Corporation Confirm()
        {
            return Corporation;
        }
    }
}
