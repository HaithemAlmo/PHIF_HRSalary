using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IQualificationRepository : IRepository<Qualification>
    {
        Qualification GetQualificationWithImages(int QualificationId);
        Qualification GetQualificationById(int QualificationId);
        IEnumerable<Qualification> GetQualificationReport(QualificationReportDto qualificationReportDto);
        int GetMaxNumber(int employeeId);
        IEnumerable<Qualification> GetQualificationByEmployee(Employee employee);
        //IEnumerable<Qualification> GetQualificationById(int QualificationId);
        IEnumerable<Qualification> GetQualificationByEmployeeId(int employeeid);
    }
}