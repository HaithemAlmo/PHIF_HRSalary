using Almotkaml.HR.Models;
using System;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class HomeBusiness : Business, IHomeBusiness
    {
        public HomeBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        public HomeModel View()
        {
            var dd = UnitOfWork.Employees.EmployeesDeserveBounsCount();


            return new HomeModel()
            {
                DeserveBouneshr = UnitOfWork.Employees.EmployeesDeserveBounshrCount(),

                AreAbsent = UnitOfWork.Absences.AbsentEmployeesCount(DateTime.Today),
                DeserveBounes = UnitOfWork.Employees.EmployeesDeserveBounsCount(),
                DeserveDegree = UnitOfWork.Employees.EmployeesDeserveDegreeCount(),
                EmployeesWithoutJobInfo = UnitOfWork.Employees.EmployeesWithoutJobInfoCount(),
                EmployeesWithoutSalaryInfo = UnitOfWork.Employees.EmployeesWithoutSalaryInfoCount(),
                HaveExtraWork = UnitOfWork.ExtraWorks.HaveExtraWorkCount(DateTime.Today),
                InVacation = UnitOfWork.Vacations.EmployeesInVacationCount(DateTime.Today),
                SuspendedSalary = UnitOfWork.Employees.EmployeesCount()
            };
        }
    }
}