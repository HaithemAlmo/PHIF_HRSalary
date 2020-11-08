using System;
using Almotkaml.HR.Domain;
using Almotkaml.Repository;

namespace Almotkaml.HR.Repository
{
    public interface IHolidayRepository : IRepository<Holiday>, ICheckNameExisted
    {
        int HolidayCount(DateTime dateFrom, DateTime dateTo);
    }
}