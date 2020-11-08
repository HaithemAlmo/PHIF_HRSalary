using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private HrDbContext Context { get; }

        internal CourseRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public override IEnumerable<Course> GetAll() => Context.Courses
            .Include(c => c.City)
            .ThenInclude(c => c.Country);

        public override Course Find(object id) => Context.Courses
            .Include(c => c.City)
            .ThenInclude(c => c.Country)
            .FirstOrDefault(c => c.CourseId == (int)id);
    }
}