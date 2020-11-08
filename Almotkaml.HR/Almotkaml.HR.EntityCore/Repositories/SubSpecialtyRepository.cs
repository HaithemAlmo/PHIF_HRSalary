using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class SubSpecialtyRepository : Repository<SubSpecialty>, ISubSpecialtyRepository
    {
        private HrDbContext Context { get; }

        internal SubSpecialtyRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<SubSpecialty> GetSubSpecialtyWithSpecialty(int specialtyId)
        {
            return Context.SubSpecialties
                .Include(s => s.Specialty)
                .Where(s => s.SpecialtyId == specialtyId);
        }

        public IEnumerable<SubSpecialty> GetSubSpecialtyWithSpecialty()
        {
            return Context.SubSpecialties
                .Include(s => s.Specialty);
        }

        public bool SubSpecialtyExisted(string name, int specialtyId) => Context.SubSpecialties
            .Any(e => e.Name == name && e.SpecialtyId == specialtyId);

        public bool SubSpecialtyExisted(string name, int specialtyId, int idToExcept) => Context.SubSpecialties
            .Any(e => e.Name == name && e.SubSpecialtyId != idToExcept && e.SpecialtyId == specialtyId);
    }
}