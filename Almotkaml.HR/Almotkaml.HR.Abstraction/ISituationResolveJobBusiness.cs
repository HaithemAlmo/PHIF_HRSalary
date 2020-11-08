using Almotkaml.Business;
using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ISituationResolveJobBusiness : ISimpleBusiness<SituationResolveJobModel, int>
    {
        bool Create(SituationResolveJobModel situationResolveJob, int v);
    }
}
