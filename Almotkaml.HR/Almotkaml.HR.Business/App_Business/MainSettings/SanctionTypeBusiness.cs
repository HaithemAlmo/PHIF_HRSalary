using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SanctionTypeBusiness : Business, ISanctionTypeBusiness
    {
        public SanctionTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SanctionType && permission;

        public SanctionTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SanctionType_Create))
                return Null<SanctionTypeModel>(RequestState.NoPermission);

            return new SanctionTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.SanctionType_Create,
                CanEdit = ApplicationUser.Permissions.SanctionType_Edit,
                CanDelete = ApplicationUser.Permissions.SanctionType_Delete,
                SanctionTypeGrid = UnitOfWork.SanctionTypes
                    .GetAll()
                    .Select(a => new SanctionTypeGridRow()
                    {
                        SanctionTypeId = a.SanctionTypeId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(SanctionTypeModel model)
        {

        }

        public bool Select(SanctionTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SanctionType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SanctionTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var sanctionType = UnitOfWork.SanctionTypes.Find(model.SanctionTypeId);

            if (sanctionType == null)
                return Fail(RequestState.NotFound);

            model.Name = sanctionType.Name;
            return true;

        }

        public bool Create(SanctionTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SanctionType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.SanctionTypes.NameIsExisted(model.Name))
                return NameExisted();
            var sanctionType = SanctionType.New(model.Name);
            UnitOfWork.SanctionTypes.Add(sanctionType);

            UnitOfWork.Complete(n => n.SanctionType_Create);

            return SuccessCreate();


        }

        public bool Edit(SanctionTypeModel model)
        {
            if (model.SanctionTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.SanctionType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var sanctionType = UnitOfWork.SanctionTypes.Find(model.SanctionTypeId);

            if (sanctionType == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.SanctionTypes.NameIsExisted(model.Name, model.SanctionTypeId))
                return NameExisted();
            sanctionType.Modify(model.Name);

            UnitOfWork.Complete(n => n.SanctionType_Edit);

            return SuccessEdit();
        }

        public bool Delete(SanctionTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SanctionType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SanctionTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var sanctionType = UnitOfWork.SanctionTypes.Find(model.SanctionTypeId);

            if (sanctionType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.SanctionTypes.Remove(sanctionType);

            if (!UnitOfWork.TryComplete(n => n.SanctionType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}