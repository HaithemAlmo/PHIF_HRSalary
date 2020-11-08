using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISettlementVacationReportBusiness
    {
        SettlementVacationReportModel Prepare();
        bool View(SettlementVacationReportModel model);
    }
}