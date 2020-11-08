using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{

    public class TimeSheetBusiness : Business, ITimeSheetBusiness
    {

        public TimeSheetBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }
        private bool HavePermission(bool permission = true)
          => ApplicationUser.Permissions.TimeSheet && permission;

        public TimeSheetIndexModel Index()
        {
            if (!HavePermission())
                return Null<TimeSheetIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.TimeSheets
                           .GetAll()
                           .Select(a => new TimeSheetGridRow()
                           {
                               TimeSheetId = a.TimeSheetId,
                               EmployeeName = a.Employee.FirstName + a.Employee.LastName,
                               HourAccess = a.HourAccess,
                               Hourleave = a.Hourleave,
                               Date = a.Date

                           });

            return new TimeSheetIndexModel()
            {
                TimeSheetGridRows = grid,
                CanCreate = ApplicationUser.Permissions.TimeSheet_Create,
                CanEdit = ApplicationUser.Permissions.TimeSheet_Edit,
                CanDelete = ApplicationUser.Permissions.TimeSheet_Delete,
            };
        }

        public void Refresh(TimeSheetFormModel model)
        {
            throw new NotImplementedException();
        }

        public TimeSheetFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.TimeSheet_Create))
                return Null<TimeSheetFormModel>(RequestState.NoPermission);




            return new TimeSheetFormModel()
            {
                Date = DateTime.Now.FormatToString(),
                HourAccess = DateTime.Now.FormatToString(),//-------تعديل
                Hourleave = DateTime.Now.FormatToString(),
            };
        }

        public bool Create(TimeSheetFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.TimeSheet_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var timesheet = TimeSheet.New()
                .WithEmployeeId(model.EmployeeId)
                .WithHourAccess(model.HourAccess)
                .WithHourleave(model.Hourleave)
                .WithDate(model.Date.ToDateTime())
                .Biuld();


            UnitOfWork.TimeSheets.Add(timesheet);

            UnitOfWork.Complete(n => n.TimeSheet_Create);

            return SuccessCreate();
        }

        public TimeSheetFormModel Find(long id)
        {
            if (!HavePermission(ApplicationUser.Permissions.TimeSheet_Edit))
                return Null<TimeSheetFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<TimeSheetFormModel>(RequestState.BadRequest);

            var timesheet = UnitOfWork.TimeSheets.Find(id);

            if (timesheet == null)
                return Null<TimeSheetFormModel>(RequestState.NotFound);

            return new TimeSheetFormModel()
            {
                EmployeeId = timesheet.EmployeeId,
                HourAccess = timesheet.HourAccess,
                Hourleave = timesheet.Hourleave,
                Date = timesheet.Date.ToString()
            };
        }

        public bool Edit(long id, TimeSheetFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.TimeSheet_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var timesheet = UnitOfWork.TimeSheets.Find(id);

            if (timesheet == null)
                return Fail(RequestState.NotFound);

            timesheet.Modify()
                .WithEmployeeId(model.EmployeeId)
                .WithHourAccess(model.HourAccess)
                .WithHourleave(model.Hourleave)
                .WithDate(model.Date.ToDateTime());

            UnitOfWork.Complete(n => n.TimeSheet_Edit);

            return SuccessEdit();
        }

        public bool Delete(long id, TimeSheetFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.TimeSheet_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var timesheet = UnitOfWork.TimeSheets.Find(id);

            if (timesheet == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.TimeSheets.Remove(timesheet);
            if (!UnitOfWork.TryComplete(n => n.TimeSheet_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}
