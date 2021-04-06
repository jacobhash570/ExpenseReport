using ExpenseReport.Models;
using ExpenseReport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseReport.WebMVC.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(CreateCompanyService().GetCompanyList());
        }
        public ActionResult Create()
        {
            ViewBag.Title = "New Company";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateCompanyService().CreateCompany(model))
            {
                TempData["SaveResult"] = "Company Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, could not create company.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var company = CreateCompanyService().GetCompanyDetailsById(id);
            return View(company);
        }

        public ActionResult Edit(int id)
        {
            var company = CreateCompanyService().GetCompanyDetailsById(id);
            return View(new CompanyEdit
            {
                CompanyId = company.CompanyId,
                Address = company.Address,
                Name = company.Name,
                Industry = company.Industry,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompanyId != id)
            {
                ModelState.AddModelError("", "Invalid ID.");
                return View(model);
            }

            if (CreateCompanyService().UpdateCompany(model))
            {
                TempData["SaveResults"] = "Company was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occured, could not update company.");
            return View(model);
        }

        private CompanyServices CreateCompanyService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyServices(/*userId*/);
            return service;
        }
    }
}