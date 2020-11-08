using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class MilitaryDataRepository : Repository<MilitaryData>, IMilitaryDataRepository
    {
        private HrDbContext Context { get; }

        internal MilitaryDataRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public MilitaryData MilitaryDataByEmployeeId(int employeeId)
            => Context.MilitaryDatas.Find(employeeId); //FirstOrDefault(Column("EmployeeId") == employeeId);
    }
}