using System;

namespace Almotkaml.HR.Domain.SituationResolveJobFactory
{
    public class SituationResolveJobBuilder : IEmployeeIdHolder, IDecisionNumberHolder, IDecisionDateHolder, IDegreeHolder, IBounHolder, IDegreeNowHolder, IBounNowHolder,
        IDateDegreeLastHolder, IBuild
    {

        internal SituationResolveJobBuilder() { }

        private SituationResolveJob SituationResolveJob { get; } = new SituationResolveJob();
        public SituationResolveJob Biuld()
        {
            return SituationResolveJob;
        }

        public IDegreeNowHolder WithBoun(int boun)
        {
            //Check.MoreThanZero(boun, nameof(boun));
            SituationResolveJob.Boun = boun;
            return this;
        }

        public IBuild WithBounNow(int bounNow)
        {
            //Check.MoreThanZero(bounNow, nameof(bounNow));
            SituationResolveJob.BounNow = bounNow;
            SituationResolveJob.Employee.JobInfo.Bouns = bounNow;
            return this;
        }

        public IDegreeHolder WithDecisionDate(DateTime decisionDate)
        {
            Check.NotNull(decisionDate, nameof(decisionDate));
            SituationResolveJob.DecisionDate = decisionDate;
            //SituationResolveJob.Employee.JobInfo.DateBouns = decisionDate;
            //SituationResolveJob.Employee.JobInfo.DateDegreeNow = decisionDate;
            return this;
        }

        public IDecisionDateHolder WithDecisionNumber(string decisionNumber)
        {
            //Check.NotNull(decisionNumber, nameof(decisionNumber));
            SituationResolveJob.DecisionNumber = decisionNumber;
            return this;
        }

        public IBounHolder WithDegree(int degree)
        {
            //Check.MoreThanZero(degree, nameof(degree));
            SituationResolveJob.Degree = degree;
            return this;
        }

        public IDateDegreeLastHolder WithDegreeNow(int degreeNow)
        {
            //Check.MoreThanZero(degreeNow, nameof(degreeNow));
            SituationResolveJob.DegreeNow = degreeNow;
            //SituationResolveJob.Employee.JobInfo.DegreeNow = degreeNow;
            return this;

        }
        public IBounNowHolder WithDateDegreeLast(DateTime dateDegreeLast)
        {
            //Check.NotNull(dateDegreeLast, nameof(dateDegreeLast));
            SituationResolveJob.DateDegreeLast = dateDegreeLast;
            return this;

        }

        public IDecisionNumberHolder WithEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            SituationResolveJob.Employee = employee;
            return this;
        }

        public IDecisionNumberHolder WithEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            SituationResolveJob.EmployeeId = employeeId;
            return this;
        }
    }
}
