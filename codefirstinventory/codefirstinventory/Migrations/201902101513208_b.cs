namespace codefirstinventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "quantity", c => c.Double(nullable: false));
            DropColumn("dbo.orders", "ammount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.orders", "ammount", c => c.Double(nullable: false));
            DropColumn("dbo.orders", "quantity");
        }
    }
}
