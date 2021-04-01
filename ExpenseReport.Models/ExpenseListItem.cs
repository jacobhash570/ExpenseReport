using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ExpenseListItem
    {
  
        [Display(Name = "Expense Id")]
        public int ExpenseId { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Date of Expense")]
        public DateTime DateOfExpense { get; set; }

        public string Description { get; set; }

        [Display(Name = "Expense Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Location of Expense")]
        public string Location { get; set; }
        public int ReportId { get; set; }
    }
}
