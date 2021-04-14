# ExpenseTrak
--- 
Developer: Jacob Hash
- Note: This is the first iteration of this application and lacks some fuctionality.

# Table of Contents
- Mission Statement
- Database
- Features
- Links

# Mission Statement
---
This expense report keeping app is meant to allow users to keep a running ledger of their expenses throughout the month giving a company a better way of keeping records. I decided on this application because it is a business application. 


# Database
---
#### table Company
- CompnayId int
- Name string
- Address string
- Industry enum
- Employees virtualLisEmployess

#### table Employee
- EmployeeId int
- FirstName string
- LastName string
- Email string
- Department enum
- Title string
- CompanyId ForiegnKey
- Reports virtualLisReports

#### table Expenses
- ExpenseId int
- Category enum
- DateOfExpense DateTime
- Description string
- Amount decimal
- Location string
- ReportId ForiegnKey

#### table Report
- ReportId int
- MonthOfReport enum
- Total decimal
- EmployeeId ForiegnKey
- Expense virtualLisExpenses
- Compnay virtualLisCompanies
 
# Features
---
#### Create a Company, Employee, Report, and Expense
- Allow for preaccounting expensing

# Links

[DB Diagram](https://dbdesigner.page.link/u5hWv5nQ6Ma46WY3A)

[DeployedLink](https://expensetrak.azurewebsites.net/)
