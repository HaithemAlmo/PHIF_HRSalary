using Almotkaml.HR.Domain;
using Almotkaml.HR.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    //public class DevelopmentTypeERepository : Repository<DevelopmentTypeE>, IDevelopmentTypeERepository
    //{
    //    private HrDbContext Context { get; }

    //    internal DevelopmentTypeERepository(HrDbContext context)
    //        : base(context)
    //    {
    //        Context = context;
    //    }

    //    public IEnumerable<DevelopmentTypeE> GetDevelopmentTypeEWithDevelopmentTypeD(int developmentTypeDId)
    //    {
    //        return Context.DevelopmentTypeEs
    //                     .Include(d => d.DevelopmentTypeD)
    //                     .ThenInclude(d => d.DevelopmentTypeC)
    //                     .ThenInclude(d => d.DevelopmentTypeB)
    //                     .ThenInclude(d => d.DevelopmentTypeA)
    //                     .Where(d => d.DevelopmentTypeDId == developmentTypeDId);
    //    }

    //    public IEnumerable<DevelopmentTypeE> GetDevelopmentTypeEWithDevelopmentTypeD()
    //    {
    //        return Context.DevelopmentTypeEs
    //            .Include(d => d.DevelopmentTypeD)
    //            .ThenInclude(d => d.DevelopmentTypeC)
    //            .ThenInclude(d => d.DevelopmentTypeB)
    //            .ThenInclude(d => d.DevelopmentTypeA);
    //    }

    //    public bool DevelopmentTypeEExisted(string name, int developmentTypeDId) => Context.DevelopmentTypeEs
    //        .Any(e => e.Name == name && e.DevelopmentTypeDId == developmentTypeDId);

    //    public bool DevelopmentTypeEExisted(string name, int developmentTypeDId, int idToExcept) => Context.DevelopmentTypeEs
    //        .Any(e => e.Name == name && e.DevelopmentTypeEId != idToExcept && e.DevelopmentTypeDId == developmentTypeDId);
    //}
}