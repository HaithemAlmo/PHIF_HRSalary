using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface IRequestedQualificationRepository : IRepository<RequestedQualification>, ICheckNameExisted
    {
    }
}