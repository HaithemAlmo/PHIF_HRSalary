using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class NationalityBusiness : Business, INationalityBusiness
    {
        public NationalityBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Nationality && permission;


        public NationalityModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Nationality_Create))
                return Null<NationalityModel>(RequestState.NoPermission);

            return new NationalityModel()
            {
                CanCreate = ApplicationUser.Permissions.Nationality_Create,
                CanEdit = ApplicationUser.Permissions.Nationality_Edit,
                CanDelete = ApplicationUser.Permissions.Nationality_Delete,
                NationalityGrid = UnitOfWork.Nationalities
                    .GetAll().ToGrid()

            };
        }

        public void Refresh(NationalityModel model)
        {

        }

        public bool Select(NationalityModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Nationality_Edit))
                return Fail(RequestState.NoPermission);
            if (model.NationalityId <= 0)
                return Fail(RequestState.BadRequest);

            var nationality = UnitOfWork.Nationalities.Find(model.NationalityId);

            if (nationality == null)
                return Fail(RequestState.NotFound);

            model.Name = nationality.Name;
            return true;
        }

        public bool Create(NationalityModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Nationality_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Nationalities.NameIsExisted(model.Name))
                return NameExisted();
            var nationality = Nationality.New(model.Name);
            UnitOfWork.Nationalities.Add(nationality);
            UnitOfWork.Complete(n => n.Nationality_Create);
            return SuccessCreate();
        }

        public bool Edit(NationalityModel model)
        {
            if (model.NationalityId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Nationality_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var nationality = UnitOfWork.Nationalities.Find(model.NationalityId);

            if (nationality == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Nationalities.NameIsExisted(model.Name, model.NationalityId))
                return NameExisted();
            nationality.Modify(model.Name);

            UnitOfWork.Complete(n => n.Nationality_Edit);

            return SuccessEdit();
        }

        public bool Delete(NationalityModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Nationality_Delete))
                return Fail(RequestState.NoPermission);

            if (model.NationalityId <= 0)
                return Fail(RequestState.BadRequest);

            var nationality = UnitOfWork.Nationalities.Find(model.NationalityId);

            if (nationality == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Nationalities.Remove(nationality);

            if (!UnitOfWork.TryComplete(n => n.Nationality_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}