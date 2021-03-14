namespace ProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeText : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_CategoryID", newName: "CategoryID");
            RenameIndex(table: "dbo.Products", name: "IX_Category_CategoryID", newName: "IX_CategoryID");
            AddColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderID", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "category_id");
            DropColumn("dbo.OrderDetails", "product_id");
            DropColumn("dbo.OrderDetails", "order_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "order_id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "product_id", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "category_id", c => c.Int());
            DropColumn("dbo.OrderDetails", "OrderID");
            DropColumn("dbo.OrderDetails", "ProductID");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryID", newName: "IX_Category_CategoryID");
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Category_CategoryID");
        }
    }
}
