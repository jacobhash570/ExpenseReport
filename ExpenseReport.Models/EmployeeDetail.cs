using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        //public Department Department { get; set; }
        [Display(Name = "Job Title")]
        public string Title { get; set; }
    }
}