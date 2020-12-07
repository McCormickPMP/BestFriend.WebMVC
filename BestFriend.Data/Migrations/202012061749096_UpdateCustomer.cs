namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
