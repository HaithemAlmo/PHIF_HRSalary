using System;

namespace Almotkaml.HR.Domain.SituationResolveJobFactory
{
    public class SituationResolveJobModifier
    {

        internal SituationResolveJobModifier(SituationResolveJob situationResolveJob)
        {
            SituationResolveJob = situationResolveJob;

        }

        private SituationResolveJob SituationResolveJob { get; }

        public SituationResolveJob Confirm()
        {
            return SituationResolveJob;
        }

        //public SituationResolveJobModifier Boun(int boun)
        //{
        //    Check.MoreThanZero(boun, nameof(boun));
        //    SituationResolveJob.Boun = boun;
        //    return this;
        //}

        public SituationResolveJobModifier BounNow(int bounNow)
        {
            ////Check.MoreThanZero(bounNow, nameof(bounNow));
            SituationResolveJob.BounNow = bounNow;
            SituationResolveJob.Employee.JobInfo.Bouns = bounNow;
            return this;
        }

        public SituationResolveJobModifier DecisionDate(DateTime decisionDate)
        {
            //Check.NotNull(decisionDate, nameof(decisionDate));
            SituationResolveJob.DecisionDate = decisionDate;
            SituationResolveJob.Employee.JobInfo.DateBouns = decisionDate;
            SituationResolveJob.Employee.JobInfo.DateDegreeNow = decisionDate;
            return this;
        }

        public SituationResolveJobModifier DecisionNumber(string decisionNumber)
        {
            //Check.NotNull(decisionNumber, nameof(decisionNumber));
            SituationResolveJob.DecisionNumber = decisionNumber;
            return this;
        }

        //public SituationResolveJobModifier Degree(int degree)
        //{
        //    Check.MoreThanZero(degree, nameof(degree));
        //    SituationResolveJob.Degree = degree;
        //    return this;
        //}

        public SituationResolveJobModifier DegreeNow(int degreeNow)
        {
            //Check.MoreThanZero(degreeNow, nameof(degreeNow));
            SituationResolveJob.DegreeNow = degreeNow;
            SituationResolveJob.Employee.JobInfo.DegreeNow = degreeNow;
            return this;

        }

        public SituationResolveJobModifier Employee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));
            SituationResolveJob.Employee = employee;
            return this;
        }

        public SituationResolveJobModifier Employee(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));
            SituationResolveJob.EmployeeId = employeeId;
            return this;
        }

        //public SituationResolveJobModifier DateDegreeLast(DateTime dateDegreeLast)
        //{
        //    Check.NotNull(dateDegreeLast, nameof(dateDegreeLast));
        //    SituationResolveJob.DateDegreeLast = dateDegreeLast;
        //    return this;

        //}
    }
}
