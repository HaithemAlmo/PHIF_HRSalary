using Almotkaml.HR.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almotkaml.HR.Models
{
    public class DifrancesModel
    {
        public IEnumerable<YearMonthListItem> YearMonthReport { get; set; } = new HashSet<YearMonthListItem>();
        // public IEnumerable<DepartmentListItem> MonthReport { get; set; } = new HashSet<DepartmentListItem>();
        public int Month2 { get; set; }

        public int EmployeeId { get; set; }

        public IEnumerable<DifrancesGrideRow> Grid { get; set; } = new HashSet<DifrancesGrideRow>();
        [Display(ResourceType = typeof(Title), Name = nameof(Title.Month))]
        public int Month { get; set; }

        [Display(ResourceType = typeof(Title), Name = nameof(Title.Year))]
        public int Year { get; set; }
        public decimal FinalSalary { get; set; }
        public string FullName { get; set; }
        public int DegreeNow { get; set; }
        public int Bounc { get; set; }
        public string DivisionName { get; set; }
        public string JobNow { get; set; }
        public DateTime Date { get; set; }
        public string TotalDate { get; set; }
        public string FullFinalSalary { get; set; }


    }
    public class DifrancesGrideRow
    {
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string JobNumber { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalDate { get; set; }
        public decimal FullFinalSalary { get; set; }
        public decimal FinalSalary { get; set; }
        public string FullName { get; set; }
        public int DegreeNow { get; set; }
        public int Bounc { get; set; }
        public string DivisionName { get; set; }
        public string JobNow { get; set; }
        public string Date { get; set; }
    }
    public class YearMonthListItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }

}
