using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;


namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class SubSpecialtyBusiness : Business, ISubSpecialtyBusiness
    {
        public SubSpecialtyBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.SubSpecialty && permission;

        public SubSpecialtyModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.SubSpecialty_Create))
                return Null<SubSpecialtyModel>(RequestState.NoPermission);

            return new SubSpecialtyModel()
            {
                CanCreate = ApplicationUser.Permissions.Specialty_Create,
                CanEdit = ApplicationUser.Permissions.Specialty_Edit,
                CanDelete = ApplicationUser.Permissions.Specialty_Delete,
                SpecialtyList = UnitOfWork.Specialties.GetAll().ToList(),
                SubSpecialtyGrid = UnitOfWork.SubSpecialties
                    .GetSubSpecialtyWithSpecialty().ToGrid()

            };
        }

        public void Refresh(SubSpecialtyModel model)
        {

        }

        public bool Select(SubSpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SubSpecialty_Edit))
                return Fail(RequestState.NoPermission);
            if (model.SubSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var subSpecialty = UnitOfWork.SubSpecialties.Find(model.SubSpecialtyId);

            if (subSpecialty == null)
                return Fail(RequestState.NotFound);
            model.SpecialtyId = subSpecialty.SpecialtyId;
            model.Name = subSpecialty.Name;
            return true;
        }

        public bool Create(SubSpecialtyModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.SubSpecialty_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.SubSpecialties.SubSpecialtyExisted(model.Name, model.SpecialtyId))
                return NameExisted();
            var subSpecialty = SubSpecialty.New(model.Name, model.SpecialtyId);
            UnitOfWork.SubSpecialties.Add(subSpecialty);

            UnitOfWork.Complete(n => n.SubSpecialty_Create);

            return SuccessCreate();
        }

        public bool Edit(SubSpecialtyModel model)
        {
            if (model.SubSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.SubSpecialty_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var subSpecialty = UnitOfWork.SubSpecialties.Find(model.SubSpecialtyId);

            if (subSpecialty == null)
                return Fail(RequestState.NotFound);
            if (UnitOfWork.SubSpecialties.SubSpecialtyExisted(model.Name, model.SpecialtyId, model.SubSpecialtyId))
                return NameExisted();
            subSpecialty.Modify(model.Name, model.SpecialtyId);

            UnitOfWork.Complete(n => n.SubSpecialty_Edit);

            return SuccessEdit();
        }

        public bool Delete(SubSpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.SubSpecialty_Delete))
                return Fail(RequestState.NoPermission);

            if (model.SubSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var subSpecialty = UnitOfWork.SubSpecialties.Find(model.SubSpecialtyId);

            if (subSpecialty == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.SubSpecialties.Remove(subSpecialty);

            if (!UnitOfWork.TryComplete(n => n.SubSpecialty_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}