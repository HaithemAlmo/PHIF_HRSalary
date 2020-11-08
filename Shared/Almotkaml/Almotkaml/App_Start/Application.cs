using Almotkaml.Models;
using System;

namespace Almotkaml
{
    public abstract class Application
        <TLoginModel, TUnitOfWork, TManager, TUser, TApplicationUser, TApplicationUserInterface, TSettings, TPermission, TCompanyInfo>
        : IApplication<TApplicationUserInterface, TSettings, TCompanyInfo, TPermission>
        where TLoginModel : class, ILoginModel
        where TUnitOfWork : class, IDisposable
        where TManager : ApplicationManager<TLoginModel, TUser, TUnitOfWork, TSettings, TCompanyInfo>, new()
        where TApplicationUser : ApplicationUser<TPermission, TUser, TLoginModel, TApplicationUserInterface>, IApplicationUser<TPermission>, new()
        where TApplicationUserInterface : IApplicationUser<TPermission>
        where TUser : class
        where TSettings : class
        where TCompanyInfo : class
    {
        private TUnitOfWork _unitOfWork;
        private ModelState _modelState;
        private string _message;

        internal TUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork != null)
                    return _unitOfWork;

                if (StartUp?.ApplicationUser?.Id != null && StartUp.ApplicationUser.Id > 0)
                {
                    _unitOfWork = ObjectCreator.Create<TUnitOfWork>(AppConfig.RepositoryType, AppConfig, StartUp.ApplicationUser.Id);
                    return _unitOfWork;
                }

                _unitOfWork = ObjectCreator.Create<TUnitOfWork>(AppConfig.RepositoryType, AppConfig, 0);
                return _unitOfWork;
            }
        }

        internal TApplicationUser ApplicationUser { get; }
        internal TSettings Settings { get; }
        private TManager ApplicationManager { get; } = new TManager();
        internal TCompanyInfo CompanyInfo { get; }

        private RequestState _requestState = RequestState.Valid;
        public RequestState RequestState
        {
            get
            {
                if (_modelState != null && _modelState.ModelIsValid == false)
                    return RequestState.Invalid;

                return _requestState;
            }
            internal set { _requestState = value; }
        }

        public ModelState ModelState
        {
            get
            {
                if (_modelState != null)
                    return _modelState;

                _modelState = new ModelState();
                return _modelState;
            }
        }

        public string Message
        {
            get
            {
                return string.IsNullOrWhiteSpace(_modelState?.ValidationMessages)
                    ? _message
                    : _modelState.ValidationMessages;
            }
            set { _message = value; }
        }

        public StartUp<TApplicationUserInterface, TSettings, TCompanyInfo> StartUp { get; }

        private AppConfig AppConfig { get; }
        public bool IsLogged { get; }

        protected Application(StartUp<TLoginModel> startUp)
        {
            Check.NotNull(startUp, nameof(startUp));

            AppConfig = startUp.AppConfig;
            ApplicationManager.UnitOfWork = UnitOfWork;
            Settings = ApplicationManager.GetSettings();
            CompanyInfo = ApplicationManager.GetCompanyInfo();
            ApplicationUser = new TApplicationUser();
            StartUp = new StartUp<TApplicationUserInterface, TSettings, TCompanyInfo>()
            {
                AppConfig = AppConfig,
                CompanyInfo = CompanyInfo,
                ApplicationUser = ApplicationUser.AsInterface(),
                Settings = Settings
            };

            var user = ApplicationManager.LoginStart(startUp.LoginModel);

            if (user == null)
                return;

            var message = ApplicationManager.ExtraCheck(startUp.LoginModel, user);

            if (!string.IsNullOrWhiteSpace(message))
            {
                Message = message;
                return;
            }

            ApplicationUser.Set(user, startUp.LoginModel);
            IsLogged = true;
        }

        protected Application(StartUp<TApplicationUserInterface, TSettings, TCompanyInfo> startUp)
        {
            Check.NotNull(startUp, nameof(startUp));

            AppConfig = startUp.AppConfig;
            Settings = startUp.Settings;
            ApplicationUser = startUp.ApplicationUser as TApplicationUser;

            if (ApplicationUser == null)
                throw new NullReferenceException("applicationUser is null");

            CompanyInfo = startUp.CompanyInfo;
            StartUp = startUp;
            IsLogged = true;
        }

        public virtual void Dispose()
        {
            ModelState.Clear();
            _unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}