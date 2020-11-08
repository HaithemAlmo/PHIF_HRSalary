using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface ICenterRepository : IRepository<Center>, ICheckNameExisted
    {
        int GetCenterNumberBy(int centerId);
    }
}