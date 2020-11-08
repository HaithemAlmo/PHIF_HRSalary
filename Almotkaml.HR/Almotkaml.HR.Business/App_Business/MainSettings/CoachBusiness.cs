using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CoachBusiness : Business, ICoachBusiness
    {
        public CoachBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Coach && permission;

        public CoachIndexModel Index()
        {
            if (!HavePermission())
                return Null<CoachIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Coaches.GetAll().ToGrid();

            return new CoachIndexModel()
            {
                CoachGrid = grid,
                CanCreate = ApplicationUser.Permissions.Coach_Create,
                CanEdit = ApplicationUser.Permissions.Coach_Edit,
                CanDelete = ApplicationUser.Permissions.Coach_Delete,
            };
        }

        public void Refresh(CoachFormModel model)
        {
            if (model.CoachType == CoachType.Inside)
            {
                var employee = UnitOfWork.Employees.GetEmployeeNameById(model.EmployeeId ?? 0);
                if (employee == null)
                    return;
                model.Name = employee.GetFullName();
                model.Phone = employee.Phone;
                model.Email = employee.Email;
            }
            else
            {
                Clear(model);
            }
        }

        public CoachFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Coach_Create))
                return Null<CoachFormModel>(RequestState.NoPermission);

            var employeeGrid = UnitOfWork.Employees.GetAll();

            return new CoachFormModel()
            {
                EmployeeGrid = employeeGrid.ToGrid(),
                CanSubmit = ApplicationUser.Permissions.Coach_Create
            };
        }

        public bool Create(CoachFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Coach_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.Coachs.NameIsExisted(model.Name))
            //    return NameExisted();
            var coach = Coach.New(model.CoachType, model.Name, model.EmployeeId, model.Phone, model.Email, model.Note);
            UnitOfWork.Coaches.Add(coach);

            UnitOfWork.Complete(n => n.Coach_Create);

            return SuccessCreate();
        }

        public CoachFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Coach_Edit))
                return Null<CoachFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<CoachFormModel>(RequestState.BadRequest);

            var coach = UnitOfWork.Coaches.Find(id);

            if (coach == null)
                return Null<CoachFormModel>(RequestState.NotFound);

            if (coach.CoachType == CoachType.Inside)
            {
                return new CoachFormModel()
                {
                    CoachId = id,
                    EmployeeId = coach.EmployeeId,
                    CoachType = coach.CoachType,
                    Name = coach.Employee?.GetFullName(),
                    Email = coach.Employee?.Email,
                    Phone = coach.Employee?.Phone,
                    Note = coach.Note,
                    EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                    CanSubmit = ApplicationUser.Permissions.Coach_Edit,
                };
            }
            return new CoachFormModel()
            {
                CoachId = id,
                Name = coach.Name,
                CoachType = coach.CoachType,
                Email = coach.Email,
                Note = coach.Note,
                Phone = coach.Phone,
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                CanSubmit = ApplicationUser.Permissions.Coach_Edit,
            };
        }

        public bool Edit(int id, CoachFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Coach_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var coach = UnitOfWork.Coaches.Find(id);

            if (coach == null)
                return Fail(RequestState.NotFound);

            //if (UnitOfWork.Coachs.NameIsExisted(model.Name, model.CoachId))
            //    return NameExisted();
            coach.Modify(model.CoachType, model.Name, model.EmployeeId, model.Phone, model.Email, model.Note);

            UnitOfWork.Complete(n => n.Coach_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, CoachFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Coach_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var coach = UnitOfWork.Coaches.Find(id);

            if (coach == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Coaches.Remove(coach);

            if (!UnitOfWork.TryComplete(n => n.Coach_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        private void Clear(CoachFormModel model)
        {
            model.Name = "";
            model.Phone = "";
            model.Email = "";
        }
    }
}