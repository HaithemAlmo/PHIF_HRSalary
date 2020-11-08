using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class AdvancePaymentBusiness : Business, IAdvancePaymentBusiness
    {
        public AdvancePaymentBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.AdvancePayment && permission;

        public AdvancePaymentModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.AdvancePayment_Create))
                return Null<AdvancePaymentModel>(RequestState.NoPermission);
            return new AdvancePaymentModel()
            {
                AdvanseNameList = UnitOfWork.Premiums.GetAll().ToListPremiumums(),

                CanCreate = ApplicationUser.Permissions.AdvancePayment_Create,
                CanEdit = ApplicationUser.Permissions.AdvancePayment_Edit,
                CanDelete = ApplicationUser.Permissions.AdvancePayment_Delete,
                AdvancePaymentGrid = UnitOfWork.AdvancePayments.GetAdvancePaymentByEmployeeId(0).ToGrid(),
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                AdvanceDetectionReportModel = new AdvanceDetectionReportModel()
                {
                    DateFrom = new DateTime(2017, 1, 1).FormatToString(),
                    DateTo = DateTime.Now.FormatToString(),
                },
                EmployeeAdvanceDetectionReportModel = new EmployeeAdvanceDetectionReportModel()
                {
                    DateFrom = new DateTime(2017, 1, 1).FormatToString(),
                    DateTo = DateTime.Now.FormatToString(),
                    EmployeeId = 1
                },
            };
        }

        public bool Delete(AdvancePaymentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdvancePayment_Delete))
                return Fail(RequestState.NoPermission);

            if (model.AdvancePaymentId <= 0)
                return Fail(RequestState.BadRequest);

            var advancePayment = UnitOfWork.AdvancePayments.Find(model.AdvancePaymentId);

            if (advancePayment == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.AdvancePayments.Remove(advancePayment);
            if (!UnitOfWork.TryComplete(n => n.AdvancePayment_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Edit(AdvancePaymentModel model)
        {
            if (model.AdvancePaymentId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.AdvancePayment_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var advancePayment = UnitOfWork.AdvancePayments.Find(model.AdvancePaymentId);

            if (advancePayment == null)
                return Fail(RequestState.NotFound);

            advancePayment.Modify(model.Value, model.InstallmentValue, model.DeductionDate.ToDateTime(), model.IsInside
                        , model.Date.ToDateTime(),model.AdvanseNameID );

            UnitOfWork.Complete(n => n.AdvancePayment_Edit);

            Clear(model);
            return SuccessEdit();
        }

        public bool Create(AdvancePaymentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdvancePayment_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var advancePayment = AdvancePayment.New(model.EmployeeId, model.Value, model.InstallmentValue, model.DeductionDate.ToDateTime()
                                                , model.IsInside, model.Date.ToDateTime(),model.AdvanseNameID);

            UnitOfWork.AdvancePayments.Add(advancePayment);

            UnitOfWork.Complete(n => n.AdvancePayment_Create);
            Clear(model);

            return SuccessCreate();
        }

        public bool Select(AdvancePaymentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.AdvancePayment_Edit))
                return Fail(RequestState.NoPermission);
            if (model.AdvancePaymentId <= 0)
                return Fail(RequestState.BadRequest);

            var advancePayment = UnitOfWork.AdvancePayments.Find(model.AdvancePaymentId);

            if (advancePayment == null)
                return Fail(RequestState.NotFound);
           
            model.AdvancePaymentId = advancePayment.AdvancePaymentId;
            model.EmployeeId = advancePayment.EmployeeId;
            model.Value = advancePayment.Value;
            model.InstallmentValue = advancePayment.InstallmentValue;
            model.DeductionDate = advancePayment.DeductionDate.ToString();
            model.IsInside = advancePayment.IsInside;

            return true;
        }

        public void Refresh(AdvancePaymentModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.AdvanseNameList = UnitOfWork.Premiums.GetAll().ToListPremiumums();
            model.Jobnumber = employee.JobInfo?.JobNumber.ToString();
            model.EmployeeName = employee.GetFullName();
            model.AdvancePaymentGrid = UnitOfWork.AdvancePayments.GetAdvancePaymentByEmployeeId(model.EmployeeId).ToGrid();
        }
        public bool ViewInside(AdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetAll().Where(s=>s.EmployeeId==model.Grid.FirstOrDefault().EmployeeId).ToList();//////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<AdvanceDetectionReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new AdvanceDetectionReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.CenterId ?? 0,////////
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,///////
                    //Date =,
                    Value = salary.Employee?.AdvancePayments.Where(a => a.IsInside).Sum(a => a.Value) ?? 0,
                    //Rest = ,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool ViewInside(EmployeeAdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByEmployeeIdAndDate(model.EmployeeId
                        , DateTime.Now, DateTime.Now).ToList();///////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<EmployeeAdvanceDetectionReportGridRow>();

            foreach (var salary in salaries)
            {
                foreach (var advancePayments in salary.Employee.AdvancePayments.Where(a => a.IsInside))
                {
                    var row = new EmployeeAdvanceDetectionReportGridRow()
                    {
                        EmployeeId = salary.EmployeeId,
                        EmployeeName = salary.Employee?.GetFullName(),
                        JobNumber = salary.JobNumber, ///////
                        Value = advancePayments.Value,
                        InstallmentValue = advancePayments.InstallmentValue,
                        DeductionDate = advancePayments.DeductionDate.FormatToString(),
                        Rest = salary.Employee.AdvancePayments.Where(a => a.IsInside).Sum(a => a.Value)
                               - salaries.Sum(s => s.AdvancePremiumInside),
                        //Date =,
                    };

                    grid.Add(row);
                }
            }

            model.Grid = grid;

            return true;
        }
        public bool ViewOutside(AdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByDate(DateTime.Now, DateTime.Now);//////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<AdvanceDetectionReportGridRow>();

            foreach (var salary in salaries)
            {
                var row = new AdvanceDetectionReportGridRow()
                {
                    EmployeeName = salary.Employee?.GetFullName(),
                    JobNumber = salary.JobNumber,///////
                    CostCenterId = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.CenterId ?? 0,////////
                    CostCenterName = salary.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name,///////
                    //Date =,
                    Value = salary.Employee?.AdvancePayments.Where(a => a.IsInside).Sum(a => a.Value) ?? 0,
                    //Rest = ,
                };

                grid.Add(row);
            }

            model.Grid = grid;

            return true;
        }

        public bool ViewOutside(EmployeeAdvanceDetectionReportModel model)
        {
            if (!ModelState.IsValid(model))
                return false;

            var salaries = UnitOfWork.Salaries.GetSalaryByEmployeeIdAndDate(model.EmployeeId
                        , DateTime.Now, DateTime.Now).ToList();///////////////////////

            if (salaries == null)
                return false;

            var grid = new HashSet<EmployeeAdvanceDetectionReportGridRow>();

            foreach (var salary in salaries)
            {
                foreach (var advancePayments in salary.Employee.AdvancePayments.Where(a => a.IsInside == false))
                {
                    var row = new EmployeeAdvanceDetectionReportGridRow()
                    {
                        EmployeeId = salary.EmployeeId,
                        EmployeeName = salary.Employee?.GetFullName(),
                        JobNumber = salary.JobNumber, ///////
                        Value = advancePayments.Value,
                        InstallmentValue = advancePayments.InstallmentValue,
                        DeductionDate = advancePayments.DeductionDate.FormatToString(),
                        Rest = salary.Employee.AdvancePayments.Where(a => a.IsInside == false).Sum(a => a.Value)
                               - salaries.Sum(s => s.AdvancePremiumOutside),
                        //Date =
                    };

                    grid.Add(row);
                }
            }

            model.Grid = grid;

            return true;
        }
        private void Clear(AdvancePaymentModel model)
        {
            model.Value = 0;
            model.AdvancePaymentId = 0;
            model.DeductionDate = "";
            model.InstallmentValue = 0;
            model.IsInside = false;
        }
    }
}