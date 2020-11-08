using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class ExactSpecialtyRepository : Repository<ExactSpecialty>, IExactSpecialtyRepository
    {
        private HrDbContext Context { get; }

        internal ExactSpecialtyRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<ExactSpecialty> GetExactSpecialtyWithSubSpecialty(int subSpecialtyId)
            => Context.ExactSpecialties
                .Include(u => u.SubSpecialty)
                .Where(d => d.SubSpecialtyId == subSpecialtyId);

        public IEnumerable<ExactSpecialty> GetExactSpecialtyWithSubSpecialty()
            => Context.ExactSpecialties.Include(u => u.SubSpecialty);

        public bool ExactSpecialtyExisted(string name, int subSpecialtyId, int idToExcept)
        => Context.ExactSpecialties.Any(
                    e => e.Name == name && e.SubSpecialtyId == subSpecialtyId && subSpecialtyId != idToExcept);

        public bool ExactSpecialtyExisted(string name, int subSpecialtyId)
         => Context.ExactSpecialties.Any(
                    e => e.Name == name && e.SubSpecialtyId == subSpecialtyId);


        public override ExactSpecialty Find(object id)
        {
            return Context.ExactSpecialties
                .Include(d => d.SubSpecialty)
                .ThenInclude(d => d.Specialty)
                .FirstOrDefault(i => i.ExactSpecialtyId == (int)id);
        }
    }
}