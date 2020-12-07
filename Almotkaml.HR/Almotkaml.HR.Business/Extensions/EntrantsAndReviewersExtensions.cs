using Almotkaml.HR.Domain;
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.HR.Business.Extensions
{

    public static class EntrantsAndReviewersExtensions
    {
        public static IEnumerable<EntrantsAndReviewersListItem> ToList(this IEnumerable<EntrantsAndReviewers> entrantsAndReviewerss)
           => entrantsAndReviewerss.Select(d => new EntrantsAndReviewersListItem()
           {
               EntrantsAndReviewersId=d.EntrantsAndReviewersId,
               EmployeeNumber = d.EmployeeNumber,
               EmployeeName =d.EmployeeName ,
               NationalNumber =d.NationalNumber ,
               Gender = d.Gender,
               Phone = d.Phone,
               Email = d.Email,
               StartDate  = d.StartDate,
               Note = d.Note,
               EntrantsAndReviewersType = d.EntrantsAndReviewersType,
           });
        public static IEnumerable<EntrantsAndReviewersGridRow> ToGrid(this IEnumerable<EntrantsAndReviewers> entrantsAndReviewerss)
           => entrantsAndReviewerss.Select(d => new EntrantsAndReviewersGridRow()
           {
               EntrantsAndReviewersId = d.EntrantsAndReviewersId,
               EmployeeNumber = d.EmployeeNumber,
               EmployeeName = d.EmployeeName,
               NationalNumber = d.NationalNumber,
               Gender = d.Gender,
               Phone = d.Phone,
               Email = d.Email,
               StartDate = d.StartDate,
               Note = d.Note,
               EntrantsAndReviewersType = d.EntrantsAndReviewersType,
           });
    }
}
