namespace ProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "category_id", c => c.Int());
            AddColumn("dbo.OrderDetails", "product_id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "order_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "order_id");
            DropColumn("dbo.OrderDetails", "product_id");
            DropColumn("dbo.Products", "category_id");
        }
    }
}
