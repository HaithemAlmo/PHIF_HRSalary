using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SalaryExtensions
    {
        public static IEnumerable<SalaryGridRow> ToGridSerch(this IEnumerable<Salary> salaries, ISettings settings)
          => salaries.Select(d => new SalaryGridRow()
          {
              EmloyeeId = d.EmployeeId,

              MonthGrid = d.MonthDate.Month,
              YearGrid = d.MonthDate.Year,

              EmployeeName = d.Employee?.GetFullName(),
              BasicSalary = d.BasicSalary,
              FinalSalary = d.FinalSalary(settings),
              JobNumber = d.Employee?.JobInfo?.GetJobNumber(),
              MonthDate = d.MonthDate.FormatToString(),
              BankId = d.BankBranch.BankId


          }).ToList()
           ;
        public static IEnumerable<SalaryGridRow> ToGrid(this IEnumerable<Salary> salaries, ISettings settings)
            => salaries.Select(d => new SalaryGridRow()
            {
                SalaryId = d.SalaryId,
                EmloyeeId = d.Employee.EmployeeId,
                EmployeeName = d.Employee?.GetFullName(),
                BasicSalary = d.BasicSalary,
                FinalSalary = d.FinalSalary(settings),
                TotalSalary = d.TotalSalary(settings),
                IsSuspended = d.IsSuspended,
                SuspendedNote = d.SuspendedNote,
                JobNumber = d.Employee?.JobInfo?.GetJobNumber(),
                MonthDate = d.MonthDate.FormatToString(),
                TotalDiscount = d.TotalDiscount(settings),
                NetSalary = d.NetSalary(settings),
                
            });
        public static IEnumerable<TemporaryPremiumGridRow> ToGrid(this IEnumerable<TemporaryPremium> temporaryPremium)
            => temporaryPremium.Select(d => new TemporaryPremiumGridRow()
            {
                IsSubject = d.IsSubject,
                Name = d.Name,
                SalaryId = d.SalaryId,
                TemporaryPremiumId = d.TemporaryPremiumId,
                Value = d.Value
            });

        public static IList<NotTemporaryPremmiumListE> ToTemList1(this IEnumerable<EmployeePremium> premiumsNT)
           => premiumsNT.Select(d => new NotTemporaryPremmiumListE()
           {
                 // EmployeeId = d.Employee.EmployeeId,
                 ISAdvancePremmium = d.Premium?.ISAdvancePremmium ?? 0,
               PremiumId = d.PremiumId,
               Value = d.Value,
               IsTemporary = d.Premium?.IsTemporary ?? 0,
           }).ToList();

        public static IList<TemSalaryPremiumListItem> ToTemList(this IEnumerable<EmployeePremium> premiumsNT)
             => premiumsNT.Select(d => new TemSalaryPremiumListItem()
             {
                // EmployeeId = d.Employee.EmployeeId,
                 ISAdvancePremmium = d.Premium?.ISAdvancePremmium ?? 0,
                 PremiumId = d.PremiumId,
                 Value = d.Value,
                 IsTemporary = d.Premium?.IsTemporary ?? 0,
             }).ToList();

        public static IList<TemSalaryPremiumListItem> ToTemList(this IEnumerable<SalaryPremium> premiums)
        => premiums.Select(d => new TemSalaryPremiumListItem()
        {
            ISAdvancePremmium = d.IsAdvansePremmium,
            
            PremiumId = d.PremiumId,
            Value = d.Value
        }).ToList();
        public static IList<SalaryPremiumListItem> ToList(this IEnumerable<SalaryPremium> premiums)
       => premiums.Select(d => new SalaryPremiumListItem()
       {
           PremiumId = d.PremiumId,
           Value = d.Value
       }).ToList();
        public static IList<SalaryAdvancePymentListItem> ToSalartAdvanseList(this IEnumerable<AdvancePayment> premiums1)
               => premiums1.Select(d1 => new SalaryAdvancePymentListItem()
               {
                   EmployeeID = d1.Employee.EmployeeId,
                   PremiumId = d1.PremiumId,
                   Value = d1.InstallmentValue,

                   AllValue = d1.AllValue,



               }).ToList();
    }
}