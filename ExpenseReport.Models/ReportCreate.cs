using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ReportCreate
    { 
        [Required]
        [Display(Name = "Report Month")]
        public MonthOfReport MonthOfReport { get; set; }
        public int EmployeeId { get; set; }

    }
}
