using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        private HrDbContext Context { get; }

        internal UnitRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Unit> GetUnitWithDivision(int divisionId)
            => Context.Units
                .Include(u => u.Division)
            .ThenInclude(d => d.Department)
            .ThenInclude(c => c.Center)
                .Where(d => d.DivisionId == divisionId);

        public IEnumerable<Unit> GetUnitWithDivision()
            => Context.Units
            .Include(u => u.Division)
            .ThenInclude(d => d.Department)
            .ThenInclude(c => c.Center);

        public bool UnitExisted(string name, int divisionId, int idToExcept)
            => Context.Units.Any(u => u.Name == name && u.DivisionId == divisionId && u.UnitId != idToExcept);

        public bool UnitExisted(string name, int divisionId)
        => Context.Units.Any(u => u.Name == name && u.DivisionId == divisionId);

        public override Unit Find(object id)
        {
            return Context.Units
                .Include(d => d.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(c => c.Center)
                .FirstOrDefault(i => i.UnitId == (int)id);
        }


    }
}