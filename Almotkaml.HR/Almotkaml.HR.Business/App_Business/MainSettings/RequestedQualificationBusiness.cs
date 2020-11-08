using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class RequestedQualificationBusiness : Business, IRequestedQualificationBusiness
    {
        public RequestedQualificationBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.RequestedQualification && permission;


        public RequestedQualificationModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.RequestedQualification_Create))
                return Null<RequestedQualificationModel>(RequestState.NoPermission);

            return new RequestedQualificationModel()
            {
                CanCreate = ApplicationUser.Permissions.RequestedQualification_Create,
                CanEdit = ApplicationUser.Permissions.RequestedQualification_Edit,
                CanDelete = ApplicationUser.Permissions.RequestedQualification_Delete,
                Grid = UnitOfWork.RequestedQualifications.GetAll().ToGrid()
            };
        }

        public void Refresh(RequestedQualificationModel model)
        {

        }

        public bool Select(RequestedQualificationModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.RequestedQualification_Edit))
                return Fail(RequestState.NoPermission);
            if (model.RequestedQualificationId <= 0)
                return Fail(RequestState.BadRequest);

            var requestedQualification = UnitOfWork.RequestedQualifications.Find(model.RequestedQualificationId);

            if (requestedQualification == null)
                return Fail(RequestState.NotFound);

            model.Name = requestedQualification.Name;
            return true;
        }

        public bool Create(RequestedQualificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RequestedQualification_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.RequestedQualifications.NameIsExisted(model.Name))
                return NameExisted();
            var requestedQualification = RequestedQualification.New(model.Name);
            UnitOfWork.RequestedQualifications.Add(requestedQualification);

            UnitOfWork.Complete(n => n.RequestedQualification_Create);

            return SuccessCreate();
        }

        public bool Edit(RequestedQualificationModel model)
        {
            if (model.RequestedQualificationId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.RequestedQualification_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var requestedQualification = UnitOfWork.RequestedQualifications.Find(model.RequestedQualificationId);

            if (requestedQualification == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.RequestedQualifications.NameIsExisted(model.Name, model.RequestedQualificationId))
                return NameExisted();
            requestedQualification.Modify(model.Name);

            UnitOfWork.Complete(n => n.RequestedQualification_Edit);

            return SuccessEdit();
        }

        public bool Delete(RequestedQualificationModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RequestedQualification_Delete))
                return Fail(RequestState.NoPermission);

            if (model.RequestedQualificationId <= 0)
                return Fail(RequestState.BadRequest);

            var requestedQualification = UnitOfWork.RequestedQualifications.Find(model.RequestedQualificationId);

            if (requestedQualification == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.RequestedQualifications.Remove(requestedQualification);
            if (!UnitOfWork.TryComplete(n => n.RequestedQualification_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}