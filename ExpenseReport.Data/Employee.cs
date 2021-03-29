using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Data
{
    public enum Department { Marketing = 1, Operations, Finance, Sales, HumanResouces, Puchasing, Other }
    public class Employee
    {
        [Key]
        public int EmployerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Department Department { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
