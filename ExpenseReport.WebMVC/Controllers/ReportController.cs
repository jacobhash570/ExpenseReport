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

        public ActionResult Details(int id)
        {
            var report = CreateReportService().GetReportDetailsById(id);
            return View(report);
        }

        public ActionResult Edit(int id)
        {
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReportService(userId);
            return service;
        }
    }
}