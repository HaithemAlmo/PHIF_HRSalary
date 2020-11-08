using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ITaxReportBusiness
    {
        TaxReportModel Prepare();
        bool View(TaxReportModel model);
    }
}