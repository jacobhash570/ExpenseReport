namespace ExpenseReport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenseAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        DateofExpense = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expense");
        }
    }
}
