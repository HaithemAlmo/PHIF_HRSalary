using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class TrainingCourseRepository : Repository<TrainingCourse>, ITrainingCourseRepository
    {
        private HrDbContext Context { get; }

        internal TrainingCourseRepository(HrDbContext context)
            : base(context)
        {
            Context = context;
        }



    }
}