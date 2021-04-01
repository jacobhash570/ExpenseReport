namespace ExpenseReport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Report", "Expense_ExpenseId", "dbo.Expense");
            DropIndex("dbo.Report", new[] { "Expense_ExpenseId" });
            AddColumn("dbo.Expense", "ReportId", c => c.Int(nullable: false));
            CreateIndex("dbo.Expense", "ReportId");
            AddForeignKey("dbo.Expense", "ReportId", "dbo.Report", "ReportId", cascadeDelete: true);
            DropColumn("dbo.Report", "Expense_ExpenseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Report", "Expense_ExpenseId", c => c.Int());
            DropForeignKey("dbo.Expense", "ReportId", "dbo.Report");
            DropIndex("dbo.Expense", new[] { "ReportId" });
            DropColumn("dbo.Expense", "ReportId");
            CreateIndex("dbo.Report", "Expense_ExpenseId");
            AddForeignKey("dbo.Report", "Expense_ExpenseId", "dbo.Expense", "ExpenseId");
        }
    }
}
