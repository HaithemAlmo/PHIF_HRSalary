using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        IEnumerable<Salary> GetSalaryByDateEndJob(DateTime dateFrom, DateTime dateTo);
        IEnumerable<Employee> GetEmployeeReport(EmployeeReportDto employeeReport);
        IEnumerable<Employee> GetEmployeeReportDate(EmployeeReportDto employeeReport);
        IEnumerable<SalaryPremium> GettAllSalaryPremmium();
        IEnumerable<Salary> GetSerchSalaryAdvPayement(int BankId, int BankBranshId, int Year, int Month);
        IEnumerable<SalaryPremium> GetSalaryPremium(int year, int month);
        IEnumerable<Salary> GetSerchSalarySummary(int Year, int Month);
        IEnumerable<Salary> GetSerchSalary(int BankId, int BankBranshId, int Year, int Month);
        IEnumerable<Salary> GetSerchSalaryDifrancess(int BankId, int BankBranshId, int Year, int Month);

        IEnumerable<Salary> GetClosedSalary();
        IEnumerable<Salary> GetClosedSalaryByMonth(int year, int month);
        IEnumerable<Salary> GetOpenedSalary();
        IEnumerable<Salary> GetSalaryByMonth(int year, int month);
        IEnumerable<Salary> GetSalaryByEmployeeAndMonth(int year, int month, int salaryId);
        IEnumerable<Salary> GetSalaryByEmployeeIdAndDate(int employeeId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<Salary> GetSalaryByDate(DateTime dateFrom, DateTime dateTo);
        IEnumerable<Salary> GetSalaryBy(DateTime date, int month);
        Salary GetSalaryBy(int employeeId, DateTime date);
        IEnumerable<Salary> GetSalaryBy(int employeeId, DateTime dateFrom, DateTime dateTo);
        Salary GetLastSalary();
        Salary GetLastClosedSalary();
        IEnumerable<TemporaryPremium> GetTemporaryPremium(long salaryId);
        void RemoveTemporaryPremium(TemporaryPremium temporaryPremium);
        void RemoveSalaryPremium(IEnumerable<SalaryPremium> salaryPremiums);
        TemporaryPremium FindTemporaryPremium(int temporaryPremiumId);
        //IEnumerable<SalaryPremium> FindSalaryPremium(int premiumId, long salaryId);
        bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId);
        bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId, int idToExcept);
        IEnumerable<SalaryPremium> GetSalaryPremiumBy(long salaryId);
        IEnumerable<SalaryPremium> GetTemSalaryPremiumBy(long salaryId);
        IEnumerable<EmployeePremium> GetNotTemEmployeePremiumBy(int employeeId);
        int SuspendedSalaryCount();
        // IEnumerable<Salary> GetSalaryByDateEndJob(DateTime dateFrom, DateTime dateTo);
        // IEnumerable<Employee> GetEmployeeReport(EmployeeReportDto employeeReport);
        // IEnumerable<Employee> GetEmployeeReportDate(EmployeeReportDto employeeReport);
        // IEnumerable<SalaryPremium> GettAllSalaryPremmium();
        // IEnumerable<Salary> GetSerchSalaryAdvPayement(int BankId, int BankBranshId, int Year, int Month);
        // IEnumerable<SalaryPremium> GetSalaryPremium(int year, int month);
        // IEnumerable<Salary> GetSerchSalarySummary(int Year, int Month);
        // IEnumerable<Salary> GetSerchSalary(int BankId, int BankBranshId, int Year, int Month);
        // IEnumerable<Salary> GetSerchSalaryDifrancess(int BankId, int BankBranshId, int Year, int Month);
      bool AdvancePremiumFreeze1();
        // IEnumerable<Salary> GetClosedSalary();
        // IEnumerable<Salary> GetClosedSalaryByMonth(int year, int month);
        // IEnumerable<Salary> GetOpenedSalary();
        // IEnumerable<Salary> GetSalaryByMonth(int year, int month);
        //// IEnumerable<Salary> GetSalaryPremiumBy(long salaryId);
        // IEnumerable<Salary> GetSalaryByEmployeeAndMonth(int year, int month, int salaryId);
        // IEnumerable<Salary> GetSalaryByEmployeeIdAndDate(int employeeId, DateTime dateFrom, DateTime dateTo);
        // IEnumerable<Salary> GetSalaryByDate(DateTime dateFrom, DateTime dateTo);
        // IEnumerable<Salary> GetSalaryBy(DateTime date, int month);
        // Salary GetSalaryBy(int employeeId, DateTime date);
        // IEnumerable<Salary> GetSalaryBy(int employeeId, DateTime dateFrom, DateTime dateTo);
        // Salary GetLastSalary();
        // Salary GetLastClosedSalary();
        // IEnumerable<TemporaryPremium> GetTemporaryPremium(long salaryId);
        // void RemoveTemporaryPremium(TemporaryPremium temporaryPremium);
        // void RemoveSalaryPremium(IEnumerable<SalaryPremium> salaryPremiums);
        // TemporaryPremium FindTemporaryPremium(int temporaryPremiumId);
        // //IEnumerable<SalaryPremium> FindSalaryPremium(int premiumId, long salaryId);
        // bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId);
        // bool TemporaryPremiumIsExisted(int temporaryPremiumId, long salaryId, int idToExcept);
       //IEnumerable<SalaryPremium> GetSalaryPremiumBy(long salaryId);
        IEnumerable<AdvancePayment> GetSalaryAdvanceBy(int employee);

        // int SuspendedSalaryCount();
    }
}