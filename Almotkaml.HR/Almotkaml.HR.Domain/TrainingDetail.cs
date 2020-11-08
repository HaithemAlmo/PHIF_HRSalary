namespace Almotkaml.HR.Domain
{
    public class TrainingDetail
    {
        public static TrainingDetail New(Training training, int employeeId)
        {
            Check.NotNull(training, nameof(training));
            Check.MoreThanZero(employeeId, nameof(employeeId));

            var trainingDetail = new TrainingDetail()
            {
                Training = training,
                EmployeeId = employeeId,
            };

            return trainingDetail;
        }
        public static TrainingDetail New(Training training, Employee employee)
        {
            Check.NotNull(training, nameof(training));
            Check.NotNull(employee, nameof(employee));

            var trainingDetail = new TrainingDetail()
            {
                EmployeeId = employee.EmployeeId,
                Training = training,
                Employee = employee
            };

            return trainingDetail;
        }

        private TrainingDetail()
        {
        }
        public int TrainingDetailId { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public void Modify(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));

            EmployeeId = employeeId;
        }
        public void Modify(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));

            EmployeeId = employee.EmployeeId;
            Employee = employee;
        }
    }
}