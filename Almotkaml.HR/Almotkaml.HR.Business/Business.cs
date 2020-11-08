using Almotkaml.Erp.Accounting.Repository;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.Business
{
    public abstract class Business : Business<HumanResource, LoginModel, IUnitOfWork, ApplicationManager, User, ApplicationUser, IApplicationUser, ISettings, Permission, ICompanyInfo>
    {
        private readonly HumanResource _humanResource;

        public Business(HumanResource humanResource) : base(humanResource)
        {
            _humanResource = humanResource;
        }

        protected IErpUnitOfWork ErpUnitOfWork => _humanResource.ErpUnitOfWork;

    }
}