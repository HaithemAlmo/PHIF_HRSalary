using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface IMilitaryDataRepository : IRepository<MilitaryData>
    {
        MilitaryData MilitaryDataByEmployeeId(int employeeId);
    }
}