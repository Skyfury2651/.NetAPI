namespace ProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "balance", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "balance");
        }
    }
}
