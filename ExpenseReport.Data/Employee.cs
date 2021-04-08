using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Data
{
    public enum Department { Marketing, Operations, Finance, Sales, HumanResouces, Puchasing, Other }
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
        [Required]
        public string Email { get; set; }
        [Required]
        public Department Department { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
