using System;

namespace Almotkaml.HR.Domain.JobInfoFactory
{
    public class JobInfoModifier
    {
        public JobInfoModifier(JobInfo jobInfo)
        {
            JobInfo = jobInfo;
        }
        protected JobInfo JobInfo { get; }

        public JobInfoModifier EmploymentValues(EmploymentValues employmentValues)
        {
            Check.NotNull(employmentValues, nameof(employmentValues));
            JobInfo.EmploymentValues = employmentValues;
            return this;
        }

        public JobInfoModifier DirectlyDate(DateTime? directlyDate)
        {
            JobInfo.DirectlyDate = directlyDate;
            return this;
        }

        public JobInfoModifier Degree(int? degree, ClampDegree? clampDegree, SalayClassification? salayClassification)
        {
            if (salayClassification == HR.SalayClassification.Default)
                JobInfo.Degree = degree;
            else if (salayClassification == HR.SalayClassification.Clamp)
                JobInfo.Degree = (int?)clampDegree;
            return this;
        }
        public JobInfoModifier Job(int? jobId)
        {
            JobInfo.JobId = jobId;
            return this;
        }

        public JobInfoModifier Job(Job job)
        {
            Check.NotNull(job, nameof(job));
            JobInfo.JobId = job.JobId;
            JobInfo.Job = job;
            return this;
        }

        public JobInfoModifier JobNumber(int jobNumber)
        {
            JobInfo.JobNumber =  jobNumber;
            return this;
        }

        public JobInfoModifier JobNumberLIC(int? jobNumberLIC)
        {
            JobInfo.JobNumberLIC = jobNumberLIC;
            return this;
        }

        public JobInfoModifier JobNumberApproved(int? jobNumberApproved)
        {
            JobInfo.JobNumberApproved = jobNumberApproved;
            return this;
        }

        public JobInfoModifier CurrentSituation(int? currentSituationId)
        {
            JobInfo.CurrentSituationId = currentSituationId;
            return this;
        }

        public JobInfoModifier CurrentSituation(CurrentSituation currentSituation)
        {
            Check.NotNull(currentSituation, nameof(currentSituation));
            JobInfo.CurrentSituationId = currentSituation.CurrentSituationId;
            JobInfo.CurrentSituation = currentSituation;
            return this;
        }

        public JobInfoModifier Unit(int? unitId)
        {
            JobInfo.UnitId = unitId;
            return this;
        }

        public JobInfoModifier Unit(Unit unit)
        {
            Check.NotNull(unit, nameof(unit));
            JobInfo.UnitId = unit.UnitId;
            JobInfo.Unit = unit;
            return this;
        }

        public JobInfoModifier DegreeNow(int? degreeNow, ClampDegree? clampDegree
            , SalayClassification? salayClassification)
        {
            
            if (salayClassification == HR.SalayClassification.Default)
                JobInfo.DegreeNow = degreeNow;
            else if (salayClassification == HR.SalayClassification.Clamp)
                JobInfo.DegreeNow = (int?)clampDegree;
            return this;
        }
        public JobInfoModifier DegreeNow(int? degreeNow)
        {
            JobInfo.DegreeNow = degreeNow;
            return this;
        }

        public JobInfoModifier DateDegreeNow(DateTime? dateDegreeNow)
        {
            JobInfo.DateDegreeNow = dateDegreeNow;
            return this;
        }

        public JobInfoModifier DateMeritDegreeNow(DateTime? dateMeritDegreeNow)
        {
            JobInfo.DateMeritDegreeNow = dateMeritDegreeNow;
            return this;
        }

        public JobInfoModifier Bouns(int? bouns)
        {
            JobInfo.Bouns = bouns;
            return this;
        }

        public JobInfoModifier Bounshr(int? bouns)
        {
            JobInfo.Bounshr = bouns;
            return this;
        }

        public JobInfoModifier DateBouns(DateTime? dateBouns)
        {
            JobInfo.DateBouns = dateBouns;
            return this;
        }

        public JobInfoModifier DateMeritBouns(DateTime? dateMeritBouns)
        {
            JobInfo.DateMeritBouns = dateMeritBouns;
            return this;
        }

        public JobInfoModifier AdjectiveEmployee(int? adjectiveEmployeeId)
        {
            if (adjectiveEmployeeId == 0)
                adjectiveEmployeeId = null;

            JobInfo.AdjectiveEmployeeId = adjectiveEmployeeId;
            return this;
        }

        public JobInfoModifier AdjectiveEmployee(AdjectiveEmployee adjectiveEmployee)
        {
            JobInfo.AdjectiveEmployeeId = adjectiveEmployee?.AdjectiveEmployeeId;
            JobInfo.AdjectiveEmployee = adjectiveEmployee;
            return this;
        }

