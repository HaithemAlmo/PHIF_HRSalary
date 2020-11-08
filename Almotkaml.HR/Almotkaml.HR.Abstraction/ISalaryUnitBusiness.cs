using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISalaryUnitBusiness
    {
        SalaryUnitModel Prepare();
        bool Save(SalaryUnitModel model);
        void Refresh(SalaryUnitModel model);
    }
}