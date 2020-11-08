using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Reports
{
    public class AbstractClipboardBanking
    {
        // add by ali alherbade 27-05-2019
        //تقرير ملخص الحوافظ
        public string BankBranchName { get; set; }
        public int BankBranchId { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public decimal Value { get; set; }
        public int TotalSalary { get; set; }//عدد المرتبات
    }
}
