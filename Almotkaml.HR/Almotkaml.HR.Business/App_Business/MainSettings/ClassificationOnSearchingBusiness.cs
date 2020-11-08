using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class ClassificationOnSearchingBusiness : Business, IClassificationOnSearchingBusiness
    {
        public ClassificationOnSearchingBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.ClassificationOnSearching && permission;


        public ClassificationOnSearchingModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnSearching_Create))
                return Null<ClassificationOnSearchingModel>(RequestState.NoPermission);

            return new ClassificationOnSearchingModel()
            {
                CanCreate = ApplicationUser.Permissions.ClassificationOnSearching_Create,
                CanEdit = ApplicationUser.Permissions.ClassificationOnSearching_Edit,
                CanDelete = ApplicationUser.Permissions.ClassificationOnSearching_Delete,
                Grid = UnitOfWork.ClassificationOnSearchings
                    .GetAll()
                    .Select(a => new ClassificationOnSearchingGridRow()
                    {
                        ClassificationOnSearchingId = a.ClassificationOnSearchingId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(ClassificationOnSearchingModel model)
        {

        }

        public bool Select(ClassificationOnSearchingModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnSearching_Edit))
                return Fail(RequestState.NoPermission);
            if (model.ClassificationOnSearchingId <= 0)
                return Fail(RequestState.BadRequest);

            var classificationOnSearching = UnitOfWork.ClassificationOnSearchings.Find(model.ClassificationOnSearchingId);

            if (classificationOnSearching == null)
                return Fail(RequestState.NotFound);

            model.Name = classificationOnSearching.Name;
            return true;
        }

        public bool Create(ClassificationOnSearchingModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnSearching_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.ClassificationOnSearchings.NameIsExisted(model.Name))
                return NameExisted();
            var classificationOnSearching = ClassificationOnSearching.New(model.Name);
            UnitOfWork.ClassificationOnSearchings.Add(classificationOnSearching);

            UnitOfWork.Complete(n => n.ClassificationOnSearching_Create);

            return SuccessCreate();
        }

        public bool Edit(ClassificationOnSearchingModel model)
        {
            if (model.ClassificationOnSearchingId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnSearching_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var classificationOnSearching = UnitOfWork.ClassificationOnSearchings.Find(model.ClassificationOnSearchingId);

            if (classificationOnSearching == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.ClassificationOnSearchings.NameIsExisted(model.Name, model.ClassificationOnSearchingId))
                return NameExisted();
            classificationOnSearching.Modify(model.Name);

            UnitOfWork.Complete(n => n.ClassificationOnSearching_Edit);

            return SuccessEdit();
        }

        public bool Delete(ClassificationOnSearchingModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnSearching_Delete))
                return Fail(RequestState.NoPermission);

            if (model.ClassificationOnSearchingId <= 0)
                return Fail(RequestState.BadRequest);

            var classificationOnSearching = UnitOfWork.ClassificationOnSearchings.Find(model.ClassificationOnSearchingId);

            if (classificationOnSearching == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.ClassificationOnSearchings.Remove(classificationOnSearching);

            if (!UnitOfWork.TryComplete(n => n.ClassificationOnSearching_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}