using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ITechnicalAffairsDepartmentnBusiness : ISimpleBusiness<TechnicalAffairsDepartmentModel, int>
    {
        //void RefreshReport(TechnicalAffairsDepartmentModel model);
        //void Report(TechnicalAffairsDepartmentModel model);
        bool SelectEntries(TechnicalAffairsDepartmentModel model, int id);
        void Select0(TechnicalAffairsDepartmentModel model);
        void Refresh0(TechnicalAffairsDepartmentModel model);
       
    }
}