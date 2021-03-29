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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public string Title { get; set; }

    }
}
