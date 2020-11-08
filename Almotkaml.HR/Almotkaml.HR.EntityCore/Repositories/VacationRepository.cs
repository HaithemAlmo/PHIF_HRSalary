using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class VacationRepository : Repository<Vacation>, IVacationRepository
    {
        private HrDbContext Context { get; }

        internal VacationRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public bool GetVacationWithEmployee(int employeeId, DateTime dateFrom, DateTime dateTo)
            => Context.Vacations
                     .Include(e => e.Employee)
                     .ThenInclude(e => e.JobInfo)
                     .ThenInclude(j => j.Unit)
                     .ThenInclude(u => u.Division)
                     .ThenInclude(d => d.Department)
                     .ThenInclude(d => d.Center)
                     .Include(r => r.VacationType)
                     .Any(v => v.EmployeeId == employeeId && (v.DateFrom.Date <= dateFrom.Date
                                && v.DateTo.Date >= dateTo.Date || (v.DateFrom.Date <= dateFrom.Date
                                && v.DateTo.Date >= dateFrom.Date) || (v.DateFrom.Date <= dateTo.Date
                                && v.DateTo.Date >= dateTo.Date) || (v.DateFrom.Date >= dateFrom.Date
                                && v.DateTo.Date <= dateTo.Date)));

        public bool GetVacationWithEmployee(int employeeId, DateTime dateFrom, DateTime dateTo, long vacationId)
            => Context.Vacations
                     .Include(e => e.Employee)
                     .ThenInclude(e => e.JobInfo)
                     .ThenInclude(j => j.Unit)
                     .ThenInclude(u => u.Division)
                     .ThenInclude(d => d.Department)
                     .ThenInclude(d => d.Center)
                     .Include(r => r.VacationType)
                     .Any(v => v.EmployeeId == employeeId && (v.DateFrom.Date <= dateFrom.Date
                                && v.DateTo.Date >= dateTo.Date || (v.DateFrom.Date <= dateFrom.Date
                                && v.DateTo.Date >= dateFrom.Date) || (v.DateFrom.Date <= dateTo.Date
                                && v.DateTo.Date >= dateTo.Date) || v.DateFrom.Date >= dateFrom.Date
                                && v.DateTo.Date <= dateTo.Date) && v.VacationId != vacationId);

        public IEnumerable<Vacation> GetVacationByEmployeeId(int employeeId)
        {
            return Context.Vacations
                     .Include(e => e.Employee)
                     .ThenInclude(e => e.JobInfo)
                     .ThenInclude(j => j.Unit)
                     .ThenInclude(u => u.Division)
                     .ThenInclude(d => d.Department)
                     .ThenInclude(d => d.Center)
                     .Include(r => r.VacationType)
                     .Where(e => e.EmployeeId == employeeId);
        }
    
        
           
        
        public int EmployeesInVacationCount(DateTime date)
            => Context.Vacations.Count(v => (v.DateFrom.Date <= date.Date && v.DateTo.Date >= date.Date));

        public IEnumerable<Vacation> GetVacationBy(DateTime dateFrom, DateTime dateTo, int vacationTypeId)
        {
            return Context.Vacations
                .Include(e => e.Employee)
                .ThenInclude(s=>s.SalaryInfo)
                .Include(e => e.Employee)

                .ThenInclude(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(r => r.VacationType)
                .Where(v => v.VacationTypeId == vacationTypeId
                            && (v.DateFrom.Date <= dateFrom.Date && v.DateTo.Date >= dateTo.Date
                            || (v.DateFrom.Date <= dateFrom.Date && v.DateTo.Date >= dateFrom.Date)
                            || (v.DateFrom.Date <= dateTo.Date && v.DateTo.Date >= dateTo.Date)
                            || v.DateFrom.Date >= dateFrom.Date && v.DateTo.Date <= dateTo.Date));
        }

        public override Vacation Find(object id)
        {
            return Context.Vacations
                .Include(e => e.Employee)
                .ThenInclude(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(r => r.VacationType)
                .FirstOrDefault(v => v.VacationId == (int)id);
        }

        public IEnumerable< Vacation> GetEmployeeNameById(int id)
        {
            return Context.Vacations
                .Include(e => e.Employee)
                .ThenInclude(e => e.JobInfo)
                .ThenInclude(j => j.Unit)
                .ThenInclude(u => u.Division)
                .ThenInclude(d => d.Department)
                .ThenInclude(d => d.Center)
                .Include(r => r.VacationType)         
                .Where(v => v.Employee.EmployeeId==id);
        }


        public IEnumerable<Vacation> GetVacationBy2(int employeeId, int vacationTypeId)
        {
            return Context.Vacations
                .Include(e => e.Employee)
                .ThenInclude(g => g.JobInfo)
                //.Include(j => j.CountKids)
                //.Include(h=>h.DateFrom)
                .Include(r => r.VacationType)
                .Where(v => v.EmployeeId == employeeId && v.VacationTypeId == vacationTypeId );
        }
        public IEnumerable<Vacation> GetVacationBy3(int employeeId)
        {
            return Context.Vacations
                .Include(e => e.Employee)
                .ThenInclude(g => g.JobInfo)
                //.Include(j => j.CountKids)
                //.Include(h => h.DateFrom)
                .Include(r => r.VacationType)
                .Where(v => v.EmployeeId == employeeId );
        }


        public Vacation find2()
        {
            return Context.Vacations
                 .Include(e => e.Employee)
                 .ThenInclude(e => e.JobInfo)
                 .ThenInclude(j => j.Unit)
                 .ThenInclude(u => u.Division)
                 .ThenInclude(d => d.Department)
                 .ThenInclude(d => d.Center)
                 .Include(r => r.VacationType)
                 .FirstOrDefault();
        }
    }
}