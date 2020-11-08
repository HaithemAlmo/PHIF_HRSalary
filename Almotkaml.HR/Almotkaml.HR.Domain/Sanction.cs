using Almotkaml.HR.Domain.SanctionFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Sanction
    {
        public static ISanctionTypeIdHolder New()
        {
            return new SanctionBuilder();
        }


        internal Sanction()
        {

        }
        public int SanctionId { get; internal set; }
        public int SanctionTypeId { get; internal set; }
        public SanctionType SanctionType { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Cause { get; internal set; }
        public int SanctionDay { get; internal set; }
        public int DeductionMonth { get; internal set; }
        public int DeductionYear { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public SanctionModifier Modify()
        {
            return new SanctionModifier(this);
        }

    }
}