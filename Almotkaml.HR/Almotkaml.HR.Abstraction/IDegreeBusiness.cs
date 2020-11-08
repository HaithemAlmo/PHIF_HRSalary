using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface IDegreeBusiness
    {
        DegreeModel Prepare();
        bool Submit(DegreeModel model);
        bool Submit(JobInfoDegreeModel model, int type);
        bool Cancel(DegreeModel model);
    }
}