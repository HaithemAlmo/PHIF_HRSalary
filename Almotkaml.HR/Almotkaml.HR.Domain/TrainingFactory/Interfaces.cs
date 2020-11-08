using System;

namespace Almotkaml.HR.Domain.TrainingFactory
{
    public interface ITrainingTypeHolder
    {
        IDevelopmentTypeDHolder WithTrainingType(TrainingType trainingType);
    }
    public interface IDevelopmentTypeDHolder
    {
        IRequestedQualificationHolder WithDevelopmentTypeD(DevelopmentTypeD developmentTypeD);
        IRequestedQualificationHolder WithDevelopmentTypeD(int developmentTypeDId);
    }
    public interface IRequestedQualificationHolder
    {
        IExecutingAgencyHolder WithRequestedQualification(RequestedQualification requestedQualification);
        IExecutingAgencyHolder WithRequestedQualification(int? requestedQualificationId);
    }
    public interface IExecutingAgencyHolder
    {
        IDecisionNumberHolder WithExecutingAgency(string executingAgency);
    }
    public interface IDecisionNumberHolder
    {
        IDeducationTypeHolder WithDecisionNumber(string decisionNumber);
    }
    public interface IDeducationTypeHolder
    {
        ICityHolder WithDeducationType(DeducationType deducationType);
    }
    public interface ICityHolder
    {
        ISubjectHolder WithCity(City city);
        ISubjectHolder WithCity(int cityId);
    }
    public interface ISubjectHolder
    {
        IDateFromHolder WithSubject(TrainingType trainingType, string subject, Course course);
        IDateFromHolder WithSubject(TrainingType trainingType, string subject, int? courseId);
    }
    public interface IDateFromHolder
    {
        IDateToHolder WithDateFrom(DateTime dateFrom);
    }
    public interface IDateToHolder
    {
        IDevelopmentStateHolder WithDateTo(DateTime dateTo);
    }
    public interface IDevelopmentStateHolder
    {
        ITrainingPlaceHolder WithDevelopmentState(DevelopmentState developmentState);
        ITrainingPlaceHolder WithDevelopmentState(int? developmentStateId);
    }
    public interface ITrainingPlaceHolder
    {
        ICorporationHolder WithTrainingPlace(TrainingPlace trainingPlace);
    }
    public interface ICorporationHolder
    {
        IDecisionDateHolder WithCorporation(Corporation corporation);
        IDecisionDateHolder WithCorporation(int? corporationId);
    }
    public interface IDecisionDateHolder
    {
        IBuild WithDecisionDate(DateTime decisionDate);
    }

    public interface IBuild
    {
        Training Biuld();
    }

}