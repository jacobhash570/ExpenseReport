using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Data
{
    public enum Industry { Manufacturing, Finance, Construction, Retail, Transportation, Agriculture, Technology, HealthCare }
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Industry Industry { get; set; }

        //[ForeignKey(nameof(Report))]
        //[Required]
        //public int ReportId { get; set; }
        //public virtual Report Report { get; set; }

        public virtual IEnumerable<Employee> Employee { get; set; } = new List<Employee>();

    }
}
