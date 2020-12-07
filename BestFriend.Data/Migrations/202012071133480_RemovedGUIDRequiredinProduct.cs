namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedGUIDRequiredinProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "OrderId", "dbo.Order");
            DropIndex("dbo.Product", new[] { "OrderId" });
            AlterColumn("dbo.Product", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "OrderId");
            AddForeignKey("dbo.Product", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "OrderId", "dbo.Order");
            DropIndex("dbo.Product", new[] { "OrderId" });
            AlterColumn("dbo.Product", "OrderId", c => c.Int());
            CreateIndex("dbo.Product", "OrderId");
            AddForeignKey("dbo.Product", "OrderId", "dbo.Order", "OrderId");
        }
    }
}
