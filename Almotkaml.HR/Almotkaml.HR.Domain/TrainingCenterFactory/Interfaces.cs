namespace Almotkaml.HR.Domain.TrainingCenterFactory
{
    public interface INameHolder
    {
        IPhoneHolder WithName(string name);
    }
    public interface IPhoneHolder
    {
        IEmailHolder WithPhone(string phone);
    }
    public interface IEmailHolder
    {
        IAddressHolder WithEmail(string email);
    }
    public interface IAddressHolder
    {
        ICityHolder WithAddress(string address);
    }
    public interface ICityHolder
    {
        INoteHolder WithCityId(int cityId);
        INoteHolder WithCity(City city);
    }

    public interface INoteHolder
    {
        IDonorFoundationTypeHolder WithNote(string note);
    }
    public interface IDonorFoundationTypeHolder
    {
        IBuild WithDonorFoundationType(DonorFoundationType donorFoundationType);
    }

    public interface IBuild
    {
        Corporation Biuld();
    }
}