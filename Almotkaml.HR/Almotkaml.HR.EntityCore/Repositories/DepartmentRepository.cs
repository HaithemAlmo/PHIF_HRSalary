using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private HrDbContext Context { get; }

        internal DepartmentRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Department> GetDepartmentWithCenter(int centerId)
        {
            return Context.Departments
                         .Include(d => d.Center)
                         .Where(d => d.CenterId == centerId);
        }

        public IEnumerable<Department> GetDepartmentWithCenter()
        {
            return Context.Departments
                .Include(d => d.Center);
        }

        public bool DepartmentExisted(string name, int centerId) => Context.Departments
            .Any(e => e.Name == name && e.CenterId == centerId);

        public bool DepartmentExisted(string name, int centerId, int idToExcept) => Context.Departments
            .Any(e => e.Name == name && e.DepartmentId != idToExcept && e.CenterId == centerId);
    }
}