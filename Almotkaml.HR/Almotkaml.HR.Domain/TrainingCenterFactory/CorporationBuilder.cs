namespace Almotkaml.HR.Domain.TrainingCenterFactory
{
    public class CorporationBuilder : INameHolder, IPhoneHolder, IEmailHolder, IAddressHolder, ICityHolder
        , INoteHolder, IDonorFoundationTypeHolder, IBuild
    {
        internal CorporationBuilder()
        { }

        private Corporation Corporation { get; } = new Corporation();

        public IPhoneHolder WithName(string name)
        {
            Check.NotEmpty(name, nameof(name));
            Corporation.Name = name;
            return this;
        }

        public IEmailHolder WithPhone(string phone)
        {
            Corporation.Phone = phone;
            return this;
        }

        public IAddressHolder WithEmail(string email)
        {
            Corporation.Email = email;
            return this;
        }

        public ICityHolder WithAddress(string address)
        {
            Corporation.Address = address;
            return this;
        }

        public INoteHolder WithCityId(int cityId)
        {
            Check.MoreThanZero(cityId, nameof(cityId));
            Corporation.CityId = cityId;
            return this;
        }

        public INoteHolder WithCity(City city)
        {
            Check.NotNull(city, nameof(city));
            Corporation.City = city;
            Corporation.CityId = city.CityId;
            return this;
        }
        public IDonorFoundationTypeHolder WithNote(string note)
        {
            Corporation.Note = note;
            return this;
        }
        public IBuild WithDonorFoundationType(DonorFoundationType donorFoundationType)
        {
            Corporation.DonorFoundationType = donorFoundationType;
            return this;
        }
        public Corporation Biuld()
        {
            return Corporation;
        }
    }
}