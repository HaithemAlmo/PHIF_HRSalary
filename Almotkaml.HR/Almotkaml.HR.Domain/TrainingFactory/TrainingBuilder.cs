using System;

namespace Almotkaml.HR.Domain.TrainingFactory
{
    public class TrainingBuilder : ITrainingTypeHolder, IDevelopmentTypeDHolder, IRequestedQualificationHolder
        , IExecutingAgencyHolder, IDecisionNumberHolder, IDeducationTypeHolder, ICityHolder, ISubjectHolder
        , IDateFromHolder, IDateToHolder, IDevelopmentStateHolder, ITrainingPlaceHolder, ICorporationHolder
        , IDecisionDateHolder, IBuild
    {

        internal TrainingBuilder() { }
        private Training Training { get; } = new Training();
        public IDevelopmentTypeDHolder WithTrainingType(TrainingType trainingType)
        {
            Training.TrainingType = trainingType;
            return this;
        }
        public IRequestedQualificationHolder WithDevelopmentTypeD(DevelopmentTypeD developmentTypeD)
        {
            Training.DevelopmentTypeD = developmentTypeD;
            Training.DevelopmentTypeDId = developmentTypeD.DevelopmentTypeDId;
            return this;
        }

        public IRequestedQualificationHolder WithDevelopmentTypeD(int developmentTypeDId)
        {
            Training.DevelopmentTypeDId = developmentTypeDId;
            return this;
        }

        public IExecutingAgencyHolder WithRequestedQualification(RequestedQualification requestedQualification)
        {
            Training.RequestedQualification = requestedQualification;
            Training.RequestedQualificationId = requestedQualification.RequestedQualificationId;
            return this;
        }

        public IExecutingAgencyHolder WithRequestedQualification(int? requestedQualificationId)
        {
            Training.RequestedQualificationId = requestedQualificationId;
            return this;
        }

        public IDecisionNumberHolder WithExecutingAgency(string executingAgency)
        {
            Training.ExecutingAgency = executingAgency;
            return this;
        }

        public IDeducationTypeHolder WithDecisionNumber(string decisionNumber)
        {
            Training.DecisionNumber = decisionNumber;
            return this;
        }

        public ICityHolder WithDeducationType(DeducationType deducationType)
        {
            Training.DeducationType = deducationType;
            return this;
        }

        public ISubjectHolder WithCity(City city)
        {
            Training.City = city;
            Training.CityId = city.CityId;
            return this;
        }

        public ISubjectHolder WithCity(int cityId)
        {
            Training.CityId = cityId;
            return this;
        }

        public IDateFromHolder WithSubject(TrainingType trainingType, string subject, Course course)
        {
            if (trainingType == TrainingType.Study || trainingType == TrainingType.Training)
            {
                Training.Course = course;
                Training.CourseId = course.CourseId;
            }
            else if (trainingType == TrainingType.Collaboration)
            {
                Training.Subject = subject;
            }
            return this;
        }

        public IDateFromHolder WithSubject(TrainingType trainingType, string subject, int? courseId)
        {
            if (trainingType == TrainingType.Study || trainingType == TrainingType.Training)
            {
                Training.CourseId = courseId;
            }
            else if (trainingType == TrainingType.Collaboration)
            {
                Training.Subject = subject;
            }
            return this;
        }


        public IDateToHolder WithDateFrom(DateTime dateFrom)
        {
            Training.DateFrom = dateFrom;
            return this;
        }

        public IDevelopmentStateHolder WithDateTo(DateTime dateTo)
        {
            Training.DateTo = dateTo;
            return this;
        }
        public ITrainingPlaceHolder WithDevelopmentState(DevelopmentState developmentState)
        {
            Training.DevelopmentState = developmentState;
            Training.DevelopmentStateId = developmentState.DevelopmentStateId;
            return this;
        }

        public ITrainingPlaceHolder WithDevelopmentState(int? developmentStateId)
        {
            Training.DevelopmentStateId = developmentStateId;
            return this;
        }

        public ICorporationHolder WithTrainingPlace(TrainingPlace trainingPlace)
        {
            Training.TrainingPlace = trainingPlace;
            return this;
        }

        public IDecisionDateHolder WithCorporation(Corporation corporation)
        {
            Training.Corporation = corporation;
            Training.CorporationId = corporation.CorporationId;
            return this;
        }

        public IDecisionDateHolder WithCorporation(int? corporationId)
        {
            Training.CorporationId = corporationId;
            return this;
        }

        public IBuild WithDecisionDate(DateTime decisionDate)
        {
            Training.DecisionDate = decisionDate;
            return this;
        }
        public Training Biuld()
        {
            return Training;
        }


    }
}
