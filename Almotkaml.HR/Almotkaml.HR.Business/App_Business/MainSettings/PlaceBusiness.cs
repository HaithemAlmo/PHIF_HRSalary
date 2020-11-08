using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class PlaceBusiness : Business, IPlaceBusiness
    {
        public PlaceBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Place && permission;


        public PlaceModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Place_Create))
                return Null<PlaceModel>(RequestState.NoPermission);

            return new PlaceModel()
            {
                CanCreate = ApplicationUser.Permissions.Place_Create,
                CanEdit = ApplicationUser.Permissions.Place_Edit,
                CanDelete = ApplicationUser.Permissions.Place_Delete,
                BranchList = UnitOfWork.Branches.GetAll().ToList(),
                PlaceGrid = UnitOfWork.Places
                    .GetPlaceWithBranch().ToGrid()

            };
        }

        public void Refresh(PlaceModel model)
        {

        }

        public bool Select(PlaceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Place_Edit))
                return Fail(RequestState.NoPermission);
            if (model.PlaceId <= 0)
                return Fail(RequestState.BadRequest);

            var place = UnitOfWork.Places.Find(model.PlaceId);

            if (place == null)
                return Fail(RequestState.NotFound);
            model.BranchId = place.BranchId;
            model.Name = place.Name;
            return true;
        }

        public bool Create(PlaceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Place_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Places.PlaceExisted(model.Name, model.BranchId))
                return NameExisted();
            var place = Place.New(model.Name, model.BranchId);
            UnitOfWork.Places.Add(place);

            UnitOfWork.Complete(n => n.Place_Create);

            return SuccessCreate();
        }

        public bool Edit(PlaceModel model)
        {
            if (model.PlaceId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Place_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var place = UnitOfWork.Places.Find(model.PlaceId);

            if (place == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Places.PlaceExisted(model.Name, model.BranchId, model.PlaceId))
                return NameExisted();
            place.Modify(model.Name, model.BranchId);

            UnitOfWork.Complete(n => n.Place_Edit);

            return SuccessEdit();
        }

        public bool Delete(PlaceModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Place_Delete))
                return Fail(RequestState.NoPermission);

            if (model.PlaceId <= 0)
                return Fail(RequestState.BadRequest);

            var place = UnitOfWork.Places.Find(model.PlaceId);

            if (place == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Places.Remove(place);

            if (!UnitOfWork.TryComplete(n => n.Place_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}