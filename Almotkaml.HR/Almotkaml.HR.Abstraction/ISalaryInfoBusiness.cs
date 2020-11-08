using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISalaryInfoBusiness
    {
        SalaryInfoIndexModel Index();
        SalaryInfoIndexModel Index(SalaryInfoIndexModel model);
        void Refresh(SalaryInfoFormModel model);
        SalaryInfoFormModel Find(int id);
       
        bool Save(int id, SalaryInfoFormModel model);
        SalaryInfoIndexModel EndedSalary();
    }
}