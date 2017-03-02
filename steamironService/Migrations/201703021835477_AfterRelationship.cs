namespace steamironService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterRelationship : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Carts", name: "Merchant_Id", newName: "MerchantId");
            RenameColumn(table: "dbo.Orders", name: "Cart_Id", newName: "CartId");
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Orders", name: "Merchant_Id", newName: "MerchantId");
            RenameColumn(table: "dbo.ProductItems", name: "Merchant_Id", newName: "MerchantId");
            RenameIndex(table: "dbo.Carts", name: "IX_Customer_Id", newName: "IX_CustomerId");
            RenameIndex(table: "dbo.Carts", name: "IX_Merchant_Id", newName: "IX_MerchantId");
            RenameIndex(table: "dbo.ProductItems", name: "IX_Merchant_Id", newName: "IX_MerchantId");
            RenameIndex(table: "dbo.Orders", name: "IX_Customer_Id", newName: "IX_CustomerId");
            RenameIndex(table: "dbo.Orders", name: "IX_Merchant_Id", newName: "IX_MerchantId");
            RenameIndex(table: "dbo.Orders", name: "IX_Cart_Id", newName: "IX_CartId");
            AddColumn("dbo.Carts", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.ProductItems", "Cart_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductItems", "Cart_Id");
            AddForeignKey("dbo.ProductItems", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.ProductItems", new[] { "Cart_Id" });
            DropColumn("dbo.ProductItems", "Cart_Id");
            DropColumn("dbo.Carts", "Count");
            RenameIndex(table: "dbo.Orders", name: "IX_CartId", newName: "IX_Cart_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_MerchantId", newName: "IX_Merchant_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.ProductItems", name: "IX_MerchantId", newName: "IX_Merchant_Id");
            RenameIndex(table: "dbo.Carts", name: "IX_MerchantId", newName: "IX_Merchant_Id");
            RenameIndex(table: "dbo.Carts", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.ProductItems", name: "MerchantId", newName: "Merchant_Id");
            RenameColumn(table: "dbo.Orders", name: "MerchantId", newName: "Merchant_Id");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Orders", name: "CartId", newName: "Cart_Id");
            RenameColumn(table: "dbo.Carts", name: "MerchantId", newName: "Merchant_Id");
            RenameColumn(table: "dbo.Carts", name: "CustomerId", newName: "Customer_Id");
        }
    }
}
