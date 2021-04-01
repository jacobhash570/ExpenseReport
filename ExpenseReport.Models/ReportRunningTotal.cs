using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Models
{
    public class ReportRunningTotal
    {
        public int ExpenseId { get; set; }
        public int ReportId { get; set; }
        public decimal RunningTotal { get; set; }
    }
}
