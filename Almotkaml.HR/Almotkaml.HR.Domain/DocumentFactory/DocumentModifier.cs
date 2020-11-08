using System;

namespace Almotkaml.HR.Domain.DocumentFactory
{
    public class DocumentModifier
    {
        internal DocumentModifier(Document document)
        {
            Document = document;
        }

        private Document Document { get; }

        public DocumentModifier Type(DocumentType documentType)
        {
            Check.NotNull(documentType, nameof(documentType));

            Document.DocumentType = documentType;
            Document.DocumentTypeId = documentType.DocumentTypeId;
            return this;
        }

        public DocumentModifier IssueDate(DateTime date)
        {
            Check.IsValidDate(date, nameof(date));

            Document.IssueDate = date;
            return this;
        }

        public DocumentModifier IssuePlace(string place)
        {
            Document.IssuePlace = place;
            return this;
        }

        public DocumentModifier ExpireDate(DateTime? date)
        {
            if (date == null)
            {
                Document.ExpireDate = null;
                return this;
            }

            Check.IsValidDate(date.Value, nameof(date));

            Document.ExpireDate = date;
            return this;
        }

        public DocumentModifier DecisionNumber(int? decisionNumber)
        {
            if (decisionNumber.GetValueOrDefault() == 0)
            {
                Document.DecisionNumber = null;
                return this;
            }

            Document.DecisionNumber = decisionNumber;
            return this;
        }

        public DocumentModifier DecisionInYear(int? year)
        {
            if (year == null)
            {
                Document.DecisionYear = null;
                return this;
            }

            if (year > 2100 || year < 1900)
                throw new ArgumentOutOfRangeException(nameof(year));

            Document.DecisionYear = year;
            return this;
        }

        public DocumentModifier WithNote(string note)
        {
            Document.Note = note;
            return this;
        }

        public Document Confirm()
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