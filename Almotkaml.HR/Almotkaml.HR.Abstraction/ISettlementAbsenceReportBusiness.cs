using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISettlementAbsenceReportBusiness
    {
        SettlementAbsenceReportModel Prepare();
        bool View(SettlementAbsenceReportModel model);
    }
}