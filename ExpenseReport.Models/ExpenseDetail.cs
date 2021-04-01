using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ExpenseDetail
    {
        [Required]
        [Display(Name = "Expense Id")]
        public int ExpenseId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Date of Expense")]
        public DateTime DateOfExpense { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Expense Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Location of Expense")]
        [Required]
        public string Location { get; set; }
    }
}
