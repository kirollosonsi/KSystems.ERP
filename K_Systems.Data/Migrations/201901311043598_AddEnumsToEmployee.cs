namespace K_Systems.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumsToEmployee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "isMarried");
            AddColumn("dbo.Employee", "isMarried", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "isMarried");
            AddColumn("dbo.Employee", "isMarried", c => c.Boolean());
        }
    }
}
