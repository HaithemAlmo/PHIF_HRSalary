using Almotkaml.HR.Domain.DocumentFactory;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class Document
    {
        public static IEmployeeHolder New() => new DocumentBuilder();

        internal Document() { }

        public int DocumentId { get; private set; }
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; internal set; }
        public int DocumentTypeId { get; internal set; }
        public DocumentType DocumentType { get; internal set; }
        public int Number { get; internal set; }
        public DateTime IssueDate { get; internal set; }
        public string IssuePlace { get; internal set; }
        public DateTime? ExpireDate { get; internal set; }
        public int? DecisionNumber { get; internal set; }
        public int? DecisionYear { get; internal set; }
        public string Note { get; internal set; }
        public ICollection<DocumentImage> DocumentImages { get; } = new HashSet<DocumentImage>();
        public DocumentModifier Modify() => new DocumentModifier(this);
    }
}