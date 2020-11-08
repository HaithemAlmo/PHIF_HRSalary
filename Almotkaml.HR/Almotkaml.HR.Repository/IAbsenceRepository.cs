using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IAbsenceRepository : IRepository<Absence>
    {
        IEnumerable<Absence> GetAbsenceByEmployeeId(int employeeid);
        bool CheckAbsenceBy(int employeeId, DateTime date);
        int AbsentEmployeesCount(DateTime date);
        IEnumerable<Absence> GetAbsentEmployeesBy(DateTime dateFrom, DateTime dateTo, AbsenceType absenceType);
    }
}