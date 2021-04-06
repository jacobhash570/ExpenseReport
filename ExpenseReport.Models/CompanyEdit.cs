using ExpenseReport.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class CompanyEdit
    {
        [Display(Name = "Identification Number")]
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Name of Company")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Industry of Company")]
        public Industry Industry { get; set; }
    }
}