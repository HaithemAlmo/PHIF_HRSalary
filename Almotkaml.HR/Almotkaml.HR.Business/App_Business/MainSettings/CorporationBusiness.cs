using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class CorporationBusiness : Business, ICorporationBusiness
    {
        public CorporationBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
           => ApplicationUser.Permissions.Corporation && permission;
        public CorporationIndexModel Index()
        {
            if (!HavePermission())
                return Null<CorporationIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Corporations
                .GetAll().ToGrid();

            return new CorporationIndexModel()
            {
                CorporationGrid = grid,
                CanCreate = ApplicationUser.Permissions.Corporation_Create,
                CanEdit = ApplicationUser.Permissions.Corporation_Edit,
                CanDelete = ApplicationUser.Permissions.Corporation_Delete,
            };
        }

        public void Refresh(CorporationFormModel model)
        {
            if (model == null)
                return;


            model.CityList = model.CountryId > 0
                ? UnitOfWork.Cities.GetCityWithCountry(model.CountryId).ToList()
                : new HashSet<CityListItem>();
        }

        public CorporationFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Corporation_Create))
                return Null<CorporationFormModel>(RequestState.NoPermission);

            var country = UnitOfWork.Countries.GetAll();

            return new CorporationFormModel()
            {
                CountryList = country.ToList()
            };
        }

        public bool Create(CorporationFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Corporation_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var corporation = Corporation.New()
                .WithName(model.Name)
                .WithPhone(model.Phone)
                .WithEmail(model.Email)
                .WithAddress(model.Address)
                .WithCityId(model.CityId)
                .WithNote(model.Note)
                .WithDonorFoundationType(model.DonorFoundationType)
                .Biuld();

            UnitOfWork.Corporations.Add(corporation);

            UnitOfWork.Complete(n => n.Corporation_Create);

            return SuccessCreate();
        }

        public CorporationFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Corporation_Edit))
                return Null<CorporationFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<CorporationFormModel>(RequestState.BadRequest);

            var corporation = UnitOfWork.Corporations.Find(id);

            if (corporation == null)
                return Null<CorporationFormModel>(RequestState.NotFound);

            var countryId = corporation.City?.CountryId ?? 0;
            return new CorporationFormModel()
            {
                CorporationId = id,
                Name = corporation.Name,
                Email = corporation.Email,
                Phone = corporation.Phone,
                Address = corporation.Address,
                CityId = corporation.CityId,
                CountryId = countryId,
                Note = corporation.Note,
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                CityList = UnitOfWork.Cities.GetCityWithCountry(countryId).ToList(),
                CanSubmit = ApplicationUser.Permissions.Corporation_Edit,
            };
        }

        public bool Edit(int id, CorporationFormModel model)
        {
            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Corporation_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var corporation = UnitOfWork.Corporations.Find(id);

            if (corporation == null)
                return Fail(RequestState.NotFound);

            corporation.Modify()
                .Name(model.Name)
                .Phone(model.Phone)
                .Email(model.Email)
                .Address(model.Address)
                .CityId(model.CityId)
                .WithNote(model.Note)
                .DonorFoundationType(model.DonorFoundationType)
                .Confirm();

            UnitOfWork.Complete(n => n.Corporation_Edit);

            return SuccessEdit();
        }

        public bool Delete(int id, CorporationFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Corporation_Delete))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var corporation = UnitOfWork.Corporations.Find(id);

            if (corporation == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Corporations.Remove(corporation);

            if (!UnitOfWork.TryComplete(n => n.Corporation_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}
