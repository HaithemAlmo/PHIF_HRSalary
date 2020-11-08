using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Reports
{
    public class ManPowerReport
    {
        //ملاك فني
        public string AdjectiveEmployeeType { get; set; }
        public int PhDCount { get; set; }
        public int MasterCount { get; set; }
        public int DiplomaCount { get; set; }
        public int EngCount { get; set; }
        public int AssistantCount { get; set; }
        public int CraftsmanCount { get; set; }
        public int OperationalCount { get; set; }
        //ملاك إداري
        public int AdministrativeCount { get; set; }
        public int WriterAdmCount { get; set; }
        public int FinancialCount { get; set; }
        public int BookkeeperCount { get; set; }
        public int JuristCount { get; set; }
        //الخدمات العامة
        public int AlternateCount { get; set; }
        public int DailyTimeCount { get; set; }
        public int OccSafEngCount { get; set; }//مهندسون سلامة مهنية
        public int TechnicalSafEngCount { get; set; }//فني سلامة مهنية
        //الخدمات العامة الحرفية
        public int literalityEngCount { get; set; }//مهندسون الخدمات الحرفية
        public int AssistantlitCountCount { get; set; }//مساعد الخدمات الحرفية
        public int OperationallitCount { get; set; }//تشغيلي الخدمات الحرفية
        public int ServicesCount { get; set; }
        //الملاك من المدنيون و العسكريون
        public int OfficerCount { get; set; }
        public int WarrantOfficerCount { get; set; }
        public int SoldiersCount { get; set; }
        public int CMilitaryACount { get; set; }//مدنيون يتقاضون مرتباتهم من حسابات عسكرية
        public int CStandardACount { get; set; }//مدنيون يتقاضون مرتباتهم من وزارة المالية

    }
}
