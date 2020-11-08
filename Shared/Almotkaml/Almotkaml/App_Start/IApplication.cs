using System;

namespace Almotkaml
{
    public interface IApplication<TApplicationUser, TSettings, TCompanyInfo, TPermission> : IApplication
        where TApplicationUser : IApplicationUser<TPermission>
    {
        StartUp<TApplicationUser, TSettings, TCompanyInfo> StartUp { get; }
    }

    public interface IApplication : IDisposable
    {
        RequestState RequestState { get; }
        ModelState ModelState { get; }
        string Message { get; set; }
        bool IsLogged { get; }
    }
}