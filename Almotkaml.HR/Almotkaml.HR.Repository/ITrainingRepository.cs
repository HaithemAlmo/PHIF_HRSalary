using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ITrainingRepository : IRepository<Training>
    {
        TrainingDetail FindDetail(int id);
        void RemoveDetail(TrainingDetail trainingDetail);
    }
}