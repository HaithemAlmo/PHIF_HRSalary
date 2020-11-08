using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISolidarityFundReportBusiness
    {
        SolidarityFundReportModel Prepare();
        bool View(SolidarityFundReportModel model);
    }
}