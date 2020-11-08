using Almotkaml.Extensions;
using Almotkaml.HR.Business.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.MainSettings
{
    public class TrainingBusiness : Business, ITrainingBusiness
    {
        public TrainingBusiness(HumanResource humanResource)
            : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Training && permission;

        public TrainingIndexModel Index()
        {
            if (!HavePermission())
                return Null<TrainingIndexModel>(RequestState.NoPermission);

            var grid = UnitOfWork.Trainings.GetAll().ToGrid();

            return new TrainingIndexModel()
            {
                TrainingGrid = grid,
                CanCreate = ApplicationUser.Permissions.Training_Create,
                CanEdit = ApplicationUser.Permissions.Training_Edit,
                CanDelete = ApplicationUser.Permissions.Training_Delete,
            };
        }

        public TrainingFormModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.Training_Create))
                return Null<TrainingFormModel>(RequestState.NoPermission);

            return new TrainingFormModel()
            {
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                DevelopmentStateList = UnitOfWork.DevelopmentStates.GetAll().ToList(),
                RequestedQualificationList = UnitOfWork.RequestedQualifications.GetAll().ToList(),
                DevelopmentTypeAList = UnitOfWork.DevelopmentTypeAs
                        .DevelopmentTypeAWithTrainingType(TrainingType.Training).ToList(),
                CorporationGrid = UnitOfWork.Corporations.GetAll().ToGrid(),
                CourseGrid = UnitOfWork.Courses.GetAll().ToGrid(),
                TrainingDetailForm = new TrainingDetailForm()
                {
                    EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid()
                },
                CanSubmit = ApplicationUser.Permissions.Training_Create
            };
        }

        public TrainingFormModel Find(int id)
        {
            if (!HavePermission(ApplicationUser.Permissions.Training_Edit))
                return Null<TrainingFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<TrainingFormModel>(RequestState.BadRequest);

            var training = UnitOfWork.Trainings.Find(id);

            if (training == null)
                return Null<TrainingFormModel>(RequestState.NotFound);

            var developmentTypeAId = training.DevelopmentTypeD?.DevelopmentTypeC?.DevelopmentTypeB?
                .DevelopmentTypeAId ?? 0;
            var developmentTypeBId = training.DevelopmentTypeD?.DevelopmentTypeC?.DevelopmentTypeBId ?? 0;
            var developmentTypeCId = training.DevelopmentTypeD?.DevelopmentTypeCId ?? 0;
            var developmentTypeDId = training.DevelopmentTypeDId;
            var countryId = training.City?.CountryId ?? 0;

            return new TrainingFormModel()
            {
                TrainingId = id,
                DateFrom = training.DateFrom.FormatToString(),
                DateTo = training.DateTo.FormatToString(),
                CountryId = countryId,
                DevelopmentTypeAId = developmentTypeAId,
                CityList = UnitOfWork.Cities.GetCityWithCountry(countryId).ToList(),
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                RequestedQualificationList = UnitOfWork.RequestedQualifications.GetAll().ToList(),
                DevelopmentStateList = UnitOfWork.DevelopmentStates.GetAll().ToList(),
                DevelopmentTypeAList = UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(training.TrainingType).ToList(),
                RequestedQualificationId = training.RequestedQualificationId,
                CityId = training.CityId,
                DecisionNumber = training.DecisionNumber,
                DeducationType = training.DeducationType,
                DevelopmentStateId = training.DevelopmentStateId,
                DevelopmentTypeBId = developmentTypeBId,
                DevelopmentTypeBList = UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(developmentTypeAId).ToList(),
                DevelopmentTypeCId = developmentTypeCId,
                DevelopmentTypeCList = UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(developmentTypeBId).ToList(),
                DevelopmentTypeDId = developmentTypeDId,
                DevelopmentTypeDList = UnitOfWork.DevelopmentTypeDs.GetDevelopmentTypeDWithDevelopmentTypeC(developmentTypeCId).ToList(),
                ExecutingAgency = training.ExecutingAgency,
                Subject = training.Subject,
                CorporationGrid = UnitOfWork.Corporations.GetAll().ToGrid(),
                CorporationId = training.CorporationId,
                TrainingPlace = training.TrainingPlace,
                CorporationName = training.Corporation?.Name,
                TrainingType = training.TrainingType,
                CourseId = training.CourseId,
                DecisionDate = training.DecisionDate.FormatToString(),
                CourseName = training.Course?.Name,
                CourseGrid = UnitOfWork.Courses.GetAll().ToGrid(),
                TrainingDetailForm = new TrainingDetailForm()
                {
                    TrainingId = training.TrainingId,
                    EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                    TrainingDetailGrid = training.TrainingDetails.ToGrid(),
                },
                CanSubmit = ApplicationUser.Permissions.Training_Edit
            };
        }

        public bool SelectDetail(TrainingFormModel model)
        {
            if (model.TrainingDetailForm.TrainingDetailId <= 0)
                return Fail(RequestState.BadRequest);

            var detail = UnitOfWork.Trainings.FindDetail(model.TrainingDetailForm.TrainingDetailId);

            if (detail == null)
                return Fail(RequestState.NotFound);

            model.TrainingDetailForm.EmployeeName = detail.Employee?.GetFullName();
            model.TrainingDetailForm.EmployeeId = detail.EmployeeId;
            model.TrainingDetailForm.TrainingDetailId = detail.TrainingDetailId;
            model.TrainingDetailForm.TrainingId = detail.TrainingId;

            return true;
        }

        public bool Delete(TrainingFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Training_Delete))
                return Fail(RequestState.NoPermission);

            if (model.TrainingId <= 0)
                return Fail(RequestState.BadRequest);

            var training = UnitOfWork.Trainings.Find(model.TrainingId);

            if (training == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Trainings.Remove(training);

            if (!UnitOfWork.TryComplete(n => n.Training_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool DeleteDetail(TrainingFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Training_Edit))
                return Fail(RequestState.NoPermission);

            if (model.TrainingDetailForm.TrainingDetailId <= 0 || model.TrainingId <= 0)
                return Fail(RequestState.BadRequest);

            var training = UnitOfWork.Trainings.Find(model.TrainingId);

            if (training == null)
                return Fail(RequestState.NotFound);

            var detail = training.TrainingDetails
                .FirstOrDefault(d => d.TrainingDetailId == model.TrainingDetailForm.TrainingDetailId);

            if (detail == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Trainings.RemoveDetail(detail);

            if (!UnitOfWork.TryComplete(n => n.Training_Delete))
                return Fail(UnitOfWork.Message);

            ReloadGrid(model, training);

            return SuccessDelete();
        }
        private void ReloadGrid(TrainingFormModel model, Training training)
        {
            model.TrainingDetailForm = new TrainingDetailForm()
            {
                EmployeeGrid = UnitOfWork.Employees.GetAll().ToGrid(),
                TrainingDetailGrid = training.TrainingDetails.ToGrid(),
            };
            model.TrainingId = training.TrainingId;
        }
        public bool Save(TrainingFormModel model) => model.TrainingId > 0
            ? Edit(model)
            : Create(model);

        private bool Create(TrainingFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Training_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var training = Training.New()
                .WithTrainingType(model.TrainingType)
                .WithDevelopmentTypeD(model.DevelopmentTypeDId)
                .WithRequestedQualification(model.RequestedQualificationId)
                .WithExecutingAgency(model.ExecutingAgency)
                .WithDecisionNumber(model.DecisionNumber)
                .WithDeducationType(model.DeducationType)
                .WithCity(model.CityId)
                .WithSubject(model.TrainingType, model.Subject, model.CourseId)
                .WithDateFrom(model.DateFrom.ToDateTime())
                .WithDateTo(model.DateTo.ToDateTime())
                .WithDevelopmentState(model.DevelopmentStateId)
                .WithTrainingPlace(model.TrainingPlace)
                .WithCorporation(model.CorporationId)
                .WithDecisionDate(model.DecisionDate.ToDateTime())
                .Biuld();

            if (!CreateDetail(model, training))
                return false;

            UnitOfWork.Trainings.Add(training);

            UnitOfWork.Complete(n => n.Training_Create);

            ReloadGrid(model, training);
            return SuccessCreate();
        }

        private bool Edit(TrainingFormModel model)
        {
            if (model.TrainingId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Training_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var training = UnitOfWork.Trainings.Find(model.TrainingId);

            if (training == null)
                return Fail(RequestState.NotFound);

            training.Modify()
                .WithTrainingType(model.TrainingType)
                .DevelopmentTypeD(model.DevelopmentTypeDId)
                .RequestedQualification(model.RequestedQualificationId)
                .ExecutingAgency(model.ExecutingAgency)
                .DecisionNumber(model.DecisionNumber)
                .DeducationType(model.DeducationType)
                .City(model.CityId)
                .Subject(model.TrainingType, model.Subject, model.CourseId)
                .DateFrom(model.DateFrom.ToDateTime())
                .DateTo(model.DateTo.ToDateTime())
                .DevelopmentState(model.DevelopmentStateId)
                .TrainingPlace(model.TrainingPlace)
                .Corporation(model.CorporationId)
                .DecisionDate(model.DecisionDate.ToDateTime())
                .Confirm();

            var isDone = model.TrainingDetailForm.TrainingDetailId > 0
                ? EditDetail(model, training)
                : CreateDetail(model, training);

            if (!isDone)
                return false;

            UnitOfWork.Complete(n => n.Training_Edit);

            ReloadGrid(model, training);

            return SuccessEdit();
        }

        private bool CreateDetail(TrainingFormModel model, Training training)
        {
            training.TrainingDetails.Add(TrainingDetail.New(training, model.TrainingDetailForm.EmployeeId));

            return true;
        }

        private bool EditDetail(TrainingFormModel model, Training training)
        {
            var detail = training.TrainingDetails
               .FirstOrDefault(d => d.TrainingDetailId == model.TrainingDetailForm.TrainingDetailId);

            if (detail == null)
                return Fail(RequestState.NotFound);

            detail.Modify(model.TrainingDetailForm.EmployeeId);

            return true;
        }


        public void Refresh(TrainingFormModel model)
        {
            if (model == null)
                return;

            model.DevelopmentTypeAList = model.TrainingType >= 0
                ? UnitOfWork.DevelopmentTypeAs.DevelopmentTypeAWithTrainingType(model.TrainingType).ToList()
                : new HashSet<DevelopmentTypeAListItem>();

            model.DevelopmentTypeBList = model.DevelopmentTypeAId > 0
                ? UnitOfWork.DevelopmentTypeBs.GetDevelopmentTypeBWithDevelopmentTypeA(model.DevelopmentTypeAId).ToList()
                : new HashSet<DevelopmentTypeBListItem>();

            model.DevelopmentTypeCList = model.DevelopmentTypeBId > 0
                ? UnitOfWork.DevelopmentTypeCs.GetDevelopmentTypeCWithDevelopmentTypeB(model.DevelopmentTypeBId).ToList()
                : new HashSet<DevelopmentTypeCListItem>();

            model.DevelopmentTypeDList = model.DevelopmentTypeCId > 0
                ? UnitOfWork.DevelopmentTypeDs.GetDevelopmentTypeDWithDevelopmentTypeC(model.DevelopmentTypeCId).ToList()
                : new HashSet<DevelopmentTypeDListItem>();

            model.CityList = model.CountryId > 0
                ? UnitOfWork.Cities.GetCityWithCountry(model.CountryId).ToList()
                : new HashSet<CityListItem>();

            var employee = UnitOfWork.Employees.GetEmployeeNameById(model.TrainingDetailForm.EmployeeId);
            if (employee != null)
                model.TrainingDetailForm.EmployeeName = employee.GetFullName();

            var corporation = UnitOfWork.Corporations.Find(model.CorporationId);
            if (corporation != null)
                model.CorporationName = corporation.Name;

            var course = UnitOfWork.Courses.Find(model.CourseId);
            if (course != null)
                model.CourseName = course.Name;
        }

    }
}