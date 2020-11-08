using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IAdvancePaymentBusiness : ISimpleBusiness<AdvancePaymentModel, int>
    {
        bool ViewInside(AdvanceDetectionReportModel model);
        bool ViewOutside(AdvanceDetectionReportModel model);
        bool ViewInside(EmployeeAdvanceDetectionReportModel model);
        bool ViewOutside(EmployeeAdvanceDetectionReportModel model);
    }
}