using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IQualificationBusiness : ISimpleBusiness<QualificationModel, int>
    {
        void RefreshReport(QualificationModel model);
        void Report(QualificationModel model);
    }
}