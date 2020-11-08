using Almotkaml.HR.Domain.BookletFactory;
using System;

namespace Almotkaml.HR.Domain
{
    public class Booklet
    {
        public static INumberHolder New()
        {
            return new BookletBuilder();
        }

        internal Booklet()
        {

        }
        internal Booklet(Employee employee)
        {
            Employee = employee;
        }

        public Employee Employee { get; set; }
        public string Number { get; set; }
        public string FamilyNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssuePlace { get; set; }
        public string CivilRegistry { get; set; }

        public BookletModifier Modify()
        {
            return new BookletModifier(this);
        }
    }
}