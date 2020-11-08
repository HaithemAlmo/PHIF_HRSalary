using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IOldSalaryBusiness
    {
        SalaryIndexModel Index();
        SalaryIndexModel Index(SalaryIndexModel model);
        SalaryFormModel Find(long id);
        SalaryFormModel Report(SalaryFormModel model);
        bool View(AdvancePaymentReportModel model);
        bool View(SocialSecurityFundReportModel model);
        bool View(SolidarityFundReportModel model);
        bool View(TaxReportModel model);
        bool View(SalaryFormReportModel model);
        bool View(SalaryCardReportModel model, int id);
        bool View(ClipboardBankingReportModel model);
    }
}