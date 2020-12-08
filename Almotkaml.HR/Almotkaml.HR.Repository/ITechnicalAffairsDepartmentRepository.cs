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
    }
}
