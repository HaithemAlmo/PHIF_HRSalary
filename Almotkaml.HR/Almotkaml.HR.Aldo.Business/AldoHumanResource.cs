using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Aldo.Business
{
    public class AldoHumanResource : HumanResource
    {
        private IEmployeeBusiness _employee;

        public AldoHumanResource(StartUp<LoginModel> startUp, AppConfig erAppConfig) : base(startUp, erAppConfig)
        {
        }

        public AldoHumanResource(StartUp<IApplicationUser, ISettings, ICompanyInfo> startUp, AppConfig erAppConfig) : base(startUp, erAppConfig)
        {
        }

        public override IEmployeeBusiness Employee
        {
            get
            {
                if (_employee != null)
                    return _employee;

                _employee = new AldoEmployeeBusiness(this);
                return _employee;
            }
        }
    }
}
