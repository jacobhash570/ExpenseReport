using ExpenseReport.Data;
using ExpenseReport.Models;
using ExpenseReport.Services;
using ExpenseReport.WebMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.WebMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(CreateEmployeeService().GetEmployeeList());
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Employee";

            List<Company> Companies = new CompanyServices().GetCompanies().ToList();
            var query = from e in Companies
                        select new SelectListItem()
                        {
                            Value = e.CompanyId.ToString(),
                            Text = e.Name.ToString(),
                        };

            ViewBag.CompanyId = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateEmployeeService().CreateEmployee(model))
            {
                TempData["SaveResult"] = "Employee Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, could not add employee.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employee = CreateEmployeeService().GetEmployeeDetailsById(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            List<Company> Companies = new CompanyServices().GetCompanies().ToList();
            var query = from e in Companies
                        select new SelectListItem()
                        {
                            Value = e.CompanyId.ToString(),
                            Text = e.Name.ToString(),
                        };

            ViewBag.CompanyId = query.ToList();

            var employee = CreateEmployeeService().GetEmployeeDetailsById(id);
            return View(new EmployeeEdit
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Department = employee.Department,
                Title = employee.Title,
                CompanyId = employee.CompanyId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Invalid ID.");
                return View(model);
            }

            if (CreateEmployeeService().UpdateEmployee(model))
            {
                TempData["SaveResults"] = "Employee was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occured, could not update employee.");
            return View(model);
        }

        private EmployeeService CreateEmployeeService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(/*userId*/);
            return service;
        }
    }
}
