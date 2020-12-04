namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrdering : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Category");
        }
    }
}
