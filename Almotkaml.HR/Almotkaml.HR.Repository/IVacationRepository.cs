using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IVacationRepository : IRepository<Vacation>
    {
      
        IEnumerable<Vacation> GetEmployeeNameById(int id);
        bool GetVacationWithEmployee(int employeeId, DateTime dateFrom, DateTime dateTo);
        bool GetVacationWithEmployee(int employeeId, DateTime dateFrom, DateTime dateTo, long vacationId);
        IEnumerable<Vacation> GetVacationByEmployeeId(int employeeId);
        int EmployeesInVacationCount(DateTime date);
        IEnumerable<Vacation> GetVacationBy(DateTime dateFrom, DateTime dateTo, int vacationTypeId);
        Vacation find2();
        IEnumerable<Vacation> GetVacationBy2(int employeeId, int vacationTypeId);
        IEnumerable<Vacation> GetVacationBy3(int employeeId);

    }
}