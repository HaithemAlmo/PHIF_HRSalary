using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EmploymentTypeBusiness : Business, IEmploymentTypeBusiness
    {
        public EmploymentTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.EmploymentType && permission;

        public EmploymentTypeIndexModel Index()
        {
            if (!HavePermission())
                return Null<EmploymentTypeIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.EmploymentTypes
                           .GetAll()
                           .Select(a => new EmploymentTypeGridRow()
                           {
                               EmploymentTypeId = a.EmploymentTypeId,
                               Name = a.Name,
                               ContractDate = a.ContractDate,
                               ContractDuration = a.ContractDuration,
                               DesignationIssue = a.DesignationIssue,
                               DesignationResolutionDate = a.DesignationResolutionDate,
                               DesignationResolutionNumber = a.DesignationResolutionNumber
                           });

            return new EmploymentTypeIndexModel()
            {
                EmploymentTypeGrid = grid,
                CanCreate = ApplicationUser.Permissions.EmploymentType_Create,
                CanEdit = ApplicationUser.Permissions.EmploymentType_Edit,
                CanDelete = ApplicationUser.Permissions.EmploymentType_Delete,
            };
        }

        public EmploymentTypeFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.EmploymentType_Create))
                return Null<EmploymentTypeFormModel>(RequestState.NoPermission);

            return new EmploymentTypeFormModel();
        }

        public EmploymentTypeFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.EmploymentType_Edit))
                return Null<EmploymentTypeFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<EmploymentTypeFormModel>(RequestState.BadRequest);

            var employmentType = UnitOfWork.EmploymentTypes.Find(id);

            if (employmentType == null)
                return Null<EmploymentTypeFormModel>(RequestState.NotFound);

            return new EmploymentTypeFormModel()
            {
                Name = employmentType.Name,
                ContractDate = employmentType.ContractDate,
                ContractDuration = employmentType.ContractDuration,
                DesignationIssue = employmentType.DesignationIssue,
                DesignationResolutionDate = employmentType.DesignationResolutionDate,
                DesignationResolutionNumber = employmentType.DesignationResolutionNumber,
                CanSubmit = ApplicationUser.Permissions.EmploymentType_Edit,
            };
        }

        public bool Delete(int id, EmploymentTypeFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EmploymentType_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var employmentType = UnitOfWork.EmploymentTypes.Find(id);

            if (employmentType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.EmploymentTypes.Remove(employmentType);

            if (!UnitOfWork.TryComplete(n => n.EmploymentType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Edit(int id, EmploymentTypeFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.EmploymentType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employmentType = UnitOfWork.EmploymentTypes.Find(id);

            if (employmentType == null)
                return Fail(RequestState.NotFound);

            employmentType.Modify()
                .Name(model.Name)
                .ContractDate(model.ContractDate)
                .ContractDuration(model.ContractDuration)
                .DesignationIssue(model.DesignationIssue)
                .DesignationResolutionDate(model.DesignationResolutionDate)
                .DesignationResolutionNumber(model.DesignationResolutionNumber)
                .Confirm();

            UnitOfWork.Complete(n => n.EmploymentType_Edit);

            return SuccessEdit();
        }

        public bool Create(EmploymentTypeFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EmploymentType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var employmentType = EmploymentType.New()
                .WithName(model.Name)
                .WithDesignationResolutionNumber(model.DesignationResolutionNumber)
                .WithDesignationResolutionDate(model.DesignationResolutionDate)
                .WithDesignationIssue(model.DesignationIssue)
                .WithContractDate(model.ContractDate)
                .WithContractDuration(model.ContractDuration)
                .Biuld();

            UnitOfWork.EmploymentTypes.Add(employmentType);

            UnitOfWork.Complete(n => n.EmploymentType_Create);

            return SuccessCreate();
        }

        public void Refresh(EmploymentTypeFormModel model)
        {
        }
    }
}