using Almotkaml.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Almotkaml.HR.Resources;

namespace Almotkaml.HR.Models
{
    public class SalaryUnitModel
    {
        public IList<SalaryUnitGridRow> SalaryUnitGrid { get; set; } = new List<SalaryUnitGridRow>();
        public bool CanSave { get; set; }
        public int SalaryUnitId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.Degree))]
        public int Degree { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.BeginningValue))]
        public decimal BeginningValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.PremiumValue))]
        public decimal PremiumValue { get; set; }
        public decimal PremiumValue1 { get; set; }
        public decimal PremiumValue2 { get; set; }
        public decimal PremiumValue3 { get; set; }
        public decimal PremiumValue4 { get; set; }





        public decimal HIF1 { get; set; }
        public decimal HIF2 { get; set; }

        public decimal HIF3 { get; set; }

        public decimal HIF4 { get; set; }
        public decimal HIF5 { get; set; }
        public decimal HIF6 { get; set; }
        public decimal HIF7 { get; set; }

        public decimal HIF8 { get; set; }
        public decimal HIF9 { get; set; }
        public decimal HIF10 { get; set; }
        public decimal HIF11 { get; set; }
        public decimal HIF12 { get; set; }



        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.SalayClassification))]
        public SalayClassification SalayClassification { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedMessages),
        //    ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ExtraValue))]
        public decimal ExtraValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedMessages),
            ErrorMessageResourceName = nameof(SharedMessages.IsRequired))]
        [Display(ResourceType = typeof(Title),
            Name = nameof(Title.ExtraGeneralValue))]
        public decimal ExtraGeneralValue { get; set; }

        public decimal GetPremium(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return salaryUnit.BeginningValue + salaryUnit.PremiumValue * premium;
        }
        public decimal GetPremium1(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return salaryUnit.BeginningValue + salaryUnit.PremiumValue1 * premium;
        }
        public decimal GetPremium2(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return salaryUnit.BeginningValue + salaryUnit.PremiumValue2 * premium;
        }
        public decimal GetPremium3(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return salaryUnit.BeginningValue + salaryUnit.PremiumValue3 * premium;
        }
        public decimal GetPremium4(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return salaryUnit.BeginningValue + salaryUnit.PremiumValue4 * premium;
        }
        public decimal GetExtraValue(int premium, int degree)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.Degree == degree);
            return (salaryUnit.BeginningValue + salaryUnit.PremiumValue * premium) * 40 / 100;
        }
        public decimal GetHIF1(decimal hif1)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF1 == hif1);
            return hif1;
        }
        public decimal GetHIF2(decimal hif2)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF2 == hif2);
            return hif2;
        }
        public decimal GetHIF3(decimal hif3)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF3 == hif3);
            return hif3;
        }
        public decimal GetHIF4(decimal hif4)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF4 == hif4);
            return hif4;
        }
        public decimal GetHIF5(decimal hif5)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF5 == hif5);
            return hif5;
        }
        public decimal GetHIF6(decimal hif6)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF6 == hif6);
            return hif6;
        }
        public decimal GetHIF7(decimal hif7)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF7 == hif7);
            return hif7;
        }
        public decimal GetHIF8(decimal hif8)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF8 == hif8);
            return hif8;
        }
        public decimal GetHIF9(decimal hif9)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF9 == hif9);
            return hif9;
        }
        public decimal GetHIF10(decimal hif10)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF10 == hif10);
            return hif10;
        }
        public decimal GetHIF11(decimal hif11)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF11 == hif11);
            return hif11;
        }
        public decimal GetHIF12(decimal hif12)
        {
            var salaryUnit = SalaryUnitGrid.FirstOrDefault(s => s.HIF12 == hif12);
            return hif12;
        }
    }

    public class SalaryUnitGridRow
    {
        public int SalaryUnitId { get; set; }
        public int Degree { get; set; }
        public decimal BeginningValue { get; set; }
        public decimal PremiumValue { get; set; }
        public decimal PremiumValue1 { get; set; }
        public decimal PremiumValue2 { get; set; }
        public decimal PremiumValue3 { get; set; }
        public decimal PremiumValue4 { get; set; }
        public decimal ExtraValue { get; set; }
        public decimal ExtraGeneralValue { get; set; }



        public decimal HIF1 { get; set; }
        public decimal HIF2 { get; set; }

        public decimal HIF3 { get; set; }

        public decimal HIF4 { get; set; }
        public decimal HIF5 { get; set; }
        public decimal HIF6 { get; set; }
        public decimal HIF7 { get; set; }

        public decimal HIF8 { get; set; }
        public decimal HIF9 { get; set; }
        public decimal HIF10 { get; set; }
        public decimal HIF11 { get; set; }
        public decimal HIF12 { get; set; }

        public decimal ExtraValue1 { get; set; }
        public decimal ExtraValue2 { get; set; }
        public decimal ExtraValue3 { get; set; }
        public decimal ExtraValue4 { get; set; }
        public decimal ExtraValue5 { get; set; }
        public decimal ExtraValue6 { get; set; }
        public decimal ExtraValue7 { get; set; }
        public decimal ExtraValue8 { get; set; }
        public decimal ExtraValue9 { get; set; }
        public decimal ExtraValue10 { get; set; }
        public decimal ExtraValue11 { get; set; }
        public decimal ExtraValue12 { get; set; }


    }
}
