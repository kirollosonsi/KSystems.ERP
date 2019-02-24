namespace K_Systems.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatefromPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TrainingHistory", "PK_TrainingHistory");
            AddPrimaryKey("dbo.TrainingHistory", new[] { "employeeID", "courseID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TrainingHistory", "PK_TrainingHistory");
            AddPrimaryKey("dbo.TrainingHistory", new[] { "employeeID", "courseID", "trainingDate" });
        }
    }
}
