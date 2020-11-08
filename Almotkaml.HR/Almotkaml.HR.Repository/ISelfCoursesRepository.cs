using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISelfCoursesRepository : IRepository<SelfCourses>
    {
        IEnumerable<SelfCourses> GetSelfCoursesesWithEmployee();
        IEnumerable<SelfCourses> GetSelfCourseByEmployeeId(int employeeId);

    }
}
