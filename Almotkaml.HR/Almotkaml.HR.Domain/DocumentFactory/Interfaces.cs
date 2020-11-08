using System;

namespace Almotkaml.HR.Domain.DocumentFactory
{
    public interface IEmployeeHolder
    {
        IDocumentTypeHolder ForEmployee(Employee employee);
        IDocumentTypeHolder ForEmployeeId(int employeeId);
    }
    public interface IDocumentTypeHolder
    {
        INumberHolder WithType(DocumentType documentType);
    }

    public interface INumberHolder
    {
        IIssueDateHolder WithNumber(int number);
    }

    public interface IIssueDateHolder
    {
        IIssuePlaceHolder IssuedInDate(DateTime date);
    }

    public interface IIssuePlaceHolder
    {
        IExpireDateHolder IssuedInPlace(string place);
    }

    public interface IExpireDateHolder
    {
        IDecisionNumberHolder ExpireIn(DateTime? date);
    }

    public interface IDecisionNumberHolder
    {
        IDecisionYearHolder WithDecisionNumber(int? decisionNumber);
    }

    public interface IDecisionYearHolder
    {
        INoteHolder DecisionInYear(int? year);
    }

    public interface INoteHolder
    {
        IBuild WithNote(string note);
    }

    public interface IBuild
    {
        Document Build();
    }
}