using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISalaryBusiness
    {
        SalaryIndexModel ClipordIndex(SalaryIndexModel model);
        SalaryIndexModel SearchSummary(SalaryIndexModel model);
        void GetBranch(SalaryIndexModel model);
        SalaryIndexModel Search(SalaryIndexModel model);
        SalaryIndexModel SearchSalaryAdvPayement(SalaryIndexModel model);

        SalaryIndexModel SearchDifrancess(SalaryIndexModel model);
        SalaryIndexModel Index();
        bool Create(SalaryFormModel model);
        SalaryFormModel Find(long id);
        SalaryFormModel Prepare();
        string GetMonthDate();
        bool Spent(SalaryFormModel model);
        bool Update(SalaryIndexModel model);
        bool Close(SalaryIndexModel model);
        bool InsideAdvancePremiumFreeze(SalaryIndexModel model);
        bool OutsideAdvancePremiumFreeze(SalaryIndexModel model);
        bool InsideAdvancePremiumAllow(SalaryIndexModel model);
        bool OutsideAdvancePremiumAllow(SalaryIndexModel model);
        bool SaveBondNumber(SalaryIndexModel model);
        bool SuspendedTrue(SalaryIndexModel model, long id,string note);
        bool SuspendedFalse(SalaryIndexModel model, long id);
        bool Edit(SalaryFormModel model);
        bool AdvancePremiumFreeze(bool IsActive);
        void Refresh(SalaryFormModel model);
        bool SelectPremium(SalaryFormModel model);
        bool CreatePremium(SalaryFormModel model);
        bool EditPremium(SalaryFormModel model);
        bool DeletePremium(int id, SalaryFormModel model);
        bool View(AdvancePaymentReportModel model);
        bool View(SocialSecurityFundReportModel model);
        bool View(SolidarityFundReportModel model);
        bool View(TaxReportModel model);
        bool View(SalaryFormReportModel model);
        bool View(SalaryCardReportModel model);
        bool View(ClipboardBankingReportModel model);
        bool View(SalariesTotalReportModel model);
        bool View(DifrancesModel model);
        bool View(SummaryReportModel model);

        
        //bool View(AdvanceDetectionReportModel model);
        //bool View(EmployeeAdvanceDetectionReportModel model);
    }
}