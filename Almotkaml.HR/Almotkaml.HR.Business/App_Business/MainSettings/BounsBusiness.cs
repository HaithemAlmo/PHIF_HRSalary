using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;
using System;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class BounsBusiness : Business, IBounsBusiness
    {
        public BounsBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Bouns && permission;

        public BounsModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Bouns))
                return Null<BounsModel>(RequestState.NoPermission);
            var grid = UnitOfWork.Employees.GetEmployeeBouns().ToBounsGrid();
            return new BounsModel()
            {
                CanSubmit = ApplicationUser.Permissions.Bouns_Add,
                BounsGrid = grid
            };
        }
        public BounsModel Preparehr()
        {
            if (!HavePermission(ApplicationUser.Permissions.Bouns))
                return Null<BounsModel>(RequestState.NoPermission);
            var grid = UnitOfWork.Employees.GetEmployeeBounshr().ToBounsGridhr();
            return new BounsModel()
            {
                CanSubmit = ApplicationUser.Permissions.Bouns_Add,
                BounsGrid = grid
            };
        }
        public bool Submit(BounsModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Bouns_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            var date = employee.JobInfo?.DateBouns;

            var dateBoun = new DateTime(date.GetValueOrDefault().AddYears(1).Year
                        , date.GetValueOrDefault().AddMonths(1).Month, 1);

            var modify = employee.JobInfo?.Modify();
            //if (date?.Day > 2)
            //    modify?.DateBouns(dateBoun);
            //else
                modify?.DateBouns(date?.AddYears(1))
                      .Bouns(employee.JobInfo?.Bouns + 1)
                      .Confirm();
        
            UnitOfWork.Complete(n => n.Bouns_Add);

            return SuccessCreate();

        }
        public bool Submithr(BounsModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Bouns_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            var date = employee.JobInfo?.DateBounshr;

            //var dateBoun = new DateTime(date.GetValueOrDefault().Year
            //            , date.GetValueOrDefault().AddMonths(1).Month, 1);

            var modify = employee.JobInfo?.Modify();
            //if (date?.Day > 2)
            //    modify?.DateBounshr(dateBoun);
            //else
                modify?.DateBounshr(date?.AddYears(1))
                      .Bounshr(employee.JobInfo?.Bounshr + 1)
                      .Confirm();
            UnitOfWork.Complete(n => n.Bouns_Add);

            return SuccessCreate();

        }

        public bool Cancel(BounsModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Bouns_Add))
                return Fail(RequestState.NoPermission);

            if (model == null)
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail(RequestState.NotFound);

            employee.JobInfo.Modify()
                .DateBounshr(employee.JobInfo?.DateBounshr?.AddYears(1))
                .Confirm();


            UnitOfWork.Complete(n => n.Bouns_Add);

            return SuccessCreate();
        }
        
    }
}