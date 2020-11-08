using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISocialSecurityFundReportBusiness
    {
        SocialSecurityFundReportModel Prepare();
        bool View(SocialSecurityFundReportModel model);
    }
}