using System;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class AccountBusiness : Business, IAccountBusiness
    {
        public AccountBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        public LoginModel Prepare() => new LoginModel();

        public bool Login(LoginModel model)
        {
            if (!ModelState.IsValid(model))
                return false;
            var model2 = new HomeModel();
            var user = UnitOfWork.Users.GetByNameAndPassword(model.UserName, model.Password);
            //  model.CheckUserPerm = user.CheckUserPerm;
           


           
            return user != null || LoginFailed(m => model.UserName);
        }

        public ProfileModel Profile()
        {
            return new ProfileModel()
            {
                UserName = ApplicationUser.UserName,
                Title = ApplicationUser.Title,
                ChangePassword = false,
                Permissions = ApplicationUser.Permissions
            };
        }

        public bool Update(ProfileModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var user = UnitOfWork.Users.Find(ApplicationUser.Id);

            if (user == null)
                return Fail(RequestState.NotFound);

            if (model.ChangePassword)
            {
                user.Modify()
                    .UserName(model.UserName)
                    .Title(model.Title)
                    .Password(model.NewPassword)
                    .Confirm();
            }
            else
            {
                user.Modify()
                    .UserName(model.UserName)
                    .Title(model.Title)
                    .Confirm();
            }

            UnitOfWork.Complete(null);

            return SuccessEdit();
        }

        public NotificationModel Notifications()
        {
            return new NotificationModel()
            {
                Notifications = ApplicationUser.Notify
            };
        }

        public bool Update(NotificationModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var user = UnitOfWork.Users.Find(ApplicationUser.Id);

            if (user == null)
                return Fail(RequestState.NotFound);

            user.Modify()
                .NotifyOn(model.Notifications)
                .Confirm();

            UnitOfWork.Complete(null);

            return SuccessEdit();
        }

        public void Logout() { }

        public LoginModel GetUserPerm(LoginModel model)
        {
            var GetUserList = UnitOfWork.Users.GetByNameAndPassword(model.UserName, model.Password);

            return model;
        }
    }
}
