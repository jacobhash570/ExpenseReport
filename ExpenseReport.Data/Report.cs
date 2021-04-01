using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Data
{
    public enum MonthOfReport {January = 1, Febuary, March, April, May, June, July, August, September, October, November, December }
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public MonthOfReport MonthOfReport { get; set; }

        //Add to this
        public decimal Total { get; set; }

        [ForeignKey(nameof(Employee))]
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
