namespace BestFriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateZipcodeFromStringToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplier", "SuppZipcode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supplier", "SuppZipcode", c => c.String());
            AlterColumn("dbo.Customer", "ZipCode", c => c.String());
        }
    }
}
