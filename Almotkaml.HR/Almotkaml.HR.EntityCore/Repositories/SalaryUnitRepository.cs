using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SalaryUnitRepository : Repository<SalaryUnit>, ISalaryUnitRepository
    {
        private HrDbContext Context { get; }

        internal SalaryUnitRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<SalaryUnit> GetBySalayClassification(SalayClassification salayClassification)
            => Context.SalaryUnits.Where(s => s.SalayClassification == salayClassification);
    }
}