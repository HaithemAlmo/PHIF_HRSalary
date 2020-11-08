using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IPremiumSettlementReportBusiness
    {
        PremiumSettlementReportModel Prepare();
        void Refresh(PremiumSettlementReportModel model);
        bool View(PremiumSettlementReportModel model);
    }
}