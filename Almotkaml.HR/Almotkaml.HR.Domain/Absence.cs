using Almotkaml.HR.Domain.AbsenceFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Absence
    {
        public static IAbsenceTypeHolder New()
        {
            return new AbsenceBuilder();
        }

        internal Absence()
        {

        }

        public int AbsenceId { get; internal set; }
        public int AbsenceDay { get;  set; }

        public AbsenceType AbsenceType { get; internal set; }
        public DateTime Date { get; internal set; }
        public int DeductionMonth { get; internal set; }
        public int DeductionYear { get; internal set; }
        public string Note { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public AbsenceModifier Modify()
        {
            return new AbsenceModifier(this);
        }

    }


}

