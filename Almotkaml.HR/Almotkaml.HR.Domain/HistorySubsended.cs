using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Domain
{
  public   class HistorySubsended
    {
        public static HistorySubsended New(int? id, string note, string isclosemessage, string date, string jobnumber, string salaryid,bool subsended, bool isclose,decimal netSalray, string monthdate, bool Isclipord, decimal securtey, decimal solidrtyFound, decimal absense, int absenseDay,decimal jeihad)
        {

            var historey = new HistorySubsended()
            {
                HistorySubsendedNote = note,
                DateSubsended = date,
                EmployeeId = id,
                iSCloseMessage = isclosemessage,
                JoubNumber = jobnumber,
                SalaryID=salaryid,
                ISSubsended=subsended,
            IsClose = isclose,
            NetSalray=netSalray,
            MonthDate=monthdate,
            IsClipord = Isclipord,
            AbsenceDays=absenseDay,
    Absence = absense,

            jihad = jeihad,
            SocialSecurityFundBondNumber=securtey,
            SolidarityFundBondNumber=solidrtyFound

        };


            return historey;
        }
        public void ModifySubsended(int? id, string note, string isclosemessage, string date, string jobnumber, string salaryid, bool subsended,bool isclose,decimal netSalray,string monthdate,bool Isclipord, decimal securtey, decimal solidrtyFound, decimal absense, int absenseDay, decimal jeihad)
        {
            HistorySubsendedNote = note;
            DateSubsended = date;
            EmployeeId = id;
            iSCloseMessage = isclosemessage;
            JoubNumber = jobnumber;
            SalaryID = salaryid;
            ISSubsended = subsended;
            IsClose = isclose;
            NetSalray = netSalray;
            MonthDate = monthdate;
            IsClipord = Isclipord;
            AbsenceDays = absenseDay;
            Absence = absense;
            jihad = jeihad;
            SocialSecurityFundBondNumber = securtey;
            SolidarityFundBondNumber = solidrtyFound;


        }
        public decimal employeSharea { get; set; }
        public decimal jihad { get; set; }
        public decimal Total { get; set; }
        public decimal FinalSalary { get; set; }
        public decimal subject { get; set; }

        public decimal SolidarityFundBondNumber { get;  set; }
        public decimal SocialSecurityFundBondNumber { get;  set; }
        public int AbsenceDays { get;  set; }
        public decimal Absence { get; set; }

        public int HistorySubsendedID { get; set; }
        public string HistorySubsendedNote { get; set; }
        public string iSCloseMessage{ get; set; }
        public int? EmployeeId { get; set; }
        public string JoubNumber { get; set; }
        public string SalaryID { get; set; }
        public bool ISSubsended { get; set; }
        public bool IsClose { get; set; }
        public decimal NetSalray { get; set; }
        public string MonthDate { get; set; }
        public bool IsClipord { get; set; }

        public string DateSubsended { get; set; }
       
        
    }
}
