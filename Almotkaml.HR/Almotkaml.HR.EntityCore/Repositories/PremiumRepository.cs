using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class PremiumRepository : Repository<Premium>, IPremiumRepository
    {
        private HrDbContext Context { get; }

        internal PremiumRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.Premiums
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.Premiums
            .Any(e => e.Name == name && e.PremiumId != idToExcept);

        public IEnumerable<Premium> GetPremiumsDiscount()
        {
            return Context.Premiums
                .Where(p => p.DiscountOrBoun == DiscountOrBoun.Discount);
        }
    }
}