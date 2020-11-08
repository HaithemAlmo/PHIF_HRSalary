using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almotkaml.HR.Domain;

namespace Almotkaml.HR.EntityCore.Entities
{
   public class EmployeeTrainingCourse
    {
        public int EmployeeId { get; set; }
        public int TrainingCourseId { get; set; }

        public Employee Employee { get; set; }

        public TrainingCourse TrainingCourse { get; set; }

    }
}
