using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class UserGroupBusiness : Business, IUserGroupBusiness
    {
        public UserGroupBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.UserGroup && permission;


        public UserGroupIndexModel Index()
        {
            if (!HavePermission())
                return Null<UserGroupIndexModel>(RequestState.NoPermission);


            var grid = UnitOfWork.UserGroups
                .GetAll()
                .ToGrid();

            return new UserGroupIndexModel()
            {
                UserGroupGrid = grid,
                CanCreate = ApplicationUser.Permissions.UserGroup_Create,
                CanEdit = ApplicationUser.Permissions.UserGroup_Edit,
                CanDelete = ApplicationUser.Permissions.UserGroup_Delete,
            };
        }

        public void Refresh(UserGroupFormModel model) { }

        public UserGroupFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.UserGroup_Create))
                return Null<UserGroupFormModel>(RequestState.NoPermission);

            return new UserGroupFormModel()
            {
                CanSubmit = ApplicationUser.Permissions.UserGroup_Edit,
                Permissions = new Permission(),
            };
        }

        public bool Create(UserGroupFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.UserGroup_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.UserGroups.NameIsExisted(model.Name))
                return NameExisted(m => model.Name);

            var userGroup = UserGroup.New(model.Name, model.Permissions);

            UnitOfWork.UserGroups.Add(userGroup);
            UnitOfWork.Complete(n => n.UserGroup_Create);

            return SuccessCreate();
        }

        public UserGroupFormModel Find(int id)
        {
            if (!HavePermission())
                return Null<UserGroupFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<UserGroupFormModel>(RequestState.BadRequest);

            var userGroup = UnitOfWork.UserGroups.Find(id);

            if (userGroup == null)
                return Null<UserGroupFormModel>(RequestState.NotFound);

            return new UserGroupFormModel()
            {
                Name = userGroup.Name,
                Permissions = userGroup.Permissions,
                CanSubmit = ApplicationUser.Permissions.UserGroup_Edit
            };
        }

        public bool Edit(int id, UserGroupFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.UserGroup_Edit))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.UserGroups.NameIsExisted(model.Name, id))
                return NameExisted(m => model.Name);


            var userGroup = UnitOfWork.UserGroups.Find(id);

            if (userGroup == null)
                return Fail(RequestState.NotFound);

            userGroup.Modify(model.Name, model.Permissions);

            UnitOfWork.Complete(n => n.UserGroup_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, UserGroupFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.UserGroup_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var userGroup = UnitOfWork.UserGroups.Find(id);

            if (userGroup == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.UserGroups.Remove(userGroup);

            if (!UnitOfWork.TryComplete(n => n.UserGroup_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}