using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class RetirementBusiness : Business, IRetirementBusiness
    {
        public RetirementBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Retirement && permission;

        public RetirementModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Retirement))
                return Null<RetirementModel>(RequestState.NoPermission);

            return new RetirementModel()
            {
                RetirementGrid = UnitOfWork.Employees.GetRetirementEmployee().ToRetirementGrid(),
            };
        }
    }
}