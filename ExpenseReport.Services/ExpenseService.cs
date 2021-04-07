using ExpenseReport.Data;
using ExpenseReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Services
{
    public class ExpenseService
    {
        private readonly Guid _userId;

        public ExpenseService(Guid userId)
        {
            _userId = userId;
        }

        public ExpenseDetail GetExpenseDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var expense = ctx.Expenses.Single(e => e.ExpenseId == id);
                return new ExpenseDetail
                {
                    ExpenseId = expense.ExpenseId,
                    DateOfExpense = expense.DateofExpense,
                    Description = expense.Description,
                    Amount = expense.Amount,
                    Location = expense.Location,
                    Category = expense.Category,
                    ReportId = expense.ReportId
                };
            }
        }

        public IEnumerable<Expense> GetExpenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Expenses.ToList();
            }
        }

        public bool CreateExpense(ExpenseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newExpense = new Expense()
                {
                    DateofExpense = model.DateOfExpense,
                    Description = model.Description,
                    Amount = model.Amount,
                    Location = model.Location,
                    Category = model.Category,
                    ReportId = model.ReportId,
                };
                ctx.Expenses.Add(newExpense);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ExpenseListItem> GetExpenseList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Expenses.Select(e => new ExpenseListItem
                {
                    ExpenseId = e.ExpenseId,
                    DateOfExpense  = e.DateofExpense,
                    Description = e.Description,
                    Amount = e.Amount,
                    Location = e.Location,
                    Category = e.Category,
                    ReportId = e.ReportId
                });
                return query.ToArray();
            }
        }

        public bool UpdateExpense(ExpenseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var expense = ctx.Expenses.Single(e => e.ExpenseId == model.ExpenseId);
                expense.DateofExpense = model.DateOfExpense;
                expense.Description = model.Description;
                expense.Amount = model.Amount;
                expense.Location = model.Location;
                expense.Category = model.Category;
                expense.ReportId = model.ReportId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteExpense(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Expenses
                        .Single(e => e.ExpenseId == id /*&& e.OwnerId == _userId*/);

                ctx.Expenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
