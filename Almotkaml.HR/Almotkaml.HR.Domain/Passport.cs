using System;

namespace Almotkaml.HR.Domain
{
    public class Passport
    {
        public static Passport New(string number, string autoNumber, DateTime? issueDate, string issuePlace,
            DateTime expirationDate)
        {

            var passport = new Passport()
            {
                Number = number,
                AutoNumber = autoNumber,
                IssueDate = issueDate,
                IssuePlace = issuePlace,
                ExpirationDate = expirationDate
            };

            return passport;
        }

        internal Passport()
        {

        }
        internal Passport(Employee employee)
        {
            Employee = employee;
        }

        public Employee Employee { get; set; }
        public string Number { get; set; }
        public string AutoNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssuePlace { get; set; }
        public DateTime ExpirationDate { get; set; }
        public void Modify(string number, string autoNumber, DateTime? issueDate, string issuePlace
            , DateTime expirationDate)
        {
            Number = number;
            AutoNumber = autoNumber;
            IssueDate = issueDate;
            IssuePlace = issuePlace;
            ExpirationDate = expirationDate;
        }
    }
}