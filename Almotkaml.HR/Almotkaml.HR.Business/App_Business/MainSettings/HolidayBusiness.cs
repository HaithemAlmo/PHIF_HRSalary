using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class HolidayBusiness : Business, IHolidayBusiness
    {
        public HolidayBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Holiday && permission;


        public HolidayModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Holiday_Create))
                return Null<HolidayModel>(RequestState.NoPermission);

            return new HolidayModel()
            {
                CanCreate = ApplicationUser.Permissions.Holiday_Create,
                CanEdit = ApplicationUser.Permissions.Holiday_Edit,
                CanDelete = ApplicationUser.Permissions.Holiday_Delete,
                HolidayGrid = UnitOfWork.Holidays.GetAll().ToGrid()
            };
        }

        public void Refresh(HolidayModel model)
        {

        }

        public bool Select(HolidayModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Holiday_Edit))
                return Fail(RequestState.NoPermission);
            if (model.HolidayId <= 0)
                return Fail(RequestState.BadRequest);

            var holiday = UnitOfWork.Holidays.Find(model.HolidayId);

            if (holiday == null)
                return Fail(RequestState.NotFound);

            model.Name = holiday.Name;
            model.DayFrom = holiday.DayFrom;
            model.DayTo = holiday.DayTo;
            model.MonthFrom = holiday.MonthFrom;
            model.MonthTo = holiday.MonthTo;
            return true;
        }

        public bool Create(HolidayModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Holiday_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Holidays.NameIsExisted(model.Name))
                return NameExisted();
            var holiday = Holiday.New(model.Name, model.DayFrom, model.DayTo, model.MonthFrom, model.MonthTo);
            UnitOfWork.Holidays.Add(holiday);

            UnitOfWork.Complete(n => n.Holiday_Create);

            return SuccessCreate();
        }

        public bool Edit(HolidayModel model)
        {
            if (model.HolidayId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Holiday_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var holiday = UnitOfWork.Holidays.Find(model.HolidayId);

            if (holiday == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Holidays.NameIsExisted(model.Name, model.HolidayId))
                return NameExisted();
            holiday.Modify(model.Name, model.DayFrom, model.DayTo, model.MonthFrom, model.MonthTo);

            UnitOfWork.Complete(n => n.Holiday_Edit);

            return SuccessEdit();
        }

        public bool Delete(HolidayModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Holiday_Delete))
                return Fail(RequestState.NoPermission);

            if (model.HolidayId <= 0)
                return Fail(RequestState.BadRequest);

            var holiday = UnitOfWork.Holidays.Find(model.HolidayId);

            if (holiday == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Holidays.Remove(holiday);
            if (!UnitOfWork.TryComplete(n => n.Holiday_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}