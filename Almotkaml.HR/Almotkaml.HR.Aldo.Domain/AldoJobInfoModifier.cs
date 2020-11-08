using Almotkaml.HR.Domain.JobInfoFactory;

namespace Almotkaml.HR.Aldo.Domain
{
    public class AldoJobInfoModifier
    {
        public AldoJobInfoModifier(AldoJobInfo jobInfo)
        {
            JobInfo = jobInfo;
        }

        private AldoJobInfo JobInfo { get; }

        public JobInfoModifier JobClass(JobClass jobClass)
        {
            JobInfo.JobClass = jobClass;
            return new JobInfoModifier(JobInfo);
        }
    }
}