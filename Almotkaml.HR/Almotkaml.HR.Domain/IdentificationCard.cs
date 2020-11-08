using System;

namespace Almotkaml.HR.Domain
{
    public class IdentificationCard : IIdentificationCard<DateTime?>

    {
        public static IdentificationCard New(string number, DateTime? issueDate, string issuePlace)
        {

            var identificationCard = new IdentificationCard()
            {
                Number = number,
                IssueDate = issueDate,
                IssuePlace = issuePlace
            };

            return identificationCard;
        }

        internal IdentificationCard()
        {

        }
        internal IdentificationCard(Employee employee)
        {
            Employee = employee;
        }
        public Employee Employee { get; set; }
        public string Number { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssuePlace { get; set; }
        public void Modify(string number, string autoNumber, DateTime? issueDate, string issuePlace)
        {
            Number = number;
            IssueDate = issueDate;
            IssuePlace = issuePlace;
        }
    }
}