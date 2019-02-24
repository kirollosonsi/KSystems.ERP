namespace K_Systems.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodCatSupp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        price = c.Double(nullable: false),
                        categoryID = c.Int(nullable: false),
                        supplierID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.supplierID, cascadeDelete: true)
                .Index(t => t.categoryID)
                .Index(t => t.supplierID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        companyName = c.String(nullable: false, maxLength: 50),
                        contactName = c.String(nullable: false, maxLength: 50),
                        address = c.String(maxLength: 50),
                        mobile = c.String(maxLength: 20),
                        extraInfo = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "supplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "categoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "supplierID" });
            DropIndex("dbo.Products", new[] { "categoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
        }
    }
}
