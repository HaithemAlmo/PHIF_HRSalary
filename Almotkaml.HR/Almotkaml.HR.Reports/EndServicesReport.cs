using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Reports
{
     public class EndServicesReport
    {
        public string EmployeeName { get; set; }        //اسم الموظف
        public string NationalNumber { get; set; }      //الرقم الوطني
        public string Qualification { get; set; }       //الموهل العلمي
        public string JobTitle { get; set; }            //المسمى الوظيفي
        public string DecisionDate { get; set; }        //تاريخ انهاء الخدمة
        public string DecisionNumber { get; set; }      //رقم القرار
        public string WorkPlace { get; set; }           // مكان العمل
        public string Cause { get; set; }               // سبب انهاء الخدمة

    }
}
