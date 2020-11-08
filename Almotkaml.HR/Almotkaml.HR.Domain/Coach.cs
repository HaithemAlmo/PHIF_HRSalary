namespace Almotkaml.HR.Domain
{
    public class Coach
    {
        public static Coach New(CoachType coachType, string name, int? employeeId, string phone, string email
                                , string note)
        {
            var coach = new Coach();
            if (coachType == CoachType.Inside)
            {
                coach.CoachType = coachType;
                coach.EmployeeId = employeeId;
                coach.Note = note;
                coach.Name = null;
            }
            else if (coachType == CoachType.Outside)
            {
                coach.CoachType = coachType;
                coach.Name = name;
                coach.Phone = phone;
                coach.Email = email;
                coach.Note = note;
                coach.Employee = null;
                coach.EmployeeId = null;
            }
            return coach;
        }
        public static Coach New(CoachType coachType, string name, Employee employee, string phone, string email
                                , string note)
        {
            var coach = new Coach();
            if (coachType == CoachType.Inside)
            {
                coach.CoachType = coachType;
                coach.EmployeeId = employee.EmployeeId;
                coach.Employee = employee;
                coach.Note = note;
                coach.Name = null;
            }
            else if (coachType == CoachType.Outside)
            {
                coach.CoachType = coachType;
                coach.Name = name;
                coach.Phone = phone;
                coach.Email = email;
                coach.Note = note;
                coach.Employee = null;
                coach.EmployeeId = null;
            }
            return coach;
        }
        public int CoachId { get; set; }
        public CoachType CoachType { get; set; }
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public void Modify(CoachType coachType, string name, int? employeeId, string phone, string email
                                , string note)
        {
            if (coachType == CoachType.Inside)
            {
                CoachType = coachType;
                EmployeeId = employeeId;
                Note = note;
                Name = null;
            }
            else if (coachType == CoachType.Outside)
            {
                CoachType = coachType;
                Name = name;
                Phone = phone;
                Email = email;
                Note = note;
                Employee = null;
                EmployeeId = null;
            }
        }
        public void Modify(CoachType coachType, string name, Employee employee, string phone, string email
                                , string note)
        {
            if (coachType == CoachType.Inside)
            {
                CoachType = coachType;
                EmployeeId = employee.EmployeeId;
                Employee = employee;
                Note = note;
                Name = null;
            }
            else if (coachType == CoachType.Outside)
            {
                CoachType = coachType;
                Name = name;
                Phone = phone;
                Email = email;
                Note = note;
                Employee = null;
                EmployeeId = null;
            }
        }
    }
}