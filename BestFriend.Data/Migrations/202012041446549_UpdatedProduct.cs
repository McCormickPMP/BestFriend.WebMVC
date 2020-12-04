namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "CreatedProduct");
            DropColumn("dbo.Product", "ModifyProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ModifyProduct", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Product", "CreatedProduct", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
