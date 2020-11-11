using Almotkaml.HR.Abstraction;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class EntrantsAndReviewersBusiness : Business, IEntrantsAndReviewersBusiness
    {
        public EntrantsAndReviewersBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
           => ApplicationUser.Permissions.EntrantsAndReviewers && permission;

        public EntrantsAndReviewersModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Create))
                return Null<EntrantsAndReviewersModel>(RequestState.NoPermission);

            return new EntrantsAndReviewersModel()
            {
                CanCreate = ApplicationUser.Permissions.EntrantsAndReviewers_Create,
                CanEdit = ApplicationUser.Permissions.EntrantsAndReviewers_Edit,
                CanDelete = ApplicationUser.Permissions.EntrantsAndReviewers_Delete,
                EntrantsAndReviewersGrid = UnitOfWork.EntrantsAndReviewerss
                    .GetAll()
                    .Select(a => new EntrantsAndReviewersGridRow()
                    {
                        EntrantsAndReviewersId=a.EntrantsAndReviewersId,
                        EmployeeNumber = a.EmployeeNumber,
                        EmployeeName = a.EmployeeName,
                        NationalNumber = a.NationalNumber,
                        Gender = a.Gender,
                        Email = a.Email,
                        Phone = a.Phone,
                        StartDate = a.StartDate,
                        Note = a.Note,
                    }),
            };
        }

        public bool Select(EntrantsAndReviewersModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Edit))
                return Fail(RequestState.NoPermission);
            if (model.EntrantsAndReviewersId  <= 0)
                return Fail(RequestState.BadRequest);

            var entrantsAndReviewers = UnitOfWork.EntrantsAndReviewerss.Find(model.EntrantsAndReviewersId);

            if (entrantsAndReviewers == null)
                return Fail(RequestState.NotFound);

            model.EmployeeName = entrantsAndReviewers.EmployeeName;
            model.EmployeeNumber = entrantsAndReviewers.EmployeeNumber;
            model.Gender = entrantsAndReviewers.Gender;
            model.NationalNumber = entrantsAndReviewers.NationalNumber;
            model.Phone = entrantsAndReviewers.Phone;
            model.Email = entrantsAndReviewers.Email;
            model.StartDate = entrantsAndReviewers.StartDate.ToString();
            model.Note = entrantsAndReviewers.Note;


            return true;

        }

        public bool Create(EntrantsAndReviewersModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.EntrantsAndReviewerss.NameIsExisted(model.EmployeeName))
                return NameExisted();
            var entrantsAndReviewers = EntrantsAndReviewers.New(model.EmployeeNumber, model.EmployeeName, model.NationalNumber, model.Gender, model.Phone, model.Email, DateTime.Parse(model.StartDate), model.Note);
            UnitOfWork.EntrantsAndReviewerss.Add(entrantsAndReviewers);

            UnitOfWork.Complete(n => n.EntrantsAndReviewers_Create);

            return SuccessCreate();


        }

        public void Refresh(EntrantsAndReviewersModel model)
        {
        }

        public bool Edit(EntrantsAndReviewersModel model)

        {
            if (model.EntrantsAndReviewersId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var entrantsAndReviewers = UnitOfWork.EntrantsAndReviewerss.Find(model.EntrantsAndReviewersId);

            if (entrantsAndReviewers == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.EntrantsAndReviewerss.NameIsExisted(model.EmployeeName,model.EntrantsAndReviewersId))
                return NameExisted();
            entrantsAndReviewers.Modify(model.EmployeeNumber, model.EmployeeName, model.NationalNumber, model.Gender, model.Phone, model.Email, DateTime.Parse(model.StartDate), model.Note);

            UnitOfWork.Complete(n => n.EntrantsAndReviewers_Edit);

            return SuccessEdit();

        }

        public bool Delete(EntrantsAndReviewersModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.EntrantsAndReviewers_Delete))
                return Fail(RequestState.NoPermission);

            if (model.EntrantsAndReviewersId  <= 0)
                return Fail(RequestState.BadRequest);

            var entrantsAndReviewers = UnitOfWork.EntrantsAndReviewerss .Find(model.EntrantsAndReviewersId );

            if (entrantsAndReviewers == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.EntrantsAndReviewerss .Remove(entrantsAndReviewers);

            if (!UnitOfWork.TryComplete(n => n.EntrantsAndReviewers_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }


    }
}
