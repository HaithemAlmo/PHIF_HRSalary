using System;

namespace Almotkaml.HR.Domain.TrainingFactory
{
    public class TrainingModifier
    {
        internal TrainingModifier(Training training)
        {
            Training = training;
        }
        private Training Training { get; }
        public TrainingModifier WithTrainingType(TrainingType trainingType)
        {
            Training.TrainingType = trainingType;
            return this;
        }
        public TrainingModifier DevelopmentTypeD(DevelopmentTypeD developmentTypeD)
        {
            Training.DevelopmentTypeD = developmentTypeD;
            Training.DevelopmentTypeDId = developmentTypeD.DevelopmentTypeDId;
            return this;
        }

        public TrainingModifier DevelopmentTypeD(int developmentTypeDId)
        {
            Training.DevelopmentTypeDId = developmentTypeDId;
            return this;
        }

        public TrainingModifier RequestedQualification(RequestedQualification requestedQualification)
        {
            Training.RequestedQualification = requestedQualification;
            Training.RequestedQualificationId = requestedQualification.RequestedQualificationId;
            return this;
        }

        public TrainingModifier RequestedQualification(int? requestedQualificationId)
        {
            Training.RequestedQualificationId = requestedQualificationId;
            return this;
        }

        public TrainingModifier ExecutingAgency(string executingAgency)
        {
            Training.ExecutingAgency = executingAgency;
            return this;
        }

        public TrainingModifier DecisionNumber(string decisionNumber)
        {
            Training.DecisionNumber = decisionNumber;
            return this;
        }

        public TrainingModifier DeducationType(DeducationType deducationType)
        {
            Training.DeducationType = deducationType;
            return this;
        }

        public TrainingModifier City(City city)
        {
            Training.City = city;
            Training.CityId = city.CityId;
            return this;
        }

        public TrainingModifier City(int cityId)
        {
            Training.CityId = cityId;
            return this;
        }

        public TrainingModifier Subject(TrainingType trainingType, string subject, Course course)
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

        public TrainingModifier Subject(TrainingType trainingType, string subject, int? courseId)
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


        public TrainingModifier DateFrom(DateTime dateFrom)
        {
            Training.DateFrom = dateFrom;
            return this;
        }

        public TrainingModifier DateTo(DateTime dateTo)
        {
            Training.DateTo = dateTo;
            return this;
        }
        public TrainingModifier DevelopmentState(DevelopmentState developmentState)
        {
            Training.DevelopmentState = developmentState;
            Training.DevelopmentStateId = developmentState.DevelopmentStateId;
            return this;
        }

        public TrainingModifier DevelopmentState(int? developmentStateId)
        {
            Training.DevelopmentStateId = developmentStateId;
            return this;
        }

        public TrainingModifier TrainingPlace(TrainingPlace trainingPlace)
        {
            Training.TrainingPlace = trainingPlace;
            return this;
        }

        public TrainingModifier Corporation(Corporation corporation)
        {
            Training.Corporation = corporation;
            Training.CorporationId = corporation.CorporationId;
            return this;
        }

        public TrainingModifier Corporation(int? corporationId)
        {
            Training.CorporationId = corporationId;
            return this;
        }

        public TrainingModifier DecisionDate(DateTime decisionDate)
        {
            Training.DecisionDate = decisionDate;
            return this;
        }

        public Training Confirm()
        {
            return Training;
        }
    }


}