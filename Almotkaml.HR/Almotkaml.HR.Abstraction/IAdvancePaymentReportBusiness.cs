using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IAdvancePaymentReportBusiness
    {
        AdvancePaymentReportModels Prepare();
        AdvancePaymentReportModels Index(AdvancePaymentReportModels model);
        //bool View(AdvancePaymentReportModel model);

        void Refresh(AdvancePaymentReportModels model);
        bool ViewInside(AdvanceDetectionReportModel model);
        bool ViewOutside(AdvanceDetectionReportModel model);
        bool ViewInside(EmployeeAdvanceDetectionReportModel model);
        bool ViewOutside(EmployeeAdvanceDetectionReportModel model);
    }
}