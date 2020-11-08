using System.Collections.Generic;

namespace Almotkaml.HR.Domain
{
    public class SalaryUnit
    {
        public static SalaryUnit New(int degree, decimal beginningValue, decimal premiumValue, decimal premiumValue1, decimal premiumValue2, decimal premiumValue3, decimal premiumValue4
            , SalayClassification salayClassification, decimal extraValue1, decimal extraValue2, decimal extraValue3, decimal extraValue4, decimal extraValue5, decimal extraValue6, decimal extraValue7, decimal extraValue8, decimal extraValue9, decimal extraValue10, decimal extraValue11, decimal extraValue12,
            decimal extraGeneralValue, decimal hif1, decimal hif2, decimal hif3, decimal hif4, decimal hif5, decimal hif6, decimal hif7, decimal hif8, decimal hif9, decimal hif10, decimal hif11, decimal hif12)
        {
            Check.MoreThanZero(degree, nameof(degree));

            var salaryUnit = new SalaryUnit()
            {
                Degree = degree,
                BeginningValue = beginningValue,
                PremiumValue = premiumValue,
                PremiumValue1 = premiumValue1,
                PremiumValue2 = premiumValue2,
                PremiumValue3 = premiumValue3,
                PremiumValue4 = premiumValue4,
                SalayClassification = salayClassification,
                ExtraValue1 = extraValue1,
                ExtraValue2 = extraValue2,
                ExtraValue3 = extraValue3,
                ExtraValue4 = extraValue4,
                ExtraValue5 = extraValue5,
                ExtraValue6 = extraValue6,
                ExtraValue7 = extraValue7,
                ExtraValue8 = extraValue8,
                ExtraValue9 = extraValue9,
                ExtraValue10 = extraValue10,
                ExtraValue11 = extraValue11,
                ExtraValue12 = extraValue12,

                ExtraGeneralValue = extraGeneralValue,




                HIF1 = hif1,
                HIF2 = hif2,
                HIF3 = hif3,
                HIF4 = hif4,
                HIF5 = hif5,
                HIF6 = hif6,
                HIF7 = hif7,
                HIF8 = hif8,
                HIF9 = hif9,
                HIF10 = hif10,
                HIF11 = hif11,
                HIF12 = hif12,
            };

            return salaryUnit;
        }

        private SalaryUnit()
        {

        }
        public int SalaryUnitId { get; private set; }
        public int Degree { get; private set; }
        public decimal BeginningValue { get; private set; }
        public decimal PremiumValue { get; private set; }
        public decimal PremiumValue1 { get; private set; }
        public decimal PremiumValue2 { get; private set; }
        public decimal PremiumValue3 { get; private set; }
        public decimal PremiumValue4 { get; private set; }





        public decimal HIF1 { get; private set; }
        public decimal ExtraValue1 { get; private set; }
        public decimal HIF2 { get; private set; }
        public decimal ExtraValue2 { get; private set; }
        public decimal HIF3 { get; private set; }
        public decimal ExtraValue3 { get; private set; }
        public decimal HIF4 { get; private set; }
        public decimal ExtraValue4 { get; private set; }
        public decimal HIF5 { get; private set; }
        public decimal ExtraValue5 { get; private set; }
        public decimal HIF6 { get; private set; }
        public decimal ExtraValue6 { get; private set; }
        public decimal HIF7 { get; private set; }
        public decimal ExtraValue7 { get; private set; }
        public decimal HIF8 { get; private set; }
        public decimal ExtraValue8 { get; private set; }
        public decimal HIF9 { get; private set; }
        public decimal ExtraValue9 { get; private set; }
        public decimal HIF10 { get; private set; }
        public decimal ExtraValue10 { get; private set; }
        public decimal HIF11 { get; private set; }
        public decimal ExtraValue11 { get; private set; }
        public decimal HIF12 { get; private set; }
        public decimal ExtraValue12 { get; private set; }



        public decimal ExtraGeneralValue { get; private set; }
        public SalayClassification SalayClassification { get; private set; }
        public void Modify(decimal beginningValue, decimal premiumValue, decimal premiumValue1, decimal premiumValue2, decimal premiumValue3, decimal premiumValue4, decimal extraValue, decimal extraGeneralValue
    , decimal extraValue1, decimal extraValue2, decimal extraValue3, decimal extraValue4, decimal extraValue5, decimal extraValue6, decimal extraValue7, decimal extraValue8, decimal extraValue9, decimal extraValue10, decimal extraValue11, decimal extraValue12, decimal hif1, decimal hif2, decimal hif3, decimal hif4, decimal hif5, decimal hif6, decimal hif7, decimal hif8, decimal hif9, decimal hif10, decimal hif11, decimal hif12)

        {
            BeginningValue = beginningValue;
            PremiumValue = premiumValue;
            PremiumValue1 = premiumValue1;
            PremiumValue2 = premiumValue2;
            PremiumValue3 = premiumValue3;
            PremiumValue4 = premiumValue4;


            ExtraValue1 = extraValue1;
            ExtraValue2 = extraValue2;
            ExtraValue3 = extraValue3;
            ExtraValue4 = extraValue4;
            ExtraValue5 = extraValue5;
            ExtraValue6 = extraValue6;
            ExtraValue7 = extraValue7;
            ExtraValue8 = extraValue8;
            ExtraValue9 = extraValue9;
            ExtraValue10 = extraValue10;
            ExtraValue11 = extraValue11;
            ExtraValue12 = extraValue12;
            ExtraGeneralValue = extraGeneralValue;
            HIF1 = hif1;
            HIF2 = hif2;
            HIF3 = hif3;
            HIF4 = hif4;
            HIF5 = hif5;
            HIF6 = hif6;
            HIF7 = hif7;
            HIF8 = hif8;
            HIF9 = hif9;
            HIF10 = hif10;
            HIF11 = hif11;
            HIF12 = hif12;
        }

        public static IEnumerable<ClampDegree> ClampDegrees()
            => new HashSet<ClampDegree>()
            {
                ClampDegree.Seven,
                ClampDegree.Nine,
                ClampDegree.TenB,
                ClampDegree.TenA,
                ClampDegree.Eleven,
                ClampDegree.Twelve,
                ClampDegree.ThirteenB,
                ClampDegree.ThirteenA,
                ClampDegree.FourteenB,
                ClampDegree.FourteenA
            };

        public static IEnumerable<ClampDegree> Leaders()
            => new HashSet<ClampDegree>()
            {
                ClampDegree.Seven,
                ClampDegree.Nine,
                ClampDegree.TenB,
                ClampDegree.TenA,
                ClampDegree.Eleven,
                ClampDegree.Twelve,
                ClampDegree.ThirteenB,
                ClampDegree.ThirteenA,
                ClampDegree.FourteenB,
                ClampDegree.FourteenA
            };
    }
}