using Almotkaml.Models;

namespace Almotkaml
{
    public class StartUp<TApplicationUser, TSettings, TCompanyInfo>
    {
        public AppConfig AppConfig { get; internal set; }
        public TApplicationUser ApplicationUser { get; internal set; }
        public TSettings Settings { get; internal set; }
        public TCompanyInfo CompanyInfo { get; internal set; }
    }

    public class StartUp<TLoginModel> where TLoginModel : ILoginModel
    {
        public AppConfig AppConfig { get; set; }
        public TLoginModel LoginModel { get; set; }
    }
}