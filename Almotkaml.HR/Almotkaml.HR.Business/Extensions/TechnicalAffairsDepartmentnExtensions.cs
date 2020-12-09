using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Almotkaml.HR.Models.TechnicalAffairsDepartmentModel;

namespace Almotkaml.HR.Business.Extensions
{

    public static class TechnicalAffairsDepartmentExtensions
    {
        public static IEnumerable<TechnicalAffairsDepartmentListItem> ToList0(this IEnumerable<TechnicalAffairsDepartment> technicalAffairsDepartments)
           => technicalAffairsDepartments.Select(d => new TechnicalAffairsDepartmentListItem()
           {
               EntrantsAndReviewersId=d.EntrantsAndReviewersId,
               EmployeeName  = d.EntrantsAndReviewers .EmployeeName ,
               TechnicalAffairsDepartmentId =d.TechnicalAffairsDepartmentId,
               MonthWork =d.MonthWork ,
               YearWork =d.YearWork,
               TotalBalance =d.TotalBalance 
              

             //  EmployeeName=d.EmployeeName,        
           });
        public static IEnumerable<TechnicalAffairsDepartmentGridRow> ToGrid(this IEnumerable<TechnicalAffairsDepartment> technicalAffairsDepartments)
           => technicalAffairsDepartments.Select(d =>new TechnicalAffairsDepartmentGridRow()
           {
              EntrantsAndReviewersId = d.EntrantsAndReviewersId,
              TechnicalAffairsDepartmentId = d.TechnicalAffairsDepartmentId,
            EmployeeName = d.EntrantsAndReviewers.EmployeeName,
              MonthWork = d.MonthWork,
              YearWork = d.YearWork,
               TotalBalance = d.TotalBalance,
               IsPaid = d.IsPaid,
               EntrantsAndReviewersType = d.EntrantsAndReviewers.EntrantsAndReviewersType

           });

    
    }
}
