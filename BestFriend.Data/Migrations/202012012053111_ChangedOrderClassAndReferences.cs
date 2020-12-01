namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOrderClassAndReferences : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "ItemId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "ItemId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Order", "ItemId");
            AddForeignKey("dbo.Order", "ItemId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
    }
}
