using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Almotkaml.HR.Domain;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {

        private HrDbContext Context { get; }
        internal TrainingRepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public override Training Find(object id)
        {
            return Context.Trainings
                .Include(t => t.RequestedQualification)
                .Include(t => t.DevelopmentTypeD)
                .ThenInclude(t => t.DevelopmentTypeC)
                .ThenInclude(t => t.DevelopmentTypeB)
                .ThenInclude(t => t.DevelopmentTypeA)
                .Include(t => t.DevelopmentState)
                .Include(t => t.Corporation)
                .Include(t => t.TrainingDetails)
                .ThenInclude(t => t.Employee)
                .Include(t => t.City)
                .ThenInclude(c => c.Country)
                .FirstOrDefault(t => t.TrainingId == (int)id);
        }

        public override IEnumerable<Training> GetAll()
        {
            return Context.Trainings
                .Include(t => t.RequestedQualification)
                .Include(t => t.DevelopmentTypeD)
                .ThenInclude(t => t.DevelopmentTypeC)
                .ThenInclude(t => t.DevelopmentTypeB)
                .ThenInclude(t => t.DevelopmentTypeA)
                .Include(t => t.DevelopmentState)
                .Include(t => t.Corporation)
                .Include(t => t.TrainingDetails)
                .ThenInclude(t => t.Employee)
                .Include(t => t.City)
                .ThenInclude(c => c.Country);
        }

        public TrainingDetail FindDetail(int id)
        {
            return Context.TrainingDetails
                .Include(t => t.Training)
                .Include(t => t.Employee)
                .FirstOrDefault(t => t.TrainingDetailId == id);
        }

        public void RemoveDetail(TrainingDetail trainingDetail) => Context.TrainingDetails.Remove(trainingDetail);
    }
}