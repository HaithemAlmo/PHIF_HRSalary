using Almotkaml.HR.Models;

namespace Almotkaml.HR.Abstraction
{
    public interface ITrainingBusiness
    {
        TrainingIndexModel Index();
        TrainingFormModel Prepare();
        TrainingFormModel Find(int id);
        void Refresh(TrainingFormModel model);
        bool Save(TrainingFormModel model);
        bool SelectDetail(TrainingFormModel model);
        bool Delete(TrainingFormModel model);
        bool DeleteDetail(TrainingFormModel model);

    }
}