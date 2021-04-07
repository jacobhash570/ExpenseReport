using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ReportDetail
    {
        [Display(Name = "Identification Number")]
        public int ReportId { get; set; }
        [Required]
        [Display(Name = "Report Month")]
        public MonthOfReport MonthOfReport { get; set; }

        [Display(Name = "Report Total")]
        //Add to this
        public decimal Total { get; set; }
        public int EmployeeId { get; set; }
        //public IEnumerable<Expense> Expenses { get; set; }

    }
}
