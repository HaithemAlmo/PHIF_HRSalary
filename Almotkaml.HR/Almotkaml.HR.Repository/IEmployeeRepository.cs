using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using Almotkaml.Repository;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetGride();
        IEnumerable<EmployeePremium> GetEmployeePremium();
       IEnumerable<AdvancePayment> GetEmployeeAdvance();
        IEnumerable<SalaryInfo> GettSalaryInfo();
        Employee GetEmployeeNameById(int id);
        IEnumerable<Employee> GetRetirementEmployee();
        IEnumerable<Employee> GetEmployeeBouns();
        IEnumerable<Employee> GetEmployeeBounshr();
        IEnumerable<Employee> GetAllNew();
        IEnumerable<Employee> GetEmployeeDegree();
        IEnumerable<Employee> GetEmployeeWithoutSaraies(DateTime monthDate);
        IEnumerable<EmployeePremium> GetTemEmployeePremiumBy(int employeeId);
        //IEnumerable<EmployeePremium> GetNotTemEmployeePremiumBy(int employeeId);
        IEnumerable<AdvancePayment> GetEmployeeAdvanceBy(int employeeId);
        IEnumerable<EmployeePremium> GettAllEmplyeeePremmium();
        IEnumerable<AdvancePayment> GettAllEmplyeeeAdvancse();
        //IEnumerable<SalaryPremium> GetSalaryPremiumBy(long salaryId);
        //IEnumerable<AdvancePayment> GetSalaryAdvanceBy(long salaryId);
        void AddSalaryInfo(SalaryInfo salaryInfo);
        void RemoveMilitaryData(MilitaryData militaryData);
        MilitaryData FindMilitaryData(int employeeId);
        int EmployeesDeserveBounsCount();
        int EmployeesCount();
        int EmployeesDeserveBounshrCount();

        int EmployeesDeserveDegreeCount();
        int EmployeesWithoutJobInfoCount();
        int EmployeesWithoutSalaryInfoCount();
        byte[] GetImageById(int employeeId);
        //bool IsFiftyOrDirectlyTwentyYear(int employeeId);
        int VacationBalanc(int employeeId);
        int VacationBalanc2(int employeeId);

        IEnumerable<Employee> GetEmployeeReport(EmployeeReportDto employeeReport);
        IEnumerable<ManPowerReportGridRow> GetEmployeeReport2();
        int GetJobNumber();
      //  int GetJobNumberLIC();
        IEnumerable<Employee> GetEmployeeWithoutSalaries(DateTime monthDate, int currentSituationId);
        bool NumIsExisted(int jobNumLIC);
        bool NumIsExisted(int jobNumLIC, int jobnumber);
    }
}