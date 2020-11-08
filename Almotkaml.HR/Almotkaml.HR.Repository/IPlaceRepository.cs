using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IPlaceRepository : IRepository<Place>
    {
        IEnumerable<Place> GetPlaceWithBranch(int branchId);
        IEnumerable<Place> GetPlaceWithBranch();
        bool PlaceExisted(string name, int branchId);
        bool PlaceExisted(string name, int branchId, int idToExcept);
    }
}