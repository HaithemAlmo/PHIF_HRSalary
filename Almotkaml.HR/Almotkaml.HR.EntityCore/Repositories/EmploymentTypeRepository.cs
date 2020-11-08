using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class EmploymentTypeRepository : Repository<EmploymentType>, IEmploymentTypeRepository
    {
        private HrDbContext Context { get; }

        internal EmploymentTypeRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }
    }
}