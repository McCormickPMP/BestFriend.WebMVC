namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedOutStatusIdInOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "StatusId", "dbo.Status");
            DropIndex("dbo.Order", new[] { "StatusId" });
            AlterColumn("dbo.Order", "Category", c => c.String());
            DropColumn("dbo.Order", "StatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "Category", c => c.String(nullable: false));
            CreateIndex("dbo.Order", "StatusId");
            AddForeignKey("dbo.Order", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
        }
    }
}
