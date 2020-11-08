using System;

namespace Almotkaml.HR.Domain.DocumentFactory
{
    public class DocumentBuilder : IEmployeeHolder, IDocumentTypeHolder, INumberHolder, IIssueDateHolder, IIssuePlaceHolder
        , IExpireDateHolder, IDecisionNumberHolder, IDecisionYearHolder, INoteHolder, IBuild
    {
        internal DocumentBuilder() { }
        private Document Document { get; } = new Document();

        public IDocumentTypeHolder ForEmployee(Employee employee)
        {
            Check.NotNull(employee, nameof(employee));

            Document.Employee = employee;
            Document.EmployeeId = employee.EmployeeId;
            return this;
        }

        public IDocumentTypeHolder ForEmployeeId(int employeeId)
        {
            Check.MoreThanZero(employeeId, nameof(employeeId));

            Document.EmployeeId = employeeId;
            return this;
        }

        public INumberHolder WithType(DocumentType documentType)
        {
            Check.NotNull(documentType, nameof(documentType));

            Document.DocumentType = documentType;
            Document.DocumentTypeId = documentType.DocumentTypeId;
            return this;
        }

        public IIssueDateHolder WithNumber(int number)
        {
            Check.MoreThanZero(number, nameof(number));

            Document.Number = number;
            return this;
        }

        public IIssuePlaceHolder IssuedInDate(DateTime date)
        {
            Check.IsValidDate(date, nameof(date));

            Document.IssueDate = date;
            return this;
        }

        public IExpireDateHolder IssuedInPlace(string place)
        {
            Document.IssuePlace = place;
            return this;
        }

        public IDecisionNumberHolder ExpireIn(DateTime? date)
        {
            if (date == null)
                return this;

            Check.IsValidDate(date.Value, nameof(date));

            Document.ExpireDate = date;
            return this;
        }

        public IDecisionYearHolder WithDecisionNumber(int? decisionNumber)
        {
            if (decisionNumber.GetValueOrDefault() == 0)
                return this;

            Document.DecisionNumber = decisionNumber;
            return this;
        }

        public INoteHolder DecisionInYear(int? year)
        {
            if (year == null)
                return this;

            if (year > 2100 || year < 1900)
                throw new ArgumentOutOfRangeException(nameof(year));

            Document.DecisionYear = year;
            return this;
        }

        public IBuild WithNote(string note)
        {
            Document.Note = note;
            return this;
        }

        public Document Build()
        {
            if (Document.DocumentType.HaveDecisionNumber && Document.DecisionNumber == null)
                throw new Exception("DecisionNumber is rquired");

            if (Document.DocumentType.HaveDecisionYear && Document.DecisionYear == null)
                throw new Exception("DecisionYear is rquired");

            if (Document.DocumentType.HaveExpireDate && Document.ExpireDate == null)
                throw new Exception("ExpireDate is rquired");

            return Document;
        }
    }
}