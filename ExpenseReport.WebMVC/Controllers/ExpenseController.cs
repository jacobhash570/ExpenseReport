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
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View(CreateExpenseService().GetExpenseList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Expense";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateExpenseService().CreateExpense(model))
            {
                TempData["SaveResult"] = "Expense Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, could not add expense.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employee = CreateExpenseService().GetExpenseDetailsById(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var expense = CreateExpenseService().GetExpenseDetailsById(id);
            return View(new ExpenseEdit
            {
                ExpenseId = expense.ExpenseId,
                DateOfExpense = expense.DateOfExpense,
                Description = expense.Description,
                Amount = expense.Amount,
                Location = expense.Location,
                Category = expense.Category,
                ReportId = expense.ReportId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExpenseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ExpenseId != id)
            {
                ModelState.AddModelError("", "Invalid ID.");
                return View(model);
            }

            if (CreateExpenseService().UpdateExpense(model))
            {
                TempData["SaveResults"] = "Expense was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occured, could not update expense.");
            return View(model);
        }

        private ExpenseService CreateExpenseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExpenseService(userId);
            return service;
        }
    }
}