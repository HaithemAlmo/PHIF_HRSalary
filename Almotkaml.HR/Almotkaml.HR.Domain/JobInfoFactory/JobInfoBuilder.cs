using System;

namespace Almotkaml.HR.Domain.EmployeeFactory
{
    public class EmployeeBuilder : IEmploymentValuesHolder
        , IDirectlyDateHolder, IDegreeHolder, IJobIdHolder, IJobNumberHolder, IJobNumberApprovedHolder
        , ICurrentSituationIdHolder, IUnitIdHolder, IDegreeNowHolder, IDateDegreeNowHolder
        , IDateMeritDegreeNowHolder, IBounsHolder, IDateBounsHolder, IDateMeritBounsHolder
        , IAdjectiveEmployeeIdHolder, IStaffingIdHolder, IBuild, INotesHolder
        , IClassificationOnWorkHolder, IClassificationOnSearchingHolder, ISalayClassificationHolder
        , IOldJobNumberHolder
    {

        internal EmployeeBuilder() { }
        private Employee Employee { get; } = new Employee();




        //public IEmploymentTypeHolder WithEmployeeId(int employeeId)
        //{
        //    Check.MoreThanZero(employeeId, nameof(employeeId));
        //    Employee.EmployeeId = employeeId;
        //    return this;
        //}

        //public IEmploymentTypeHolder WithEmployee(Employee employee)
        //{
        //    Check.NotNull(employee, nameof(employee));
        //    Employee.EmployeeId = employee.EmployeeId;
        //    Employee.Employee = employee;
        //    return this;
        //}

        //public IEmploymentValuesHolder WithEmploymentType(EmploymentType employmentType)
        //{
        //    Check.NotNull(employmentType, nameof(employmentType));
        //    Employee.EmploymentTypeId = employmentType.EmploymentTypeId;
        //    Employee.EmploymentType = employmentType;
        //    return this;
        //}

        //public IEmploymentValuesHolder WithEmploymentTypeId(int employmentTypeId)
        //{
        //    Employee.EmploymentTypeId = employmentTypeId;
        //    return this;
        //}

        public IDirectlyDateHolder WithEmploymentValues(EmploymentValues employmentValues)
        {
            Check.NotNull(employmentValues, nameof(employmentValues));
            Employee.EmploymentValues = employmentValues;
            return this;
        }

        public IDegreeHolder WithDirectlyDate(DateTime? directlyDate)
        {
            Employee.DirectlyDate = directlyDate;
            return this;
        }

        public IJobIdHolder WithDegree(int? degree, ClampDegree? clampDegree, SalayClassification? salayClassification)
        {
            if (salayClassification == SalayClassification.Default)
                Employee.Degree = degree;
            else
                Employee.Degree = (int?)clampDegree;
            return this;
        }

        public IJobNumberHolder WithJobId(int? jobId)
        {
            Employee.JobId = jobId;
            return this;
        }

        public IJobNumberHolder WithJob(Job job)
        {
            Check.NotNull(job, nameof(job));
            Employee.JobId = job.JobId;
            Employee.Job = job;
            return this;
        }

        public IJobNumberApprovedHolder WithJobNumber(int jobNumber)
        {
            Employee.JobNumber = jobNumber;
            return this;
        }

        public ICurrentSituationIdHolder WithJobNumberApproved(int? jobNumberApproved)
        {
            Employee.JobNumberApproved = jobNumberApproved;
            return this;
        }

        public IUnitIdHolder WithCurrentSituationId(int? currentSituationId)
        {
            Employee.CurrentSituationId = currentSituationId;
            return this;
        }

        public IUnitIdHolder WithCurrentSituation(CurrentSituation currentSituation)
        {
            Check.NotNull(currentSituation, nameof(currentSituation));
            Employee.CurrentSituationId = currentSituation.CurrentSituationId;
            Employee.CurrentSituation = currentSituation;
            return this;
        }

        //public IResolveResolutionDateHolder WithResolveResolutionNumber(string resolveResolutionNumber)
        //{
        //    Employee.ResolveResolutionNumber = resolveResolutionNumber;
        //    return this;
        //}

        //public IUnitIdHolder WithResolveResolutionDate(DateTime? resolveResolutionDate)
        //{
        //    Employee.ResolveResolutionDate = resolveResolutionDate;
        //    return this;
        //}

        public IDegreeNowHolder WithUnitId(int? unitId)
        {
            Employee.UnitId = unitId;
            return this;
        }

        public IDegreeNowHolder WithUnit(Unit unit)
        {
            Check.NotNull(unit, nameof(unit));
            Employee.UnitId = unit.UnitId;
            Employee.Unit = unit;
            return this;
        }

        public IDateDegreeNowHolder WithDegreeNow(int? degreeNow, ClampDegree? clampDegree
            , SalayClassification? salayClassification)
        {
            if (salayClassification == SalayClassification.Default)
                Employee.DegreeNow = degreeNow;
            else
                Employee.DegreeNow = (int?)clampDegree;
            return this;
        }

        public IDateDegreeNowHolder WithDegreeNow(int? degreeNow)
        {
            Employee.DegreeNow = degreeNow;
            return this;
        }

        public IDateMeritDegreeNowHolder WithDateDegreeNow(DateTime? dateDegreeNow)
        {
            Employee.DateDegreeNow = dateDegreeNow;
            return this;
        }

        public IBounsHolder WithDateMeritDegreeNow(DateTime? dateMeritDegreeNow)
        {
            Employee.DateMeritDegreeNow = dateMeritDegreeNow;
            return this;
        }

        public IDateBounsHolder WithBouns(int? bouns)
        {
            Employee.Bouns = bouns;
            return this;
        }

        public IDateMeritBounsHolder WithDateBouns(DateTime? dateBouns)
        {
            Employee.DateBouns = dateBouns;
            return this;
        }

        public IAdjectiveEmployeeIdHolder WithDateMeritBouns(DateTime? dateMeritBouns)
        {
            Employee.DateMeritBouns = dateMeritBouns;
            return this;
        }

        public IStaffingIdHolder WithAdjectiveEmployeeId(int? adjectiveEmployeeId)
        {
            Employee.AdjectiveEmployeeId = adjectiveEmployeeId;
            return this;
        }

        public IStaffingIdHolder WithAdjectiveEmployee(AdjectiveEmployee adjectiveEmployee)
        {
            Check.NotNull(adjectiveEmployee, nameof(adjectiveEmployee));
            Employee.AdjectiveEmployeeId = adjectiveEmployee.AdjectiveEmployeeId;
            Employee.AdjectiveEmployee = adjectiveEmployee;
            return this;
        }

        public INotesHolder WithStaffingId(int? staffingId)
        {
            Employee.StaffingId = staffingId;
            return this;
        }

        public INotesHolder WithStaffing(Staffing staffing)
        {
            Check.NotNull(staffing, nameof(staffing));
            Employee.StaffingId = staffing.StaffingId;
            Employee.Staffing = staffing;
            return this;
        }

        public IClassificationOnWorkHolder WithNotes(string notes)
        {
            Employee.Notes = notes;
            return this;
        }
        public IClassificationOnSearchingHolder WithClassificationOnWork(int? classificationOnWorkId)
        {
            Employee.ClassificationOnWorkId = classificationOnWorkId;
            return this;
        }

        public IClassificationOnSearchingHolder WithClassificationOnWork(ClassificationOnWork classificationOnWork)
        {
            Check.NotNull(classificationOnWork, nameof(classificationOnWork));
            Employee.ClassificationOnWorkId = classificationOnWork.ClassificationOnWorkId;
            Employee.ClassificationOnWork = classificationOnWork;
            return this;
        }

        public ISalayClassificationHolder WithClassificationOnSearching(int? classificationOnSearchingId)
        {
            Employee.ClassificationOnSearchingId = classificationOnSearchingId;
            return this;
        }

        public ISalayClassificationHolder WithClassificationOnSearching(ClassificationOnSearching classificationOnSearching)
        {
            Check.NotNull(classificationOnSearching, nameof(classificationOnSearching));
            Employee.ClassificationOnSearchingId = classificationOnSearching.ClassificationOnSearchingId;
            Employee.ClassificationOnSearching = classificationOnSearching;
            return this;
        }

        public IOldJobNumberHolder WithSalayClassification(SalayClassification? salayClassification)
        {
            Employee.SalayClassification = salayClassification;
            return this;
        }
        public IBuild WithOldJobNumber(string oldJobNumber)
        {
            Employee.OldJobNumber = oldJobNumber;
            return this;
        }
        //public IBuild WithJobClass(JobClass jobClass)
        //{
        //    Employee.JobClass = jobClass;
        //    return this;
        //}
        public Employee Biuld() => Employee;

    }

}