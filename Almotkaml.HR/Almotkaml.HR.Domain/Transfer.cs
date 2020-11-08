using Almotkaml.HR.Domain.TransferFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Transfer
    {
        internal Transfer()
        {

        }
        public static IEmployeeHolder New()
        {
            return new TransferBuilder();
        }
        public int TransferId { get; internal set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public JobTypeTransfer JobTypeTransfer { get; internal set; }
        public DateTime DateFrom { get; internal set; }
        public DateTime DateTo { get; internal set; }
        public string SideName { get; internal set; }
        public TransferModifier Modify()
        {
            return new TransferModifier(this);
        }

    }
}
