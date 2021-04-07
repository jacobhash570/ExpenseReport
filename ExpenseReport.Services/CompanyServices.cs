using ExpenseReport.Data;
using ExpenseReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Services
{
    public class CompanyServices
    {
        public CompanyDetail GetCompanyDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var company = ctx.Companies.Single(c => c.CompanyId == id);
                return new CompanyDetail
                {
                    CompanyId = company.CompanyId,
                    Address = company.Address,
                    Name = company.Name,
                    Industry = company.Industry
                };
            }
        }

        public bool CreateCompany(CompanyCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newCompany = new Company()
                {
                    Address = model.Address,
                    Name = model.Name,
                    Industry = model.Industry,
                };
                ctx.Companies.Add(newCompany);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CompanyListItem> GetCompanyList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Companies.Select(c => new CompanyListItem
                {
                    CompanyId = c.CompanyId,
                    Address = c.Address,
                    Name = c.Name,
                    Industry = c.Industry,
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Company> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Companies.ToList();
            }
        }

        public IEnumerable<Employee> GetEmployeesByCompany(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = (from r in ctx.Employees
                             where r.CompanyId.Equals(id)
                             select r).ToList();
                return query;
            };
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var company = ctx.Companies.Single(c => c.CompanyId == model.CompanyId);
                company.Address = model.Address;
                company.Name = model.Name;
                company.Industry = model.Industry;
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteCompany(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == id /*&& e.OwnerId == _userId*/);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
