namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAllfromCharToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Address", c => c.String());
            AddColumn("dbo.Customer", "City", c => c.String());
            AddColumn("dbo.Customer", "ZipCode", c => c.String());
            AddColumn("dbo.Gift", "TType", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "StatusType", c => c.String(nullable: false));
            AddColumn("dbo.Supplier", "SupplierName", c => c.String(nullable: false));
            AddColumn("dbo.Supplier", "SuppAddress", c => c.String());
            AddColumn("dbo.Supplier", "SuppCity", c => c.String());
            AddColumn("dbo.Supplier", "SuppZipcode", c => c.String());
            AddColumn("dbo.Supplier", "SuppEmail", c => c.String(nullable: false));
            AddColumn("dbo.WishList", "Item", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Class", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Class", c => c.String());
            DropColumn("dbo.WishList", "Item");
            DropColumn("dbo.Supplier", "SuppEmail");
            DropColumn("dbo.Supplier", "SuppZipcode");
            DropColumn("dbo.Supplier", "SuppCity");
            DropColumn("dbo.Supplier", "SuppAddress");
            DropColumn("dbo.Supplier", "SupplierName");
            DropColumn("dbo.Status", "StatusType");
            DropColumn("dbo.Gift", "TType");
            DropColumn("dbo.Customer", "ZipCode");
            DropColumn("dbo.Customer", "City");
            DropColumn("dbo.Customer", "Address");
            DropColumn("dbo.Customer", "FullName");
            DropColumn("dbo.Customer", "Password");
            DropColumn("dbo.Customer", "Email");
            DropColumn("dbo.Customer", "UserName");
        }
    }
}
