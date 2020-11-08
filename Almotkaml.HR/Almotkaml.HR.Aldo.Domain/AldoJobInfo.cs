using Almotkaml.HR.Domain;

namespace Almotkaml.HR.Aldo.Domain
{
    public class AldoJobInfo : JobInfo
    {
        public JobClass JobClass { get; internal set; }

        public AldoJobInfoModifier AldoModify()
        {
            return new AldoJobInfoModifier(this);
        }
    }
}
