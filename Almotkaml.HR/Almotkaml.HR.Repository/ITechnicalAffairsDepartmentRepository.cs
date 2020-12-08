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
    {
        bool NameIsExisted(int entrantsAndReviewersId);
        TechnicalAffairsDepartment Find1(object id, object month, object year);
        bool Findispaid(object month, object year);

    }
}
