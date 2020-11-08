using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class DevelopmentTypeARepository : Repository<DevelopmentTypeA>, IDevelopmentTypeARepository
    {
        private HrDbContext Context { get; }

        internal DevelopmentTypeARepository(HrDbContext context) : base(context)
        {
            Context = context;
        }

        public bool NameIsExisted(string name) => Context.DevelopmentTypeAs
            .Any(e => e.Name == name);

        public bool NameIsExisted(string name, int idToExcept) => Context.DevelopmentTypeAs
            .Any(e => e.Name == name && e.DevelopmentTypeAId != idToExcept);

        public IEnumerable<DevelopmentTypeA> DevelopmentTypeAWithTrainingType(TrainingType trainingType)
                 => Context.DevelopmentTypeAs
                    .Where(e => e.TrainingType == trainingType);
    }
}