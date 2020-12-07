namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Category", c => c.Int(nullable: false));
        }
    }
}
