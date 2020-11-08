using Almotkaml.HR.Domain;

namespace Almotkaml.HR.Repository
{
    public interface ICompanyInfoRepository
    {
        CompanyInfo Load();
        void Save(CompanyInfo companyInfo);
    }
}