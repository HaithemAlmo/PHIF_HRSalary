using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IVacationBusiness : ISimpleBusiness<VacationModel, int>
    {
        bool VacationBalancYear(VacationModel model);
        void Refresh2(VacationModel model);
    }
}