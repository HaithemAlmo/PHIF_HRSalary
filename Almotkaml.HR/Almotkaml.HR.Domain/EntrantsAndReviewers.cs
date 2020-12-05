using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Domain
{
   public  class EntrantsAndReviewers
    {

        public int EntrantsAndReviewersId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
        public string Note { get; set; }
        public EntrantsAndReviewersType EntrantsAndReviewersType { get; set; }
        public ICollection<TechnicalAffairsDepartment> TechnicalAffairsDepartment { get; set; } = new HashSet<TechnicalAffairsDepartment>();


        public static EntrantsAndReviewers New( int employeeNumber, string employeeName, string nationalNumber,Gender gender, string phone, string email, DateTime? startDate
                         , string note , EntrantsAndReviewersType EntrantsAndReviewersType)
        {
            var entrantsAndReviewers = new EntrantsAndReviewers();

            
                entrantsAndReviewers.EmployeeNumber = employeeNumber;
                entrantsAndReviewers.EmployeeName = employeeName;
                entrantsAndReviewers.NationalNumber = nationalNumber;
                entrantsAndReviewers.Gender = gender;
                entrantsAndReviewers.Phone = phone;
                entrantsAndReviewers.Email = email;
                entrantsAndReviewers.StartDate = startDate;
                entrantsAndReviewers.Note = note;
                entrantsAndReviewers.EntrantsAndReviewersType = EntrantsAndReviewersType;



            return entrantsAndReviewers;
        }

        public void Modify(int employeeNumber, string employeeName, string nationalNumber, Gender gender, string phone, string email, DateTime? startDate
                   , string note,EntrantsAndReviewersType entrantsAndReviewersType)
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            NationalNumber = nationalNumber;
            Gender = gender;
            Phone = phone;
            Email = email;
            StartDate = startDate;
            Note = note;
            EntrantsAndReviewersType = entrantsAndReviewersType;
        }
            
              

            
            
        

    }


    
}
