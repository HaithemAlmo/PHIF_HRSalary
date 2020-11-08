using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SelfCoursesRepository : Repository<SelfCourses>, ISelfCoursesRepository
    {
        private HrDbContext Context { get; }
        internal SelfCoursesRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<SelfCourses> GetSelfCoursesesWithEmployee()
        {
            return Context.SelfCourses
                .Include(e => e.Employee)
                .Include(s => s.SubSpecialty)
                .ThenInclude(s => s.Specialty);


        }

        public IEnumerable<SelfCourses> GetSelfCourseByEmployeeId(int employeeId)
        {
            return Context.SelfCourses
                .Include(e => e.Employee)
                .Include(s => s.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .Where(e => e.EmployeeId == employeeId);
        }

        public override SelfCourses Find(object id)
        {
            return Context.SelfCourses
               .Include(e => e.Employee)
               .Include(s => s.SubSpecialty)
               .ThenInclude(s => s.Specialty)
               .FirstOrDefault(d => d.SelfCoursesId == (int)id);
        }


    }
}
