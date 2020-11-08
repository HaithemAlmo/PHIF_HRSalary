using Almotkaml.Extensions;
using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.HR.Business.Extensions
{
    public static class SalaryUnitExtensions
    {
        public static IList<SalaryUnitGridRow> ToGrid(this IEnumerable<SalaryUnit> salaryUnits)
        {
            var list = new List<SalaryUnitGridRow>();
            var units = salaryUnits.AsIList();

            for (var i = 23; i > 0; i--)
            {
                var unit = units.FirstOrDefault(u => u.Degree == i);
                if (unit == null)
                    list.Add(new SalaryUnitGridRow()
                    {
                        Degree = i,
                    });
                else
                    list.Add(new SalaryUnitGridRow()
                    {
                        Degree = unit.Degree,
                        BeginningValue = unit.BeginningValue,
                        PremiumValue = unit.PremiumValue,
                        PremiumValue1 = unit.PremiumValue1,
                        PremiumValue2 = unit.PremiumValue2,
                        PremiumValue3 = unit.PremiumValue3,
                        //PremiumValue4 = unit.PremiumValue4,
                        SalaryUnitId = unit.SalaryUnitId,
                        ExtraValue1 = unit.ExtraValue1,
                        ExtraValue2 = unit.ExtraValue2,
                        ExtraValue3 = unit.ExtraValue3,
                        ExtraValue4 = unit.ExtraValue4,
                        ExtraValue5 = unit.ExtraValue5,
                        ExtraValue6 = unit.ExtraValue6,
                        ExtraValue7 = unit.ExtraValue7,
                        ExtraValue8 = unit.ExtraValue8,
                        ExtraValue9 = unit.ExtraValue9,
                        ExtraValue10 = unit.ExtraValue10,
                        ExtraValue11 = unit.ExtraValue11,
                        ExtraValue12 = unit.ExtraValue12,
                        ExtraGeneralValue = unit.ExtraGeneralValue
                    });
            }

            return list;
        }
        public static IList<SalaryUnitGridRow> ToGridClamp(this IEnumerable<SalaryUnit> salaryUnits)
        {
            var list = new List<SalaryUnitGridRow>();
            var units = salaryUnits.AsIList();

            foreach (var degree in SalaryUnit.ClampDegrees())
            {
                var unit = units.FirstOrDefault(u => u.Degree == (int)degree);
                if (unit == null)
                    list.Add(new SalaryUnitGridRow()
                    {
                        Degree = (int)degree,
                    });
                else
                    list.Add(new SalaryUnitGridRow()
                    {

                        Degree = unit.Degree,
                        BeginningValue = unit.BeginningValue,
                        PremiumValue = unit.PremiumValue,
                        PremiumValue1 = unit.PremiumValue1,
                        PremiumValue2 = unit.PremiumValue2,
                        PremiumValue3 = unit.PremiumValue3,
                        //PremiumValue4 = unit.PremiumValue4,
                        SalaryUnitId = unit.SalaryUnitId,
                        ExtraValue1 = unit.ExtraValue1,
                        ExtraValue2 = unit.ExtraValue2,
                        ExtraValue3 = unit.ExtraValue3,
                        ExtraValue4 = unit.ExtraValue4,
                        ExtraValue5 = unit.ExtraValue5,
                        ExtraValue6 = unit.ExtraValue6,
                        ExtraValue7 = unit.ExtraValue7,
                        ExtraValue8 = unit.ExtraValue8,
                        ExtraValue9 = unit.ExtraValue9,
                        ExtraValue10 = unit.ExtraValue10,
                        ExtraValue11 = unit.ExtraValue11,
                        ExtraValue12 = unit.ExtraValue12,
                        ExtraGeneralValue = unit.ExtraGeneralValue
                    });
            }

            return list;
        }


        public static IList<SalaryUnitGridRow> ToLeader(this IEnumerable<SalaryUnit> salaryUnits)
        {
            var list = new List<SalaryUnitGridRow>();
            var units = salaryUnits.AsIList();

            for (var i = 25; i > 23; i--)
            {
                var unit = units.FirstOrDefault(u => u.Degree == i);
                if (unit == null)
                    list.Add(new SalaryUnitGridRow()
                    {
                        Degree = i,
                    });
                else
                    list.Add(new SalaryUnitGridRow()
                    {
                        Degree = unit.Degree,
                        //BeginningValue = unit.BeginningValue,
                        //PremiumValue = unit.PremiumValue,
                        //PremiumValue1 = unit.PremiumValue1,
                        //PremiumValue2 = unit.PremiumValue2,
                        //PremiumValue3 = unit.PremiumValue3,
                        ////PremiumValue4 = unit.PremiumValue4,
                        HIF1 = unit.HIF1,
                        HIF2 = unit.HIF2,
                        HIF3 = unit.HIF3,
                        HIF4 = unit.HIF4,
                        HIF5 = unit.HIF5,
                        HIF6 = unit.HIF6,
                        HIF7 = unit.HIF7,
                        HIF8 = unit.HIF8,
                        HIF9 = unit.HIF9,
                        HIF10 = unit.HIF10,
                        HIF11 = unit.HIF11,
                        HIF12 = unit.HIF12,

                        SalaryUnitId = unit.SalaryUnitId,
                        ExtraValue1 = unit.ExtraValue1,
                        ExtraValue2 = unit.ExtraValue2,
                        ExtraValue3 = unit.ExtraValue3,
                        ExtraValue4 = unit.ExtraValue4,
                        ExtraValue5 = unit.ExtraValue5,
                        ExtraValue6 = unit.ExtraValue6,
                        ExtraValue7 = unit.ExtraValue7,
                        ExtraValue8 = unit.ExtraValue8,
                        ExtraValue9 = unit.ExtraValue9,
                        ExtraValue10 = unit.ExtraValue10,
                        ExtraValue11 = unit.ExtraValue11,
                        ExtraValue12 = unit.ExtraValue12,
                        ExtraGeneralValue = unit.ExtraGeneralValue
                    });
            }

            return list;
        }
    }
}