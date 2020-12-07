using Almotkaml.HR.Repository;
using Almotkaml.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class EntrantsAndReviewersRepository : Repository<EntrantsAndReviewers>, IEntrantsAndReviewersRepository
    {
        private HrDbContext Context { get; }

        internal EntrantsAndReviewersRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string employeeName) => Context.EntrantsAndReviewerss
            .Any(e => e.EmployeeName  == employeeName);

        public bool NameIsExisted(string employeeName, int id) => Context.EntrantsAndReviewerss
            .Any(e => e.EmployeeName == employeeName && e.EntrantsAndReviewersId != id);


           public override EntrantsAndReviewers Find(object id)
        {
            return Context.EntrantsAndReviewerss
                //.Include(e => e.EntrantsAndReviewers)
                .FirstOrDefault(t => t.EntrantsAndReviewersId == (long)id);
        }
    }
}
