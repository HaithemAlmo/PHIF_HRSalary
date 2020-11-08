using Almotkaml.HR.Domain;
using Almotkaml.Repository;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public interface ISubSpecialtyRepository : IRepository<SubSpecialty>
    {
        IEnumerable<SubSpecialty> GetSubSpecialtyWithSpecialty(int specialtyId);
        IEnumerable<SubSpecialty> GetSubSpecialtyWithSpecialty();
        bool SubSpecialtyExisted(string name, int specialtyId);
        bool SubSpecialtyExisted(string name, int specialtyId, int idToExcept);

    }
}