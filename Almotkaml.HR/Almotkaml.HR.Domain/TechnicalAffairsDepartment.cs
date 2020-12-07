using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Domain
{
    public class TechnicalAffairsDepartment
    {
        public long TechnicalAffairsDepartmentId { get; private set; }
        public int EntrantsAndReviewersId { get; internal set; }
        public EntrantsAndReviewers EntrantsAndReviewers { get; internal set; }
        public int MonthWork { get; internal set; }
        public int YearWork { get; internal set; }
        // مدخلين بيانات
        public int DataEntryCount { get; internal set; }
        public decimal DataEntryBalance { get; internal set; }

        //مراجعة اولية
        public int FirstReviewCount { get; internal set; }
        public decimal FirstReviewBalance { get; internal set; }

        // مراجعة ايواء
        public int AccommodationReviewCount { get; internal set; }
        public decimal AccommodationReviewBalance { get; internal set; }

        // مراجعة عيادات
        public int ClincReviewCount { get; internal set; }
        public decimal ClincReviewBalance { get; internal set; }

        public decimal TotalBalance { get; internal set; }
        public string Note { get; internal set; }

        // اقفال وتسديد الشهر
        public bool IsPaid { get; internal set; }

        //public ICollection<EntrantsAndReviewers > EntrantsAndReviewerss { get; set; } = new HashSet<EntrantsAndReviewers>();

        public static TechnicalAffairsDepartment New(int entrantsAndReviewersId, int monthWork, int yearWork, int dataEntryCount, decimal dataEntryBalance,
           int firstReviewCount, decimal firstReviewBalance, int accommodationReviewCount, decimal accommodationReviewBalance, int clincReviewCount,
            decimal clincReviewBalance, decimal totalBalance, string note, bool isPaid)
        {

            Check.MoreThanZero(entrantsAndReviewersId, nameof(entrantsAndReviewersId));
            Check.MoreThanZero(monthWork, nameof(monthWork));
            Check.MoreThanZero(yearWork, nameof(yearWork));

            var technicalAffairsDepartment = new TechnicalAffairsDepartment()
            {

                EntrantsAndReviewersId = entrantsAndReviewersId,
                MonthWork = monthWork,
                YearWork = yearWork,
                DataEntryCount = dataEntryCount,
                DataEntryBalance = dataEntryBalance,
                FirstReviewCount = firstReviewCount,
                FirstReviewBalance = firstReviewBalance,
                AccommodationReviewCount = accommodationReviewCount,
                AccommodationReviewBalance = accommodationReviewBalance,
                ClincReviewCount = clincReviewCount,
                ClincReviewBalance = clincReviewBalance,
                TotalBalance = totalBalance,
                Note = note,
                IsPaid = isPaid


            };


            return technicalAffairsDepartment;
        }
        public static TechnicalAffairsDepartment New(EntrantsAndReviewers entrantsAndReviewers, int monthWork, int yearWork, int dataEntryCount, decimal dataEntryBalance,
           int firstReviewCount, decimal firstReviewBalance, int accommodationReviewCount, decimal accommodationReviewBalance, int clincReviewCount,
            decimal clincReviewBalance, decimal totalBalance, string note, bool isPaid)
        {
            Check.MoreThanZero(monthWork, nameof(monthWork));
            Check.MoreThanZero(yearWork, nameof(yearWork));
            Check.NotNull(entrantsAndReviewers, nameof(entrantsAndReviewers));


            var technicalAffairsDepartment = new TechnicalAffairsDepartment()
            {

                EntrantsAndReviewers = entrantsAndReviewers,
                MonthWork = monthWork,
                YearWork = yearWork,
                DataEntryCount = dataEntryCount,
                DataEntryBalance = dataEntryBalance,
                FirstReviewCount = firstReviewCount,
                FirstReviewBalance = firstReviewBalance,
                AccommodationReviewCount = accommodationReviewCount,
                AccommodationReviewBalance = accommodationReviewBalance,
                ClincReviewCount = clincReviewCount,
                ClincReviewBalance = clincReviewBalance,
                TotalBalance = totalBalance,
                Note = note,
                IsPaid = isPaid
            };


            return technicalAffairsDepartment;
        }

        public void Modify(int entrantsAndReviewersId, int monthWork, int yearWork, int dataEntryCount, decimal dataEntryBalance,
           int firstReviewCount, decimal firstReviewBalance, int accommodationReviewCount, decimal accommodationReviewBalance, int clincReviewCount,
            decimal clincReviewBalance, decimal totalBalance, string note, bool isPaid)
        {
            Check.MoreThanZero(monthWork, nameof(monthWork));
            Check.MoreThanZero(yearWork, nameof(yearWork));

            //Check.MoreThanZero(entrantsAndReviewersId, nameof(entrantsAndReviewersId));

            EntrantsAndReviewersId = entrantsAndReviewersId;
            EntrantsAndReviewers = null;
            MonthWork = monthWork;
            YearWork = yearWork;
            DataEntryCount = dataEntryCount;
            DataEntryBalance = dataEntryBalance;
            FirstReviewCount = firstReviewCount;
            FirstReviewBalance = firstReviewBalance;
            AccommodationReviewCount = accommodationReviewCount;
            AccommodationReviewBalance = accommodationReviewBalance;
            ClincReviewCount = clincReviewCount;
            ClincReviewBalance = clincReviewBalance;
            TotalBalance = totalBalance;
            Note = note;
            IsPaid = isPaid;


        }

        public void Modify(EntrantsAndReviewers entrantsAndReviewers, int monthWork, int yearWork, int dataEntryCount, decimal dataEntryBalance,
           int firstReviewCount, decimal firstReviewBalance, int accommodationReviewCount, decimal accommodationReviewBalance, int clincReviewCount,
            decimal clincReviewBalance, decimal totalBalance, string note, bool isPaid)
        {
            Check.MoreThanZero(monthWork, nameof(monthWork));
            Check.MoreThanZero(yearWork, nameof(yearWork));

            EntrantsAndReviewers = entrantsAndReviewers;
            MonthWork = monthWork;
            YearWork = yearWork;
            DataEntryCount = dataEntryCount;
            DataEntryBalance = dataEntryBalance;
            FirstReviewCount = firstReviewCount;
            FirstReviewBalance = firstReviewBalance;
            AccommodationReviewCount = accommodationReviewCount;
            AccommodationReviewBalance = accommodationReviewBalance;
            ClincReviewCount = clincReviewCount;
            ClincReviewBalance = clincReviewBalance;
            TotalBalance = totalBalance;
            Note = note;
            IsPaid = isPaid;
        }


    }
}