        public JobInfoModifier Staffing(int? staffingId)
        {
            if (staffingId == 0)
                staffingId = null;

            JobInfo.StaffingId = staffingId;
            return this;
        }

        public JobInfoModifier Staffing(Staffing staffing)
        {
            JobInfo.StaffingId = staffing?.StaffingId;
            JobInfo.Staffing = staffing;
            return this;
        }
        public JobInfoModifier StaffingClassification(int? staffingClassificationId)
        {
            if (staffingClassificationId == 0)
                staffingClassificationId = null;

            JobInfo.StaffingClassificationId = staffingClassificationId;
            return this;
        }
        public JobInfoModifier StaffingClassification(StaffingClassification staffingClassification)
        {
            JobInfo.StaffingClassificationId = staffingClassification?.StaffingClassificationId;
            JobInfo.StaffingClassification = staffingClassification;
            return this;
        }
        //public JobInfoModifier FinancialData(FinancialData financialData)
        //{
        //    Check.NotNull(financialData, nameof(financialData));
        //    JobInfo.FinancialData = financialData;
        //    return this;
        //}

        public JobInfoModifier JobType(JobType jobType)
        {
            JobInfo.JobType = jobType;
            return this;
        }
        public JobInfoModifier VacationBalance(int? vacationBalance)
        {
            JobInfo.VacationBalance = vacationBalance;
            return this;
        }

        public JobInfoModifier Notes(string notes)
        {
            JobInfo.Notes = notes;
            return this;
        }
        public JobInfoModifier ClassificationOnWork(int? classificationOnWorkId)
        {
            JobInfo.ClassificationOnWorkId = classificationOnWorkId;
            return this;
        }

        public JobInfoModifier ClassificationOnWork(ClassificationOnWork classificationOnWork)
        {
            Check.NotNull(classificationOnWork, nameof(classificationOnWork));
            JobInfo.ClassificationOnWorkId = classificationOnWork.ClassificationOnWorkId;
            JobInfo.ClassificationOnWork = classificationOnWork;
            return this;
        }

        public JobInfoModifier ClassificationOnSearching(int? classificationOnSearchingId)
        {
            JobInfo.ClassificationOnSearchingId = classificationOnSearchingId;
            return this;
        }

        public JobInfoModifier ClassificationOnSearching(ClassificationOnSearching classificationOnSearching)
        {
            Check.NotNull(classificationOnSearching, nameof(classificationOnSearching));
            JobInfo.ClassificationOnSearchingId = classificationOnSearching.ClassificationOnSearchingId;
            JobInfo.ClassificationOnSearching = classificationOnSearching;
            return this;
        }
        public JobInfoModifier SalayClassification(SalayClassification? salayClassification)
        {
            JobInfo.SalayClassification = salayClassification;
            return this;
        }
        public JobInfoModifier WithJobClass(int? jobClass)
        {
            JobInfo.JobClassValu = jobClass;
            return this;
        }
        public JobInfoModifier WithSituons(SiutiontnType Situons)
        {
            JobInfo.Situons = Situons;
            return this;
        }
        public JobInfoModifier WithSituionsNumber(int? SituionsNumber)
        {
            JobInfo.SituionsNumber = SituionsNumber;
            return this;
        }
        public JobInfoModifier Redirection(Redirection redirection, string redirectionNote)
        {
            if (redirection == HR.Redirection.Yes)
            {
                JobInfo.Redirection = redirection;
                JobInfo.RedirectionNote = redirectionNote;
            }
            else
            {
                JobInfo.Redirection = redirection;
                JobInfo.RedirectionNote = null;
            }

            return this;
        }
        public JobInfoModifier OldJobNumber(string oldJobNumber)
        {
            JobInfo.OldJobNumber = oldJobNumber;
            return this;
        }
        public JobInfoModifier HealthStatus(string healthStatus)
        {
            JobInfo.HealthStatus = healthStatus;
            return this;
        }
        public JobInfoModifier CurrentClassification(string currentClassification)
        {
            JobInfo.CurrentClassification = currentClassification;
            return this;
        }
        public JobInfoModifier Adjective(Adjective adjective)
        {
            JobInfo.Adjective = adjective;
            return this;
        }
        public JobInfoModifier LastBouns(DateTime lastbouns)
        {
            JobInfo.DateBounsLast = lastbouns;
            return this;
        }
        public JobInfoModifier DateBounshr(DateTime? dateBounshr)
        {
            JobInfo.DateBounshr = dateBounshr;
            return this;
        }
        public JobInfoModifier LeaderType(LeaderType? LeaderType)
        {
            JobInfo.leaderType = LeaderType;
            return this;
        }

        public JobInfo Confirm()
        {
            return JobInfo;
        }
    }
}