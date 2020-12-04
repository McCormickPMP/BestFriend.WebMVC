namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayedWOrderProdId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "ProductId");
        }
    }
}
