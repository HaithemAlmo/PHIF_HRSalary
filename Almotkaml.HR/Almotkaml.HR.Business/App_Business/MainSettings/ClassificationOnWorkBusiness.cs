using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class ClassificationOnWorkBusiness : Business, IClassificationOnWorkBusiness
    {
        public ClassificationOnWorkBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.ClassificationOnWork && permission;


        public ClassificationOnWorkModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnWork_Create))
                return Null<ClassificationOnWorkModel>(RequestState.NoPermission);

            return new ClassificationOnWorkModel()
            {
                CanCreate = ApplicationUser.Permissions.ClassificationOnWork_Create,
                CanEdit = ApplicationUser.Permissions.ClassificationOnWork_Edit,
                CanDelete = ApplicationUser.Permissions.ClassificationOnWork_Delete,
                Grid = UnitOfWork.ClassificationOnWorks
                    .GetAll()
                    .Select(a => new ClassificationOnWorkGridRow()
                    {
                        ClassificationOnWorkId = a.ClassificationOnWorkId,
                        Name = a.Name
                    }),
            };
        }

        public void Refresh(ClassificationOnWorkModel model)
        {

        }

        public bool Select(ClassificationOnWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnWork_Edit))
                return Fail(RequestState.NoPermission);
            if (model.ClassificationOnWorkId <= 0)
                return Fail(RequestState.BadRequest);

            var classificationOnWork = UnitOfWork.ClassificationOnWorks.Find(model.ClassificationOnWorkId);

            if (classificationOnWork == null)
                return Fail(RequestState.NotFound);

            model.Name = classificationOnWork.Name;
            return true;
        }

        public bool Create(ClassificationOnWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnWork_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.ClassificationOnWorks.NameIsExisted(model.Name))
                return NameExisted();
            var classificationOnWork = ClassificationOnWork.New(model.Name);
            UnitOfWork.ClassificationOnWorks.Add(classificationOnWork);

            UnitOfWork.Complete(n => n.ClassificationOnWork_Create);

            return SuccessCreate();
        }

        public bool Edit(ClassificationOnWorkModel model)
        {
            if (model.ClassificationOnWorkId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnWork_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var classificationOnWork = UnitOfWork.ClassificationOnWorks.Find(model.ClassificationOnWorkId);

            if (classificationOnWork == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.ClassificationOnWorks.NameIsExisted(model.Name, model.ClassificationOnWorkId))
                return NameExisted();
            classificationOnWork.Modify(model.Name);

            UnitOfWork.Complete(n => n.ClassificationOnWork_Edit);

            return SuccessEdit();
        }

        public bool Delete(ClassificationOnWorkModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.ClassificationOnWork_Delete))
                return Fail(RequestState.NoPermission);

            if (model.ClassificationOnWorkId <= 0)
                return Fail(RequestState.BadRequest);

            var classificationOnWork = UnitOfWork.ClassificationOnWorks.Find(model.ClassificationOnWorkId);

            if (classificationOnWork == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.ClassificationOnWorks.Remove(classificationOnWork);

            if (!UnitOfWork.TryComplete(n => n.ClassificationOnWork_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}