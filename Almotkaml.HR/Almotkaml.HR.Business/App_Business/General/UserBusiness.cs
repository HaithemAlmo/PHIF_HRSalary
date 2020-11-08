using System;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class UserBusiness : Business, IUserBusiness
    {
        public UserBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.User && permission;

        public UserIndexModel Index() => Index(0);

        public UserIndexModel Index(int userGroupId)
        {
            if (!HavePermission())
                return Null<UserIndexModel>(RequestState.NoPermission);

            var users = userGroupId > 0
                ? UnitOfWork.Users.GetUsersWithGroups(userGroupId)
                : UnitOfWork.Users.GetUsersWithGroups();


            return new UserIndexModel()
            {
                UserGrid = users.ToGrid(),
                CanCreate = ApplicationUser.Permissions.User_Create,
                CanEdit = ApplicationUser.Permissions.User_Edit,
                CanDelete = ApplicationUser.Permissions.User_Delete,
                UserGroupId = userGroupId,
                UserGroupList = UnitOfWork.UserGroups.GetAll().ToList()
            };
        }


        public UserCreateModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.User_Create))
                return Null<UserCreateModel>(RequestState.NoPermission);

            var usersGroupList = UnitOfWork.UserGroups
                .GetAll()
                .ToList();

            return new UserCreateModel()
            {
                UserGroupList = usersGroupList,
            };
        }

        public void Refresh(UserCreateModel model)
        {

        }
        public void Refresh(UserEditModel model)
        {

        }

        public bool Create(UserCreateModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.User_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Users.NameIsExisted(model.UserName))
                return NameExisted(m => model.UserName);

            var user = User.New()
                .WithUserName(model.UserName)
                .WithPassword(model.Password)
                 .WithCheckPerm(model.CheckPerm)
                .BelongsToGroupId(model.UserGroupId)
                .WithTitle(model.Title)
                .NotifyOn(new Notify())
                .Biuld();

            UnitOfWork.Users.Add(user);

            UnitOfWork.Complete(n => n.User_Create);

            return SuccessCreate();
        }

        public UserEditModel Find(int id)
        {
            if (!HavePermission())
                return Null<UserEditModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<UserEditModel>(RequestState.BadRequest);

            var user = UnitOfWork.Users.Find(id);

            if (user == null)
                return Null<UserEditModel>(RequestState.NotFound);

            var userGroupsList = UnitOfWork.UserGroups.GetAll().ToList();

            return new UserEditModel()
            {
                UserName = user.UserName,
                Title = user.Title,
                UserGroupId = user.UserGroupId,
                UserGroupList = userGroupsList,
                ChangePassword = false,
                CanSubmit = ApplicationUser.Permissions.User_Edit,
            };
        }

        public bool Edit(int id, UserEditModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.User_Edit))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!ModelState.IsValid(model))
                return false;

            var user = UnitOfWork.Users.Find(id);

            if (user == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Users.NameIsExisted(model.UserName, id))
                return NameExisted(m => model.UserName);

            if (model.ChangePassword)
            {
                user.Modify()
                    .UserName(model.UserName)
                    .Password(model.NewPassword)
                    .GroupId(model.UserGroupId)
                    .Title(model.Title)
                    .Confirm();
            }
            else
            {
                user.Modify()
                    .UserName(model.UserName)
                    .GroupId(model.UserGroupId)
                    .Title(model.Title)
                    .Confirm();
            }

            UnitOfWork.Complete(n => n.User_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, UserEditModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.User_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var user = UnitOfWork.Users.Find(id);

            if (user == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Users.Remove(user);

            if (!UnitOfWork.TryComplete(n => n.User_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }


    }
}