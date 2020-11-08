using Almotkaml.HR.EntityCore;

namespace Almotkaml.HR.Aldo.EntityCore
{
    public class AldoUnitOfWork : UnitOfWork//, IAldoUnitOfWork
    {
        // private IAldoEmpoyeeRepository _employees;

        public AldoUnitOfWork(AppConfig appConfig, int loggedInUserId = 0) : base(appConfig, loggedInUserId)
        {

        }

        //public override IEmployeeRepository Employees => AldoEmpoyees;

        //public IAldoEmpoyeeRepository AldoEmpoyees
        //{
        //    get
        //    {
        //        if (_employees != null)
        //            return _employees;

        //        _employees = new AldoEmployeeRepository(Context);
        //        return _employees;
        //    }
        //}

    }
}
