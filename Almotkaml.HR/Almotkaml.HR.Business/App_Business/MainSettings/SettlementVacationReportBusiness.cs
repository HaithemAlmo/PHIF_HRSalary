using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SettlementVacationReportBusiness : Business, ISettlementVacationReportBusiness
    {
        public SettlementVacationReportBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SettlementVacationReport && permission;

        public SettlementVacationReportModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SettlementVacationReport))
                return Null<SettlementVacationReportModel>(RequestState.NoPermission);

            return new SettlementVacationReportModel()
            {
                DateFrom = DateTime.Now.Date.FormatToString(),
                DateTo = DateTime.Now.Date.FormatToString(),
                VacationTypeList = UnitOfWork.VacationTypes.GetAll().ToList()
            };
        }

        public bool View(SettlementVacationReportModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var vacations = UnitOfWork.Vacations.GetVacationBy(model.DateFrom.ToDateTime()
                , model.DateTo.ToDateTime(), model.VacationTypeId);

            var grid = new List<SettlementVacationReportGridRow>();
            foreach (var vacation in vacations)
            {
                var row = new SettlementVacationReportGridRow()
                {
                    Center = vacation.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,
                    Name = vacation.Employee?.GetFullName(),
                    NationalNumber = vacation.Employee?.SalaryInfo?.FinancialNumber,
                    Unit = vacation.Employee?.JobInfo?.Unit?.Name,
                    Division = vacation.Employee?.JobInfo?.Unit?.Division?.Name,
                    Department = vacation.Employee?.JobInfo?.Unit?.Division?.Department?.Name,
                    JobNumber = vacation.Employee?.JobInfo?.GetJobNumber(),
                    VacationFrom = vacation.DateFrom.FormatToString(),
                    VacationTo = vacation.DateTo.FormatToString(),
                };

                grid.Add(row);
                model.VacationTypeName = vacation.VacationType?.Name;
            }

            model.Grid = grid;

            return true;
        }
    }
}