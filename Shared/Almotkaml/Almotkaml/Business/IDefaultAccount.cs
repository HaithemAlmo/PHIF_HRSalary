using Almotkaml.Models;

namespace Almotkaml.Business
{
    public interface IDefaultAccount<TLoginModel, TProfileModel, TNotificationsModel>
        where TLoginModel : ILoginModel
        where TProfileModel : IProfileModel
    {
        TLoginModel Prepare();
        bool Login(TLoginModel model);
        TProfileModel Profile();
        bool Update(TProfileModel model);
        TNotificationsModel Notifications();
        bool Update(TNotificationsModel model);
        void Logout();
    }
}