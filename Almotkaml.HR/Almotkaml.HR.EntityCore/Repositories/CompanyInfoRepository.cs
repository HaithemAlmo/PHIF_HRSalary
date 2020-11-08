using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.EntityCore.Entities;
using Almotkaml.HR.Repository;
using System;
using System.Linq;

namespace Almotkaml.HR.EntityCore.Repositories
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        internal CompanyInfoRepository(HrDbContext context)
        {
            Context = context;
        }
        private HrDbContext Context { get; }

        public CompanyInfo Load()
        {
            var domainCompanyInfo = new CompanyInfo();

            foreach (var dbCompanyInfo in Context.Info.ToList())
            {
                var type = domainCompanyInfo.GetType().GetProperty(dbCompanyInfo.Name).PropertyType;

                var value = Convert.ChangeType(dbCompanyInfo.Value, type);

                domainCompanyInfo.SetValue(dbCompanyInfo.Name, value);
            }
            return domainCompanyInfo;
        }

        public void Save(CompanyInfo companyInfo)
        {
            var dbCompanyInfos = Context.Info.ToList();

            foreach (var domainCompanyInfoProperty in companyInfo.GetType().GetProperties())
            {
                var dbCompanyInfo = dbCompanyInfos.FirstOrDefault(s => s.Name == domainCompanyInfoProperty.Name);

                var domainValue = domainCompanyInfoProperty.GetValue(companyInfo)?.ToString();

                if (dbCompanyInfo != null)
                    dbCompanyInfo.Value = domainValue;
                else
                    Context.Info.Add(new Info()
                    {
                        Name = domainCompanyInfoProperty.Name,
                        Value = domainValue
                    });
            }
        }

    }
}