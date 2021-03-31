namespace ExpenseReport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmployeeDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Department", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Department");
        }
    }
}
