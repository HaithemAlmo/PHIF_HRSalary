using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using Almotkaml.HR.Abstraction;

namespace Almotkaml.HR.Business.App_Business.General
{
    public class SettingsBusiness : Business, ISettingsBusiness
    {
        public SettingsBusiness(HumanResource humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Setting && permission;

        public SettingsModel Get()
        {
            if (!HavePermission())
                return Null<SettingsModel>(RequestState.NoPermission);

            var settings = UnitOfWork.Settings.Load();

            if (settings == null)
                throw new Exception("failed to load settings !");

            return new SettingsModel()
            {
                Grouplife = settings.Grouplife,
                DataEntryPrice =settings .DataEntryPrice,
                FirstReviewPrice = settings.FirstReviewPrice,
                AccommodationReviewPrice = settings.AccommodationReviewPrice ,
                ClincReviewPrice = settings.ClincReviewPrice ,
                Number = settings.Number,
                NumberCheck = settings.NumberCheck,
                TextboxFrom = settings.TextboxFrom,
                TextboxTo = settings.TextboxTo,
                SafeShareAll = settings.SafeShareAll,
                SafeShareReduced = settings.SafeShareReduced,
                CanSubmit = ApplicationUser.Permissions.Setting,
                ChilderPermium = settings.ChilderPermium,
                ExtraWork = settings.ExtraWork,
                SickVacation = settings.SickVacation,
                SickLeave=settings.SickLeave,
                ExtraWorkVacation = settings.ExtraWorkVacation,
                SolidarityFund = settings.SolidarityFund,
                StampTax = settings.StampTax,
                CompanyShareReduced35Year = settings.CompanyShareReduced35Year,
                EmployeeShareWithoutReduced = settings.EmployeeShareWithoutReduced,
                CompanyShareAll = settings.CompanyShareAll,
                ExemptionTaxOne = settings.ExemptionTaxOne,
                CompanyShareReduced = settings.CompanyShareReduced,
                JihadTax = settings.JihadTax,
                EmployeeShareReduced = settings.EmployeeShareReduced,
                EmployeeShareAll = settings.EmployeeShareAll,
                CompanyShareWithoutReduced = settings.CompanyShareWithoutReduced,
                IncomeTaxOne = settings.IncomeTaxOne,
                IncomeTaxTwo = settings.IncomeTaxTwo,
                EmployeeShareReduced35Year = settings.EmployeeShareReduced35Year,
                ExemptionTaxTwo = settings.ExemptionTaxTwo,
                Date = settings.Date.FormatToString(),
                Saturday = settings.Saturday,
                Sunday = settings.Sunday,
                Monday = settings.Monday,
                Thursday = settings.Thursday,
                Wednesday = settings.Wednesday,
                Tuesday = settings.Tuesday,
                Friday = settings.Friday,
                VacationIncludesHolidays=settings.VacationIncludesHolidays,
            };
        }

        public bool Save(SettingsModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Setting_Update))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var settings = new Settings(model.Grouplife, model.DataEntryPrice , model.FirstReviewPrice, model.AccommodationReviewPrice, model.ClincReviewPrice, model.SickVacation,model.SickLeave, model.ExtraWork, model.ExtraWorkVacation,
                model.SolidarityFund, model.EmployeeShareAll, model.EmployeeShareReduced,
                model.EmployeeShareWithoutReduced, model.EmployeeShareReduced35Year, model.CompanyShareAll,
                model.CompanyShareReduced, model.CompanyShareWithoutReduced, model.CompanyShareReduced35Year
                , model.JihadTax, model.ExemptionTaxOne, model.ExemptionTaxTwo, model.StampTax, model.ChilderPermium
                , model.IncomeTaxOne, model.IncomeTaxTwo, model.Date.ToDateTime(), model.Saturday, model.Sunday, model.Monday
                , model.Thursday, model.Wednesday, model.Tuesday, model.Friday, model.SafeShareAll, model.SafeShareReduced, model.TextboxFrom, model.TextboxTo, model.Number, model.NumberCheck,model.VacationIncludesHolidays);

            UnitOfWork.Settings.Save(settings);

            UnitOfWork.Complete(n => n.Setting_Update);

            return SuccessEdit();
        }
    }
}