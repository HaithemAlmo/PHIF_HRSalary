using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using Almotkaml.HR.Abstraction;


namespace Almotkaml.HR.Business.App_Business.UsersSitting
{
    public class UserActivityBusiness : Business, IUserActivityBusiness
    {
        public UserActivityBusiness(HumanResource humanResource) : base(humanResource)
        {
        }
        private bool HavePermission(bool permission = true)
    => ApplicationUser.Permissions.UserActivity && permission;
        public UserActivityModel Index()
        {
            if (!HavePermission())
                return Null<UserActivityModel>(RequestState.NoPermission);

            var dateTo = DateTime.Now;
            var dateFrom = new DateTime(dateTo.Year, dateTo.Month, 1);

            return new UserActivityModel()
            {
                DateTo = dateTo.FormatToString(),
                DateFrom = dateFrom.FormatToString(),
                UserListItems = UnitOfWork.Users.GetAll().ToList()
            };

        }

        public bool Search(UserActivityModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);
            if (!ModelState.IsValid(model))
                return false;
            model.GridRows =
                UnitOfWork.Activities.GetUserActivities(model.DateFrom.ToDateTime(), model.DateTo.ToDateTime(), model.UserId ?? 0).ToGrid();

            return true;
        }

        public void Refresh(UserActivityModel model)
        {
            //model.CanSave = ApplicationUser.Permissions.UserActivity;

            //model.UserListItems = UnitOfWork.Users.GetAll().ToList();

        }
    }
}
