using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IStaffingRepository : IRepository<Staffing>
    {
        IEnumerable<Staffing> GetStaffingWithStaffingType(int staffingTypeId);
        IEnumerable<Staffing> GetStaffingWithStaffingType();
        bool StaffingExisted(string name, int staffingTypeId);
        bool StaffingExisted(string name, int staffingTypeId, int idToExcept);
        IEnumerable<StaffingClassification> GetStaffingType(int staffingId);
    }
}