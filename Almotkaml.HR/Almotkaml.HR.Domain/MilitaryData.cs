using Almotkaml.HR.Domain.MilitaryDataFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class MilitaryData
    {
        public static IAdjectiveMilitaryHolder New()
        {
            return new MilitaryDataBuilder();
        }

        internal MilitaryData()
        {

        }
        internal MilitaryData(Employee employee)
        {
            Employee = employee;
        }
        public Employee Employee { get; set; }
        //public int MilitaryDataId { get; internal set; }
        //public int EmployeeId { get; internal set; }
        //public Employee Employee { get; internal set; }
        public AdjectiveMilitary AdjectiveMilitary { get; internal set; }
        public string MilitaryNumber { get; internal set; }
        public string Subunit { get; internal set; }
        public string Rank { get; internal set; }
        public DateTime? GranduationDate { get; internal set; }
        public string MotherUnit { get; internal set; }
        public string College { get; internal set; }

        public MilitaryDataModifier Modify()
        {
            return new MilitaryDataModifier(this);
        }

    }


}