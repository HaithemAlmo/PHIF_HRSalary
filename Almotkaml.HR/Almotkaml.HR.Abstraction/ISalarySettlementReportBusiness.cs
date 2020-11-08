using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISalarySettlementReportBusiness 
    {
        SalarySettlementReportModel Prepare();
        void Refresh(SalarySettlementReportModel model);
        bool Search(SalarySettlementReportModel model);
        bool SearchByDate(SalarySettlementReportModel model);

        bool ViewPledge(SalarySettlementReportModel model);
        bool ViewSalaryCertificate(SalarySettlementReportModel model);
        bool ViewPensionFund(SalarySettlementReportModel model);
    }
}