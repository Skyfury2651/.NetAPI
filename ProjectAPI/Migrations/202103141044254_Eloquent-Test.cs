namespace ProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EloquentTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        totalPrice = c.String(),
                        ShipperCity = c.String(),
                        IsShipped = c.Boolean(nullable: false),
                        Order_ProductId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Products", t => t.Order_ProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Order_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Product_ProductId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropTable("dbo.OrderProducts");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
