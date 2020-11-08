using Almotkaml.HR.Domain.EndServicesFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class EndServices
    {
        internal EndServices()
        {

        }
        //public static IEmployeeId New()
        //{
        //    return new EndServicesBuilder();
        //}
        public int EndServicesId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public CauseOfEndService CauseOfEndService { get; internal set; }
        public string Cause { get; internal set; }
        public string DecisionNumber { get; internal set; }
        public DateTime DecisionDate { get; internal set; }
        
        public EndServicesModifier Modify()
        {
            return new EndServicesModifier(this);
        }

    }
}
