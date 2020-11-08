using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        private HrDbContext Context { get; }

        internal DivisionRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Division> GetDivisionWithDepartment(int departmentId)
        {
            return Context.Divisions
               .Include(d => d.Department)
               .Where(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Division> GetDivisionWithDepartment()
        {
            return Context.Divisions
                .Include(d => d.Department);
        }

        public bool DivisionExisted(string name, int departmentId) => Context.Divisions
            .Any(e => e.Name == name && e.DepartmentId == departmentId);

        public bool DivisionExisted(string name, int departmentId, int idToExcept) => Context.Divisions
            .Any(e => e.Name == name && e.DivisionId != idToExcept && e.DepartmentId == departmentId);


        public override Division Find(object id)
            => Context.Divisions
                .Include(d => d.Department)
                .ThenInclude(c => c.Center)
                .FirstOrDefault(d => d.DivisionId == (int)id);

    }
}