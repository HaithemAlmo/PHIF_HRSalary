using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Repository
{
    //class ITechnicalAffairsDepartmentRepository
    //{
    //}

    public interface ITechnicalAffairsDepartmentRepository : IRepository<TechnicalAffairsDepartment>
    {     IEnumerable<TechnicalAffairsDepartment> GetTechnicalAffairsDepartmentByEmployeeId(int TechnicalAffairsDepartmentid);
        bool NameIsExisted(int entrantsAndReviewersId);
        TechnicalAffairsDepartment Find1(object id, object month, object year);
        IEnumerable<TechnicalAffairsDepartment> Findispaid(object year, object month);
        IEnumerable<TechnicalAffairsDepartment> GetEntrantsAndReviewersBy(int year, int month, bool IsPaid);

    }
}
