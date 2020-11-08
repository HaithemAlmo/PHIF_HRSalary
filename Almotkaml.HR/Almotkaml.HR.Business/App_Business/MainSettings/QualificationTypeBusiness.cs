using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class QualificationTypeBusiness : Business, IQualificationTypeBusiness
    {
        public QualificationTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.QualificationType && permission;

        public QualificationTypeModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.QualificationType_Create))
                return Null<QualificationTypeModel>(RequestState.NoPermission);

            return new QualificationTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.QualificationType_Create,
                CanEdit = ApplicationUser.Permissions.QualificationType_Edit,
                CanDelete = ApplicationUser.Permissions.QualificationType_Delete,
                QualificationTypeGrid = UnitOfWork.QualificationTypes
                    .GetAll()
                    .Select(a => new QualificationTypeGridRow()
                    {
                        QualificationTypeId = a.QualificationTypeId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(QualificationTypeModel model)
        {

        }

        public bool Select(QualificationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.QualificationType_Edit))
                return Fail(RequestState.NoPermission);
            if (model.QualificationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var qualificationType = UnitOfWork.QualificationTypes.Find(model.QualificationTypeId);

            if (qualificationType == null)
                return Fail(RequestState.NotFound);

            model.Name = qualificationType.Name;
            return true;

        }

        public bool Create(QualificationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.QualificationType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.QualificationTypes.NameIsExisted(model.Name))
                return NameExisted();
            var qualificationType = QualificationType.New(model.Name);
            UnitOfWork.QualificationTypes.Add(qualificationType);

            UnitOfWork.Complete(n => n.QualificationType_Create);

            return SuccessCreate();


        }

        public bool Edit(QualificationTypeModel model)
        {
            if (model.QualificationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.QualificationType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var qualificationType = UnitOfWork.QualificationTypes.Find(model.QualificationTypeId);

            if (qualificationType == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.QualificationTypes.NameIsExisted(model.Name, model.QualificationTypeId))
                return NameExisted();
            qualificationType.Modify(model.Name);

            UnitOfWork.Complete(n => n.QualificationType_Edit);

            return SuccessEdit();
        }

        public bool Delete(QualificationTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.QualificationType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.QualificationTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var qualificationType = UnitOfWork.QualificationTypes.Find(model.QualificationTypeId);

            if (qualificationType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.QualificationTypes.Remove(qualificationType);

            if (!UnitOfWork.TryComplete(n => n.QualificationType_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}