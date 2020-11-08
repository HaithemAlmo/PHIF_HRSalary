using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class AbsenceRepository : Repository<Absence>, IAbsenceRepository
    {
        private HrDbContext Context { get; }

        internal AbsenceRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Absence> GetAbsenceByEmployeeId(int employeeid)
        {
            return Context.Absences
                .Include(e => e.Employee)
                .Where(e => e.EmployeeId == employeeid);
        }

        public bool CheckAbsenceBy(int employeeId, DateTime date)
        {
            return Context.Absences
                .Include(e => e.Employee)
                .Any(e => e.EmployeeId == employeeId && e.Date.Date == date);
        }

        public int AbsentEmployeesCount(DateTime date)
            => Context.Absences.Count(a => a.Date.Date == date.Date);

        public IEnumerable<Absence> GetAbsentEmployeesBy(DateTime dateFrom, DateTime dateTo, AbsenceType absenceType)
        {
            return Context.Absences
                .Include(e => e.Employee)
                .ThenInclude(s=>s.SalaryInfo)
                .Include(e => e.Employee)
                .ThenInclude(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Where(e => e.AbsenceType == absenceType
                        && e.Date.Date >= dateFrom.Date
                        && e.Date.Date <= dateTo.Date);
        }
    }
}