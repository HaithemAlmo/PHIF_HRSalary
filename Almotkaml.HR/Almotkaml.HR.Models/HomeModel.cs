namespace Almotkaml.HR.Models
{
    public class HomeModel
    {
        public bool HR { get; set; }
        public bool Counting { get; set; }
        public bool Salary { get; set; }
        public bool WareHouseGov { get; set; }
        public int Ischeck { get; set; }
        public int DeserveBouneshr { get; set; }

        public int EmployeesWithoutJobInfo { get; set; }
        public int EmployeesWithoutSalaryInfo { get; set; }
        public int DeserveBounes { get; set; }
        public int DeserveDegree { get; set; }
        public int InVacation { get; set; }
        public int AreAbsent { get; set; }
        public int HaveExtraWork { get; set; }
        public int SuspendedSalary { get; set; }
    }
}