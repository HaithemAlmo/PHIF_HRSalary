using Almotkaml.HR.Domain.SituationResolveJobFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class SituationResolveJob
    {
        public static IEmployeeIdHolder New()
        {
            return new SituationResolveJobBuilder();
        }
        internal SituationResolveJob() { }
        public int SituationResolveJobId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime? DateDegreeLast { get; set; }
        public DateTime? DateBounLast { get; set; }
        public int? Degree { get; set; }
        public int? Boun { get; set; }
        public int DegreeNow { get; set; }
        public int BounNow { get; set; }
        public int? JobLastId { get; set; }
        public Job JobLast { get; set; }
        public int? JobNowId { get; set; }
        public Job JobNow { get; set; }
        public string Note { get; set; }
        public SituationResolveJobModifier Modify()
        {
            return new SituationResolveJobModifier(this);
        }

        public void Modify(int degreeNow, int bounNow, string decisionNumber, DateTime decisionDate, int jobNowId)
        {
            if (Employee?.JobInfo == null)
                throw new NullReferenceException("empolyee or jobInfo null");

            DecisionNumber = decisionNumber;
            DecisionDate = decisionDate;
            DegreeNow = degreeNow;
            BounNow = bounNow;
            Employee.JobInfo.Bouns = bounNow;
            Employee.JobInfo.DegreeNow = degreeNow;
            Employee.JobInfo.DateDegreeNow = decisionDate;
            Employee.JobInfo.DateBouns = decisionDate;
            Employee.JobInfo.JobId = jobNowId;
        }

    }

}