using ExpenseReport.Data;
using ExpenseReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Services
{
    public class ReportService
    {
        /*private readonly Guid _userId;

        public ReportService(Guid userId)
        {
            _userId = userId;
        }*/

        public ReportDetail GetReportDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = ctx.Reports.Single(e => e.ReportId == id);
                return new ReportDetail
                {
                    ReportId = report.ReportId,
                    MonthOfReport = report.MonthOfReport,
                    //Total = report.Total,
                    EmployeeId = report.EmployeeId
                };
            }
        }

        public bool CreateReport(ReportCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newReport = new Report()
                {
                    MonthOfReport = model.MonthOfReport,
                    //Total = model.Total,
                    EmployeeId = model.EmployeeId
                };
                ctx.Reports.Add(newReport);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReportListItem> GetReportList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Reports.Select(e => new ReportListItem
                {
                    ReportId = e.ReportId,
                    MonthOfReport = e.MonthOfReport,
                    //Total = e.Total,
                    EmployeeId = e.EmployeeId
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Report> GetReports()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Reports.ToList();
            }
        }

        public IEnumerable<Expense> GetExpenseItemized(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = (from r in ctx.Expenses
                             where r.ReportId.Equals(id)
                             select r).ToList();
                return query;
            };
        }


        public bool UpdateReport(ReportEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = ctx.Reports.Single(e => e.ReportId == model.ReportId);
                report.MonthOfReport = model.MonthOfReport;
                //report.Total = model.Total;
                report.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        public ReportTotal GetReportTotal(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = (from r in ctx.Expenses
                             where r.ReportId.Equals(id)
                             select r.Amount).Sum();
                return new ReportTotal
                {
                    Amount = query
                };
            }
        }

        /*public ReportTotal GetReportById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = ctx.Reports.Single(e => e.ReportId == id);
                return new ReportTotal
                {
                    //ReportId = report.ReportId,
                    //Amount = report.Total;
                };
            }
        }*/
    }
}