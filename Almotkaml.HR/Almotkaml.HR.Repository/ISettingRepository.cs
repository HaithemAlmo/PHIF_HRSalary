using Almotkaml.HR.Domain;

namespace Almotkaml.HR.Repository
{
    public interface ISettingRepository
    {
        Settings Load();
        void Save(Settings settings);
    }
}