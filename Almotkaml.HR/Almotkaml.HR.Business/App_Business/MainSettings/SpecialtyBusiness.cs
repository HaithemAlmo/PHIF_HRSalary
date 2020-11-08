using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SpecialtyBusiness : Business, ISpecialtyBusiness
    {
        public SpecialtyBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Specialty && permission;

        public SpecialtyModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Specialty_Create))
                return Null<SpecialtyModel>(RequestState.NoPermission);

            return new SpecialtyModel()
            {
                CanCreate = ApplicationUser.Permissions.Specialty_Create,
                CanEdit = ApplicationUser.Permissions.Specialty_Edit,
                CanDelete = ApplicationUser.Permissions.Specialty_Delete,
                SpecialtyGrid = UnitOfWork.Specialties
                    .GetAll()
                    .Select(a => new SpecialtyGridRow()
                    {
                        SpecialtyId = a.SpecialtyId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(SpecialtyModel model)
        {

        }

        public bool Select(SpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Specialty_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var specialty = UnitOfWork.Specialties.Find(model.SpecialtyId);

            if (specialty == null)
                return Fail(RequestState.NotFound);

            model.Name = specialty.Name;
            return true;

        }

        public bool Create(SpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Specialty_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Specialties.NameIsExisted(model.Name))
                return NameExisted();
            var specialty = Specialty.New(model.Name);
            UnitOfWork.Specialties.Add(specialty);

            UnitOfWork.Complete(n => n.Specialty_Create);

            return SuccessCreate();


        }

        public bool Edit(SpecialtyModel model)
        {
            if (model.SpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Specialty_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var specialty = UnitOfWork.Specialties.Find(model.SpecialtyId);

            if (specialty == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Specialties.NameIsExisted(model.Name, model.SpecialtyId))
                return NameExisted();
            specialty.Modify(model.Name);

            UnitOfWork.Complete(n => n.Specialty_Edit);

            return SuccessEdit();
        }

        public bool Delete(SpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Specialty_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var specialty = UnitOfWork.Specialties.Find(model.SpecialtyId);

            if (specialty == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Specialties.Remove(specialty);

            if (!UnitOfWork.TryComplete(n => n.Specialty_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}