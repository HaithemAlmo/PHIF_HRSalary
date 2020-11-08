using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IEmployeeReportBusiness
    {
        EmployeeReportModel Prepare();
        void Refresh(EmployeeReportModel model);
        bool Search(EmployeeReportModel model);
        bool SearchReports(EmployeeReportModel model);
        bool ManPowerReport(EmployeeReportModel model);
        void CheckCkeckBox(EmployeeReportModel model);
        void CheckCkeckBox2(EmployeeReportModel model);

    }
}