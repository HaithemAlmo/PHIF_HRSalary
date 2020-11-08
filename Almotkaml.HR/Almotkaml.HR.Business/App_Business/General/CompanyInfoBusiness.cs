using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class CompanyInfoBusiness : Business, ICompanyInfoBusiness
    {
        public CompanyInfoBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.CompanyInfo && permission;

        public CompanyInfoModel Get()
        {
            if (!HavePermission())
                return Null<CompanyInfoModel>(RequestState.NoPermission);

            var companyInfo = UnitOfWork.CompanyInfo.Load();

            if (companyInfo == null)
                throw new Exception("failed to load info !");

            return new CompanyInfoModel()
            {
                ShortName = companyInfo.ShortName,
                LongName = companyInfo.LongName,
                EnglishName = companyInfo.EnglishName,
                Email = companyInfo.Email,
                Address = companyInfo.Address,
                Mobile = companyInfo.Mobile,
                Phone = companyInfo.Phone,
                Website = companyInfo.Website,
                LogoPath = companyInfo.LogoPath,
                //add by ali alherbade 26-05-2019
                Department = companyInfo.Department,
                FinancialAffairs = companyInfo.FinancialAffairs,
                FinancialAuditor = companyInfo.FinancialAuditor,
                PayrollUnit = companyInfo.PayrollUnit,
                References = companyInfo.References,
                //
                CanSubmit = ApplicationUser.Permissions.CompanyInfo_Update,
            };
        }

        public bool Save(CompanyInfoModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.CompanyInfo_Update))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var companyInfo = new CompanyInfo()
            {
                Email = model.Email,
                EnglishName = model.EnglishName,
                LongName = model.LongName,
                Mobile = model.Mobile,
                Address = model.Address,
                ShortName = model.ShortName,
                Website = model.Website,
                Phone = model.Phone,
                LogoPath = model.LogoPath,
                //add by ali alherbade 26-05-2019
                Department = model.Department,
                FinancialAffairs = model.FinancialAffairs,
                FinancialAuditor = model.FinancialAuditor,
                PayrollUnit = model.PayrollUnit,
                References = model.References,
                //
            };

            UnitOfWork.CompanyInfo.Save(companyInfo);

            UnitOfWork.Complete(n => n.CompanyInfo_Update);

            return SuccessEdit();
        }
    }
}