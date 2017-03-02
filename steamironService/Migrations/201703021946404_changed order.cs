namespace steamironService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Data.Entity.Migrations.Model;

    public partial class changedorder : DbMigration
    {

        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "MerchantId", "dbo.Merchants");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "MerchantId" });
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "MerchantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "MerchantId", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "MerchantId");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "MerchantId", "dbo.Merchants", "Id");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
        }
    }
}
