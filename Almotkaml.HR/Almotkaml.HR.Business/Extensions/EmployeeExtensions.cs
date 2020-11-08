using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class EmployeeExtensions
    {
        public static IEnumerable<EmployeeListItem> ToEmployeeList(this IEnumerable<Employee> employees)
            => employees.Select(e => new EmployeeListItem()
            {
                Name = e.GetFullName(),
                EmployeeId = e.EmployeeId
            });

        //[Obsolete]
        public static IEnumerable<EmployeeGridRow> ToGrid(this IEnumerable<Employee> employees)
          => employees.Select(d => new EmployeeGridRow()
          {
              EmployeeId = d.EmployeeId,
              ArabicFullName = d.GetFullName(),
              DepartmentName = d.JobInfo?.Unit?.Division?.Department?.Name,
              JobNumber = d.JobInfo?.JobClassValu+d.JobInfo?.GetJobNumber(),
            //  JobNumberLIC = d.JobNumberLIC,
              NationalNumber = d.NationalNumber,
              CenterName = d.JobInfo?.Unit?.Division?.Department?.Center?.Name,
          });

      
        public static IList<TemporaryPremmiumListItem> ToNotTemList(this IEnumerable<EmployeePremium> premiumsNT)
             => premiumsNT.Select(d => new TemporaryPremmiumListItem()
             {
                 EmployeeId = d.Employee.EmployeeId,
                 ISAdvancePremmium = d.Premium?.ISAdvancePremmium??0,
                 PremiumId = d.PremiumId,
                 Value = d.Value,
                 IsTemporary=d.Premium?.IsTemporary??0,
             }).ToList();


        public static IList<EmployeeAdvancePymentListItem> ToAdvanseList(this IEnumerable<AdvancePayment> premiums1)
               => premiums1.Select(d1 => new EmployeeAdvancePymentListItem()
               {
                   EmployeeID=d1.Employee.EmployeeId,
                   PremiumId=d1.PremiumId,
                   Value=d1.InstallmentValue,
                  
                   AllValue =d1.AllValue,
                 
                  

               }).ToList();

        public static Booklet ToDomain(this BookletModel booklet) => Booklet.New()
            .WithNumber(booklet.Number)
            .WithFamilyNumber(booklet.FamilyNumber)
            .WithRegistrationNumber(booklet.RegistrationNumber)
            .WithIssueDate(booklet.IssueDate.ToDateTime())
            .WithIssuePlace(booklet.IssuePlace)
            .WithCivilRegistry(booklet.CivilRegistry)
            .Biuld();

        public static Passport ToDomain(this PassportModel passport)
            => Passport.New(passport.Number, passport.AutoNumber, passport.IssueDate.ToDateTime(), passport.IssuePlace, passport.ExpirationDate.ToDateTime());
        public static ContactInfo ToDomain(this ContactInfoModel contactInfo)
            => ContactInfo.New(contactInfo.Phone, contactInfo.Note, contactInfo.NearKindr, contactInfo.RelativeRelation
                            , contactInfo.NearPoint, contactInfo.Address, contactInfo.WorkAddress);
        public static IdentificationCard ToDomain(this IdentificationCardModel identificationCard)
            => IdentificationCard.New(identificationCard.Number, identificationCard.IssueDate.ToDateTime()
                , identificationCard.IssuePlace);

        public static EmploymentValues ToDomain(this EmploymentValuesModel employmentValues)
            =>
                new EmploymentValues(employmentValues.DesignationResolutionNumber,
                    employmentValues.DesignationResolutionDate.ToDateTime()
                    , employmentValues.DesignationIssue, employmentValues.ContractDateFrom.ToDateTime(),
                     employmentValues.ContractDateTo.ToDateTime(), employmentValues.DelegationDate.ToDateTime(), employmentValues.DelegationSide,
                      employmentValues.TransferDate.ToDateTime(), employmentValues.TransferSide, employmentValues.LoaningDate.ToDateTime()
                    , employmentValues.LoaningSide, employmentValues.BenefitFromServicesDate.ToDateTime(), employmentValues.BenefitFromServicesSide
                    , employmentValues.EmptiedDate.ToDateTime(), employmentValues.EmptiedSide, employmentValues.CollaboratorDate.ToDateTime(),
                      employmentValues.CollaboratorSide);

        public static ContactInfoModel ToModel(this ContactInfo contactInfo)
                        => new ContactInfoModel()
                        {
                            Address = contactInfo.Address,
                            RelativeRelation = contactInfo.RelativeRelation,
                            NearKindr = contactInfo.NearKindr,
                            NearPoint = contactInfo.NearPoint,
                            WorkAddress = contactInfo.WorkAddress,
                            Note = contactInfo.Note,
                            Phone = contactInfo.Phone
                        };
        public static PassportModel ToModel(this Passport passport)
                        => new PassportModel()
                        {
                            IssueDate = passport.IssueDate.FormatToString(),
                            Number = passport.Number,
                            IssuePlace = passport.IssuePlace,
                            AutoNumber = passport.AutoNumber,
                            ExpirationDate = passport.ExpirationDate.FormatToString()
                        };

        public static IdentificationCardModel ToModel(this IdentificationCard identificationCard)
            => new IdentificationCardModel()
            {
                IssuePlace = identificationCard.IssuePlace,
                IssueDate = identificationCard.IssueDate.FormatToString(),
                Number = identificationCard.Number
            };

        public static BookletModel ToModel(this Booklet booklet) =>
            new BookletModel()
            {
                CivilRegistry = booklet.CivilRegistry,
                FamilyNumber = booklet.FamilyNumber,
                IssueDate = booklet.IssueDate.FormatToString(),
                IssuePlace = booklet.IssuePlace,
                Number = booklet.Number,
                RegistrationNumber = booklet.RegistrationNumber
            };

        public static EmploymentValuesModel ToModel(this EmploymentValues employmentValues)
            =>
                new EmploymentValuesModel()
                {
                    ContractDateFrom = employmentValues.ContractDateFrom.FormatToString(),
                    ContractDateTo = employmentValues.ContractDateTo.FormatToString(),
                    DesignationResolutionDate = employmentValues.DesignationResolutionDate.FormatToString(),
                    DesignationIssue = employmentValues.DesignationIssue,
                    DesignationResolutionNumber = employmentValues.DesignationResolutionNumber,
                    DelegationDate = employmentValues.DelegationDate.FormatToString(),
                    DelegationSide = employmentValues.DelegationSide,
                    TransferDate = employmentValues.TransferDate.FormatToString(),
                    TransferSide = employmentValues.TransferSide
                };
        //public static FinancialDataModel ToModel(this FinancialData financialData)
        //{
        //    return new FinancialDataModel()
        //    {
        //        BankBranchName = financialData.BankBranch?.Name,
        //        BankName = financialData.BankBranch?.Bank?.Name,
        //        BondNumber = financialData.BondNumber,
        //        FinancialNumber = financialData.FinancialNumber,
        //        Salary = financialData.Salary ?? 0,
        //        SecurityNumber = financialData.SecurityNumber,
        //        BankBranchId = financialData.BankBranchId ?? 0
        //    };
        //}
        //public static FinancialData ToDomain(this FinancialDataModel financialData)
        //{
        //    return new FinancialData(financialData.BankBranchId, financialData.BondNumber, financialData.Salary, financialData.SecurityNumber
        //        , financialData.FinancialNumber);
        //}
    }
}
