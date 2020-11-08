using System.Collections.Generic;

namespace Almotkaml.HR.Models
{
    public class BanksSettlementReportModel
    {
        public IEnumerable<BanksSettlementReportGridRow> Grid { get; set; } =
            new HashSet<BanksSettlementReportGridRow>();
    }
    public class BanksSettlementReportGridRow
    {
        public string BankName { get; set; }
        public decimal Value { get; set; }
        public string BondNumber { get; set; }
    }

}