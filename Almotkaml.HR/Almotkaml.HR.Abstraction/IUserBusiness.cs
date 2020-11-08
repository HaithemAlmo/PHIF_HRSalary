using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IUserBusiness
    {
        UserIndexModel Index();
        UserIndexModel Index(int userGroupId);
        UserCreateModel Prepare();
        bool Create(UserCreateModel model);
        void Refresh(UserCreateModel model);
        void Refresh(UserEditModel model);
        UserEditModel Find(int id);
        bool Edit(int id, UserEditModel model);
        bool Delete(int id, UserEditModel model);
    }
}