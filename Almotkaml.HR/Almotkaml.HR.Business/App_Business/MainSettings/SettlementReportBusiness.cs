using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SettlementReportBusiness : Business, ISettlementReportBusiness
    {
        public SettlementReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SettlementReport && permission;

        public SettlementReportModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SettlementReport))
                return Null<SettlementReportModel>(RequestState.NoPermission);

            return new SettlementReportModel()
            {
                CenterList = UnitOfWork.Centers.GetAll().ToList(),
                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
            };
        }
        public void Refresh(SettlementReportModel model)
        {
         

            model.DepartmentList = model.CenterId > 0
                ? UnitOfWork.Departments.GetDepartmentWithCenter(model.CenterId ?? 0).ToList()
                : new HashSet<DepartmentListItem>();

            model.DivisionList = model.DepartmentId > 0
                ? UnitOfWork.Divisions.GetDivisionWithDepartment(model.DepartmentId ?? 0).ToList()
                : new HashSet<DivisionListItem>();

            if (model.DivisionId > 0)
                model.UnitList = UnitOfWork.Units.GetUnitWithDivision(model.DivisionId ?? 0).ToList();
            else
                model.UnitList = new HashSet<UnitListItem>();
            


        }
        public bool View(SettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var endServices = UnitOfWork.EndServices.GetEndServicesesWithEmployeeBy(model.DateFrom.ToDateTime()
                , model.DateTo.ToDateTime(), model.CauseOfEndService);
               
            var grid = new List<SettlementReportGridRow>();
            foreach (var endService in endServices)
            {
                var row = new SettlementReportGridRow()
                {
                
                    Center = endService.Employee?.JobInfo?.Unit?.Name,
                    Name = endService.Employee?.GetFullName(),
                    NationalNumber = endService.Employee?.NationalNumber,
                    Unit = endService.Employee?.JobInfo?.Unit?.Name,
                    Division = endService.Employee?.JobInfo?.Unit?.Division?.Name,
                    Department = endService.Employee?.JobInfo?.Unit?.Division?.Department?.Name,
                    JobNumber = endService.Employee?.JobInfo?.GetJobNumber(),
                    DecisionDate = endService.DecisionDate.FormatToString(),
                    DecisionNumber = endService.DecisionNumber,
                     CauseOfEndService = endService.CauseOfEndService,
                     Cause= endService.Cause,
                    //Qualification = UnitOfWork.Qualifications.GetQualificationName(endService.EmployeeId),
                    //Qualification = endService.Employee?.Qualifications?.Select(s => s.QualificationId).ToString(),
                     Qualification = endService.Employee?.Qualifications?.LastOrDefault().QualificationType?.Name,
                    JobTiTle = endService.Employee?.JobInfo?.Job?.Name,
                    JobClass = endService.Employee?.JobInfo?.Job?.Name,
                };
                //var Qualification = UnitOfWork.Qualifications.GetQualificationByEmployeeId(endService.EmployeeId).LastOrDefault().QualificationType.Name;
                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
        public bool PublicView(SettlementReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;
            var employeeReportDto = new EmployeeReportDto()
            {
                CenterId = model.CenterId??0,
                DivisionId=model.DivisionId??0,
                UnitId=model.UnitId??0,
                DepartmentId=model.DepartmentId??0

            };
            var List = UnitOfWork.Employees.GetEmployeeReport(employeeReportDto).ToList();
                

            var grid = new List<SettlementReportGridRow>();
            foreach (var NewList in List)
            {
                var row = new SettlementReportGridRow()
                {
                    Current=NewList.JobInfo?.CurrentSituation?.Name,
                    DateApp=NewList.JobInfo?.EmploymentValues?.DesignationResolutionDate?.Date.ToString("yyyy/MM/dd"),
                    NumberApp= NewList.JobInfo?.EmploymentValues?.DesignationResolutionNumber,
                    DegreeNow= NewList.JobInfo?.DegreeNow,
                    DirectleyDate=NewList.JobInfo?.DirectlyDate?.Date.ToString("yyyy/MM/dd"),
                    JobTiTle=NewList.JobInfo?.Job?.Name,
                    MoneyNumber=NewList.SalaryInfo?.FinancialNumber,
                    Employeer=NewList.Qualifications?.FirstOrDefault()?.QualificationType?.Name,
                    Notes=NewList.ContactInfo?.Note,
                    Center = NewList.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                    Name = NewList.GetFullName(),
                    NationalNumber = NewList.NationalNumber,
                    Unit = NewList.JobInfo?.Unit?.Name,
                    Division = NewList.JobInfo?.Unit?.Division?.Name,
                    Department = NewList.JobInfo?.Unit?.Division?.Department?.Name,
                    JobNumber = NewList.JobInfo?.GetJobNumber(),
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }
    }
}