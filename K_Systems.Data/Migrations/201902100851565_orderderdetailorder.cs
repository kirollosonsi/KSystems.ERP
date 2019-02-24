namespace K_Systems.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderderdetailorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        orderDate = c.DateTime(nullable: false),
                        customerID = c.Int(nullable: false),
                        employeeID = c.Int(nullable: false),
                        shipAddress = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.employeeID, cascadeDelete: true)
                .Index(t => t.customerID)
                .Index(t => t.employeeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        phone = c.String(maxLength: 20),
                        address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        orderID = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.orderID, t.productID })
                .ForeignKey("dbo.Orders", t => t.orderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productID, cascadeDelete: true)
                .Index(t => t.orderID)
                .Index(t => t.productID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "productID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "orderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "employeeID", "dbo.Employee");
            DropForeignKey("dbo.Orders", "customerID", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "productID" });
            DropIndex("dbo.OrderDetails", new[] { "orderID" });
            DropIndex("dbo.Orders", new[] { "employeeID" });
            DropIndex("dbo.Orders", new[] { "customerID" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
        }
    }
}
