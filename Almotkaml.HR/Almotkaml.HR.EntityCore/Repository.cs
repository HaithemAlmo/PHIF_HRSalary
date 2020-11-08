using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.EntityCore
{
    public abstract class Repository<TDomain> : IRepository<TDomain> where TDomain : class
    {
        protected string Column(string name) => "_" + name;
        private HrDbContext Context { get; }

        internal Repository(HrDbContext context)
        {
            Context = context;
        }
        public void Add(TDomain domain) => Context.Set<TDomain>().Add(domain);

        public virtual TDomain Find(object id) => Context.Set<TDomain>().Find(id);

        public virtual IEnumerable<TDomain> GetAll() => Context.Set<TDomain>();

        public virtual void Remove(TDomain domain) => Context.Set<TDomain>().Remove(domain);

        public virtual void RemoveRange(IEnumerable<TDomain> domains)
            => Context.Set<TDomain>().RemoveRange(domains);

        public virtual void AddRange(IEnumerable<TDomain> domains) => Context.Set<TDomain>().AddRange(domains);
    }
}
