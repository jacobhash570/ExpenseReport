using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ReportListItem
    {

        [Display(Name = "Report #")]
        public int ReportId { get; set; }
        [Required]
        [Display(Name = "Report Month")]
        public MonthOfReport MonthOfReport { get; set; }

        //[Display(Name = "Report Total")]
        //public decimal Total { get; set; }
        [Display(Name = "Employee #")]
        public int EmployeeId { get; set; }   
    }
}
