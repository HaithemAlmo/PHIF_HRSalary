using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CountryBusiness : Business, ICountryBusiness
    {
        public CountryBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Country && permission;


        public CountryModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Country_Create))
                return Null<CountryModel>(RequestState.NoPermission);

            return new CountryModel()
            {
                CanCreate = ApplicationUser.Permissions.Country_Create,
                CanEdit = ApplicationUser.Permissions.Country_Edit,
                CanDelete = ApplicationUser.Permissions.Country_Delete,
                CountryGrid = UnitOfWork.Countries
                    .GetAll()
                    .Select(a => new CountryGridRow()
                    {
                        CountryId = a.CountryId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(CountryModel model)
        {

        }

        public bool Select(CountryModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Country_Edit))
                return Fail(RequestState.NoPermission);
            if (model.CountryId <= 0)
                return Fail(RequestState.BadRequest);

            var country = UnitOfWork.Countries.Find(model.CountryId);

            if (country == null)
                return Fail(RequestState.NotFound);

            model.Name = country.Name;
            return true;

        }

        public bool Create(CountryModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Country_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Countries.NameIsExisted(model.Name))
                return NameExisted();
            var country = Country.New(model.Name);
            UnitOfWork.Countries.Add(country);

            UnitOfWork.Complete(n => n.Country_Create);

            return SuccessCreate();


        }

        public bool Edit(CountryModel model)
        {
            if (model.CountryId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Country_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var country = UnitOfWork.Countries.Find(model.CountryId);

            if (country == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Countries.NameIsExisted(model.Name, model.CountryId))
                return NameExisted();
            country.Modify(model.Name);

            UnitOfWork.Complete(n => n.Country_Edit);

            return SuccessEdit();
        }

        public bool Delete(CountryModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Country_Delete))
                return Fail(RequestState.NoPermission);

            if (model.CountryId <= 0)
                return Fail(RequestState.BadRequest);

            var country = UnitOfWork.Countries.Find(model.CountryId);

            if (country == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Countries.Remove(country);

            if (!UnitOfWork.TryComplete(n => n.Country_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

    }
}