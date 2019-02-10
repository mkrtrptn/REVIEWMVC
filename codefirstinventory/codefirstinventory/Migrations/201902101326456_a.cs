namespace codefirstinventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        cateid = c.Int(nullable: false, identity: true),
                        catedesc = c.String(),
                    })
                .PrimaryKey(t => t.cateid);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        prodid = c.Int(nullable: false, identity: true),
                        proddesc = c.String(),
                        prodprice = c.Double(nullable: false),
                        cateid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prodid)
                .ForeignKey("dbo.categories", t => t.cateid, cascadeDelete: true)
                .Index(t => t.cateid);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        orderid = c.Int(nullable: false, identity: true),
                        ammount = c.Double(nullable: false),
                        prodid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderid);
            
            CreateTable(
                "dbo.orderproducts",
                c => new
                    {
                        order_orderid = c.Int(nullable: false),
                        product_prodid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.order_orderid, t.product_prodid })
                .ForeignKey("dbo.orders", t => t.order_orderid, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.product_prodid, cascadeDelete: true)
                .Index(t => t.order_orderid)
                .Index(t => t.product_prodid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orderproducts", "product_prodid", "dbo.products");
            DropForeignKey("dbo.orderproducts", "order_orderid", "dbo.orders");
            DropForeignKey("dbo.products", "cateid", "dbo.categories");
            DropIndex("dbo.orderproducts", new[] { "product_prodid" });
            DropIndex("dbo.orderproducts", new[] { "order_orderid" });
            DropIndex("dbo.products", new[] { "cateid" });
            DropTable("dbo.orderproducts");
            DropTable("dbo.orders");
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
