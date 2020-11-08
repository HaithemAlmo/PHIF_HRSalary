using Almotkaml.HR.Domain.ExtraworkFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Extrawork
    {
        internal Extrawork()
        {

        }
        public static IEmployeeIdHolder New()
        {
            return new ExtraworkBuilder();
        }
        public long ExtraworkId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public decimal TimeCount { get; internal set; }
        public string DecisionNumber { get; internal set; }
        public DateTime Date { get; internal set; }
        public DateTime DateFrom { get; internal set; }
        public DateTime DateTo { get; internal set; }

        public ExtraworkModifier Modify()
        {
            return new ExtraworkModifier(this);
        }
    }
}
