namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidToDataSets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Order", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "OwnerId");
            DropColumn("dbo.Order", "OwnerId");
            DropColumn("dbo.Customer", "OwnerId");
        }
    }
}
