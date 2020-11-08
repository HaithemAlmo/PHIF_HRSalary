using System.Collections.Generic;

namespace Almotkaml.Repository
{
    public interface IRepository<TDomain> where TDomain : class
    {
        void Add(TDomain domain);
        void AddRange(IEnumerable<TDomain> domains);


        TDomain Find(object id);

      

        IEnumerable<TDomain> GetAll();

        void Remove(TDomain domain);
        void RemoveRange(IEnumerable<TDomain> domains);
    }
}