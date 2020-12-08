using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ITechnicalAffairsDepartmentnBusiness : ISimpleBusiness<TechnicalAffairsDepartmentModel, int>
    {
        //void RefreshReport(TechnicalAffairsDepartmentModel model);
        //void Report(TechnicalAffairsDepartmentModel model);
        bool SelectEntries(TechnicalAffairsDepartmentModel model);
        void Select0(TechnicalAffairsDepartmentModel model);    }
}