namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMVCLayers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustId = c.Guid(nullable: false),
                        Class = c.String(),
                        CreateCustomer = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyCustomer = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Gift",
                c => new
                    {
                        GiftId = c.Int(nullable: false, identity: true),
                        DonationId = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedGift = c.DateTimeOffset(nullable: false, precision: 7),
                        RedeemGift = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.GiftId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderGuid = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Category = c.String(nullable: false),
                        CreateOrder = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyOrder = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusGuid = c.Guid(nullable: false),
                        CreateStatus = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyStatus = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierGuid = c.Guid(nullable: false),
                        Phone = c.Int(nullable: false),
                        CreateSupp = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifySupp = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.WishList",
                c => new
                    {
                        WishId = c.Int(nullable: false, identity: true),
                        WishGuid = c.Guid(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier = c.Int(nullable: false),
                        CreateWish = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifyWish = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.WishId);
            
            AddColumn("dbo.Product", "CreatedProduct", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Product", "ModifyProduct", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Product", "CreatedAt");
            DropColumn("dbo.Product", "ModifiedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ModifiedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Product", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Product", "ModifyProduct");
            DropColumn("dbo.Product", "CreatedProduct");
            DropTable("dbo.WishList");
            DropTable("dbo.Supplier");
            DropTable("dbo.Status");
            DropTable("dbo.Order");
            DropTable("dbo.Gift");
            DropTable("dbo.Customer");
        }
    }
}
