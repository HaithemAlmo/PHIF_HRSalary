using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class DocumentTypeBusiness : Business, IDocumentTypeBusiness
    {
        public DocumentTypeBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.DocumentType && permission;

        public DocumentTypeModel Prepare()
        {
            if (!HavePermission())
                return Null<DocumentTypeModel>(RequestState.NoPermission);

            return new DocumentTypeModel()
            {
                CanCreate = ApplicationUser.Permissions.DocumentType_Create,
                CanEdit = ApplicationUser.Permissions.DocumentType_Edit,
                CanDelete = ApplicationUser.Permissions.DocumentType_Delete,
                DocumentTypeGrid = UnitOfWork.DocumentTypes.GetAll().ToGrid()
            };
        }

        public void Refresh(DocumentTypeModel model) { }

        public bool Select(DocumentTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DocumentType_Edit))
                return Fail(RequestState.NoPermission);

            if (model.DocumentTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

            if (documentType == null)
                return Fail(RequestState.NotFound);

            model.Name = documentType.Name;
            model.HaveDecisionNumber = documentType.HaveDecisionNumber;
            model.HaveDecisionYear = documentType.HaveDecisionYear;
            model.HaveExpireDate = documentType.HaveExpireDate;

            return true;
        }

        public bool Create(DocumentTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DocumentType_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.DocumentTypes.NameIsExisted(model.Name))
                return NameExisted();

            var documentType = DocumentType
                .New(model.Name, model.HaveDecisionNumber, model.HaveDecisionYear, model.HaveExpireDate);

            UnitOfWork.DocumentTypes.Add(documentType);

            UnitOfWork.Complete(n => n.DocumentType_Create);

            return SuccessCreate();
        }


        public bool Edit(DocumentTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DocumentType_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (model.DocumentTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

            if (documentType == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.DocumentTypes.NameIsExisted(model.Name, model.DocumentTypeId))
                return NameExisted();


            documentType.Modify(model.Name, model.HaveDecisionNumber, model.HaveDecisionYear, model.HaveExpireDate);

            UnitOfWork.Complete(n => n.DocumentType_Edit);

            return SuccessEdit();
        }

        public bool Delete(DocumentTypeModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.DocumentType_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DocumentTypeId <= 0)
                return Fail(RequestState.BadRequest);

            var documentType = UnitOfWork.DocumentTypes.Find(model.DocumentTypeId);

            if (documentType == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.DocumentTypes.Remove(documentType);

            return !UnitOfWork.TryComplete(n => n.DocumentType_Delete) ? Fail(UnitOfWork.Message) : SuccessDelete();
        }
    }
}