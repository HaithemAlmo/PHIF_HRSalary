using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
 public   interface IEvaluationRepository:IRepository<Evaluation>
 {
     IEnumerable<Evaluation> GetEvaluationByEmployeeId(int employeeId);
 

    }
}
