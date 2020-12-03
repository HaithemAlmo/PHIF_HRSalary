using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Domain
{
    public  class TechnicalAffairsDepartment
    {
        public long TechnicalAffairsDepartmentId { get; private set; }
        public int EntrantsAndReviewersId { get; internal set; }
        public EntrantsAndReviewers EntrantsAndReviewers { get; internal set; }
        public int MonthWork { get; internal set; }
        public int YearWork { get; internal set; }
        // مدخلين بيانات
        public int DataEntryCount { get; internal set; }
        public bool DataEntryDemand { get; internal set; }
        public bool DataEntryBayan { get; internal set; }

        //مراجعة اولية
        public int FirstReviewCount { get; internal set; }
        public bool FirstReviewDemand { get; internal set; }
        public bool FirstReviewBayan { get; internal set; }

        // مراجعة ايواء
        public int AccommodationReviewCount { get; internal set; }
        public bool AccommodationReviewDemand { get; internal set; }
        public bool AccommodationReviewBayan { get; internal set; }

        // مراجعة عيادات
        public int ClincReviewCount { get; internal set; }
        public bool ClincReviewDemand { get; internal set; }
        public bool ClincReviewBayan { get; internal set; }

        // التصحيح
        public bool IsCorrect { get; internal set; }
        public bool IsNotCorrect { get; internal set; }
        public int CorrectCount { get; internal set; }

    }
}
