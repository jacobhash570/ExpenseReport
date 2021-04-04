using ExpenseReport.Data;
using ExpenseReport.Models;
using ExpenseReport.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.WebMVC.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View(CreateReportService().GetReportList());
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Report";


            List<Employee> Employees = new EmployeeService().GetEmployees().ToList();
            var query = from e in Employees
                        select new SelectListItem()
                        {
                            Value = e.EmployeeId.ToString(),
                            Text = e.EmployeeId.ToString(),
                        };

            ViewBag.EmployeeId = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateReportService().CreateReport(model))
            {
                TempData["SaveResult"] = "Report Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, could not add employee.");
            return View(model);
        }

        /*public ActionResult ReportTotal(int id)
        {
            ReportTotal reportId = new ReportService().GetReportTotal(id);           
            var report = total
            {
                //ReportId = total.ReportId.ToString(),
                //Text = e.ReportId.ToString(),
                //Amount = total.Amount,
            };

           ViewBag.Total;
            return View(reportId);

            decial Report = new ReportService().GetReportById(id);
            var query = from r in Report
                        select new SelectListItem()
                        {
                            Value = e.EmployeeId.ToString(),
                            Text = e.EmployeeId.ToString(),
                        };

            ViewBag.EmployeeId = query.ToList();

            var report = CreateReportService().GetReportDetailsById(id);
            return View(new ReportEdit
            {
                ReportId = report.ReportId,
                MonthOfReport = report.MonthOfReport,
                Total = report.Total,
                EmployeeId = report.EmployeeId
            });
        }*/

        public ActionResult Details(int id)
        {
            var report = CreateReportService().GetReportDetailsById(id);
            ReportTotal total = new ReportService().GetReportTotal(id);

            return View(new ReportDetail
            {
                ReportId = report.ReportId,
                MonthOfReport = report.MonthOfReport,
                EmployeeId = report.EmployeeId,
                Total = total.Amount,
            }
                ) ;
        }


        public ActionResult Edit(int id)
        {
            List<Employee> Employees = new EmployeeService().GetEmployees().ToList();
            var query = from e in Employees
                        select new SelectListItem()
                        {
                            Value = e.EmployeeId.ToString(),
                            Text = e.EmployeeId.ToString(),
                        };

            ViewBag.EmployeeId = query.ToList();

            var report = CreateReportService().GetReportDetailsById(id);
            return View(new ReportEdit
            {
                ReportId = report.ReportId,
                MonthOfReport = report.MonthOfReport,
                Total = report.Total,
                EmployeeId = report.EmployeeId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReportEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReportId != id)
            {
                ModelState.AddModelError("", "Invalid ID.");
                return View(model);
            }

            if (CreateReportService().UpdateReport(model))
            {
                TempData["SaveResults"] = "Report was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occured, could not update report.");
            return View(model);
        }

        private ReportService CreateReportService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReportService(/*userId*/);
            return service;
        }
    }
}