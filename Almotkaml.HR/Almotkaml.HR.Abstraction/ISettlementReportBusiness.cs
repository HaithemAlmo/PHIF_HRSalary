using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISettlementReportBusiness
    {
        void Refresh(SettlementReportModel model);
        SettlementReportModel Prepare();
        bool PublicView(SettlementReportModel model);
        bool View(SettlementReportModel model);
    }
}