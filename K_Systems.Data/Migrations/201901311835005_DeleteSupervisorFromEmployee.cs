namespace K_Systems.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSupervisorFromEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "supervisor", "dbo.Employee");
            DropForeignKey("dbo.EmployeeJobAssignment", "supervisorID", "dbo.Employee");
            DropForeignKey("dbo.PerformanceReview", "reviewerID", "dbo.Employee");
            DropIndex("dbo.EmployeeJobAssignment", new[] { "supervisorID" });
            DropIndex("dbo.Employee", new[] { "supervisor" });
            DropIndex("dbo.PerformanceReview", new[] { "reviewerID" });
            DropColumn("dbo.EmployeeJobAssignment", "supervisorID");
            DropColumn("dbo.Employee", "supervisor");
            DropColumn("dbo.PerformanceReview", "reviewerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PerformanceReview", "reviewerID", c => c.Int());
            AddColumn("dbo.Employee", "supervisor", c => c.Int());
            AddColumn("dbo.EmployeeJobAssignment", "supervisorID", c => c.Int());
            CreateIndex("dbo.PerformanceReview", "reviewerID");
            CreateIndex("dbo.Employee", "supervisor");
            CreateIndex("dbo.EmployeeJobAssignment", "supervisorID");
            AddForeignKey("dbo.PerformanceReview", "reviewerID", "dbo.Employee", "ID");
            AddForeignKey("dbo.EmployeeJobAssignment", "supervisorID", "dbo.Employee", "ID");
            AddForeignKey("dbo.Employee", "supervisor", "dbo.Employee", "ID");
        }
    }
}
