using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class ExactSpecialtyBusiness : Business, IExactSpecialtyBusiness
    {
        public ExactSpecialtyBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.ExactSpecialty && permission;

        public ExactSpecialtyModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.ExactSpecialty_Create))
                return Null<ExactSpecialtyModel>(RequestState.NoPermission);

            return new ExactSpecialtyModel()
            {
                CanCreate = ApplicationUser.Permissions.ExactSpecialty_Create,
                CanEdit = ApplicationUser.Permissions.ExactSpecialty_Edit,
                CanDelete = ApplicationUser.Permissions.ExactSpecialty_Delete,
                SpecialtyList = UnitOfWork.Specialties.GetAll().ToList(),
                ExactSpecialtyGrid = UnitOfWork.ExactSpecialties.GetExactSpecialtyWithSubSpecialty().ToGrid()
            };
        }

        public void Refresh(ExactSpecialtyModel model)
        {
            if (model == null)
                return;


            model.SubSpecialtyList = model.SpecialtyId > 0
                ? UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(model.SpecialtyId).ToList()
                : new HashSet<SubSpecialtyListItem>();
        }

        public bool Select(ExactSpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ExactSpecialty_Edit))
                return Fail(RequestState.NoPermission);
            if (model.ExactSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var exactSpecialty = UnitOfWork.ExactSpecialties.Find(model.ExactSpecialtyId);

            if (exactSpecialty == null)
                return Fail(RequestState.NotFound);

            var specialtyId = exactSpecialty.SubSpecialty?.SpecialtyId ?? 0;
            model.SpecialtyId = specialtyId;
            model.SubSpecialtyId = exactSpecialty.SubSpecialtyId;
            model.SubSpecialtyList = UnitOfWork.SubSpecialties.GetSubSpecialtyWithSpecialty(specialtyId).ToList();
            model.Name = exactSpecialty.Name;
            return true;
        }

        public bool Create(ExactSpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ExactSpecialty_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.ExactSpecialties.ExactSpecialtyExisted(model.Name, model.SubSpecialtyId))
                return NameExisted();

            var exactSpecialty = ExactSpecialty.New(model.Name, model.SubSpecialtyId);

            UnitOfWork.ExactSpecialties.Add(exactSpecialty);

            UnitOfWork.Complete(n => n.ExactSpecialty_Create);

            return SuccessCreate();
        }

        public bool Edit(ExactSpecialtyModel model)
        {
            if (model.ExactSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.ExactSpecialty_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var exactSpecialty = UnitOfWork.ExactSpecialties.Find(model.ExactSpecialtyId);

            if (exactSpecialty == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.ExactSpecialties.ExactSpecialtyExisted(model.Name, model.SubSpecialtyId, model.ExactSpecialtyId))
                return NameExisted();

            exactSpecialty.Modify(model.Name, model.SubSpecialtyId);

            UnitOfWork.Complete(n => n.ExactSpecialty_Edit);

            return SuccessEdit();
        }

        public bool Delete(ExactSpecialtyModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ExactSpecialty_Delete))
                return Fail(RequestState.NoPermission);

            if (model.ExactSpecialtyId <= 0)
                return Fail(RequestState.BadRequest);

            var exactSpecialty = UnitOfWork.ExactSpecialties.Find(model.ExactSpecialtyId);

            if (exactSpecialty == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.ExactSpecialties.Remove(exactSpecialty);

            if (!UnitOfWork.TryComplete(n => n.ExactSpecialty_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }



    }
}