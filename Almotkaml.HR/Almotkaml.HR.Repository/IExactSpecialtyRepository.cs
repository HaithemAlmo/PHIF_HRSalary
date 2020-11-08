using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface IExactSpecialtyRepository : IRepository<ExactSpecialty>
    {
        IEnumerable<ExactSpecialty> GetExactSpecialtyWithSubSpecialty(int subSpecialtyId);
        IEnumerable<ExactSpecialty> GetExactSpecialtyWithSubSpecialty();
        bool ExactSpecialtyExisted(string name, int subSpecialtyId, int idToExcept);
        bool ExactSpecialtyExisted(string name, int subSpecialtyId);

    }
}