using Almotkaml.Extensions;
using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EndServiceBusiness : Business, IEndServicesBusiness
    {
        public EndServiceBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
           => ApplicationUser.Permissions.EndServices && permission;
        public EndServicesIndexModel Index()
        {
            if (!HavePermission())
                return Null<EndServicesIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.EndServices
                .GetEndServicesesWithEmployee().ToGrid();

            return new EndServicesIndexModel()
            {
                EndServicesGrid = grid,
                CanCreate = ApplicationUser.Permissions.EndServices_Create,
                CanEdit = ApplicationUser.Permissions.EndServices_Edit,
                CanDelete = ApplicationUser.Permissions.EndServices_Delete,
            };
        }

        public void Refresh(EndServicesFormModel model)
        {
            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId);
            if (employee == null)
                return;
            model.EmployeeName = employee.GetFullName();
        }

        public EndServicesFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.EndServices_Create))
                return Null<EndServicesFormModel>(RequestState.NoPermission);

            var employeeGrid = UnitOfWork.Employees
                .GetAll();

            return new EndServicesFormModel()
            {
                EmployeeGrid = employeeGrid.ToGrid(),
                CanSubmit = ApplicationUser.Permissions.EndServices_Create
            };
        }

        public bool Create(EndServicesFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EndServices_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            if (employee == null)
                return Fail("employee not found");

            employee.EndServices(model.CauseOfEndService, model.DecisionDate.ToDateTime(), model.Cause, model.DecisionNumber);

            UnitOfWork.Complete(n => n.EndServices_Create);

            return SuccessCreate();
        }

        public EndServicesFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.EndServices_Edit))
                return Null<EndServicesFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<EndServicesFormModel>(RequestState.BadRequest);

            var endService = UnitOfWork.EndServices.Find(id);

            if (endService == null)
                return Null<EndServicesFormModel>(RequestState.NotFound);

            return new EndServicesFormModel()
            {
                DecisionDate = endService.DecisionDate.FormatToString(),
                EmployeeId = endService.EmployeeId,
                CauseOfEndService = endService.CauseOfEndService,
                Cause = endService.Cause,
                CanSubmit = ApplicationUser.Permissions.EndServices_Edit,
                DecisionNumber = endService.DecisionNumber,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                EndServicesId = id,
                EmployeeName = endService.Employee.GetFullName()


            };
        }

        public bool Edit(int id, EndServicesFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.EndServices_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var endService = UnitOfWork.EndServices.Find(id);

            if (endService == null)
                return Fail(RequestState.NotFound);

            endService.Modify()
                .Date(model.DecisionDate.ToDateTime())
                .Employee(model.EmployeeId)
                .Cause(model.Cause)
                .CauseOfEndService(model.CauseOfEndService)
                .Confirm();

            var employee = UnitOfWork.Employees.Find(model.EmployeeId);

            employee.JobInfo.Modify().CurrentSituation((int)model.CauseOfEndService + 1);

            UnitOfWork.Complete(n => n.EndServices_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, EndServicesFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EndServices_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var endService = UnitOfWork.EndServices.Find(id);

            if (endService == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.EndServices.Remove(endService);
            endService.Employee.Active();

            if (!UnitOfWork.TryComplete(n => n.EndServices_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool View(SettlementReportModel model)
        {
            //if (!ModelState.IsValid(model))
            //    return false;

            //var endServiceses = UnitOfWork.EndServices.GetEndServicesesWithEmployeeBy(model.CauseOfEndService);

            //if (endServiceses == null)
            //    return false;

            //var grid = new HashSet<SettlementReportGridRow>();

            //foreach (var endServicese in endServiceses)
            //{
            //    var row = new SalariesTotalReportGridRow()
            //    {
            //        //BasicSalaries = endServicese.BasicSalary,
            //        //CompanyShareSocialSecurity = endServicese.CompanyShare(Settings),
            //        //ContributionInSecurity = endServicese.CompanyShare(Settings) + 0,
            //        ////DeducationTotal = ,
            //        //JihadTax = endServicese.JihadTax(Settings),
            //        ////MawadaFund = ,
            //        ////SafeShareSocialSecurity = ,
            //        //SalariesNet = endServicese.NetSalary(Settings),
            //        ////SalariesNumber = ,
            //        //SalariesTotal = endServicese.TotalSalary(Settings),
            //        //SocialSecurityFund = endServicese.EmployeeShare(Settings),
            //        //SolidarityFund = endServicese.SolidarityFund(Settings),
            //        //StampTax = endServicese.StampTax(Settings),
            //    };

            //    //grid.Add(row);
            //}

            //model.Grid = grid;

            return true;
        }
    }
}
