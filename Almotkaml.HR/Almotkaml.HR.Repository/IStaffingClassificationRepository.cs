using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IStaffingClassificationRepository : IRepository<StaffingClassification>
    {
        IEnumerable<StaffingClassification> GetWithStaffings(int staffingTypeId);
        IEnumerable<StaffingClassification> GetWithStaffings();
        bool StaffingClassificationExisted(string name, int staffingId);
        //bool StaffingExisted(string name, int staffingTypeId, int idToExcept);

        //IEnumerable<StaffingClassification> GetStaffingType(int staffingId);
    }
}