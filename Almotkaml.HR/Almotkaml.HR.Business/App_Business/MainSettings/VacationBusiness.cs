using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;
using System;
using Almotkaml.HR.Domain;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class VacationBusiness : Business, IVacationBusiness
    {
        public VacationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Vacation && permission;

        public VacationModel Prepare()
        {
            if (!HavePermission())
                return Null<VacationModel>(RequestState.NoPermission);
            var settings = UnitOfWork.Settings.Load();
            var model = new VacationModel()
            {

                //VacationGrid = UnitOfWork.Vacations.GetVacationByEmployeeId(0).ToGrid(),
                CanCreate = ApplicationUser.Permissions.Vacation_Create,
                CanEdit = ApplicationUser.Permissions.Vacation_Edit,
                CanDelete = ApplicationUser.Permissions.Vacation_Delete,
                CanVacationBalance = ApplicationUser.Permissions.Vacation_BalancYear,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                VacationTypeList = UnitOfWork.VacationTypes.GetAll().ToList()
            };

            if (!settings.VacationIncludesHolidays)
                model.VacationGrid = UnitOfWork.Vacations.GetVacationByEmployeeId(0).ToGrid();
            else
                model.VacationGrid = UnitOfWork.Vacations.GetVacationByEmployeeId(0).ToGrid2();

            return model;
        }
       
        public void Refresh(VacationModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            //var employee2 = UnitOfWork.Vacations.GetEmployeeNameById(model.EmployeeId);
            var settings = UnitOfWork.Settings.Load();

            if (employee == null )
                return;
           
                model.EmployeeName = employee.GetFullName();
            if(!settings.VacationIncludesHolidays)
                model.VacationGrid = UnitOfWork.Vacations.GetVacationByEmployeeId(model.EmployeeId).ToGrid();
            else
                model.VacationGrid = UnitOfWork.Vacations.GetVacationByEmployeeId(model.EmployeeId).ToGrid2();

            model.CenterName = employee.JobInfo?.Unit?.Division?.Department?.Center?.Name;
                model.DepartmentName = employee.JobInfo?.Unit?.Division?.Department?.Name;
                model.DivisionName = employee.JobInfo?.Unit?.Division?.Name;
                model.UnitName = employee.JobInfo?.Unit?.Name;
                model.Balance = employee.JobInfo?.VacationBalance ?? 0;
                model.BalanceEmergency = employee.JobInfo?.VacationBalanceEmergency ?? 0;
                model.BalanceAlhuje = employee.JobInfo?.VacationBalanceAlhaju ?? 0;
                model.BalanceMarriage = employee.JobInfo?.VacationBalanceMarriage ?? 0;
            model.BalanceSick= employee.JobInfo?.VacationBalanceSickNew ?? 0;
          //  model.sickLeave = employee.JobInfo?.VacationSickLeaveNew ?? 0;
            //model.Note = employee2?.Select(s => s.Note).Last() ?? "";   
            if (model.DateFrom != null && model.DateTo != null && model.DateFrom.ToDateTime() <= model.DateTo)
                {
                    var holidayCount = UnitOfWork.Holidays.HolidayCount(model.DateFrom.ToDateTime(),
                        model.DateTo);

                //model.Days = employee.GetVacationDays(model.DateFrom.ToDateTime(), model.DateTo.ToDateTime(),
                //    holidayCount,
                //    model.VacationTypeId);
            }

           
          
        }
        public void Refresh2(VacationModel model)
        {
            var settings = UnitOfWork.Settings.Load();
            model.DateTo = model.DateFrom2.AddDays(model.Days-1);
            model.DateTo2 = (model.DateTo.Date);
           
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (model.DateTo!=null)
            {
                var holidayCount = UnitOfWork.Holidays.HolidayCount(model.DateFrom.ToDateTime(),
                        model.DateTo);

             var count = employee.GetVacationDays2(model.DateFrom.ToDateTime(), model.DateTo,
                    holidayCount,
                    model.VacationTypeId);
                count = count + holidayCount;

                var vac = UnitOfWork.VacationTypes.Find(model.VacationTypeId).VacationEssential;

                if (settings.VacationIncludesHolidays || vac == VacationEssential.WithoutPay)
                    model.DateTo3 = model.DateTo2.ToString("yyyy-MM-dd");
                else if (settings.VacationIncludesHolidays || vac != VacationEssential.Year)
                    model.DateTo3 = model.DateTo2.ToString("yyyy-MM-dd");
                else
                    model.DateTo3 = model.DateTo2.AddDays(count+1).ToString("yyyy-MM-dd"); model.DateTo = model.DateTo3.ToDateTime();
            }
        }
        public bool Select(VacationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Vacation_Edit))
                return Fail(RequestState.NoPermission);
            if (model.VacationId <= 0)
                return Fail(RequestState.BadRequest);

            var vacation = UnitOfWork.Vacations.Find(model.VacationId);
            var settings = UnitOfWork.Settings.Load();
            if (vacation == null)
                return Fail(RequestState.NotFound);
           
            model.VacationId = vacation.VacationId;
            model.EmployeeId = vacation.EmployeeId;
            model.DateFrom = vacation.DateFrom.FormatToString();
            model.VacationTypeId = vacation.VacationTypeId;
            model.DateTo = vacation.DateTo;
            model.Balance = vacation.Employee?.JobInfo?.VacationBalance ?? 0;
            model.BalanceEmergency = vacation.Employee?.JobInfo?.VacationBalanceEmergency ?? 0;
            model.BalanceAlhuje = vacation .Employee?.JobInfo?.VacationBalanceAlhaju?? 0;
            model.BalanceMarriage = vacation.Employee?.JobInfo?.VacationBalanceMarriage  ?? 0;
            model.BalanceSick = vacation.Employee?.JobInfo?.VacationBalanceSickNew ?? 0;
          //  model.sickLeave = vacation.Employee?.JobInfo?.VacationSickLeaveNew ??0;
            model.CenterName = vacation.Employee?.JobInfo?.Unit?.Division?.Department?.Center?.Name;
            model.DepartmentName = vacation.Employee?.JobInfo?.Unit?.Division?.Department?.Name;
            model.DivisionName = vacation.Employee?.JobInfo?.Unit?.Division?.Name;
            model.UnitName = vacation.Employee?.JobInfo?.Unit?.Name;
            model.DecisionDate = vacation.DecisionNumber;
            model.DecisionNumber = vacation.DecisionNumber;
            model.Place = vacation.Place;
            model.DeductionMonth  = vacation.DeductionMonth;
            model.DeductionYear = vacation.DeductionYear;
            model.Note = vacation.Note;
            //model.IsReadOnly = true   ;
            //
            var vac = UnitOfWork.VacationTypes.Find(model.VacationTypeId).VacationEssential;
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (model.DateTo != null)
            {
                var holidayCount = UnitOfWork.Holidays.HolidayCount(model.DateFrom.ToDateTime(),
                        model.DateTo);

                var count = employee.GetVacationDays2(model.DateFrom.ToDateTime(), model.DateTo,
                       holidayCount,
                       model.VacationTypeId);

                model.Days = (int)(vacation.DateTo - vacation.DateFrom).TotalDays;
                if (settings.VacationIncludesHolidays || vac == VacationEssential.WithoutPay)
                    model.Days = model.Days +1;
                else
                    model.Days = model.Days + 1 - count;
            }
            //
            return true;
        }

        public bool Create(VacationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Vacation_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var vacation = UnitOfWork.Vacations
                 .GetVacationWithEmployee(model.EmployeeId, model.DateFrom.ToDateTime(), model.DateTo);

            if (vacation)
            {
                ModelState.AddError(m => model.EmployeeId, "the Employee take the vacation in this date ...");
                return false;
            }

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

     
            if (employee == null)
                return false;
         

            var holidayCount = UnitOfWork.Holidays.HolidayCount(model.DateFrom.ToDateTime(), model.DateTo);
            //
            //var Countdaysvacation = UnitOfWork.Vacations.find2().GetDays(model.DateFrom.ToDateTime(),
            //           model.DateTo.ToDateTime());
            model.DateTo2 = (model.DateTo);
            var Countdaysvacation = model.DateTo2.Day ;
            model.Days = model.Days + holidayCount;
            // Edit by Haleem
            //Date 30-10-2018
            // شرط اجازة الحج "ان تكون 20 يوم فقط ومرة واحدة في العمر 
            if (model.VacationTypeId == 5)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy2(model.EmployeeId, model.VacationTypeId);

                if (model.BalanceAlhuje ==0) return ExistVacation();                      
                if (model.Days  > 20) return YearHauj();               
            }                      
            //
            // Edit by Haleem
            //Date 30-10-2018
            // شرط اجازة الزواج "ان تكون 14 يوم فقط ومرة واحدة في العمر 
            if (model.VacationTypeId==6)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy2(model.EmployeeId, model.VacationTypeId);
                if (model.BalanceMarriage == 0) return ExistVacation();
                if (model.Days > 14) return MarriageLeave();
            }
            //
            // Edit by Haleem
            //Date 10-11-2018
            // شرط الاجازة الطارئة "ان تكون 12 يوم  في السنة 
            if (model.VacationTypeId == 3)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy3(model.EmployeeId);               
                //var EmergencyCountDay = vacation2.Select(s => s.Employee.JobInfo.VacationBalanceEmergency).ToList();
                if (model.BalanceEmergency == 0) return VacationEmergency();
                if (model.Days > 3) return ConditionVacationEmergency();               

            }
            //
            // Edit by Haleem
            //Date 21-11-2018
            // شرط الاجازة المرضية "ان تكون 60 يوم في العمر 
            if (model.VacationTypeId == 12)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy3(model.EmployeeId);
                //var EmergencyCountDay = vacation2.Select(s => s.Employee.JobInfo.VacationBalanceEmergency).ToList();
                if (model.BalanceSick  == 0) return VacationSick();
                if (model.Days > 30) return ConditionVacationSick();

            }
            //
            //
            // Edit by Haleem
            //Date 21-11-2018
            // شرط اجازة الابوة "ان تكون2 يومين فقط  
            if (model.VacationTypeId == 8)
            {                
                if (model.Days > 2) return ConditionVacationPaternityLeave();
            }
            //
            // Edit by Haleem
            //Date 8-12-2018
            // شرط اجازة الولادة  اذا كان طفل واحد 45 يوم واذا توأم 120يوم  
            if (model.VacationTypeId == 7)//&& Convert.ToInt32(model.CountKids=1))
            {
                if (model.Days > 98) return ConditionVacationPaternityLeaveKidsOne();
            }
            if (model.VacationTypeId == 7)//&& Convert.ToInt32(model.CountKids=2))
            {
                if (model.Days > 112) return ConditionVacationPaternityLeaveKidsTwo();
            }


            employee.JobInfo.SetVacation(model.DateFrom.ToDateTime(), model.DateTo, model.VacationTypeId
                         , model.Place, model.DecisionNumber, model.DecisionDate.ToDateTime(), holidayCount,model.Note, model.Days, Convert.ToInt32(model.CountKids),model .DeductionMonth ,model .DeductionYear);
            if (model.VacationTypeId == 6)
                employee.UnActive();
            UnitOfWork.Complete(n => n.Vacation_Create);
         
            model.Balance = employee.JobInfo?.VacationBalance ?? 0;
            Clear(model);
            return SuccessCreate();
        }

        public bool Edit(VacationModel model)
        {
            if (model.VacationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Vacation_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var vacationOld = UnitOfWork.Vacations
                 .GetVacationWithEmployee(model.EmployeeId, model.DateFrom.ToDateTime(), model.DateTo
                   , model.VacationId);

            if (vacationOld)
            {
                ModelState.AddError(m => model.EmployeeId, "the Employee take the vacation in this date ...");
            }

            var vacation = UnitOfWork.Vacations.Find(model.VacationId);

            if (vacation == null)
                return Fail(RequestState.NotFound);

            var holidayCount = UnitOfWork.Holidays.HolidayCount(model.DateFrom.ToDateTime(), model.DateTo);
            //var getdateold = UnitOfWork.Vacations.getdateold(model.EmployeeId);

            var datefromold= vacation.DateFrom.FormatToString();
            var datetoOld= vacation.DateTo .FormatToString();
            //
            // Edit by Haleem
            //Date 30-10-2018
            // شرط اجازة الحج "ان تكون 20 يوم فقط ومرة واحدة في العمر 
            if (model.VacationTypeId == 9)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy2(model.EmployeeId, model.VacationTypeId);

                if (model.BalanceAlhuje == 0) return ExistVacation();
                if (model.Days > 20) return YearHauj();
            }
            //
            // Edit by Haleem
            //Date 30-10-2018
            // شرط اجازة الزواج "ان تكون 14 يوم فقط ومرة واحدة في العمر 
            if (model.VacationTypeId == 10)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy2(model.EmployeeId, model.VacationTypeId);
                if (model.BalanceMarriage == 0) return ExistVacation();
                if (model.Days > 14) return MarriageLeave();
            }
            //
            // Edit by Haleem
            //Date 10-11-2018
            // شرط الاجازة الطارئة "ان تكون 12 يوم  في السنة 
            if (model.VacationTypeId == 3)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy3(model.EmployeeId);               
                //var EmergencyCountDay = vacation2.Select(s => s.Employee.JobInfo.VacationBalanceEmergency).ToList();
                if (model.BalanceEmergency == 0) return VacationEmergency();
                if (model.Days > 3) return ConditionVacationEmergency();

            }
            //
            // Edit by Haleem
            //Date 21-11-2018
            // شرط الاجازة المرضية "ان تكون 60 يوم في العمر 
            if (model.VacationTypeId == 8)
            {
                //var vacation2 = UnitOfWork.Vacations.GetVacationBy3(model.EmployeeId);
                //var EmergencyCountDay = vacation2.Select(s => s.Employee.JobInfo.VacationBalanceEmergency).ToList();
                if (model.BalanceSick == 0) return VacationSick();
                if (model.Days > 45) return ConditionVacationSick();

            }
            //
            //
            // Edit by Haithem
            //Date 
            // شرط اجازة اصابة العمل "ان تكون30 يوم   
            if (model.VacationTypeId == 12)
            {
                if (model.BalanceSick == 0) return sickLeave();
                if (model.Days > 30) return sickLeave();
            }
            // Edit by Haleem
            //Date 8-12-2018
            // شرط اجازة الولادة  اذا كان طفل واحد 45 يوم واذا توأم 120يوم  
            if (model.VacationTypeId == 7 )//&& Convert.ToInt32(model.CountKids=1))
            {
                if (model.Days > 45) return ConditionVacationPaternityLeave();
            }
            if (model.VacationTypeId == 7)//&& Convert.ToInt32(model.CountKids=2))
            {
                if (model.Days > 120) return ConditionVacationPaternityLeave();
            }
           
            //end edit
            //
            if (model.DateFrom== datefromold && model.DateTo.ToString()==datetoOld  )
            {
                //var datefromold=from get in UnitOfWork.Employees.GetEmployeeNameById
                //                select get.
                vacation.Modify(model.DateFrom.ToDateTime(), model.DateTo, model.VacationTypeId, model.Place
                                    , model.DecisionNumber, model.DecisionDate.ToDateTime(), holidayCount, model.Note, Convert.ToInt32(model.CountKids), model.DeductionMonth, model.DeductionYear);
            }
            else
            {
                vacation.Modify2(model.DateFrom.ToDateTime(), model.DateTo, model.VacationTypeId, model.Place
                                   , model.DecisionNumber, model.DecisionDate.ToDateTime(), holidayCount, model.Note,model.Days, Convert.ToInt32(model.CountKids), model.DeductionMonth, model.DeductionYear);

            }

            UnitOfWork.Complete(n => n.Vacation_Edit);

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            model.Balance = employee?.JobInfo?.VacationBalance ?? 0;
            model.IsReadOnly = false   ;
            Clear(model);
            return SuccessEdit();
        }

        public bool Delete(VacationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Vacation_Delete))
                return Fail(RequestState.NoPermission);

            if (model.VacationId <= 0)
                return Fail(RequestState.BadRequest);

            var vacation = UnitOfWork.Vacations.Find(model.VacationId);

            if (vacation == null)
                return Fail(RequestState.NotFound);

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return false;

            var holidayCount = UnitOfWork.Holidays.HolidayCount(vacation.DateFrom, vacation.DateTo);

            employee.Vacation(vacation, holidayCount);
            UnitOfWork.Vacations.Remove(vacation);

            if (!UnitOfWork.TryComplete(n => n.Vacation_Delete))
                return Fail(UnitOfWork.Message);

            Clear(model);
            model.Balance = employee.JobInfo?.VacationBalance ?? 0;
            return SuccessDelete();
        }

        public bool VacationBalancYear(VacationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Vacation_BalancYear))
                return Fail(RequestState.NoPermission);

            var employees = UnitOfWork.Employees.GetAll().ToList().OrderBy(e => e.EmployeeId);

            if (!(model.DateVacationBalanceYear.ToDateTime().Month == 12
                   && model.DateVacationBalanceYear.ToDateTime().Day == 31))
                return ModelState.AddError(m => model.DateVacationBalanceYear, "error in entered date ...");

            if (employees == null)
                return false;

            if (employees.FirstOrDefault()?.JobInfo?.VacationBalanceYear >= model.DateVacationBalanceYear.ToDateTime().Year)
                return ModelState.AddError(m => model.DateVacationBalanceYear, "error enter balanc for this year ...");
            // تم ادخال الرصيد لهذه السنة

            foreach (var employee in employees)
            {
                var balanc = 0;
                balanc = UnitOfWork.Employees.VacationBalanc(employee.EmployeeId);
                var Emergencycountday = 0;
                Emergencycountday = UnitOfWork.Employees.VacationBalanc2(employee.EmployeeId);
                employee.JobInfo?.Modify(model.DateVacationBalanceYear.ToDateTime().Year, balanc, Emergencycountday);
                


            }

            UnitOfWork.Complete(n => n.Vacation_BalancYear);

            return SuccessCreate();
        }

        private void Clear(VacationModel model)
        {
            model.VacationId = 0;
            model.DecisionDate = "";
            model.DecisionNumber = "";
            model.Place = false;
            model.DateFrom = "";
            model.DateTo =DateTime.Now.Date  ;
            model.Days = 0;
            model.VacationTypeId = 0;
            model.Note = "";
            model.DeductionMonth = 0;
            model.DeductionYear = 0;
        }
    }
}