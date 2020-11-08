using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private HrDbContext Context { get; }

        internal BankRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Banks
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Banks
            .Any(e => e.Name == name && e.BankId != idToExcept);
    }
}