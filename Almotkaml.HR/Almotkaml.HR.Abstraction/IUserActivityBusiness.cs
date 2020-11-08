using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IUserActivityBusiness
    {
        UserActivityModel Index();
        bool Search(UserActivityModel model);

        void Refresh(UserActivityModel model);


    }
}
