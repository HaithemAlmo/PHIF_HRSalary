using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class QualificationRepository : Repository<Qualification>, IQualificationRepository
    {
        private HrDbContext Context { get; }

        internal QualificationRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Qualification> GetQualificationByEmployeeId(int employeeid)
        {
            return Context.Qualifications
                .Include(e => e.Employee)
                .Include(s => s.QualificationType)
                .Include(q => q.Specialty)
                .Include(q => q.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .Include(s => s.ExactSpecialty)
                .ThenInclude(e => e.SubSpecialty)
                .ThenInclude(s => s.Specialty)

                .Where(e => e.EmployeeId == employeeid);

        }
        public Qualification GetQualificationById(int QualificationId)
        => Context.Qualifications
            .Include(e => e.Employee)
                .Include(s => s.QualificationType)
                .Include(q => q.Specialty)
                .Include(q => q.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .Include(s => s.ExactSpecialty)
                .ThenInclude(e => e.SubSpecialty)
                .ThenInclude(s => s.Specialty)
            .FirstOrDefault(d => d.QualificationId == QualificationId);
        public override Qualification Find(object id)
        {
            return Context.Qualifications
                .Include(e => e.Employee)
                .Include(s => s.QualificationType)
                .Include(q => q.Specialty)
                .Include(q => q.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .Include(s => s.ExactSpecialty)
                .ThenInclude(e => e.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .FirstOrDefault(e => e.QualificationId == (int)id);
        }

        public IEnumerable<Qualification> GetQualificationByEmployee(int employeeId)
      => Context.Qualifications
          .Include(e => e.Employee)
                .Include(s => s.QualificationType)
                .Include(q => q.Specialty)
                .Include(q => q.SubSpecialty)
                .ThenInclude(s => s.Specialty)
                .Include(s => s.ExactSpecialty)
                .ThenInclude(e => e.SubSpecialty)
                .ThenInclude(s => s.Specialty)
          .Where(d => d.EmployeeId == employeeId);
        public IEnumerable<Qualification> GetQualificationByEmployee(Employee Qualification)
         => GetQualificationByEmployee(Qualification.EmployeeId);

        public Qualification GetQualificationWithImages(int QualificationId)
        {
            throw new NotImplementedException();
        }

        public int GetMaxNumber(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Qualification> GetQualificationReport(QualificationReportDto qualificationReportDto)
        {
            var report = Context.Qualifications
                .Include(q => q.Employee)
                .Include(q => q.QualificationType)
                .Include(q => q.SubSpecialty)
                .Include(q => q.Specialty)
            .Include(s => s.ExactSpecialty).AsQueryable();

            if (qualificationReportDto.QualificationTypeId > 0)
                report = report.Where(q => q.QualificationTypeId == qualificationReportDto.QualificationTypeId);
            if (qualificationReportDto.SpecialtyId > 0)
                report = report.Where(q => q.SpecialtyId == qualificationReportDto.SpecialtyId);
            if (qualificationReportDto.SubSpecialtyId > 0)
                report = report.Where(q => q.SubSpecialtyId == qualificationReportDto.SubSpecialtyId);
            if (qualificationReportDto.ExactSpecialtyId > 0)
                report = report.Where(q => q.ExactSpecialtyId == qualificationReportDto.ExactSpecialtyId);
            if (qualificationReportDto.AquiredSpecialty != null)
                report = report.Where(q => q.AquiredSpecialty == qualificationReportDto.AquiredSpecialty);
            return report;
        }
    }
}