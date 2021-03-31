﻿using ExpenseReport.Data;
using ExpenseReport.Models;
using ExpenseReport.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public EmployeeDetail GetEmployeeDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = ctx.Employees.Single(e => e.EmployeeId == id);
                return new EmployeeDetail
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Department = employee.Department,
                    Title = employee.Title
                };
            }
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newEmployee = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Department = model.Department,
                    Title = model.Title
                };
                ctx.Employees.Add(newEmployee);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EmployeeListItem> GetEmployeeList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Employees.Select(e => new EmployeeListItem
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Department = e.Department,
                    Title = e.Title
                });
                return query.ToArray();
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = ctx.Employees.Single(e => e.EmployeeId == model.EmployeeId);
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
