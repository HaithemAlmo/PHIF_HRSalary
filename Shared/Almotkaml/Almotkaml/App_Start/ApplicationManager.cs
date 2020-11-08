
namespace Almotkaml
{
    public abstract class ApplicationManager<TLoginModel, TUser, TUnitOfWork, TSettings, TCompanyInfo>
        where TLoginModel : class
        where TUser : class
        where TUnitOfWork : class
        where TSettings : class
        where TCompanyInfo : class
    {
        public TUnitOfWork UnitOfWork { get; internal set; }
        public abstract TUser LoginStart(TLoginModel model);
        public abstract string ExtraCheck(TLoginModel model, TUser user);

        public abstract TSettings GetSettings();

        public abstract TCompanyInfo GetCompanyInfo();
    }
}