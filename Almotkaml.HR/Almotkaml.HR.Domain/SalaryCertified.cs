using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Almotkaml.HR.Domain
{
    public class SalaryCertified
    {
        public int SalaryCertifiedID { get; set; }
        public int BankBranchId { get; private set; }
        //public int SalaryCertifiedNumber { get; set; }

        public int CheckNumber { get; set; }

        ///public int ClipordNumber { get; set; }

        public string Total { get; set; }
         //public BankBranch BankBranch { get; set; }

    }
}
