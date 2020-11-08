using System;

namespace Almotkaml.HR.Domain.JobInfoFactory
{
    //public interface IEmployeeIdHolder
    //{
    //    IEmploymentTypeHolder WithEmployeeId(int employeeId);
    //    IEmploymentTypeHolder WithEmployee(Employee employee);
    //}

    //public interface IEmploymentTypeHolder
    //{
    //    IEmploymentValuesHolder WithEmploymentType(EmploymentType employmentType);
    //    IEmploymentValuesHolder WithEmploymentTypeId(int employmentTypeId);
    //}

    public interface IEmploymentValuesHolder
    {
        IDirectlyDateHolder WithEmploymentValues(EmploymentValues employmentValues);
    }
    public interface IDirectlyDateHolder
    {
        IDegreeHolder WithDirectlyDate(DateTime? directlyDate);
    }
    public interface IDegreeHolder
    {
        IJobIdHolder WithDegree(int? degree, ClampDegree? clampDegree, SalayClassification? salayClassification);
    }
    public interface IJobIdHolder
    {
        IJobNumberHolder WithJobId(int? jobId);
        IJobNumberHolder WithJob(Job job);
    }

    public interface IJobNumberHolder
    {
        IJobNumberApprovedHolder WithJobNumber(int jobNumber);
    }
    public interface IJobNumberApprovedHolder
    {
        ICurrentSituationIdHolder WithJobNumberApproved(int? jobNumberApproved);
    }
    //public interface ISituationResolveJobHolder
    //{
    //    ICurrentSituationIdHolder WithSituationResolveJob(SituationResolveJob situationResolveJob);
    //}
    public interface ICurrentSituationIdHolder
    {
        IUnitIdHolder WithCurrentSituationId(int? currentSituationId);
        IUnitIdHolder WithCurrentSituation(CurrentSituation currentSituation);
    }

    //public interface IResolveResolutionNumberHolder
    //{
    //    IResolveResolutionDateHolder WithResolveResolutionNumber(string resolveResolutionNumber);
    //}
    //public interface IResolveResolutionDateHolder
    //{
    //    IUnitIdHolder WithResolveResolutionDate(DateTime? resolveResolutionDate);
    //}
    public interface IUnitIdHolder
    {
        IDegreeNowHolder WithUnitId(int? unitId);
        IDegreeNowHolder WithUnit(Unit unit);
    }

    public interface IDegreeNowHolder
    {
        IDateDegreeNowHolder WithDegreeNow(int? degreeNow, ClampDegree? clampDegree
            , SalayClassification? salayClassification);
        IDateDegreeNowHolder WithDegreeNow(int? degreeNow);
    }
    public interface IDateDegreeNowHolder
    {
        IDateMeritDegreeNowHolder WithDateDegreeNow(DateTime? dateDegreeNow);
    }
    public interface IDateMeritDegreeNowHolder
    {
        IBounsHolder WithDateMeritDegreeNow(DateTime? dateMeritDegreeNow);
    }
    public interface IBounsHolder
    {
        IDateBounsHolder WithBouns(int? bouns);
    }
    public interface IDateBounsHolder
    {
        IDateMeritBounsHolder WithDateBouns(DateTime? dateBouns);
    }
    public interface IDateMeritBounsHolder
    {
        IAdjectiveEmployeeIdHolder WithDateMeritBouns(DateTime? dateMeritBouns);
    }
    public interface IAdjectiveEmployeeIdHolder
    {
        IStaffingIdHolder WithAdjectiveEmployeeId(int? adjectiveEmployeeId);
        IStaffingIdHolder WithAdjectiveEmployee(AdjectiveEmployee adjectiveEmployee);
    }

    public interface IStaffingIdHolder
    {
        INotesHolder WithStaffingId(int? staffingId);
        INotesHolder WithStaffing(Staffing staffing);
    }
    public interface INotesHolder
    {
        IClassificationOnWorkHolder WithNotes(string notes);
    }
    public interface IClassificationOnWorkHolder
    {
        IClassificationOnSearchingHolder WithClassificationOnWork(int? classificationOnWorkId);
        IClassificationOnSearchingHolder WithClassificationOnWork(ClassificationOnWork classificationOnWork);
    }
    public interface IClassificationOnSearchingHolder
    {
        ISalayClassificationHolder WithClassificationOnSearching(int? classificationOnSearchingId);
        ISalayClassificationHolder WithClassificationOnSearching(ClassificationOnSearching classificationOnSearching);
    }

    public interface ISalayClassificationHolder
    {
        IOldJobNumberHolder WithSalayClassification(SalayClassification? salayClassification);
    }
    public interface IOldJobNumberHolder
    {
        IBuild WithOldJobNumber(string oldJobNumber);
    }
    //public interface IJobClassHolder
    //{
    //    IBuild WithJobClass(JobClass jobClass);
    //}

    public interface IBuild
    {
        JobInfo Biuld();
    }
}