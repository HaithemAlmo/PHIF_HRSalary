using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IDiscountSettlementReportBusiness
    {
        DiscountSettlementReportModel Prepare();
        void Refresh(DiscountSettlementReportModel model);
        bool View(DiscountSettlementReportModel model);
    }
}